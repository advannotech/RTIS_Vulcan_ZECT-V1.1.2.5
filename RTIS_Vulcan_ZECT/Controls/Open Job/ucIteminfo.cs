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
using RTIS_Vulcan_ZECT.Classes;
using RTIS_Vulcan_ZECT.Forms;

namespace RTIS_Vulcan_ZECT.Controls
{
    public partial class ucIteminfo : UserControl
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

        public ucIteminfo(Panel _parent, frmMain _main)
        {
            InitializeComponent();
            parent = _parent;
            main = _main;
        }

        private void ucIteminfo_Load(object sender, EventArgs e)
        {
            this.Size = parent.Size;

            cntrlOmniPad omni = new cntrlOmniPad();
            omni.Dock = DockStyle.Right;
            pnlKeyPad.Controls.Add(omni);

            txtItem.Focus();
            GlobalVars.focusedEdit = txtItem;

            //txtItem.Text = "18461-OT500";
        }

        private void txtItem_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (txtItem.Text != string.Empty)
                    {
                        GlobalVars.OJCheckSheet = txtItem.Text;
                        txtBatch.Focus();
                        GlobalVars.focusedEdit = txtBatch;
                        //string itemCode = Client.GetMFItemCode(txtItem.Text);
                        //switch (itemCode.Split('*')[0])
                        //{
                        //    case "1":
                        //        itemCode = itemCode.Remove(0, 2);
                               

                        //        break;
                        //    case "0":
                        //        itemCode = itemCode.Remove(0, 2);
                        //        msg = new frmMsg("The following server side issue was encountered:", itemCode,
                        //            GlobalVars.msgState.Error);
                        //        msg.ShowDialog();
                        //        break;
                        //    case "-1":
                        //        itemCode = itemCode.Remove(0, 3);
                        //        errMsg = itemCode.Split('|')[0];
                        //        errInfo = itemCode.Split('|')[1];
                        //        ExHandler.showErrorStr(errMsg, errInfo);
                        //        break;
                        //    case "-2":
                        //        itemCode = itemCode.Remove(0, 2);
                        //        msg = new frmMsg("A connection level error has occured", itemCode,
                        //            GlobalVars.msgState.Error);
                        //        msg.ShowDialog();
                        //        break;
                        //    default:
                        //        st = new StackTrace(0, true);
                        //        msgStr = "Unexpected error while retreiving slurry lots";
                        //        errInfo = "Unexpected error while retreiving slurry lots" + Environment.NewLine +
                        //                  "Data Returned:" + Environment.NewLine + itemCode;
                        //        break;
                        //}
                    }
                    else
                    {
                        msg = new frmMsg("No barcode", "Please scan the check sheet barcode",
                            GlobalVars.msgState.Error);
                        msg.ShowDialog();
                    }
                }
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
                if (txtItem.Text != string.Empty && txtBatch.Text != string.Empty)
                {
                    GlobalVars.OJCheckSheet = txtItem.Text;
                    GlobalVars.OJLotNumber = txtBatch.Text;
                    ucCoatNum coatNum = new ucCoatNum(parent, main);
                    main.pnlMain.Controls.Clear();
                    main.pnlMain.Controls.Add(coatNum);
                }
                else
                {
                    msg = new frmMsg("Missing information",
                        "Please scan the check sheet barcode and enter a lot number before continuing",
                        GlobalVars.msgState.Error);
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
                ucMenu menu = new ucMenu(parent, main);
                GlobalVars.lastControl = menu;
                main.pnlMain.Controls.Clear();
                main.pnlMain.Controls.Add(menu);
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void txtItem_Click(object sender, EventArgs e)
        {
            GlobalVars.focusedEdit = txtItem;
        }

        private void txtBatch_Click(object sender, EventArgs e)
        {
            GlobalVars.focusedEdit = txtBatch;
        }

        private void txtBatch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}