using System.Runtime.InteropServices;

public static partial class BuiKit
{

    // ─── Constants ─────────────────────────────────────────────────────
    public const int BUI_KIT_VERSION_MAJOR = 0;
    public const int BUI_KIT_VERSION_MINOR = 5;
    public const int BUI_KIT_VERSION_PATCH = 0;
    // #define BUI_KIT_VERSION_STRING "0.5.0"
    // #define BUI_KIT_VERSION \

    // ─── P/Invoke ────────────────────────────────────────────────────────

    [LibraryImport("bui_kit", EntryPoint = "BK_version")]
    public static partial IntPtr BK_version();

    [LibraryImport("bui_kit", EntryPoint = "BK_set_scale")]
    public static partial void BK_set_scale(float scale);

    [LibraryImport("bui_kit", EntryPoint = "BK_scale")]
    public static partial float BK_scale();

    [LibraryImport("bui_kit", EntryPoint = "BK_unit")]
    public static partial int BK_unit();

    [LibraryImport("bui_kit", EntryPoint = "BK_set_font")]
    public static partial void BK_set_font(IntPtr family);

    [LibraryImport("bui_kit", EntryPoint = "BK_set_theme")]
    public static partial int BK_set_theme(IntPtr name);

    [LibraryImport("bui_kit", EntryPoint = "BK_theme_color")]
    public static partial int BK_theme_color(IntPtr key, float r_rgba);

    [LibraryImport("bui_kit", EntryPoint = "BK_icon_id")]
    public static partial int BK_icon_id(IntPtr name);

    [LibraryImport("bui_kit", EntryPoint = "BK_icon_count")]
    public static partial int BK_icon_count();

    [LibraryImport("bui_kit", EntryPoint = "BK_icon_list_count")]
    public static partial int BK_icon_list_count();
    
    [LibraryImport("bui_kit", EntryPoint = "BK_node_new")]
    public static partial IntPtr BK_node_new(IntPtr type); 
    
    [LibraryImport("bui_kit", EntryPoint = "BK_context_new")]
    public static partial IntPtr BK_context_new(IntPtr root);    
    
    [LibraryImport("bui_kit", EntryPoint = "BK_window_new")]
    public static partial IntPtr BK_window_new(IntPtr ctx, IntPtr title, int w, int h);

    

    [LibraryImport("bui_kit", EntryPoint = "BK_node_free")]
    public static partial void BK_node_free(IntPtr node);

    [LibraryImport("bui_kit", EntryPoint = "BK_node_set_ref")]
    public static partial void BK_node_set_ref(IntPtr node, IntPtr @ref);

    [LibraryImport("bui_kit", EntryPoint = "BK_node_add")]
    public static partial int BK_node_add(IntPtr parent, IntPtr child, int index);

    [LibraryImport("bui_kit", EntryPoint = "BK_node_remove")]
    public static partial void BK_node_remove(IntPtr parent, IntPtr child);

    [LibraryImport("bui_kit", EntryPoint = "BK_node_child_count")]
    public static partial int BK_node_child_count(IntPtr node);

    [LibraryImport("bui_kit", EntryPoint = "BK_node_rect")]
    public static partial void BK_node_rect(IntPtr node, int r_rect);

    [LibraryImport("bui_kit", EntryPoint = "BK_node_natural")]
    public static partial void BK_node_natural(IntPtr node, int r_size);

    [LibraryImport("bui_kit", EntryPoint = "BK_node_invalidate")]
    public static partial void BK_node_invalidate(IntPtr node);

    [LibraryImport("bui_kit", EntryPoint = "BK_node_relayout")]
    public static partial void BK_node_relayout(IntPtr node);

    [LibraryImport("bui_kit", EntryPoint = "BK_set_num")]
    public static partial int BK_set_num(IntPtr node, IntPtr key, double value);

    [LibraryImport("bui_kit", EntryPoint = "BK_set_str")]
    public static partial int BK_set_str(IntPtr node, IntPtr key, IntPtr value);

    [LibraryImport("bui_kit", EntryPoint = "BK_set_color")]
    public static partial int BK_set_color(IntPtr node, IntPtr key, IntPtr rgba);

    [LibraryImport("bui_kit", EntryPoint = "BK_set_strs")]
    public static partial int BK_set_strs(IntPtr node, IntPtr key, IntPtr values, int n);

    [LibraryImport("bui_kit", EntryPoint = "BK_get_num")]
    public static partial double BK_get_num(IntPtr node, IntPtr key);

    [LibraryImport("bui_kit", EntryPoint = "BK_get_color")]
    public static partial int BK_get_color(IntPtr node, IntPtr key, float r_rgba);

    [LibraryImport("bui_kit", EntryPoint = "BK_strs_count")]
    public static partial int BK_strs_count(IntPtr node, IntPtr key);

    [LibraryImport("bui_kit", EntryPoint = "BK_link_fields")]
    public static partial void BK_link_fields(IntPtr fields, int n);

    [LibraryImport("bui_kit", EntryPoint = "BK_ramp_count")]
    public static partial int BK_ramp_count(IntPtr ramp);

    [LibraryImport("bui_kit", EntryPoint = "BK_ramp_get")]
    public static partial void BK_ramp_get(IntPtr ramp, int i, IntPtr r_pos, float r_rgba);

    [LibraryImport("bui_kit", EntryPoint = "BK_ramp_active")]
    public static partial int BK_ramp_active(IntPtr ramp);

    [LibraryImport("bui_kit", EntryPoint = "BK_ramp_evaluate")]
    public static partial void BK_ramp_evaluate(IntPtr ramp, float t, float r_rgba);

    [LibraryImport("bui_kit", EntryPoint = "BK_curve_count")]
    public static partial int BK_curve_count(IntPtr curve, int channel);

    [LibraryImport("bui_kit", EntryPoint = "BK_curve_get")]
    public static partial void BK_curve_get(IntPtr curve, int channel, int i, float r_xy);

    [LibraryImport("bui_kit", EntryPoint = "BK_curve_evaluate")]
    public static partial float BK_curve_evaluate(IntPtr curve, int channel, float x);

    [LibraryImport("bui_kit", EntryPoint = "BK_ramp_set_active_color")]
    public static partial void BK_ramp_set_active_color(IntPtr ramp, IntPtr rgba);

    [LibraryImport("bui_kit", EntryPoint = "BK_histogram_set")]
    public static partial void BK_histogram_set(IntPtr hist, IntPtr bins, int n, int channels);

    [LibraryImport("bui_kit", EntryPoint = "BK_tree_item_free")]
    public static partial void BK_tree_item_free(IntPtr item);

    [LibraryImport("bui_kit", EntryPoint = "BK_tree_item_set_ref")]
    public static partial void BK_tree_item_set_ref(IntPtr item, IntPtr @ref);

    [LibraryImport("bui_kit", EntryPoint = "BK_tree_item_add")]
    public static partial void BK_tree_item_add(IntPtr parent, IntPtr child);

    [LibraryImport("bui_kit", EntryPoint = "BK_tree_item_clear")]
    public static partial void BK_tree_item_clear(IntPtr parent);

    [LibraryImport("bui_kit", EntryPoint = "BK_tree_item_set")]
    public static partial void BK_tree_item_set(IntPtr item, IntPtr key, double value);

    [LibraryImport("bui_kit", EntryPoint = "BK_tree_item_get")]
    public static partial double BK_tree_item_get(IntPtr item, IntPtr key);

    [LibraryImport("bui_kit", EntryPoint = "BK_tree_item_set_label")]
    public static partial void BK_tree_item_set_label(IntPtr item, IntPtr label);

    [LibraryImport("bui_kit", EntryPoint = "BK_tree_item_child_count")]
    public static partial int BK_tree_item_child_count(IntPtr item);

    [LibraryImport("bui_kit", EntryPoint = "BK_tree_set_roots")]
    public static partial void BK_tree_set_roots(IntPtr tree, IntPtr roots, int n);

    [LibraryImport("bui_kit", EntryPoint = "BK_tree_select")]
    public static partial void BK_tree_select(IntPtr tree, IntPtr item);

    [LibraryImport("bui_kit", EntryPoint = "BK_tree_row_count")]
    public static partial int BK_tree_row_count(IntPtr tree);

    [LibraryImport("bui_kit", EntryPoint = "BK_tree_row_rect")]
    public static partial void BK_tree_row_rect(IntPtr tree, int row, int r_rect);

    [LibraryImport("bui_kit", EntryPoint = "BK_menubutton_set_items")]
    public static partial void BK_menubutton_set_items(IntPtr button, IntPtr items, int n);

    [LibraryImport("bui_kit", EntryPoint = "BK_open_menu")]
    public static partial void BK_open_menu(IntPtr ctx, IntPtr owner, IntPtr items, int n, IntPtr title, int at_x, int at_y);

    [LibraryImport("bui_kit", EntryPoint = "BK_open_pie")]
    public static partial void BK_open_pie(IntPtr ctx, IntPtr items, int n, IntPtr title);

    [LibraryImport("bui_kit", EntryPoint = "BK_geom_set_manager")]
    public static partial void BK_geom_set_manager(IntPtr child, int manager);

    [LibraryImport("bui_kit", EntryPoint = "BK_geom_manager")]
    public static partial int BK_geom_manager(IntPtr child);

    [LibraryImport("bui_kit", EntryPoint = "BK_geom_set")]
    public static partial void BK_geom_set(IntPtr child, IntPtr key, double value);

    [LibraryImport("bui_kit", EntryPoint = "BK_geom_get")]
    public static partial double BK_geom_get(IntPtr child, IntPtr key);

    [LibraryImport("bui_kit", EntryPoint = "BK_frame_grid_weight")]
    public static partial void BK_frame_grid_weight(IntPtr frame, int column_axis, int index, double weight, int minsize);

    [LibraryImport("bui_kit", EntryPoint = "BK_image_probe")]
    public static partial int BK_image_probe(IntPtr data, nuint len, IntPtr r_info);

    [LibraryImport("bui_kit", EntryPoint = "BK_image_probe_file")]
    public static partial int BK_image_probe_file(IntPtr path, IntPtr r_info);

    [LibraryImport("bui_kit", EntryPoint = "BK_imbuf_free")]
    public static partial void BK_imbuf_free(IntPtr ib);

    [LibraryImport("bui_kit", EntryPoint = "BK_imbuf_size")]
    public static partial int BK_imbuf_size(IntPtr ib, IntPtr r_w, IntPtr r_h);

    [LibraryImport("bui_kit", EntryPoint = "BK_imbuf_format")]
    public static partial int BK_imbuf_format(IntPtr ib);

    [LibraryImport("bui_kit", EntryPoint = "BK_imbuf_delay")]
    public static partial int BK_imbuf_delay(IntPtr ib, int frame);

    [LibraryImport("bui_kit", EntryPoint = "BK_imbuf_loops")]
    public static partial int BK_imbuf_loops(IntPtr ib);

    [LibraryImport("bui_kit", EntryPoint = "BK_imbuf_rgba")]
    public static partial int BK_imbuf_rgba(IntPtr ib, int frame, IntPtr dst);

    [LibraryImport("bui_kit", EntryPoint = "BK_imbuf_texture")]
    public static partial int BK_imbuf_texture(IntPtr ib, int frame);

    [LibraryImport("bui_kit", EntryPoint = "BK_imbuf_texture_update")]
    public static partial int BK_imbuf_texture_update(IntPtr ib, int frame, int tex);

    [LibraryImport("bui_kit", EntryPoint = "BK_anim_info")]
    public static partial int BK_anim_info(IntPtr anim, IntPtr r_w, IntPtr r_h, IntPtr r_loops);

    [LibraryImport("bui_kit", EntryPoint = "BK_anim_free")]
    public static partial void BK_anim_free(IntPtr anim);

    [LibraryImport("bui_kit", EntryPoint = "BK_video_free")]
    public static partial void BK_video_free(IntPtr v);

    [LibraryImport("bui_kit", EntryPoint = "BK_video_play")]
    public static partial void BK_video_play(IntPtr v);

    [LibraryImport("bui_kit", EntryPoint = "BK_video_pause")]
    public static partial void BK_video_pause(IntPtr v);

    [LibraryImport("bui_kit", EntryPoint = "BK_video_seek")]
    public static partial void BK_video_seek(IntPtr v, double seconds);

    [LibraryImport("bui_kit", EntryPoint = "BK_video_set_rate")]
    public static partial void BK_video_set_rate(IntPtr v, double rate);

    [LibraryImport("bui_kit", EntryPoint = "BK_video_set_loop")]
    public static partial void BK_video_set_loop(IntPtr v, int loop);

    [LibraryImport("bui_kit", EntryPoint = "BK_video_set_poster")]
    public static partial void BK_video_set_poster(IntPtr v, IntPtr src);

    [LibraryImport("bui_kit", EntryPoint = "BK_video_set_controls")]
    public static partial void BK_video_set_controls(IntPtr v, int on);

    [LibraryImport("bui_kit", EntryPoint = "BK_video_state")]
    public static partial int BK_video_state(IntPtr v);

    [LibraryImport("bui_kit", EntryPoint = "BK_video_time")]
    public static partial double BK_video_time(IntPtr v);

    [LibraryImport("bui_kit", EntryPoint = "BK_video_duration")]
    public static partial double BK_video_duration(IntPtr v);

    [LibraryImport("bui_kit", EntryPoint = "BK_video_size")]
    public static partial int BK_video_size(IntPtr v, IntPtr r_w, IntPtr r_h);

    [LibraryImport("bui_kit", EntryPoint = "BK_video_texture")]
    public static partial int BK_video_texture(IntPtr v, int tex, int max_w, int max_h);

    [LibraryImport("bui_kit", EntryPoint = "BK_node_set_video")]
    public static partial void BK_node_set_video(IntPtr node, IntPtr v, int fit);

    [LibraryImport("bui_kit", EntryPoint = "BK_image_set_budget")]
    public static partial void BK_image_set_budget(nuint bytes);

    [LibraryImport("bui_kit", EntryPoint = "BK_image_set_threads")]
    public static partial void BK_image_set_threads(int n);

    [LibraryImport("bui_kit", EntryPoint = "BK_image_poll")]
    public static partial int BK_image_poll();

    [LibraryImport("bui_kit", EntryPoint = "BK_image_stats")]
    public static partial void BK_image_stats(IntPtr r_stats);

    [LibraryImport("bui_kit", EntryPoint = "BK_image_info")]
    public static partial int BK_image_info(IntPtr src, IntPtr r_info);

    [LibraryImport("bui_kit", EntryPoint = "BK_image_prefetch")]
    public static partial void BK_image_prefetch(IntPtr src, int w, int h, int fit);

    [LibraryImport("bui_kit", EntryPoint = "BK_image_clear_cache")]
    public static partial void BK_image_clear_cache();

    [LibraryImport("bui_kit", EntryPoint = "BK_image_exit")]
    public static partial void BK_image_exit();

    [LibraryImport("bui_kit", EntryPoint = "BK_canvas_set_item")]
    public static partial void BK_canvas_set_item(IntPtr canvas, IntPtr item);

    [LibraryImport("bui_kit", EntryPoint = "BK_canvas_add_item")]
    public static partial void BK_canvas_add_item(IntPtr canvas, IntPtr item);

    [LibraryImport("bui_kit", EntryPoint = "BK_canvas_put_item")]
    public static partial void BK_canvas_put_item(IntPtr canvas, int index, IntPtr item);

    [LibraryImport("bui_kit", EntryPoint = "BK_canvas_truncate")]
    public static partial void BK_canvas_truncate(IntPtr canvas, int count);

    [LibraryImport("bui_kit", EntryPoint = "BK_canvas_delete")]
    public static partial void BK_canvas_delete(IntPtr canvas, int id);

    [LibraryImport("bui_kit", EntryPoint = "BK_canvas_raise")]
    public static partial void BK_canvas_raise(IntPtr canvas, int id, int to_top);

    [LibraryImport("bui_kit", EntryPoint = "BK_canvas_count")]
    public static partial int BK_canvas_count(IntPtr canvas);

    [LibraryImport("bui_kit", EntryPoint = "BK_node_set_image")]
    public static partial void BK_node_set_image(IntPtr node, IntPtr rgba, int w, int h);

    [LibraryImport("bui_kit", EntryPoint = "BK_node_set_imbuf")]
    public static partial void BK_node_set_imbuf(IntPtr node, IntPtr ib);

    [LibraryImport("bui_kit", EntryPoint = "BK_node_set_image_source")]
    public static partial void BK_node_set_image_source(IntPtr node, IntPtr src, int fit);

    [LibraryImport("bui_kit", EntryPoint = "BK_node_set_image_frame")]
    public static partial void BK_node_set_image_frame(IntPtr node, int frame);

    [LibraryImport("bui_kit", EntryPoint = "BK_custom_set")]
    public static partial int BK_custom_set(IntPtr node, IntPtr cls, IntPtr data);

    [LibraryImport("bui_kit", EntryPoint = "BK_custom_request_frame")]
    public static partial void BK_custom_request_frame(IntPtr node, int ms);

    [LibraryImport("bui_kit", EntryPoint = "BK_custom_set_cursor")]
    public static partial void BK_custom_set_cursor(IntPtr node, int cursor);

    [LibraryImport("bui_kit", EntryPoint = "BK_custom_has_focus")]
    public static partial int BK_custom_has_focus(IntPtr node);

    [LibraryImport("bui_kit", EntryPoint = "BK_textarea_insert")]
    public static partial void BK_textarea_insert(IntPtr n, int offset, IntPtr text);

    [LibraryImport("bui_kit", EntryPoint = "BK_textarea_delete")]
    public static partial void BK_textarea_delete(IntPtr n, int start, int end);

    [LibraryImport("bui_kit", EntryPoint = "BK_textarea_caret")]
    public static partial int BK_textarea_caret(IntPtr n);

    [LibraryImport("bui_kit", EntryPoint = "BK_textarea_set_caret")]
    public static partial void BK_textarea_set_caret(IntPtr n, int offset);

    [LibraryImport("bui_kit", EntryPoint = "BK_textarea_selection")]
    public static partial int BK_textarea_selection(IntPtr n, IntPtr r_start, IntPtr r_end);

    [LibraryImport("bui_kit", EntryPoint = "BK_textarea_set_selection")]
    public static partial void BK_textarea_set_selection(IntPtr n, int start, int end);

    [LibraryImport("bui_kit", EntryPoint = "BK_textarea_set_spans")]
    public static partial void BK_textarea_set_spans(IntPtr n, IntPtr spans, int count);

    [LibraryImport("bui_kit", EntryPoint = "BK_textarea_index_at")]
    public static partial int BK_textarea_index_at(IntPtr n, int x, int y);

    [LibraryImport("bui_kit", EntryPoint = "BK_textarea_see")]
    public static partial void BK_textarea_see(IntPtr n, int offset);

    [LibraryImport("bui_kit", EntryPoint = "BK_tree_item_set_values")]
    public static partial void BK_tree_item_set_values(IntPtr item, IntPtr values, int n);

    [LibraryImport("bui_kit", EntryPoint = "BK_undo")]
    public static partial int BK_undo(IntPtr ctx);

    [LibraryImport("bui_kit", EntryPoint = "BK_redo")]
    public static partial int BK_redo(IntPtr ctx);

    [LibraryImport("bui_kit", EntryPoint = "BK_undo_depth")]
    public static partial int BK_undo_depth(IntPtr ctx, IntPtr r_redo);

    [LibraryImport("bui_kit", EntryPoint = "BK_animating")]
    public static partial int BK_animating(IntPtr ctx);

    [LibraryImport("bui_kit", EntryPoint = "BK_set_animations")]
    public static partial void BK_set_animations(int enabled);

    [LibraryImport("bui_kit", EntryPoint = "BK_context_free")]
    public static partial void BK_context_free(IntPtr ctx);

    [LibraryImport("bui_kit", EntryPoint = "BK_context_set_host")]
    public static partial void BK_context_set_host(IntPtr ctx, IntPtr host);

    [LibraryImport("bui_kit", EntryPoint = "BK_context_set_header")]
    public static partial void BK_context_set_header(IntPtr ctx, IntPtr header);

    [LibraryImport("bui_kit", EntryPoint = "BK_render")]
    public static partial int BK_render(IntPtr ctx, IntPtr r, int w, int h, int full);

    [LibraryImport("bui_kit", EntryPoint = "BK_needs_render")]
    public static partial int BK_needs_render(IntPtr ctx);

    [LibraryImport("bui_kit", EntryPoint = "BK_press")]
    public static partial int BK_press(IntPtr ctx, int x, int y, int mods);

    [LibraryImport("bui_kit", EntryPoint = "BK_release")]
    public static partial int BK_release(IntPtr ctx, int x, int y, int mods);

    [LibraryImport("bui_kit", EntryPoint = "BK_motion")]
    public static partial int BK_motion(IntPtr ctx, int x, int y, int mods);

    [LibraryImport("bui_kit", EntryPoint = "BK_wheel")]
    public static partial int BK_wheel(IntPtr ctx, int x, int y, int delta, int mods);

    [LibraryImport("bui_kit", EntryPoint = "BK_scroll")]
    public static partial int BK_scroll(IntPtr ctx, int x, int y, float dx, float dy, int mods);

    [LibraryImport("bui_kit", EntryPoint = "BK_key")]
    public static partial int BK_key(IntPtr ctx, IntPtr text, IntPtr keysym, int mods);

    [LibraryImport("bui_kit", EntryPoint = "BK_context_menu")]
    public static partial int BK_context_menu(IntPtr ctx, int x, int y, int mods);

    [LibraryImport("bui_kit", EntryPoint = "BK_ime_event")]
    public static partial int BK_ime_event(IntPtr ctx, int type, IntPtr e);

    [LibraryImport("bui_kit", EntryPoint = "BK_ime_state")]
    public static partial int BK_ime_state(IntPtr ctx, IntPtr state);

    [LibraryImport("bui_kit", EntryPoint = "BK_ime_composing")]
    public static partial int BK_ime_composing(IntPtr ctx);

    [LibraryImport("bui_kit", EntryPoint = "BK_key_release")]
    public static partial int BK_key_release(IntPtr ctx, IntPtr keysym, int mods);

    [LibraryImport("bui_kit", EntryPoint = "BK_button")]
    public static partial int BK_button(IntPtr ctx, int x, int y, int button, int release, int mods);

    [LibraryImport("bui_kit", EntryPoint = "BK_timer")]
    public static partial void BK_timer(IntPtr ctx, int timer);

    [LibraryImport("bui_kit", EntryPoint = "BK_bind")]
    public static partial void BK_bind(IntPtr ctx, IntPtr combo, IntPtr @ref);

    [LibraryImport("bui_kit", EntryPoint = "BK_close_popups")]
    public static partial void BK_close_popups(IntPtr ctx);

    [LibraryImport("bui_kit", EntryPoint = "BK_set_pointer")]
    public static partial void BK_set_pointer(IntPtr ctx, int x, int y);

    [LibraryImport("bui_kit", EntryPoint = "BK_cursor")]
    public static partial int BK_cursor(IntPtr ctx);

    [LibraryImport("bui_kit", EntryPoint = "BK_focus_node")]
    public static partial void BK_focus_node(IntPtr ctx, IntPtr n);

    [LibraryImport("bui_kit", EntryPoint = "BK_clipboard_set")]
    public static partial void BK_clipboard_set(IntPtr ctx, IntPtr text);

    [LibraryImport("bui_kit", EntryPoint = "BK_modal_active")]
    public static partial int BK_modal_active(IntPtr ctx);

    [LibraryImport("bui_kit", EntryPoint = "BK_tooltip_visible")]
    public static partial int BK_tooltip_visible(IntPtr ctx);

    [LibraryImport("bui_kit", EntryPoint = "BK_popup_count")]
    public static partial int BK_popup_count(IntPtr ctx);

    [LibraryImport("bui_kit", EntryPoint = "BK_menu_row_count")]
    public static partial int BK_menu_row_count(IntPtr menu);

    [LibraryImport("bui_kit", EntryPoint = "BK_menu_row_rect")]
    public static partial void BK_menu_row_rect(IntPtr menu, int i, int r_rect);

    [LibraryImport("bui_kit", EntryPoint = "BK_window_supported")]
    public static partial int BK_window_supported();

    [LibraryImport("bui_kit", EntryPoint = "BK_window_free")]
    public static partial void BK_window_free(IntPtr win);

    [LibraryImport("bui_kit", EntryPoint = "BK_window_set_callbacks")]
    public static partial void BK_window_set_callbacks(IntPtr win, IntPtr cb);

    [LibraryImport("bui_kit", EntryPoint = "BK_window_show")]
    public static partial void BK_window_show(IntPtr win);

    [LibraryImport("bui_kit", EntryPoint = "BK_window_close")]
    public static partial void BK_window_close(IntPtr win);

    [LibraryImport("bui_kit", EntryPoint = "BK_window_is_open")]
    public static partial int BK_window_is_open(IntPtr win);

    [LibraryImport("bui_kit", EntryPoint = "BK_window_set_title")]
    public static partial void BK_window_set_title(IntPtr win, IntPtr title);

    [LibraryImport("bui_kit", EntryPoint = "BK_window_set_size")]
    public static partial void BK_window_set_size(IntPtr win, int width, int height);

    [LibraryImport("bui_kit", EntryPoint = "BK_window_get_size")]
    public static partial void BK_window_get_size(IntPtr win, IntPtr r_width, IntPtr r_height);

    [LibraryImport("bui_kit", EntryPoint = "BK_window_set_gpu")]
    public static partial void BK_window_set_gpu(IntPtr win, int on);

    [LibraryImport("bui_kit", EntryPoint = "BK_window_gpu")]
    public static partial int BK_window_gpu(IntPtr win);

    [LibraryImport("bui_kit", EntryPoint = "BK_window_frames")]
    public static partial int BK_window_frames(IntPtr win);

    [LibraryImport("bui_kit", EntryPoint = "BK_window_render_now")]
    public static partial void BK_window_render_now(IntPtr win);

    [LibraryImport("bui_kit", EntryPoint = "BK_window_timer")]
    public static partial int BK_window_timer(IntPtr win, int ms);

    [LibraryImport("bui_kit", EntryPoint = "BK_window_request_frame")]
    public static partial void BK_window_request_frame(IntPtr win, int vsync);

    [LibraryImport("bui_kit", EntryPoint = "BK_window_cancel_timer")]
    public static partial void BK_window_cancel_timer(IntPtr win, int id);

    [LibraryImport("bui_kit", EntryPoint = "BK_window_wm")]
    public static partial void BK_window_wm(IntPtr win, IntPtr key, double a, double b);

    [LibraryImport("bui_kit", EntryPoint = "BK_window_wm_get")]
    public static partial int BK_window_wm_get(IntPtr win, IntPtr key, IntPtr r_a, IntPtr r_b);

    [LibraryImport("bui_kit", EntryPoint = "BK_window_run")]
    public static partial void BK_window_run();

    [LibraryImport("bui_kit", EntryPoint = "BK_window_pump")]
    public static partial int BK_window_pump();

    [LibraryImport("bui_kit", EntryPoint = "BK_window_quit")]
    public static partial void BK_window_quit();

    [LibraryImport("bui_kit", EntryPoint = "BK_window_wake")]
    public static partial void BK_window_wake();

    [LibraryImport("bui_kit", EntryPoint = "BK_window_set_keep_alive")]
    public static partial void BK_window_set_keep_alive(int on);

    [LibraryImport("bui_kit", EntryPoint = "BK_draw_widget")]
    public static partial void BK_draw_widget(IntPtr r, IntPtr w);

    [LibraryImport("bui_kit", EntryPoint = "BK_text_width")]
    public static partial float BK_text_width(IntPtr s, int len);

    [LibraryImport("bui_kit", EntryPoint = "BK_eval_number")]
    public static partial int BK_eval_number(IntPtr expr, IntPtr r_value);

    [LibraryImport("bui_kit", EntryPoint = "BK_file_dialog")]
    public static partial int BK_file_dialog(IntPtr title, int mode, IntPtr dir, IntPtr file, IntPtr filters, int nfilters, int multiple, IntPtr r_paths);

    [LibraryImport("bui_kit", EntryPoint = "BK_file_dialog_free")]
    public static partial void BK_file_dialog_free(IntPtr paths);

    [LibraryImport("bui_kit", EntryPoint = "BK_recent_searches_enable")]
    public static partial void BK_recent_searches_enable(int enabled);

    [LibraryImport("bui_kit", EntryPoint = "BK_recent_searches_clear")]
    public static partial void BK_recent_searches_clear();

    [LibraryImport("bui_kit", EntryPoint = "BK_recent_searches_load")]
    public static partial void BK_recent_searches_load(IntPtr path);

    [LibraryImport("bui_kit", EntryPoint = "BK_recent_searches_save")]
    public static partial void BK_recent_searches_save(IntPtr path);
}
