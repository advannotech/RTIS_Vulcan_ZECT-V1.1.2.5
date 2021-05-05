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
    public partial class ucConfirmAddition : UserControl
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

       public string slurryTank = string.Empty;

        public ucConfirmAddition(Panel _parent, frmMain _main)
        {
            InitializeComponent();
            parent = _parent;
            main = _main;
        }

        private void ucConfirmAddition_Load(object sender, EventArgs e)
        {
            this.Size = parent.Size;
            lblItem.Text = GlobalVars.ASitemCode;
            lblLot.Text = GlobalVars.ASlotNumber;
            lblSlurry.Text = GlobalVars.ASslurryCode;
            lblSlurLot.Text = GlobalVars.ASslurryLot;
            lblCoat.Text = GlobalVars.AScoatNum;
            lblQty.Text = GlobalVars.ASslurryDryWeight;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                string transferred = Client.AddZectSlurry(GlobalVars.ASjobNo + "|" + GlobalVars.ASslurryTank + "|" + GlobalVars.ASslurryCode + "|" + GlobalVars.ASslurryLot + "|" + lblQty.Text + "|" + GlobalVars.zectWhse + "|" + GlobalVars.zectIT + "|" + GlobalVars.userName + "|" + GlobalVars.ASslurryTankType);
                if (transferred != string.Empty)
                {
                    switch (transferred.Split('*')[0])
                    {
                        case "1":
                            msg = new frmMsg("Issue successful", "The slurry has been issued successfully", GlobalVars.msgState.Success);
                            msg.ShowDialog();
                            ucMenu menu = new ucMenu(parent, main);
                            main.pnlMain.Controls.Clear();
                            main.pnlMain.Controls.Add(menu);
                            break;
                        case "0":
                            transferred = transferred.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", transferred, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            GlobalVars.lastControl = new ucScanAdditionalSlurries(parent, main);
                            main.pnlMain.Controls.Clear();
                            main.pnlMain.Controls.Add(GlobalVars.lastControl);
                            break;
                        case "-1":
                            transferred = transferred.Remove(0, 3);
                            errMsg = transferred.Split('|')[0];
                            errInfo = transferred.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            GlobalVars.lastControl = new ucScanAdditionalSlurries(parent, main);
                            main.pnlMain.Controls.Clear();
                            main.pnlMain.Controls.Add(GlobalVars.lastControl);
                            break;
                        case "-2":
                            transferred = transferred.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", transferred, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            GlobalVars.lastControl = new ucScanAdditionalSlurries(parent, main);
                            main.pnlMain.Controls.Clear();
                            main.pnlMain.Controls.Add(GlobalVars.lastControl);
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while retreiving slurry lot information";
                            errInfo = "Unexpected error while retreiving slurry lot information" + Environment.NewLine + "Data Returned:" + Environment.NewLine + transferred;
                            GlobalVars.lastControl = new ucScanAdditionalSlurries(parent, main);
                            main.pnlMain.Controls.Clear();
                            main.pnlMain.Controls.Add(GlobalVars.lastControl);
                            break;
                    }
                }
                else
                {
                    st = new StackTrace(0, true);
                    msgStr = "No data was returned from the server";
                    errInfo = "No data was returned from the server";
                    GlobalVars.lastControl = new ucScanAdditionalSlurries(parent, main);
                    main.pnlMain.Controls.Clear();
                    main.pnlMain.Controls.Add(GlobalVars.lastControl);
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
                GlobalVars.lastControl = new ucScanAdditionalSlurries(parent, main);
                main.pnlMain.Controls.Clear();
                main.pnlMain.Controls.Add(GlobalVars.lastControl);
            }
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVars.lastControl = new ucScanAdditionalSlurries(parent, main);
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
