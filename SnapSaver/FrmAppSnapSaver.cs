// 23/04/18

using System;
using System.Diagnostics;

using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SnapSaver
{
    public partial class FrmAppSnapSaver : Form
    {
        public FrmAppSnapSaver()
        {
            InitializeComponent();
        }

        private void FrmAppSnapSaver_Load(object sender, EventArgs e)
        {
            
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == AppBase.WM_ACTIVATE)
            {
                Debug.Print("WM_ACTIVATE");
            }

            base.WndProc(ref m);
        }

        private void FrmAppSnapSaver_FormClosing(object sender, FormClosingEventArgs e)
        {
            Debug.Print("FormClosing");
        }
    }
}
