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

namespace RTIS_Vulcan_ZECT.Controls.Open_Job
{
    public partial class ucSlurryTank : UserControl
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
        public ucSlurryTank(Panel _parent, frmMain _main)
        {
            InitializeComponent();
            parent = _parent;
            main = _main;
        }

        private void ucSlurryTank_Load(object sender, EventArgs e)
        {
            this.Size = parent.Size;
            getSlurryTanks();
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

        private void getSlurryTanks()
        {
           try
            {
                string tanks = Client.GetSlurryTanks(GlobalVars.OJSlurry + "|" + GlobalVars.OJSlurryLot);
                switch (tanks.Split('*')[0])
                {
                    case "1":
                        tanks = tanks.Remove(0, 2);
                        string[] allTanks = tanks.Split('~');
                        foreach (string item in allTanks)
                        {
                            if (item != string.Empty)
                            {
                                cntrlSlurryTank PGM = new cntrlSlurryTank(item.Split('|')[0], item.Split('|')[1], this);
                                PGM.Dock = DockStyle.Top;
                                pnlItems.Controls.Add(PGM);
                            }
                        }
                        break;
                    case "0":
                        tanks = tanks.Remove(0, 2);
                        msg = new frmMsg("The following server side issue was encountered:", tanks, GlobalVars.msgState.Error);
                        msg.ShowDialog();
                        break;
                    case "-1":
                        tanks = tanks.Remove(0, 3);
                        errMsg = tanks.Split('|')[0];
                        errInfo = tanks.Split('|')[1];
                        ExHandler.showErrorStr(errMsg, errInfo);
                        break;
                    case "-2":
                        tanks = tanks.Remove(0, 2);
                        msg = new frmMsg("A connection level error has occured", tanks, GlobalVars.msgState.Error);
                        msg.ShowDialog();
                        break;
                    default:
                        st = new StackTrace(0, true);
                        msgStr = "Unexpected error while retreiving warehouse transfer processes";
                        errInfo = "Unexpected error while retreiving warehouse transfer processes" + Environment.NewLine + "Data Returned:" + Environment.NewLine + tanks;
                        break;
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
    }
}
