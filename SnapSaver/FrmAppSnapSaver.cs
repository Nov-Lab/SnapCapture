// 23/04/18

using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using NovLab.DebugStation;

namespace SnapSaver
{
    public partial class FrmAppSnapSaver : Form
    {
        //====================================================================================================
        // Win32API関連定義
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
        //--------------------------------------------------------------------------------
        [DllImport("user32", EntryPoint = "AddClipboardFormatListener", SetLastError = true, CharSet = CharSet.Auto)]
        protected static extern bool M_AddClipboardFormatListener(      // BOOL AddClipboardFormatListener(
            IntPtr hwnd                                                 //   HWND hwnd    // ウィンドウハンドル
        );                                                              // );


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
        //--------------------------------------------------------------------------------
        [DllImport("user32", EntryPoint = "RemoveClipboardFormatListener", SetLastError = true, CharSet = CharSet.Auto)]
        protected static extern bool M_RemoveClipboardFormatListener(   // BOOL RemoveClipboardFormatListener(
            IntPtr hwnd                                                 //   HWND hwnd    // ウィンドウハンドル
        );                                                              // );


        /// <summary>
        /// 【ウィンドウメッセージ：クリップボード更新】
        /// クリップボードの内容が更新されたときに呼び出されます。
        /// </summary>
        /// <remarks>
        /// lParam：常に０です。
        /// wParam：常に０です。
        /// </remarks>
        protected const int WM_CLIPBOARDUPDATE = 0x031D;    // WinUser.h：#define WM_CLIPBOARDUPDATE 0x031D


        //====================================================================================================
        // 内部フィールド
        //====================================================================================================
        /// <summary>
        /// 【クリップボードリスナー登録済みフラグ】
        /// </summary>
        protected bool m_clipboardListenerRegistered;


        //====================================================================================================
        // フォームイベント
        //====================================================================================================

        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【メインフォーム_コンストラクター】新しいインスタンスを初期化します。
        /// </summary>
        //--------------------------------------------------------------------------------
        public FrmAppSnapSaver()
        {
            //------------------------------------------------------------
            // 自動生成された部分
            //------------------------------------------------------------
            InitializeComponent();
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【メインフォーム_Load】本フォームを初期化します。
        /// </summary>
        //--------------------------------------------------------------------------------
        private void FrmAppSnapSaver_Load(object sender, EventArgs e)
        {
            //------------------------------------------------------------
            /// アプリケーションを初期化する
            //------------------------------------------------------------
            Application.ApplicationExit +=                              //// アプリケーション_ApplicationExit ハンドラを設定する
                new EventHandler(this.OnApplicationExit);

#if DEBUG   // DEBUGビルドのみ有効
            DebugStationTraceListener.RegisterListener();
            NLDebug.SendProcessStart();
#endif

            //------------------------------------------------------------
            /// クリップボードリスナーに追加する
            //------------------------------------------------------------
            M_AddClipboardFormatListener(Handle);                       //// クリップボードリスナーにウィンドウを登録する
            m_clipboardListenerRegistered = true;                       //// クリップボードリスナー登録済みフラグ = true にセットする
            Trace.WriteLine("AddClipboardFormatListener");
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【メインフォーム_FormClosing】本フォームの終了処理を行います。
        /// </summary>
        //--------------------------------------------------------------------------------
        private void FrmAppSnapSaver_FormClosing(object sender, FormClosingEventArgs e)
        {
            //------------------------------------------------------------
            /// クリップボードリスナーから削除する
            //------------------------------------------------------------
            if (m_clipboardListenerRegistered == true)
            {                                                           //// クリップボードリスナーに登録済みの場合
                M_RemoveClipboardFormatListener(Handle);                /////  クリップボードリスナーからウィンドウを削除する
                m_clipboardListenerRegistered = false;                  /////  クリップボードリスナー登録済みフラグ = false にリセットする
                Trace.WriteLine("RemoveClipboardFormatListener");
            }
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【アプリケーション_ApplicationExit】
        /// アプリケーションが終了するときに呼び出されます。<br></br>
        /// ・アプリケーションの終了処理を行います。<br></br>
        /// </summary>
        //--------------------------------------------------------------------------------
        private void OnApplicationExit(object sender, EventArgs e)
        {
            //------------------------------------------------------------
            /// アプリケーションの終了処理を行う
            //------------------------------------------------------------
            try
            {                                                           //// try開始
#if DEBUG   // DEBUGビルドのみ有効
                NLDebug.SendProcessExit();
#endif
            }
            catch { }                                                   //// catch：すべての例外を無視する
        }


        //--------------------------------------------------------------------------------
        /// <summary>
        /// 【ウィンドウプロシージャ】
        /// ウィンドウメッセージを処理します。
        /// </summary>
        /// <param name="m">[In ]：ウィンドウメッセージ</param>
        //--------------------------------------------------------------------------------
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_CLIPBOARDUPDATE)
            {
                Debug.Print("WM_CLIPBOARDUPDATE");
                System.Media.SystemSounds.Beep.Play();
                m.Result = (IntPtr)0;
                return;
            }

            base.WndProc(ref m);
        }
    }

}
