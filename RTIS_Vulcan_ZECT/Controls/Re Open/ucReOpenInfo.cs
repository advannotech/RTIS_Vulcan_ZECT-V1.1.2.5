using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using RTIS_Vulcan_ZECT.Forms;
using RTIS_Vulcan_ZECT.Classes;
using DevExpress.XtraReports.UI;

namespace RTIS_Vulcan_ZECT.Controls
{
    public partial class ucReOpenInfo : UserControl
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

        public ucReOpenInfo(Panel _parent, frmMain _main)
        {
            InitializeComponent();
            parent = _parent;
            main = _main;
        }

        private void ucReOpenInfo_Load(object sender, EventArgs e)
        {
            this.Size = parent.Size;
            getReOpenInfo();
        }

        public void getReOpenInfo()
        {
            try
            {
                string jobInfo = Client.GetReOpenJobInfo(GlobalVars.ROjobNo);
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
                            msgStr = "Unexpected error while retreving job information";
                            errInfo = "Unexpected error while retreving job information" + Environment.NewLine + "Data Returned:" + Environment.NewLine + jobInfo;
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
        private void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                frmConfirm conf = new frmConfirm("Are you sure you wish to reopen this job?");
                conf.ShowDialog();
                DialogResult res = conf.DialogResult;
                if (res == DialogResult.Yes)
                {
                    string opened = Client.ReOpenJob(GlobalVars.ROjobNo + "|" + GlobalVars.userName);
                    if (opened != string.Empty)
                    {
                        switch (opened.Split('*')[0])
                        {
                            case "1":
                                switch (GlobalVars.currentReopenType)
                                {
                                    case GlobalVars.reOpenTye.Scan:
                                        msg = new frmMsg("Success", "The job has been reopened successfully", GlobalVars.msgState.Success);
                                        msg.ShowDialog();
                                        ucMenu menu = new ucMenu(parent, main);
                                        main.pnlMain.Controls.Clear();
                                        main.pnlMain.Controls.Add(menu);
                                        break;
                                    case GlobalVars.reOpenTye.Manual:
                                        string coatNum = string.Empty;
                                        switch (GlobalVars.ROCoatNumber)
                                        {
                                            case GlobalVars.CoatNumber.first:
                                                coatNum = "1st";
                                                break;
                                            case GlobalVars.CoatNumber.second:
                                                coatNum = "2nd";
                                                break;
                                            case GlobalVars.CoatNumber.third:
                                                coatNum = "3rd";
                                                break;
                                            case GlobalVars.CoatNumber.forth:
                                                coatNum = "4th";
                                                break;
                                            default:
                                                break;
                                        }
                                        string labelInfo = Client.GetReOpenJobLabelInfo(GlobalVars.ROitem + "|" + coatNum);
                                        if (labelInfo != string.Empty)
                                        {
                                            switch (labelInfo.Split('*')[0])
                                            {
                                                case "1":
                                                    labelInfo = labelInfo.Remove(0, 2);
                                                    string itemCode = labelInfo.Split('|')[0];
                                                    string barcode = labelInfo.Split('|')[1];
                                                    string simpleCode = labelInfo.Split('|')[2];
                                                    string binLocation = labelInfo.Split('|')[3];
                                                    string description1 = labelInfo.Split('|')[4];
                                                    string description2 = labelInfo.Split('|')[5];
                                                    string description3 = labelInfo.Split('|')[6];
                                                    string group = labelInfo.Split('|')[7];

                                                    //TODO
                                                    //XtraReport printLabel = GlobalVars.configTag;
                                                    //printLabel.Parameters["_Lot"].Value = GlobalVars.ROLotNumber;
                                                    //printLabel.Parameters["_Qty"].Value = lblJobQty.Text;
                                                    //printLabel.Parameters["_Coat"].Value = GlobalVars.ROcoat;
                                                    //printLabel.Parameters["_Slurry"].Value = "Reprint";
                                                    //printLabel.Parameters["_SlurryLot"].Value = "Reprint";
                                                    //printLabel.Parameters["_RT2D"].Value = GlobalVars.ROjobNo;
                                                    //printLabel.Parameters["_ItemCode"].Value = itemCode;
                                                    //printLabel.Parameters["_barcode"].Value = barcode;
                                                    //printLabel.Parameters["_bin"].Value = binLocation;
                                                    //printLabel.Parameters["_Date"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                                                    //printLabel.Parameters["_Description1"].Value = description1;
                                                    //printLabel.Parameters["_Description2"].Value = description2;
                                                    //printLabel.Parameters["_Description3"].Value = description3;
                                                    //printLabel.Parameters["_Group"].Value = group;
                                                    //printLabel.Parameters["_SimpleCode"].Value = simpleCode;
                                                    //printLabel.CreateDocument();
                                                    
                                                    //ReportPrintTool prtTool = new ReportPrintTool(printLabel);
                                                    //prtTool.PrinterSettings.Copies = Convert.ToInt16(2);
                                                    //prtTool.Print(GlobalVars.Printer);

                                                    msg = new frmMsg("Success", "The job has been opened", GlobalVars.msgState.Success);
                                                    msg.ShowDialog();
                                                    ucMenu menu2 = new ucMenu(parent, main);
                                                    main.pnlMain.Controls.Clear();
                                                    main.pnlMain.Controls.Add(menu2);
                                                    break;
                                                case "0":
                                                    labelInfo = labelInfo.Remove(0, 2);
                                                    msg = new frmMsg("The following server side issue was encountered:", labelInfo, GlobalVars.msgState.Error);
                                                    msg.ShowDialog();
                                                    break;
                                                case "-1":
                                                    labelInfo = labelInfo.Remove(0, 3);
                                                    errMsg = labelInfo.Split('|')[0];
                                                    errInfo = labelInfo.Split('|')[1];
                                                    ExHandler.showErrorStr(errMsg, errInfo);
                                                    break;
                                                case "-2":
                                                    labelInfo = labelInfo.Remove(0, 2);
                                                    msg = new frmMsg("A connection level error has occured", labelInfo, GlobalVars.msgState.Error);
                                                    msg.ShowDialog();
                                                    break;
                                                default:
                                                    st = new StackTrace(0, true);
                                                    msgStr = "Unexpected error while printing job tags";
                                                    errInfo = "Unexpected error while printing job tags" + Environment.NewLine + "Data Returned:" + Environment.NewLine + labelInfo;
                                                    break;
                                            }
                                        }
                                        else
                                        {
                                            st = new StackTrace(0, true);
                                            msgStr = "No data was returned from the server";
                                            errInfo = "No data was returned from the server";
                                            ExHandler.showErrorST(st, msgStr, errInfo);
                                        }                                                                                                                     
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            case "0":
                                opened = opened.Remove(0, 2);
                                msg = new frmMsg("The following server side issue was encountered:", opened, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            case "-1":
                                opened = opened.Remove(0, 3);
                                errMsg = opened.Split('|')[0];
                                errInfo = opened.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                opened = opened.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", opened, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while reopening job";
                                errInfo = "Unexpected error while reopening job" + Environment.NewLine + "Data Returned:" + Environment.NewLine + opened;
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
        private void btnNo_Click(object sender, EventArgs e)
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
