// 下書き用

using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Runtime.InteropServices;
using System.Drawing.Imaging;

namespace SnapCapture
{

#if DEBUG
    //[-]：Visual C# 2019 + Windows10 だと、ウィンドウが非アクティブの場合に、期待通りの動作をしてくれないので保留中
    public class ZZZFlashWindowTest
    {
        // Windows10で確認
        // ・期待する動作
        //   ウィンドウのアクティブ状態に関わらず、一度だけ点滅して元に戻る
        //
        // ・FlashWindow(VB6で作ったアプリだと、Windows10でも期待通りの動作をしてくれる)
        //   ウィンドウが非アクティブの場合、点滅を停止するように指示をしても、ゆっくり３度点滅してから反転状態になってウィンドウのアクティブ化を促す
        //
        // ・FlashWindowEx
        //   ウィンドウが非アクティブの場合、点滅回数終了後も、ゆっくり３度点滅してから反転状態になってウィンドウのアクティブ化を促す


        /// <summary>
        /// 【FlashWindowのテスト】
        /// </summary>
        /// <param name="handle"></param>
        public static void DoTest(IntPtr handle)
        {
            // VB6版でのやり方
            M_FlashWindow(handle, 1);
            M_FlashWindow(handle, 1);
            System.Threading.Thread.Sleep(10);
            M_FlashWindow(handle, 0);
        }


        /// <summary>
        /// 【FlashWindowExのテスト】
        /// </summary>
        /// <param name="handle"></param>
        public static void DoTestEx(IntPtr handle)
        {
            FLASHWINFO flashWInfo;

            // 点滅中の場合は停止する
            flashWInfo.cbSize = (uint)Marshal.SizeOf(typeof(FLASHWINFO));
            flashWInfo.hwnd = handle;
            flashWInfo.dwFlags = 0;
            flashWInfo.nCount = 0;
            flashWInfo.dwTimeout = 0;
            M_FlashWindowEx(ref flashWInfo);

            // １回点滅させる
            flashWInfo.cbSize = (uint)Marshal.SizeOf(typeof(FLASHWINFO));
            flashWInfo.hwnd = handle;
            flashWInfo.dwFlags = 3;
            flashWInfo.nCount = 1;
            flashWInfo.dwTimeout = 0;
            M_FlashWindowEx(ref flashWInfo);
        }


        // BOOL FlashWindow(
        //     __in  HWND hWnd,
        //     __in  BOOL bInvert);
        [DllImport("user32", EntryPoint = "FlashWindow", SetLastError = true, CharSet = CharSet.Auto)]
        protected static extern bool M_FlashWindow(
            IntPtr hWnd,
            int bInvert
        );



        /// <summary>
        /// 【ウィンドウ点滅情報】
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct FLASHWINFO
        {
            /// <summary>
            /// 【構造体のサイズ】(uint)Marshal.SizeOf(typeof(FLASHWINFO)) を設定します。
            /// </summary>
            public uint cbSize;

            /// <summary>
            /// 【ウィンドウハンドル】
            /// </summary>
            public IntPtr hwnd;

            /// <summary>
            /// 【ウィンドウ点滅指定フラグ】
            /// </summary>
            public uint dwFlags;

            /// <summary>
            /// 【ウィンドウの点滅回数】
            /// </summary>
            public uint nCount;

            /// <summary>
            /// 【ウィンドウの点滅間隔(ミリ秒)】0 の場合は既定のカーソル点滅速度
            /// </summary>
            public uint dwTimeout;
        }
        // typedef struct {
        //     UINT  cbSize;
        //     HWND  hwnd;
        //     DWORD dwFlags;
        //     UINT  uCount;
        //     DWORD dwTimeout;
        // } FLASHWINFO, *PFLASHWINFO;


        // #define FLASHW_STOP         0
        // #define FLASHW_CAPTION      0x00000001
        // #define FLASHW_TRAY         0x00000002
        // #define FLASHW_ALL          (FLASHW_CAPTION | FLASHW_TRAY)
        // #define FLASHW_TIMER        0x00000004
        // #define FLASHW_TIMERNOFG    0x0000000C


        // BOOL FlashWindowEx(
        //     __in PFLASHWINFO pfwi);
        [DllImport("user32", EntryPoint = "FlashWindowEx", SetLastError = true, CharSet = CharSet.Auto)]
        protected static extern bool M_FlashWindowEx(
            ref FLASHWINFO pfwi
        );
    }

#endif


}
