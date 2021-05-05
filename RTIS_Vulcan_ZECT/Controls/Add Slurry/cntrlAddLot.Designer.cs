namespace RTIS_Vulcan_ZECT.Controls
{
    partial class cntrlAddLot
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
            this.lblLot = new DevExpress.XtraEditors.LabelControl();
            this.lblTankCode = new DevExpress.XtraEditors.LabelControl();
            this.lblTankType = new DevExpress.XtraEditors.LabelControl();
            this.pnlBack.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlBack
            // 
            this.pnlBack.BackColor = System.Drawing.Color.White;
            this.pnlBack.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlBack.Controls.Add(this.lblTankCode);
            this.pnlBack.Controls.Add(this.lblTankType);
            this.pnlBack.Controls.Add(this.lblLot);
            this.pnlBack.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBack.Location = new System.Drawing.Point(0, 0);
            this.pnlBack.Name = "pnlBack";
            this.pnlBack.Size = new System.Drawing.Size(1082, 150);
            this.pnlBack.TabIndex = 87;
            this.pnlBack.Click += new System.EventHandler(this.pnlBack_Click);
            // 
            // lblLot
            // 
            this.lblLot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLot.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblLot.Appearance.Font = new System.Drawing.Font("Calibri", 30F);
            this.lblLot.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblLot.Appearance.Options.UseBackColor = true;
            this.lblLot.Appearance.Options.UseFont = true;
            this.lblLot.Appearance.Options.UseForeColor = true;
            this.lblLot.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblLot.Location = new System.Drawing.Point(703, 5);
            this.lblLot.Margin = new System.Windows.Forms.Padding(4);
            this.lblLot.Name = "lblLot";
            this.lblLot.Size = new System.Drawing.Size(373, 140);
            this.lblLot.TabIndex = 84;
            this.lblLot.Text = "[Lot]";
            this.lblLot.Click += new System.EventHandler(this.lblLot_Click);
            // 
            // lblTankCode
            // 
            this.lblTankCode.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblTankCode.Appearance.Font = new System.Drawing.Font("Calibri", 30F);
            this.lblTankCode.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTankCode.Appearance.Options.UseBackColor = true;
            this.lblTankCode.Appearance.Options.UseFont = true;
            this.lblTankCode.Appearance.Options.UseForeColor = true;
            this.lblTankCode.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTankCode.Location = new System.Drawing.Point(421, 5);
            this.lblTankCode.Margin = new System.Windows.Forms.Padding(4);
            this.lblTankCode.Name = "lblTankCode";
            this.lblTankCode.Size = new System.Drawing.Size(241, 140);
            this.lblTankCode.TabIndex = 88;
            this.lblTankCode.Text = "[Tank Code]";
            this.lblTankCode.Click += new System.EventHandler(this.lblTankCode_Click);
            // 
            // lblTankType
            // 
            this.lblTankType.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.lblTankType.Appearance.Font = new System.Drawing.Font("Calibri", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTankType.Appearance.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.lblTankType.Appearance.Options.UseBackColor = true;
            this.lblTankType.Appearance.Options.UseFont = true;
            this.lblTankType.Appearance.Options.UseForeColor = true;
            this.lblTankType.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTankType.Location = new System.Drawing.Point(63, 5);
            this.lblTankType.Margin = new System.Windows.Forms.Padding(4);
            this.lblTankType.Name = "lblTankType";
            this.lblTankType.Size = new System.Drawing.Size(329, 140);
            this.lblTankType.TabIndex = 87;
            this.lblTankType.Text = "[Tank Type]";
            this.lblTankType.Click += new System.EventHandler(this.lblTankType_Click);
            // 
            // cntrlAddLot
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlBack);
            this.Name = "cntrlAddLot";
            this.Size = new System.Drawing.Size(1082, 150);
            this.Load += new System.EventHandler(this.cntrlAddLot_Load);
            this.pnlBack.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlBack;
        public DevExpress.XtraEditors.LabelControl lblLot;
        public DevExpress.XtraEditors.LabelControl lblTankCode;
        public DevExpress.XtraEditors.LabelControl lblTankType;
    }
}
