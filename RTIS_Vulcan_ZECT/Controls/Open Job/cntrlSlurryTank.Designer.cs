namespace RTIS_Vulcan_ZECT.Controls.Open_Job
{
    partial class cntrlSlurryTank
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlBack = new System.Windows.Forms.Panel();
            this.lblTank = new DevExpress.XtraEditors.LabelControl();
            this.lblWeight = new DevExpress.XtraEditors.LabelControl();
            this.pnlBack.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBack
            // 
            this.pnlBack.BackColor = System.Drawing.Color.White;
            this.pnlBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBack.Controls.Add(this.lblWeight);
            this.pnlBack.Controls.Add(this.lblTank);
            this.pnlBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBack.Location = new System.Drawing.Point(0, 0);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(1082, 150);
            this.pnlBack.TabIndex = 87;
            this.pnlBack.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlBack_Paint);
            // 
            // lblTank
            // 
            this.lblTank.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblTank.Appearance.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTank.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTank.Appearance.Options.UseBackColor = true;
            this.lblTank.Appearance.Options.UseFont = true;
            this.lblTank.Appearance.Options.UseForeColor = true;
            this.lblTank.Appearance.Options.UseTextOptions = true;
            this.lblTank.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTank.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTank.Location = new System.Drawing.Point(17, 23);
            this.lblTank.Margin = new System.Windows.Forms.Padding(4);
            this.lblTank.Name = "lblTank";
            this.lblTank.Size = new System.Drawing.Size(481, 100);
            this.lblTank.TabIndex = 84;
            this.lblTank.Text = "[Tank]";
            this.lblTank.Click += new System.EventHandler(this.lblTank_Click);
            // 
            // lblWeight
            // 
            this.lblWeight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblWeight.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblWeight.Appearance.Font = new System.Drawing.Font("Calibri", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWeight.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblWeight.Appearance.Options.UseBackColor = true;
            this.lblWeight.Appearance.Options.UseFont = true;
            this.lblWeight.Appearance.Options.UseForeColor = true;
            this.lblWeight.Appearance.Options.UseTextOptions = true;
            this.lblWeight.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblWeight.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblWeight.Location = new System.Drawing.Point(586, 23);
            this.lblWeight.Margin = new System.Windows.Forms.Padding(4);
            this.lblWeight.Name = "lblWeight";
            this.lblWeight.Size = new System.Drawing.Size(481, 100);
            this.lblWeight.TabIndex = 85;
            this.lblWeight.Text = "[Weight]";
            this.lblWeight.Click += new System.EventHandler(this.lblWeight_Click);
            // 
            // cntrlSlurryTank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBack);
            this.Name = "cntrlSlurryTank";
            this.Size = new System.Drawing.Size(1082, 150);
            this.Load += new System.EventHandler(this.cntrlSlurryTank_Load);
            this.pnlBack.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlBack;
        public DevExpress.XtraEditors.LabelControl lblWeight;
        public DevExpress.XtraEditors.LabelControl lblTank;
    }
}
