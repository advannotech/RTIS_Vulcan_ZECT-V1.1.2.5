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
using RTIS_Vulcan_ZECT.Classes;
using System.Diagnostics;

namespace RTIS_Vulcan_ZECT.Controls
{
    public partial class ucMenu : UserControl
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

        public ucMenu(Panel _parent, frmMain _main)
        {
            InitializeComponent();
            parent = _parent;
            main = _main;
        }

        private void ucMenu_Load(object sender, EventArgs e)
        {
            this.Size = parent.Size;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            try
            {
                ucIteminfo itemInfo = new ucIteminfo(parent, main);
                main.pnlMain.Controls.Clear();
                main.pnlMain.Controls.Add(itemInfo);
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnAddSlurry_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVars.currentState = GlobalVars.AppState.AddSlurry;
                ucScanConfigTag itemInfo = new ucScanConfigTag(parent, main);
                main.pnlMain.Controls.Clear();
                main.pnlMain.Controls.Add(itemInfo);
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        private void btnLogoff_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVars.userName = string.Empty;
                ucLogin login = new ucLogin(parent, main);
                GlobalVars.lastControl = login;
                main.pnlMain.Controls.Clear();
                main.pnlMain.Controls.Add(login);
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVars.currentState = GlobalVars.AppState.PrintTags;
                ucScanConfigTag itemInfo = new ucScanConfigTag(parent, main);
                main.pnlMain.Controls.Clear();
                main.pnlMain.Controls.Add(itemInfo);
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVars.currentState = GlobalVars.AppState.CloseJob;
                ucScanConfigTag itemInfo = new ucScanConfigTag(parent, main);
                main.pnlMain.Controls.Clear();
                main.pnlMain.Controls.Add(itemInfo);
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnReopen_Click(object sender, EventArgs e)
        {
            try
            {
                string jobRunning = Client.checkJobOnLine(GlobalVars.zectWhse);
                if (jobRunning != string.Empty)
                {
                    switch (jobRunning.Split('*')[0])
                    {
                        case "1":
                            GlobalVars.currentState = GlobalVars.AppState.ReOpenJob;
                            ucReOpenSupervisor itemInfo = new ucReOpenSupervisor(parent, main);
                            main.pnlMain.Controls.Clear();
                            main.pnlMain.Controls.Add(itemInfo);
                            break;
                        case "0":
                            jobRunning = jobRunning.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", jobRunning, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            jobRunning = jobRunning.Remove(0, 3);
                            errMsg = jobRunning.Split('|')[0];
                            errInfo = jobRunning.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            jobRunning = jobRunning.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", jobRunning, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while reopening job";
                            errInfo = "Unexpected error while reopening job" + Environment.NewLine + "Data Returned:" + Environment.NewLine + jobRunning;
                            ExHandler.showErrorST(st, msgStr, errInfo);
                            break;
                    }
                    
                }
                else
                {
                    msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }

                
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnReprintConfigTags_Click(object sender, EventArgs e)
        {
            try
            {
                ucRPScanSheet scan = new ucRPScanSheet(parent, main);
                main.pnlMain.Controls.Clear();
                main.pnlMain.Controls.Add(scan);
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
    }
}
