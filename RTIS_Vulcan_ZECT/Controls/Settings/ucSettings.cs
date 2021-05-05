﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RTIS_Vulcan_ZECT.Forms;
using RTIS_Vulcan_ZECT.Classes;
using System.Diagnostics;
using System.Drawing.Printing;

namespace RTIS_Vulcan_ZECT.Controls
{
    public partial class ucSettings : UserControl
    {
        public frmMsg msg;
        public string errMsg;
        public string errInfo;

        Panel parent;
        public frmMain main;

        public ucSettings(Panel _parent, frmMain _main)
        {
            InitializeComponent();
            parent = _parent;
            main = _main;
        }

        private void ucSettings_Load(object sender, EventArgs e)
        {
            this.Size = parent.Size;

            cntrlOmniPad keypad = new cntrlOmniPad();
            keypad.Dock = DockStyle.Right;
            pnlKeyPad.Controls.Add(keypad);

            if (GlobalVars.lastControl != null)
            {
                btnBack.Enabled = true;
            }
            else
            {
                btnBack.Enabled = false;
            }

            getPrinters();
            getSettings();
        }
        public void getPrinters()
        {
            try
            {
                foreach (string printer in PrinterSettings.InstalledPrinters)
                {
                    cmbPrinter.Properties.Items.Add(printer);
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
        public void getSettings()
        {
            try
            {
                try
                {
                    txtIP.Text = GlobalVars.ServerIP.Split('.')[0];
                    txtIP2.Text = GlobalVars.ServerIP.Split('.')[1];
                    txtIP3.Text = GlobalVars.ServerIP.Split('.')[2];
                    txtIP4.Text = GlobalVars.ServerIP.Split('.')[3];
                }
                catch (Exception)
                { }
                txtPort.Text = GlobalVars.ServerPort;

                txtZectWhse.Text = GlobalVars.zectWhse;
                txtZectIT.Text = GlobalVars.zectIT;
                txtConfigLabel.Text = GlobalVars.configLoc;
                txtZectLabel.Text = GlobalVars.zectLoc;
                cmbPrinter.Text = GlobalVars.Printer;
                txtLotLookup.Text = GlobalVars.lotLookupPeriod;

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
                if (txtIP.Text != string.Empty && txtIP2.Text != string.Empty && txtIP3.Text != string.Empty && txtIP4.Text != string.Empty)
                {
                    if (txtPort.Text != string.Empty)
                    {
                        if (txtZectWhse.Text != string.Empty && txtZectIT.Text != string.Empty)
                        {
                            if (txtConfigLabel.Text != string.Empty && txtZectLabel.Text != string.Empty)
                            {
                                string updateCommand = string.Empty;
                                string ip = txtIP.Text + "." + txtIP2.Text + "." + txtIP3.Text + "." + txtIP4.Text;
                                updateCommand += "UPDATE [Settings] SET [Value] ='" + ip + "' WHERE [SettingName] = 'ServerIP';";
                                updateCommand += "UPDATE [Settings] SET [Value] ='" + txtPort.Text + "' WHERE [SettingName] = 'ServerPort';";
                                updateCommand += "UPDATE [Settings] SET [Value] ='" + txtZectWhse.Text + "' WHERE [SettingName] = 'ZectWhse';";
                                updateCommand += "UPDATE [Settings] SET [Value] ='" + txtZectIT.Text + "' WHERE [SettingName] = 'ZectIT';";
                                updateCommand += "UPDATE [Settings] SET [Value] ='" + txtConfigLabel.Text + "' WHERE [SettingName] = 'ConfigPath';";
                                updateCommand += "UPDATE [Settings] SET [Value] ='" + txtZectLabel.Text + "' WHERE [SettingName] = 'ZectPath';";
                                updateCommand += "UPDATE [Settings] SET [Value] ='" + cmbPrinter.Text + "' WHERE [SettingName] = 'Printer';";
                                updateCommand += "UPDATE [Settings] SET [Value] ='" + txtLotLookup.Text + "' WHERE [SettingName] = 'LotLookup';";

                                //Printer
                                string updated = SQLite.UpdateSettings(updateCommand, GlobalVars.SettingsDB);
                                switch (updated.Split('*')[0])
                                {
                                    case "1":
                                        msg = new frmMsg("Success!", "Settings have been saved successfully", GlobalVars.msgState.Success);
                                        msg.ShowDialog();
                                        GlobalVars.ServerIP = ip;
                                        GlobalVars.ServerPort = txtPort.Text;
                                        GlobalVars.zectWhse = txtZectWhse.Text;
                                        GlobalVars.zectIT = txtZectIT.Text;
                                        GlobalVars.configLoc = txtConfigLabel.Text;
                                        GlobalVars.zectLoc = txtZectLabel.Text;
                                        GlobalVars.Printer = cmbPrinter.Text;
                                        GlobalVars.lotLookupPeriod = txtLotLookup.Text;
                                        break;
                                    case "-1":
                                        updated = updated.Remove(0, 3);
                                        errMsg = updated.Split('|')[0];
                                        errInfo = updated.Split('|')[1];
                                        ExHandler.showErrorStr(errMsg, errInfo);
                                        break;
                                    default:
                                        Cursor.Current = Cursors.Default;
                                        StackTrace st1 = new StackTrace(0, true);
                                        string msgStr1 = "Unexpected saving settings";
                                        string infoStr1 = "Unexpected saving setting";
                                        ExHandler.showErrorST(st1, msgStr1, infoStr1);
                                        break;
                                }
                            }
                            else
                            {
                                msg = new frmMsg("Error", "Please enter all required folder paths", GlobalVars.msgState.Error);
                                msg.ShowDialog();
                            }
                        }
                        else
                        {
                            msg = new frmMsg("Error", "Please enter all required warehouse codes!", GlobalVars.msgState.Error);
                            msg.ShowDialog();
                        }
                    }
                    else
                    {
                        msg = new frmMsg("Error", "Please enter a port number!", GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }
                else
                {
                    msg = new frmMsg("Error", "Please enter a valid IP address!", GlobalVars.msgState.Error);
                    msg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void txtIP_Click(object sender, EventArgs e)
        {
            GlobalVars.focusedEdit = txtIP;
        }

        private void txtIP2_Click(object sender, EventArgs e)
        {
            GlobalVars.focusedEdit = txtIP2;
        }

        private void txtIP3_Click(object sender, EventArgs e)
        {
            GlobalVars.focusedEdit = txtIP3;
        }

        private void txtIP4_Click(object sender, EventArgs e)
        {
            GlobalVars.focusedEdit = txtIP4;
        }

        private void txtPort_Click(object sender, EventArgs e)
        {
            GlobalVars.focusedEdit = txtPort;
        }

        private void txtZectWhse_Click(object sender, EventArgs e)
        {
            GlobalVars.focusedEdit = txtZectWhse;
        }

        private void txtZectIT_Click(object sender, EventArgs e)
        {
            GlobalVars.focusedEdit = txtZectIT;
        }

        private void txtConfigLabel_Click(object sender, EventArgs e)
        {
            GlobalVars.focusedEdit = txtConfigLabel;
        }

        private void txtZectLabel_Click(object sender, EventArgs e)
        {
            GlobalVars.focusedEdit = txtZectLabel;
        }

        private void btnConfigPath_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.ShowDialog();
                string labelFolder = fbd.SelectedPath;
                txtConfigLabel.Text = labelFolder + @"\";
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnZectPath_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fbd = new FolderBrowserDialog();
                fbd.ShowDialog();
                string labelFolder = fbd.SelectedPath;
                txtZectLabel.Text = labelFolder + @"\";
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void txtLotLookup_Click(object sender, EventArgs e)
        {
            GlobalVars.focusedEdit = txtLotLookup;
        }
    }
}
