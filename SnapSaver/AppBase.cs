// 23/04/18

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SnapSaver
{
    class AppBase
    {
        public const int WM_ACTIVATE = 0x0006;


        // #define WM_ACTIVATE                     0x0006
        // #define WM_DRAWCLIPBOARD                0x0308
        // #define WM_CHANGECBCHAIN                0x030D

        // WINUSERAPI
        // HWND
        // WINAPI
        // SetClipboardViewer(
        //     __in HWND hWndNewViewer);

        // WINUSERAPI
        // BOOL
        // WINAPI
        // ChangeClipboardChain(
        //     __in HWND hWndRemove,
        //     __in HWND hWndNewNext);

    }
}
