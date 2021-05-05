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
    public partial class ucReOpenCoats : UserControl
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
        public ucReOpenCoats(Panel _parent, frmMain _main)
        {
            InitializeComponent();
            parent = _parent;
            main = _main;
        }

        private void ucReOpenCoats_Load(object sender, EventArgs e)
        {
            this.Size = parent.Size;
            getItemCoats();
        }

        public void getItemCoats()
        {
            try
            {
                string itemCoats = Client.GetReOpenCoats(GlobalVars.ROitem);
                if (itemCoats != string.Empty)
                {
                    switch (itemCoats.Split('*')[0])
                    {
                        case "1":
                            if (itemCoats.Contains("1st") == false)
                            {
                                btnfirst.Visible = false;
                                btnfirst.Enabled = false;
                            }

                            if (itemCoats.Contains("2nd") == false)
                            {
                                btnSecond.Visible = false;
                                btnSecond.Enabled = false;
                            }

                            if (itemCoats.Contains("3rd") == false)
                            {
                                btnThird.Visible = false;
                                btnThird.Enabled = false;
                            }

                            if (itemCoats.Contains("4th") == false)
                            {
                                btnForth.Visible = false;
                                btnForth.Enabled = false;
                            }
                            break;
                        case "0":
                            itemCoats = itemCoats.Remove(0, 2);
                            msg = new frmMsg("The following server side issue was encountered:", itemCoats, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        case "-1":
                            itemCoats = itemCoats.Remove(0, 3);
                            errMsg = itemCoats.Split('|')[0];
                            errInfo = itemCoats.Split('|')[1];
                            ExHandler.showErrorStr(errMsg, errInfo);
                            break;
                        case "-2":
                            itemCoats = itemCoats.Remove(0, 2);
                            msg = new frmMsg("A connection level error has occured", itemCoats, GlobalVars.msgState.Error);
                            msg.ShowDialog();
                            break;
                        default:
                            st = new StackTrace(0, true);
                            msgStr = "Unexpected error while printing job tags";
                            errInfo = "Unexpected error while printing job tags" + Environment.NewLine + "Data Returned:" + Environment.NewLine + itemCoats;
                            ExHandler.showErrorST(st, msgStr, errInfo);
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
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnfirst_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVars.ROCoatNumber = GlobalVars.CoatNumber.first;
                ucReOpenSelectLot slurry = new ucReOpenSelectLot(parent, main);
                main.pnlMain.Controls.Clear();
                main.pnlMain.Controls.Add(slurry);
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnSecond_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVars.ROCoatNumber = GlobalVars.CoatNumber.second;
                ucReOpenSelectLot slurry = new ucReOpenSelectLot(parent, main);
                main.pnlMain.Controls.Clear();
                main.pnlMain.Controls.Add(slurry);
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnThird_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVars.ROCoatNumber = GlobalVars.CoatNumber.third;
                ucReOpenSelectLot slurry = new ucReOpenSelectLot(parent, main);
                main.pnlMain.Controls.Clear();
                main.pnlMain.Controls.Add(slurry);
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnForth_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVars.ROCoatNumber = GlobalVars.CoatNumber.forth;
                ucReOpenSelectLot slurry = new ucReOpenSelectLot(parent, main);
                main.pnlMain.Controls.Clear();
                main.pnlMain.Controls.Add(slurry);
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
                GlobalVars.lastControl = new ucReOpenScanSheet(parent, main);
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
