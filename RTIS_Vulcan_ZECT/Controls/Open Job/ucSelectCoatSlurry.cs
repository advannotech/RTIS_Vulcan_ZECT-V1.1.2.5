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
    public partial class ucSelectCoatSlurry : UserControl
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

        public ucSelectCoatSlurry(Panel _parent, frmMain _main)
        {
            InitializeComponent();
            parent = _parent;
            main = _main;
        }

        private void ucSelectCoatSlurry_Load(object sender, EventArgs e)
        {
            this.Size = parent.Size;
            getItems();
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

        public void getItems()
        {
            try
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

                string slurries = Client.GetCatalystSlurries(GlobalVars.OJCheckSheet + "|" + coatNum);
                switch (slurries.Split('*')[0])
                {
                    case "1":
                        slurries = slurries.Remove(0, 2);
                        string[] allSlurries = slurries.Split('~');
                        foreach (string item in allSlurries)
                        {
                            if (item != string.Empty)
                            {
                                cntrlSlurryItem PGM = new cntrlSlurryItem(item, this);
                                PGM.Dock = DockStyle.Top;
                                pnlItems.Controls.Add(PGM);
                            }
                        }
                        break;
                    case "0":
                        slurries = slurries.Remove(0, 2);
                        msg = new frmMsg("The following server side issue was encountered:", slurries, GlobalVars.msgState.Error);
                        msg.ShowDialog();
                        break;
                    case "-1":
                        slurries = slurries.Remove(0, 3);
                        errMsg = slurries.Split('|')[0];
                        errInfo = slurries.Split('|')[1];
                        ExHandler.showErrorStr(errMsg, errInfo);
                        break;
                    case "-2":
                        slurries = slurries.Remove(0, 2);
                        msg = new frmMsg("A connection level error has occured", slurries, GlobalVars.msgState.Error);
                        msg.ShowDialog();
                        break;
                    default:
                        st = new StackTrace(0, true);
                        msgStr = "Unexpected error while retreiving warehouse transfer processes";
                        errInfo = "Unexpected error while retreiving warehouse transfer processes" + Environment.NewLine + "Data Returned:" + Environment.NewLine + slurries;
                        break;
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void vsbFG_Scroll(object sender, ScrollEventArgs e)
        {
            Point p = pnlItems.Location;
            p.Y = 0 - e.NewValue;
            pnlItems.Location = p;
        }
        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;
                foreach (cntrlSlurryItem item in pnlItems.Controls)
                {
                    if (item.selected == true)
                    {
                        found = true;
                        GlobalVars.OJSlurry = item.code;
                    }
                }

                if (found == true)
                {
                    ucSlurryLots lots = new ucSlurryLots(parent, main);
                    main.pnlMain.Controls.Clear();
                    main.pnlMain.Controls.Add(lots);
                }
                else
                {
                    msg = new frmMsg("Cannot Continue", "Please select a slurry", GlobalVars.msgState.Error);
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
                GlobalVars.lastControl = new ucCoatNum(parent, main);
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
