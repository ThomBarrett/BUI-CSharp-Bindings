namespace BuiCSharp;

using System.Runtime.InteropServices;
// Example program from when this was an Exe instead of a Library
public class Program
{
    static IntPtr S(string s) => Marshal.StringToCoTaskMemUTF8(s);
    static void Free(IntPtr p) => Marshal.FreeCoTaskMem(p);

    static void Main()
{
    // 1. Build tree FIRST
    var pRoot = Marshal.StringToCoTaskMemUTF8("frame");
    IntPtr root = BuiKit.BK_node_new(pRoot);
    Marshal.FreeCoTaskMem(pRoot);

    var pPad = Marshal.StringToCoTaskMemUTF8("padding");
    BuiKit.BK_set_num(root, pPad, 8);
    Marshal.FreeCoTaskMem(pPad);

    var pBtn = Marshal.StringToCoTaskMemUTF8("button");
    IntPtr btn = BuiKit.BK_node_new(pBtn);
    Marshal.FreeCoTaskMem(pBtn);

    var pText = Marshal.StringToCoTaskMemUTF8("text");
    var pVal = Marshal.StringToCoTaskMemUTF8("Hello button 1");
    BuiKit.BK_set_str(btn, pText, pVal);
    Marshal.FreeCoTaskMem(pText);
    Marshal.FreeCoTaskMem(pVal);

    BuiKit.BK_node_add(root, btn, -1);
    BuiKit.BK_geom_set_manager(btn, 1); // BK_GEOM_PACK

    // 2. Context (AFTER tree)
    IntPtr ctx = BuiKit.BK_context_new(root);

    // 3. Window
    var pTitle = Marshal.StringToCoTaskMemUTF8("BUI from C#");
    IntPtr win = BuiKit.BK_window_new(ctx, pTitle, 320, 120);
    Marshal.FreeCoTaskMem(pTitle);

    // 4. Run
    BuiKit.BK_window_show(win);
    BuiKit.BK_window_run();

    BuiKit.BK_window_free(win);
    BuiKit.BK_context_free(ctx);
    BuiKit.BK_node_free(root);
}   
}   
