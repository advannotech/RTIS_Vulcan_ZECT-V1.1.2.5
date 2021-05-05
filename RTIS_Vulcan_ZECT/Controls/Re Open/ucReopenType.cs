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
using RTIS_Vulcan_ZECT.Controls.Re_Open;

namespace RTIS_Vulcan_ZECT.Controls
{
    public partial class ucReopenType : UserControl
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
        public ucReopenType(Panel _parent, frmMain _main)
        {
            InitializeComponent();
            parent = _parent;
            main = _main;
        }

        private void ucReopenType_Load(object sender, EventArgs e)
        {
            this.Size = parent.Size;
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVars.currentReopenType = GlobalVars.reOpenTye.Scan;
                ucScanConfigTag itemInfo = new ucScanConfigTag(parent, main);
                main.pnlMain.Controls.Clear();
                main.pnlMain.Controls.Add(itemInfo);
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnManual_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVars.currentReopenType = GlobalVars.reOpenTye.Manual;
                ucReOpenScanSheet reOpen = new ucReOpenScanSheet(parent, main);
                main.pnlMain.Controls.Clear();
                main.pnlMain.Controls.Add(reOpen);
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
                GlobalVars.lastControl = new ucReOpenSupervisor(parent, main);
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
