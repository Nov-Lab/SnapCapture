
namespace SnapCapture
{
    partial class DlgNLSCConfig
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TtlSaveImageFormat = new System.Windows.Forms.Label();
            this.CboSaveImageFormat = new System.Windows.Forms.ComboBox();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.TtlBaseFileName = new System.Windows.Forms.Label();
            this.TxtBaseFileName = new System.Windows.Forms.TextBox();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // TtlSaveImageFormat
            // 
            this.TtlSaveImageFormat.AutoSize = true;
            this.TtlSaveImageFormat.Location = new System.Drawing.Point(8, 40);
            this.TtlSaveImageFormat.Name = "TtlSaveImageFormat";
            this.TtlSaveImageFormat.Size = new System.Drawing.Size(74, 12);
            this.TtlSaveImageFormat.TabIndex = 2;
            this.TtlSaveImageFormat.Text = "保存形式(&F)：";
            // 
            // CboSaveImageFormat
            // 
            this.CboSaveImageFormat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CboSaveImageFormat.FormattingEnabled = true;
            this.CboSaveImageFormat.Location = new System.Drawing.Point(120, 40);
            this.CboSaveImageFormat.Name = "CboSaveImageFormat";
            this.CboSaveImageFormat.Size = new System.Drawing.Size(152, 20);
            this.CboSaveImageFormat.TabIndex = 3;
            // 
            // BtnOK
            // 
            this.BtnOK.Location = new System.Drawing.Point(200, 72);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(88, 24);
            this.BtnOK.TabIndex = 4;
            this.BtnOK.Text = "OK";
            this.BtnOK.UseVisualStyleBackColor = true;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.Location = new System.Drawing.Point(296, 72);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(88, 24);
            this.BtnCancel.TabIndex = 5;
            this.BtnCancel.Text = "キャンセル";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // TtlBaseFileName
            // 
            this.TtlBaseFileName.AutoSize = true;
            this.TtlBaseFileName.Location = new System.Drawing.Point(8, 8);
            this.TtlBaseFileName.Name = "TtlBaseFileName";
            this.TtlBaseFileName.Size = new System.Drawing.Size(102, 12);
            this.TtlBaseFileName.TabIndex = 0;
            this.TtlBaseFileName.Text = "ベースファイル名(&B)：";
            // 
            // TxtBaseFileName
            // 
            this.TxtBaseFileName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TxtBaseFileName.Location = new System.Drawing.Point(120, 8);
            this.TxtBaseFileName.Name = "TxtBaseFileName";
            this.TxtBaseFileName.Size = new System.Drawing.Size(264, 19);
            this.TxtBaseFileName.TabIndex = 1;
            this.TxtBaseFileName.Validating += new System.ComponentModel.CancelEventHandler(this.TxtBaseFileName_Validating);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // DlgNLSCConfig
            // 
            this.AcceptButton = this.BtnOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(394, 105);
            this.Controls.Add(this.TxtBaseFileName);
            this.Controls.Add(this.TtlBaseFileName);
            this.Controls.Add(this.BtnCancel);
            this.Controls.Add(this.BtnOK);
            this.Controls.Add(this.CboSaveImageFormat);
            this.Controls.Add(this.TtlSaveImageFormat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlgNLSCConfig";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "動作設定";
            this.Load += new System.EventHandler(this.FrmConfig_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TtlSaveImageFormat;
        private System.Windows.Forms.ComboBox CboSaveImageFormat;
        private System.Windows.Forms.Button BtnOK;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Label TtlBaseFileName;
        private System.Windows.Forms.TextBox TxtBaseFileName;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}