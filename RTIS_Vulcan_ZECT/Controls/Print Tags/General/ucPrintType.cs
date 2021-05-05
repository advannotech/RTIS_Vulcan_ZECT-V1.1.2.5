using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTIS_Vulcan_ZECT.Forms;
using System.Diagnostics;
using RTIS_Vulcan_ZECT.Classes;

namespace RTIS_Vulcan_ZECT.Controls
{
    public partial class ucPrintType : UserControl
    {
        #region Error handling
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        StackTrace st;
        string msgStr = string.Empty;
        string infoStr = string.Empty;
        #endregion

        public frmMain main;
        Panel parent;

        public ucPrintType(Panel _parent, frmMain _main)
        {
            InitializeComponent();
            parent = _parent;
            main = _main;
        }
        private void ucPrintType_Load(object sender, EventArgs e)
        {
            this.Size = parent.Size;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                ucPTJobInfo print = new ucPTJobInfo(parent, main);
                main.pnlMain.Controls.Clear();
                main.pnlMain.Controls.Add(print);
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnReprint_Click(object sender, EventArgs e)
        {
            try
            {
                ucPalletList reprint = new ucPalletList(parent, main);
                main.pnlMain.Controls.Clear();
                main.pnlMain.Controls.Add(reprint);
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVars.lastControl = new ucScanConfigTag(parent, main);
                main.pnlMain.Controls.Clear();
                main.pnlMain.Controls.Add(GlobalVars.lastControl);
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
    }
}
