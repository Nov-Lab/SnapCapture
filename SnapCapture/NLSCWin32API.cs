// @(h)NLSCWin32API.cs ver 0.00 ( '23.04.25 Nov-Lab ) FrmNLSCApp.cs から分離して作成開始
// @(h)NLSCWin32API.cs ver 1.01 ( '23.04.25 Nov-Lab ) 初版完成
// @(h)NLSCWin32API.cs ver 1.01a( '23.09.30 Nov-Lab ) その他  ：コメント整理

// @(s)
// 　【Win32API定義】本アプリケーションで使用する Win32 API の関数・定数・構造体などを定義します。

using System;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using System.Text;


namespace SnapCapture
{
    //====================================================================================================
    /// <summary>
    /// 【Win32API定義】本アプリケーションで使用する Win32 API の関数・定数・構造体などを定義します。
    /// </summary>
    //====================================================================================================
    class AppWin32API
    {
        //====================================================================================================
        // クリップボード操作
        //====================================================================================================
        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【AddClipboardFormatListener API関数(GetLastError対応)】
        /// クリップボードリスナーにウィンドウを登録します。
        /// </summary>
        /// <param name="hwnd">[in ]：ウィンドウハンドル</param>
        /// <returns>
        /// 関数が成功すると、0 以外の値が返ります。
        /// 関数が失敗すると、0 が返ります。拡張エラー情報を取得するには、GetLastError 関数を使います。
        /// </returns>
        /// <remarks>
        /// ・クリップボードリスナーにウィンドウを登録することで、クリップボードが更新され
        ///   たときに WM_CLIPBOARDUPDATE メッセージが送られてくるようになります。<br></br>
        /// ・対応OS：Vista以降。<br></br>
        /// </remarks>
        //--------------------------------------------------------------------------------
        [DllImport("user32", EntryPoint = "AddClipboardFormatListener", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool AddClipboardFormatListener(   // BOOL AddClipboardFormatListener(
            IntPtr hwnd                                         //   HWND hwnd    // ウィンドウハンドル
        );                                                      // );


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【RemoveClipboardFormatListener API関数(GetLastError対応)】
        /// クリップボードリスナーからウィンドウを削除します。
        /// </summary>
        /// <param name="hwnd">[in ]：ウィンドウハンドル</param>
        /// <returns>
        /// 関数が成功すると、0 以外の値が返ります。
        /// 関数が失敗すると、0 が返ります。拡張エラー情報を取得するには、GetLastError 関数を使います。
        /// </returns>
        /// <remarks>
        /// ・対応OS：Vista以降。<br></br>
        /// </remarks>
        //--------------------------------------------------------------------------------
        [DllImport("user32", EntryPoint = "RemoveClipboardFormatListener", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern bool RemoveClipboardFormatListener(    // BOOL RemoveClipboardFormatListener(
            IntPtr hwnd                                             //   HWND hwnd    // ウィンドウハンドル
        );                                                          // );


        /// <summary>
        /// 【ウィンドウメッセージ：クリップボード更新】
        /// クリップボードの内容が更新されたときに呼び出されます。
        /// </summary>
        /// <remarks>
        /// ・lParam：常に 0 を指定します。<br></br>
        /// ・wParam：常に 0 を指定します。<br></br>
        /// ・戻り値：0 = 正常終了。<br></br>
        /// ・対応OS：Vista以降。<br></br>
        /// </remarks>
        public const int WM_CLIPBOARDUPDATE = 0x031D;   // WinUser.h：#define WM_CLIPBOARDUPDATE 0x031D
    }

}
