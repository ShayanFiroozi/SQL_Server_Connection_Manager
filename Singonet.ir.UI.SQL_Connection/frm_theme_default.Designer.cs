namespace Singonet.ir.UI.SQL_Connection
{
    partial class frm_theme_default
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
            this.sqL_Conn1 = new Singonet.ir.UI.SQL_Connection.SQL_Conn();
            this.SuspendLayout();
            // 
            // sqL_Conn1
            // 
            this.sqL_Conn1.BackColor = System.Drawing.Color.Transparent;
            this.sqL_Conn1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sqL_Conn1.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.sqL_Conn1.Location = new System.Drawing.Point(0, 0);
            this.sqL_Conn1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.sqL_Conn1.Name = "sqL_Conn1";
            this.sqL_Conn1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.sqL_Conn1.Size = new System.Drawing.Size(582, 474);
            this.sqL_Conn1.TabIndex = 0;
            this.sqL_Conn1.Connection_Established += new System.EventHandler(this.sqL_Conn1_Connection_Established);
            this.sqL_Conn1.Load += new System.EventHandler(this.sqL_Conn1_Load);
            // 
            // frm_theme_default
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(582, 474);
            this.Controls.Add(this.sqL_Conn1);
            this.Font = new System.Drawing.Font("B Yekan", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_theme_default";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "اتصال به بانک SQL Server";
            this.ResumeLayout(false);

        }

        #endregion

        private SQL_Conn sqL_Conn1;
    }
}