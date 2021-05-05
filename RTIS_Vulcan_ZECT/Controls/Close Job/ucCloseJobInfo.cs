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
    public partial class ucCloseJobInfo : UserControl
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
        public ucCloseJobInfo(Panel _parent, frmMain _main)
        {
            InitializeComponent();
            parent = _parent;
            main = _main;
        }

        private void ucCloseJobInfo_Load(object sender, EventArgs e)
        {
            this.Size = parent.Size;
            getClosingJobInfo();
        }

        public void getClosingJobInfo()
        {
            try
            {
                string jobInfo = Client.GetClosingJobInfo(GlobalVars.CJjobNo);
                if (jobInfo != string.Empty)
                {
                    switch (jobInfo.Split('*')[0])
                    {
                        case "1":
                            jobInfo = jobInfo.Remove(0, 2);
                            lblItem.Text = jobInfo.Split('|')[0];
                            lblLot.Text = jobInfo.Split('|')[1];
                            lblCoat.Text = jobInfo.Split('|')[2];
                            lblJobQty.Text = jobInfo.Split('|')[3];
                            lblManufQty.Text = jobInfo.Split('|')[4];
                            break;
                        case "0":
                            jobInfo = jobInfo.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", jobInfo, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            jobInfo = jobInfo.Remove(0, 3);
                            errMsg = jobInfo.Split('|')[0];
                            errInfo = jobInfo.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            jobInfo = jobInfo.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", jobInfo, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while logging in";
                            errInfo = "Unexpected error while logging in" + Environment.NewLine + "Data Returned:" + Environment.NewLine + jobInfo;
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

        private void btnNo_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVars.lastControl = new ucScanSupervisorClose(parent, main);
                main.pnlMain.Controls.Clear();
                main.pnlMain.Controls.Add(GlobalVars.lastControl);
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                frmConfirm conf = new frmConfirm("Are you sure you wish to close this job?");
                conf.ShowDialog();
                DialogResult res = conf.DialogResult;
                if (res == DialogResult.Yes)
                {
                    string closed = Client.CloseJob(GlobalVars.CJjobNo + "|" + GlobalVars.userName);
                    if (closed != string.Empty)
                    {
                        switch (closed.Split('*')[0])
                        {
                            case "1":
                                msg = new frmMsg("Success", "The job has been closed successfully", GlobalVars.msgState.Success);
                                msg.ShowDialog();
                                ucMenu menu = new ucMenu(parent, main);
                                main.pnlMain.Controls.Clear();
                                main.pnlMain.Controls.Add(menu);
                                break;
                            case "0":
                                closed = closed.Remove(0, 2);
                                msg = new frmMsg("The following server side issue was encountered:", closed, GlobalVars.msgState.Error);
                                msg.ShowDialog();                               
                                break;
                            case "-1":
                                closed = closed.Remove(0, 3);
                                errMsg = closed.Split('|')[0];
                                errInfo = closed.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                closed = closed.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", closed, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while logging in";
                                errInfo = "Unexpected error while logging in" + Environment.NewLine + "Data Returned:" + Environment.NewLine + closed;
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
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
    }
}
