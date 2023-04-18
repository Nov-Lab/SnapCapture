using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

using NovLab.Windows.ApplicationHelper;

namespace SnapCapture
{
    static class NLSCProgram
    {
        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            using(var blocker = new MultiInstanceBlocker())
            {                                                           //// using：二重起動ブロッカーを生成する
                if (blocker.isSingleInstance)
                {                                                       /////  単一インスタンスの場合、アプリケーション本体を実行する
                    //------------------------------------------------------------
                    // 自動生成された部分
                    //------------------------------------------------------------
                    Application.EnableVisualStyles();
                    Application.SetCompatibleTextRenderingDefault(false);
                    Application.Run(new FrmNLSCApp());
                }

                blocker.Close();                                        /////  二重起動ブロッカーを閉じる
            }
        }
    }
}
