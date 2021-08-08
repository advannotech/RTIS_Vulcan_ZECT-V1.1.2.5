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
using RTIS_Vulcan_ZECT.Controls.Open_Job;


namespace RTIS_Vulcan_ZECT.Controls
{
    public partial class ucSlurryLots : UserControl
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

        System.Timers.Timer STimer;

        public ucSlurryLots(Panel _parent, frmMain _main)
        {
            InitializeComponent();
            parent = _parent;
            main = _main;
        }




        private void ucSlurryLots_Load(object sender, EventArgs e)
        {
            this.Size = parent.Size;
            getItemLots();
            if (pnlItems.Height < pnlParent.Height)
            {
                vsbFG.Visible = false;
                pnlItems.Dock = DockStyle.Fill;
            }
            else
            {
                vsbFG.Visible = true;
                vsbFG.BringToFront();
                pnlItems.Parent = pnlParent;
                pnlItems.Height = pnlItems.Height + 80;
                vsbFG.Maximum = pnlItems.Height - pnlParent.Height;
                vsbFG.LargeChange = vsbFG.Maximum / 6;
            }
        }

        private void getItemLots()
        {
            try
            {
                string whseCode = GlobalVars.zectIT;
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

                string lots = Client.GetSlurryLots(GlobalVars.OJSlurry + "|" + whseCode);
                switch (lots.Split('*')[0])
                {
                    case "1":
                        lots = lots.Remove(0, 2);
                        string[] allLots = lots.Split('~');
                        List<string> removeDuplicateLots = new List<string>();

                        foreach (string item in allLots)
                        {
                            if (item != string.Empty)
                            {
                                removeDuplicateLots.Add(item.Split('|')[2]); 
                            }
                        }

                        foreach (string code in removeDuplicateLots.Distinct())
                        {
                            if (code != string.Empty)
                            {
                                cntrlSlurryLot PGM = new cntrlSlurryLot(string.Empty, string.Empty,"              "+ code,string.Empty,string.Empty, string.Empty, this);
                                PGM.Dock = DockStyle.Top;
                                pnlItems.Controls.Add(PGM);
                            }
                        }
                        break;
                    case "0":
                        lots = lots.Remove(0, 2);
                        msg = new frmMsg("The following server side issue was encountered:", lots, GlobalVars.msgState.Error);
                        msg.ShowDialog();
                        break;
                    case "-1":
                        lots = lots.Remove(0, 3);
                        errMsg = lots.Split('|')[0];
                        errInfo = lots.Split('|')[1];
                        ExHandler.showErrorStr(errMsg, errInfo);
                        break;
                    case "-2":
                        lots = lots.Remove(0, 2);
                        msg = new frmMsg("A connection level error has occured", lots, GlobalVars.msgState.Error);
                        msg.ShowDialog();
                        break;
                    default:
                        st = new StackTrace(0, true);
                        msgStr = "Unexpected error while retreiving warehouse transfer processes";
                        errInfo = "Unexpected error while retreiving warehouse transfer processes" + Environment.NewLine + "Data Returned:" + Environment.NewLine + lots;
                        break;
                }            
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

      

        private void btnNext_Click_1(object sender, EventArgs e)
        {
            try
            {
                bool found = false;
                foreach (cntrlSlurryLot item in pnlItems.Controls)
                {
                    if (item.selected == true)
                    {
                        found = true;
                        GlobalVars.OJSlurryTankType = item.typeCode;
                        GlobalVars.OJSlurryTank = item.tankcode;
                        GlobalVars.OJSlurryLot = item.code.Replace("Lot : ", string.Empty);
                        GlobalVars.OJWetWeight = item.wetWeight;
                        GlobalVars.OJDryWeight = item.dryWeight;
                    }
                }

                if (found == true)
                {
                    ucJobQty jcQty = new ucJobQty(parent, main);
                    main.pnlMain.Controls.Clear();
                    main.pnlMain.Controls.Add(jcQty);

                    //ucSlurryTank slurryTank = new ucSlurryTank(parent, main);
                    //main.pnlMain.Controls.Clear();
                    //main.pnlMain.Controls.Add(slurryTank);
                }
                else
                {
                    msg = new frmMsg("Cannot Continue", "Please select a slurry lot number", GlobalVars.msgState.Error);
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
                GlobalVars.lastControl = new ucSelectCoatSlurry(parent, main);
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
