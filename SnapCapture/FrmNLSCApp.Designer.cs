// @(h)FrmNLSCApp.Designer.cs ver 0.00 ( '23.04.18 Nov-Lab ) 作成開始(自動生成)


namespace SnapCapture
{
    partial class FrmNLSCApp
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.TtlNextFileBody = new System.Windows.Forms.Label();
            this.LblNextFileName = new System.Windows.Forms.Label();
            this.BtnConfig = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TtlNextFileBody
            // 
            this.TtlNextFileBody.AutoSize = true;
            this.TtlNextFileBody.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.TtlNextFileBody.Location = new System.Drawing.Point(8, 8);
            this.TtlNextFileBody.Name = "TtlNextFileBody";
            this.TtlNextFileBody.Size = new System.Drawing.Size(101, 12);
            this.TtlNextFileBody.TabIndex = 0;
            this.TtlNextFileBody.Text = "次のファイル名：";
            // 
            // LblNextFileName
            // 
            this.LblNextFileName.AutoSize = true;
            this.LblNextFileName.Font = new System.Drawing.Font("ＭＳ ゴシック", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.LblNextFileName.Location = new System.Drawing.Point(120, 8);
            this.LblNextFileName.Name = "LblNextFileName";
            this.LblNextFileName.Size = new System.Drawing.Size(53, 12);
            this.LblNextFileName.TabIndex = 1;
            this.LblNextFileName.Text = "Snap0000";
            // 
            // BtnConfig
            // 
            this.BtnConfig.Location = new System.Drawing.Point(264, 32);
            this.BtnConfig.Name = "BtnConfig";
            this.BtnConfig.Size = new System.Drawing.Size(56, 24);
            this.BtnConfig.TabIndex = 2;
            this.BtnConfig.Text = "設定(&S)";
            this.BtnConfig.UseVisualStyleBackColor = true;
            this.BtnConfig.Click += new System.EventHandler(this.BtnConfig_Click);
            // 
            // FrmNLSCApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(331, 64);
            this.Controls.Add(this.BtnConfig);
            this.Controls.Add(this.LblNextFileName);
            this.Controls.Add(this.TtlNextFileBody);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmNLSCApp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SnapCapture";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmNLSCApp_FormClosing);
            this.Load += new System.EventHandler(this.FrmNLSCApp_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label TtlNextFileBody;
        private System.Windows.Forms.Label LblNextFileName;
        private System.Windows.Forms.Button BtnConfig;
    }
}

