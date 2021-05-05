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
    public partial class ucScanSupervisorClose : UserControl
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

        public ucScanSupervisorClose(Panel _parent, frmMain _main)
        {
            InitializeComponent();
            parent = _parent;
            main = _main;
        }

        private void ucScanSupervisorClose_Load(object sender, EventArgs e)
        {
            this.Size = parent.Size;

            cntrlNumPad num = new cntrlNumPad();
            num.Dock = DockStyle.Right;
            pnlKeyPad.Controls.Add(num);

            txtPassword.Focus();
            GlobalVars.focusedEdit = txtPassword;
        }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string userPerms = Client.GetUserPermissions(txtPassword.Text);
                if (userPerms != string.Empty)
                {
                    switch (userPerms.Split('*')[0])
                    {
                        case "1":
                            userPerms = userPerms.Remove(0, 2);

                            bool found = false;
                            string[] allPerms = userPerms.Split('|');
                            foreach (string permission in allPerms)
                            {
                                if (permission.Contains("ZECT Supervisor"))
                                {
                                    found = true;
                                }
                            }

                            if (found == true)
                            {
                                ucCloseJobInfo menu = new ucCloseJobInfo(parent, main);
                                main.pnlMain.Controls.Clear();
                                main.pnlMain.Controls.Add(menu);
                            }
                            else
                            {
                                msg = new frmMsg("Incorrect user type", "Please enter the pin of a ZECT supervisor", GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                txtPassword.Text = string.Empty;
                            }
                            break;
                        case "0":
                            userPerms = userPerms.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", userPerms, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            txtPassword.Text = string.Empty;
                            break;
                        case "-1":
                            userPerms = userPerms.Remove(0, 3);
                            errMsg = userPerms.Split('|')[0];
                            errInfo = userPerms.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            txtPassword.Text = string.Empty;
                            break;
                        case "-2":
                            userPerms = userPerms.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", userPerms, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            txtPassword.Text = string.Empty;
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while logging in";
                            errInfo = "Unexpected error while logging in" + Environment.NewLine + "Data Returned:" + Environment.NewLine + userPerms;
                            ExHandler.showErrorST(st, msgStr, errInfo);
                            txtPassword.Text = string.Empty;
                            break;
                    }
                }
                else
                {
                    msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error);
                    msg.ShowDialog();
                    txtPassword.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
                txtPassword.Text = string.Empty;
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
