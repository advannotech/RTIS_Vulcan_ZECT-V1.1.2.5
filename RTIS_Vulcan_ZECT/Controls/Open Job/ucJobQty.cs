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
    public partial class ucJobQty : UserControl
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
        public ucJobQty(Panel _parent, frmMain _main)
        {
            InitializeComponent();
            parent = _parent;
            main = _main;
        }
        private void ucJobQty_Load(object sender, EventArgs e)
        {
            this.Size = parent.Size;

            cntrlNumPad num = new cntrlNumPad();
            num.Dock = DockStyle.Right;
            pnlKeyPad.Controls.Add(num);

            lblItem.Text = GlobalVars.OJCheckSheet;
            lblLot.Text = GlobalVars.OJLotNumber;
            lblSlurry.Text = GlobalVars.OJSlurry;
            lblSlurLot.Text = GlobalVars.OJSlurryLot;

            string coatNum = string.Empty;
            switch (GlobalVars.OJCoatNumber)
            {
                case GlobalVars.CoatNumber.first:
                    lblCoat.Text = "1st";
                    break;
                case GlobalVars.CoatNumber.second:
                    lblCoat.Text = "2nd";
                    break;
                case GlobalVars.CoatNumber.third:
                    lblCoat.Text = "3rd";
                    break;
                case GlobalVars.CoatNumber.forth:
                    lblCoat.Text = "4th";
                    break;
                default:
                    break;
            }

            txtQty.Focus();
            GlobalVars.focusedEdit = txtQty;
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtQty.Text != string.Empty)
                {
                    string coatNum = string.Empty;
                    switch (GlobalVars.OJCoatNumber)
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

                    string jobOpened = Client.ZectOpenJob(GlobalVars.OJCheckSheet + "|" + coatNum + "|" + GlobalVars.OJLotNumber  + "|" + GlobalVars.OJSlurry + "|" + GlobalVars.OJSlurryLot + "|" + txtQty.Text + "|" + GlobalVars.zectWhse + "|" + GlobalVars.zectIT + "|" + GlobalVars.userName + "|" + GlobalVars.OJSlurryTankType + "|" + GlobalVars.OJSlurryTank + "|" + GlobalVars.OJWetWeight + "|" + GlobalVars.OJDryWeight);
                    if (jobOpened != string.Empty)
                    {
                        switch (jobOpened.Split('*')[0])
                        {
                            case "1":
                                string labelInfo = jobOpened.Remove(0, 2);
                                //Print Label
                                //[Bar_Code], [cSimpleCode], b.[cBinLocationName], [Description_1], [Description_2], [Description_3], [ItemGroup] 
                                string jobNumber = labelInfo.Split('|')[0];
                                string itemCode = labelInfo.Split('|')[1];
                                string barcode = labelInfo.Split('|')[2];
                                string simpleCode = labelInfo.Split('|')[3];
                                string binLocation = labelInfo.Split('|')[4];
                                string description1 = labelInfo.Split('|')[5];
                                string description2 = labelInfo.Split('|')[6];
                                string description3 = labelInfo.Split('|')[7];
                                string group = labelInfo.Split('|')[8];


                                XtraReport printLabel = GlobalVars.configTag;
                                
                                printLabel.Parameters["_Lot"].Value = GlobalVars.OJLotNumber;
                                printLabel.Parameters["_Qty"].Value = txtQty.Text;
                                printLabel.Parameters["_Coat"].Value = GlobalVars.OJCoatNumber;
                                printLabel.Parameters["_Slurry"].Value = GlobalVars.OJSlurry;
                                printLabel.Parameters["_SlurryLot"].Value = GlobalVars.OJSlurryLot;
                                printLabel.Parameters["_RT2D"].Value = jobNumber;

                                printLabel.Parameters["_ItemCode"].Value = itemCode;
                                printLabel.Parameters["_barcode"].Value = barcode;
                                printLabel.Parameters["_bin"].Value = binLocation;
                                printLabel.Parameters["_Date"].Value = DateTime.Now.ToString("yyyy-MM-dd");
                                printLabel.Parameters["_Description1"].Value = description1;
                                printLabel.Parameters["_Description2"].Value = description2;
                                printLabel.Parameters["_Description3"].Value = description3;
                                printLabel.Parameters["_Group"].Value = group;
                                printLabel.Parameters["_SimpleCode"].Value = simpleCode;

                                printLabel.CreateDocument();
                                ReportPrintTool prtTool = new ReportPrintTool(printLabel);
                                prtTool.PrinterSettings.Copies = Convert.ToInt16(2);
                                prtTool.Print(GlobalVars.Printer);

                                msg = new frmMsg("Success", "The job has been opened", GlobalVars.msgState.Success);
                                msg.ShowDialog();
                                ucMenu menu = new ucMenu(parent, main);
                                main.pnlMain.Controls.Clear();
                                main.pnlMain.Controls.Add(menu);
                                break;
                            case "0":
                                jobOpened = jobOpened.Remove(0, 2);
                                msg = new frmMsg("The following server side issue was encountered:", jobOpened, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            case "-1":
                                jobOpened = jobOpened.Remove(0, 3);
                                errMsg = jobOpened.Split('|')[0];
                                errInfo = jobOpened.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                jobOpened = jobOpened.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", jobOpened, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while printing job tags";
                                errInfo = "Unexpected error while printing job tags" + Environment.NewLine + "Data Returned:" + Environment.NewLine + jobOpened;
                                break;
                        }
                    }
                    else
                    {
                        st = new StackTrace(0, true);
                        msgStr = "No data was returned from the server";
                        errInfo = "No data was returned from the server";
                    }
                }
                else
                {
                    msg = new frmMsg("No quantity", "Please enter a quantity for the job", GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
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
                GlobalVars.lastControl = new ucSlurryLots(parent, main);
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
