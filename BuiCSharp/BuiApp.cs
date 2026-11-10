using System.Runtime.InteropServices;

public unsafe class BuiApp : IDisposable
{
    private IntPtr _root;
    private IntPtr _ctx;
    private IntPtr _win;
    private IntPtr _host;
    private BKEventCallback? _callback;

    // ─── String marshalling helpers ────────────────────────────────────────

    private static IntPtr S(string s) => Marshal.StringToCoTaskMemUTF8(s);

    private static void Free(IntPtr p) => Marshal.FreeCoTaskMem(p);

    private static void Call1(Action<IntPtr> fn, string s)
    {
        var p = S(s);
        try { fn(p); } finally { Free(p); }
    }

    private static int Call1(Func<IntPtr, int> fn, string s)
    {
        var p = S(s);
        try { return fn(p); } finally { Free(p); }
    }


    private static void Call2(Action<IntPtr, IntPtr> fn, string s1, string s2)
    {
        var p1 = S(s1); var p2 = S(s2);
        try { fn(p1, p2); } finally { Free(p1); Free(p2); }
    }

    private static int Call3(Func<IntPtr, IntPtr, double, int> fn, string s1, string s2, double val)
    {
        var p1 = S(s1); var p2 = S(s2);
        try { return fn(p1, p2, val); } finally { Free(p1); Free(p2); }
    }   

    // ─── Event callback delegate ───────────────────────────────────────────

    [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
    private delegate void BKEventCallback(
        IntPtr data, IntPtr node, int kind, IntPtr @ref, double a, double b);

    // ─── BKHost struct (minimum layout — verify against header) ────────────

    [StructLayout(LayoutKind.Sequential)]
    private struct BKHostStruct
    {
        public BKEventCallback emit;
        
        public fixed byte _pad[56];
    }

    // ─── Constants ───────────────────────

    public const int GEOM_NONE = 0;
    public const int GEOM_PACK  = 1;
    public const int GEOM_GRID  = 2;
    public const int GEOM_PLACE = 3;
    
    public const int EV_CLICK   = 1;
    public const int EV_CHANGE  = 2;
    public const int EV_CALL =  3;

    // ─── Constructor / Destructor ──────────────────────────────────────────

    public BuiApp(string title, int width = 320, int height = 240)
    {
        // 1. Root node
        // node_new takes const char*, we pass the ptr directly
        var pType = S("frame");
        _root = BuiKit.BK_node_new(pType);
        Free(pType);

        // 2. Context
        _ctx = BuiKit.BK_context_new(_root);

        // 3. Host with callback
        _callback = OnEvent;
        _host = Marshal.AllocHGlobal(Marshal.SizeOf<BKHostStruct>());
        var hostPtr = (BKHostStruct*)_host;
        hostPtr->emit = _callback;
        BuiKit.BK_context_set_host(_ctx, _host);

        // 4. Window
        var pTitle = S(title);
        _win = BuiKit.BK_window_new(_ctx, pTitle, width, height);
        Free(pTitle);
    }

    private void OnEvent(IntPtr data, IntPtr node, int kind, IntPtr @ref, double a, double b)
    {
        switch (kind)
        {
            case EV_CLICK:
            {
                var pText = S("text");
                Free(pText);
                OnClick(node, a, b);
                break;
            }
            case EV_CHANGE:
                OnChange(node, a, b);
                break;
        }
    }

    // ─── Virtual event hooks (override in subclass) ────────────────────────

    protected virtual void OnClick(IntPtr node, double a, double b) { }
    protected virtual void OnChange(IntPtr node, double a, double b) { }

    // ─── Node creation ─────────────────────────────────────────────────────

    public IntPtr Node(string type)
    {
        var p = S(type);
        var node = BuiKit.BK_node_new(p);
        Free(p);
        return node;
    }

    public void Add(IntPtr parent, IntPtr child, int index = -1)
        => BuiKit.BK_node_add(parent, child, index);

    public void AddToRoot(IntPtr child) => Add(_root, child);

    // ─── Properties ────────────────────────────────────────────────────────

    public void SetStr(IntPtr node, string key, string value)
    {
        var pKey = S(key); var pVal = S(value);
        try { BuiKit.BK_set_str(node, pKey, pVal); }
        finally { Free(pKey); Free(pVal); }
    }

    public void SetNum(IntPtr node, string key, double value)
    {
        var pKey = S(key);
        try { BuiKit.BK_set_num(node, pKey, value); }
        finally { Free(pKey); }
    }

    public void SetColor(IntPtr node, string key, float r, float g, float b, float a = 1f)
    {
        var pKey = S(key);
        float* rgba = stackalloc float[4] { r, g, b, a };
        try { BuiKit.BK_set_color(node, pKey, (IntPtr)rgba); }
        finally { Free(pKey); }
    }   

    public double GetNum(IntPtr node, string key)
    {
        var pKey = S(key);
        try { return BuiKit.BK_get_num(node, pKey); }
        finally { Free(pKey); }
    }

    // ─── Geometry ──────────────────────────────────────────────────────────

    public void Pack(IntPtr node, double fill = 0, double pad = 0)
    {
        BuiKit.BK_geom_set_manager(node, GEOM_PACK);
        if (fill != 0)
        {
            var p = S("fill");
            try { BuiKit.BK_geom_set(node, p, fill); } finally { Free(p); }
        }
        if (pad != 0)
        {
            var p = S("pad");
            try { BuiKit.BK_geom_set(node, p, pad); } finally { Free(p); }
        }
    }

    public void Grid(IntPtr node, int column = 0, int row = 0)
    {
        BuiKit.BK_geom_set_manager(node, GEOM_GRID);
        if (column != 0)
        {
            var p = S("column");
            try { BuiKit.BK_geom_set(node, p, column); } finally { Free(p); }
        }
        if (row != 0)
        {
            var p = S("row");
            try { BuiKit.BK_geom_set(node, p, row); } finally { Free(p); }
        }
    }

    // ─── Theme ─────────────────────────────────────────────────────────────

    public void SetTheme(string name)
        => Call1(p => BuiKit.BK_set_theme(p), name);

    // ─── Window ────────────────────────────────────────────────────────────

    public void SetTitle(string title)
        => Call1(p => BuiKit.BK_window_set_title(_win, p), title);

    public void SetSize(int w, int h)
        => BuiKit.BK_window_set_size(_win, w, h);

    public void SetGpu(bool on)
        => BuiKit.BK_window_set_gpu(_win, on ? 1 : 0);

    public void Run()
    {
        BuiKit.BK_window_show(_win);
        BuiKit.BK_window_run(); // blocks until window closed
    }

    public void Quit()
        => BuiKit.BK_window_quit();

    public IntPtr Window => _win;
    public IntPtr Context => _ctx;
    public IntPtr Root => _root;

    // ─── Dispose ───────────────────────────────────────────────────────────

    public void Dispose()
    {
        if (_win != IntPtr.Zero) { BuiKit.BK_window_free(_win); _win = IntPtr.Zero; }
        if (_ctx != IntPtr.Zero) { BuiKit.BK_context_free(_ctx); _ctx = IntPtr.Zero; }
        if (_host != IntPtr.Zero) { Marshal.FreeHGlobal(_host); _host = IntPtr.Zero; }
        if (_root != IntPtr.Zero) { BuiKit.BK_node_free(_root); _root = IntPtr.Zero; }
        _callback = null;
    }
}   