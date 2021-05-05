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
    public partial class ucScanConfigTag : UserControl
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

        public ucScanConfigTag(Panel _parent, frmMain _main)
        {
            InitializeComponent();
            parent = _parent;
            main = _main;
        }
        private void ucScanConfigTag_Load(object sender, EventArgs e)
        {
            this.Size = parent.Size;
        }
        private void txtItem_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtItem.Text != string.Empty)
                    {
                        if (txtItem.Text.Contains("ZECT_"))
                        {
                            switch (GlobalVars.currentState)
                            {
                                case GlobalVars.AppState.AddSlurry:
                                    showNextAddSlurry();
                                    break;
                                case GlobalVars.AppState.PrintTags:
                                    showNextPrintTags();
                                    break;
                                case GlobalVars.AppState.CloseJob:
                                    showNextcloseJob();
                                    break;
                                case GlobalVars.AppState.ReOpenJob:
                                    showNextReOpenJob();
                                    break;
                                default:
                                    break;
                            }
                            
                        }
                        else
                        {
                            msg = new frmMsg("Incorrect Barcode", "Please scan a valid job tag", GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            txtItem.Text = string.Empty;
                        }
                    }
                    else
                    {
                        msg = new frmMsg("No barcode", "Please scan a valid job tag", GlobalVars.msgState.Error);
                        msg.ShowDialog();
                        txtItem.Text = string.Empty;
                    }
                }            
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void showNextAddSlurry()
        {
            try
            {
                string jcSlurry = Client.ZectGetJobInfo(txtItem.Text);
                if (jcSlurry != string.Empty)
                {
                    switch (jcSlurry.Split('*')[0])
                    {
                        case "1":
                            jcSlurry = jcSlurry.Remove(0, 2);
                            GlobalVars.ASjobNo = txtItem.Text;
                            GlobalVars.ASitemCode = jcSlurry.Split('|')[0];
                            GlobalVars.ASlotNumber = jcSlurry.Split('|')[1];
                            GlobalVars.ASslurryCode = jcSlurry.Split('|')[2];
                            GlobalVars.AScoatNum = jcSlurry.Split('|')[3];

                            ucScanAdditionalSlurries addSlu = new ucScanAdditionalSlurries(parent, main);
                            main.pnlMain.Controls.Clear();
                            main.pnlMain.Controls.Add(addSlu);
                            break;
                        case "0":
                            jcSlurry = jcSlurry.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", jcSlurry, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            txtItem.Text = string.Empty;
                            break;
                        case "-1":
                            jcSlurry = jcSlurry.Remove(0, 3);
                            errMsg = jcSlurry.Split('|')[0];
                            errInfo = jcSlurry.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            txtItem.Text = string.Empty;
                            break;
                        case "-2":
                            jcSlurry = jcSlurry.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", jcSlurry, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            txtItem.Text = string.Empty;
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving job details";
                            errInfo = "Unexpected error while retreiving job details" + Environment.NewLine + "Data Returned:" + Environment.NewLine + jcSlurry;
                            txtItem.Text = string.Empty;
                            break;
                    }
                }
                else
                {
                    st = new StackTrace(0, true);
                    msgStr = "No data was returned from the server";
                    errInfo = "No data was returned from the server";
                    ExHandler.showErrorStr(errMsg, errInfo);
                    txtItem.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void showNextPrintTags()
        {
            try
            {
                string jcInfo = Client.GetPTJobInfo(txtItem.Text);
                if (jcInfo != string.Empty)
                {
                    switch (jcInfo.Split('*')[0])
                    {
                        case "1":
                            //[vCatalystCode], [vLotNumber], [vCoat], [dQty]
                            jcInfo = jcInfo.Remove(0, 2);
                            GlobalVars.PTjobNo = txtItem.Text;
                            GlobalVars.PTitemCode = jcInfo.Split('|')[0];
                            GlobalVars.PTlotNumber = jcInfo.Split('|')[1];
                            GlobalVars.PTcoatNumber = jcInfo.Split('|')[2];
                            GlobalVars.PTjobQty = jcInfo.Split('|')[3];
                            GlobalVars.PTmanufQty = jcInfo.Split('|')[4];

                            ucPrintType print = new ucPrintType(parent, main);
                            main.pnlMain.Controls.Clear();
                            main.pnlMain.Controls.Add(print);
                            break;
                        case "0":
                            jcInfo = jcInfo.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", jcInfo, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            txtItem.Text = string.Empty;
                            break;
                        case "-1":
                            jcInfo = jcInfo.Remove(0, 3);
                            errMsg = jcInfo.Split('|')[0];
                            errInfo = jcInfo.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            txtItem.Text = string.Empty;
                            break;
                        case "-2":
                            jcInfo = jcInfo.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", jcInfo, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            txtItem.Text = string.Empty;
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving job details";
                            errInfo = "Unexpected error while retreiving job details" + Environment.NewLine + "Data Returned:" + Environment.NewLine + jcInfo;
                            txtItem.Text = string.Empty;
                            break;
                    }

                }
                else
                {
                    st = new StackTrace(0, true);
                    msgStr = "No data was returned from the server";
                    errInfo = "No data was returned from the server";
                    ExHandler.showErrorStr(errMsg, errInfo);
                    txtItem.Text = string.Empty;
                }
               
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void showNextcloseJob()
        {
            try
            {
                string jobRunning = Client.GetJobRunning(txtItem.Text);
                if (jobRunning != string.Empty)
                {
                    switch (jobRunning.Split('*')[0])
                    {
                        case "1":
                            GlobalVars.CJjobNo = txtItem.Text;
                            ucScanSupervisorClose close = new ucScanSupervisorClose(parent, main);
                            main.pnlMain.Controls.Clear();
                            main.pnlMain.Controls.Add(close);
                            break;
                        case "0":
                            jobRunning = jobRunning.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", jobRunning, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            txtItem.Text = string.Empty;
                            break;
                        case "-1":
                            jobRunning = jobRunning.Remove(0, 3);
                            errMsg = jobRunning.Split('|')[0];
                            errInfo = jobRunning.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            txtItem.Text = string.Empty;
                            break;
                        case "-2":
                            jobRunning = jobRunning.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", jobRunning, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            txtItem.Text = string.Empty;
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while logging in";
                            errInfo = "Unexpected error while logging in" + Environment.NewLine + "Data Returned:" + Environment.NewLine + jobRunning;
                            ExHandler.showErrorST(st, msgStr, errInfo);
                            txtItem.Text = string.Empty;
                            break;
                    }
                    
                }
                else
                {
                    msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error);
                    msg.ShowDialog();
                    txtItem.Text = string.Empty;
                }
                
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
                txtItem.Text = string.Empty;
            }
        }
        public void showNextReOpenJob()
        {
            try
            {
                string jobRunning = Client.checkJobClosed(txtItem.Text + "|" + GlobalVars.zectWhse);
                if (jobRunning != string.Empty)
                {
                    switch (jobRunning.Split('*')[0])
                    {
                        case "1":
                            GlobalVars.ROjobNo = txtItem.Text;
                            ucReOpenInfo close = new ucReOpenInfo(parent, main);
                            main.pnlMain.Controls.Clear();
                            main.pnlMain.Controls.Add(close);
                            break;
                        case "0":
                            jobRunning = jobRunning.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", jobRunning, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            txtItem.Text = string.Empty;
                            break;
                        case "-1":
                            jobRunning = jobRunning.Remove(0, 3);
                            errMsg = jobRunning.Split('|')[0];
                            errInfo = jobRunning.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            txtItem.Text = string.Empty;
                            break;
                        case "-2":
                            jobRunning = jobRunning.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", jobRunning, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            txtItem.Text = string.Empty;
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while logging in";
                            errInfo = "Unexpected error while logging in" + Environment.NewLine + "Data Returned:" + Environment.NewLine + jobRunning;
                            ExHandler.showErrorST(st, msgStr, errInfo);
                            txtItem.Text = string.Empty;
                            break;
                    }

                }
                else
                {
                    msg = new frmMsg("A connection level error has occured", "No data was returned from the server", GlobalVars.msgState.Error);
                    msg.ShowDialog();
                    txtItem.Text = string.Empty;
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
                txtItem.Text = string.Empty;
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVars.lastControl = new ucMenu(parent, main);
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
