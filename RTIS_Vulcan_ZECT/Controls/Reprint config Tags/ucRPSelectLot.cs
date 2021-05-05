﻿using System;
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
using RTIS_Vulcan_ZECT.Controls.Reprint_config_Tags;

namespace RTIS_Vulcan_ZECT.Controls
{
    public partial class ucRPSelectLot : UserControl
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
        public ucRPSelectLot(Panel _parent, frmMain _main)
        {
            InitializeComponent();
            parent = _parent;
            main = _main;
        }

        private void ucRPSelectLot_Load(object sender, EventArgs e)
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

        public void getItemLots()
        {
            try
            {
                string whseCode = GlobalVars.zectWhse;
                string coatNum = string.Empty;
                switch (GlobalVars.RPCoatNumber)
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

                string lots = Client.getReprintJobLots(GlobalVars.RPitem + "|" + coatNum + "|" + GlobalVars.lotLookupPeriod + "|" + whseCode);
                switch (lots.Split('*')[0])
                {
                    case "1":
                        lots = lots.Remove(0, 2);
                        string[] allLots = lots.Split('~');
                        foreach (string item in allLots)
                        {
                            if (item != string.Empty)
                            {
                                cntrlRPLot lot = new cntrlRPLot(item, this);
                                lot.Dock = DockStyle.Top;
                                pnlItems.Controls.Add(lot);
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

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVars.lastControl = new ucRPCoats(parent, main);
                main.pnlMain.Controls.Clear();
                main.pnlMain.Controls.Add(GlobalVars.lastControl);
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            try
            {
                bool found = false;
                foreach (cntrlRPLot item in pnlItems.Controls)
                {
                    if (item.selected == true)
                    {
                        found = true;
                        GlobalVars.RPLotNumber = item.code;
                    }
                }

                if (found == true)
                {
                    string whseCode = GlobalVars.zectWhse;
                    string coatNum = string.Empty;
                    switch (GlobalVars.RPCoatNumber)
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

                    string jobNo = Client.GetReprintJobNumber(GlobalVars.RPitem + "|" + coatNum + "|" + whseCode + "|" + GlobalVars.RPLotNumber);
                    if (jobNo != string.Empty)
                    {
                        switch (jobNo.Split('*')[0])
                        {
                            case "1":
                                GlobalVars.RPjobNo = jobNo.Remove(0, 2);
                                ucRPInfo menu = new ucRPInfo(parent, main);
                                main.pnlMain.Controls.Clear();
                                main.pnlMain.Controls.Add(menu);
                                break;
                            case "0":
                                jobNo = jobNo.Remove(0, 2);
                                msg = new frmMsg("The following server side issue was encountered:", jobNo, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            case "-1":
                                jobNo = jobNo.Remove(0, 3);
                                errMsg = jobNo.Split('|')[0];
                                errInfo = jobNo.Split('|')[1];
                                ExHandler.showErrorStr(errMsg, errInfo);
                                break;
                            case "-2":
                                jobNo = jobNo.Remove(0, 2);
                                msg = new frmMsg("A connection level error has occured", jobNo, GlobalVars.msgState.Error);
                                msg.ShowDialog();
                                break;
                            default:
                                st = new StackTrace(0, true);
                                msgStr = "Unexpected error while logging in";
                                errInfo = "Unexpected error while logging in" + Environment.NewLine + "Data Returned:" + Environment.NewLine + jobNo;
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

        private void vsbFG_Scroll(object sender, ScrollEventArgs e)
        {
            Point p = pnlItems.Location;
            p.Y = 0 - e.NewValue;
            pnlItems.Location = p;
        }
    }
}
