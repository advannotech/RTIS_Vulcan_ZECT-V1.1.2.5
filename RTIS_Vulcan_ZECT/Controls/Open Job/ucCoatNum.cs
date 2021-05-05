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

namespace RTIS_Vulcan_ZECT.Controls
{
    public partial class ucCoatNum : UserControl
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


        public ucCoatNum(Panel _parent, frmMain _main)
        {
            InitializeComponent();
            parent = _parent;
            main = _main;
        }
        private void ucCoatNum_Load(object sender, EventArgs e)
        {
            this.Size = parent.Size;
        }
        private void btnfirst_Click(object sender, EventArgs e)
        {
            try
            {
                GlobalVars.OJCoatNumber = GlobalVars.CoatNumber.first;
                ucSelectCoatSlurry slurry = new ucSelectCoatSlurry(parent, main);
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
                GlobalVars.OJCoatNumber = GlobalVars.CoatNumber.second;
                ucSelectCoatSlurry slurry = new ucSelectCoatSlurry(parent, main);
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
                GlobalVars.OJCoatNumber = GlobalVars.CoatNumber.third;
                ucSelectCoatSlurry slurry = new ucSelectCoatSlurry(parent, main);
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
                GlobalVars.OJCoatNumber = GlobalVars.CoatNumber.forth;
                ucSelectCoatSlurry slurry = new ucSelectCoatSlurry(parent, main);
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
                ucIteminfo itemInfo = new ucIteminfo(parent, main);
                GlobalVars.lastControl = itemInfo;
                main.pnlMain.Controls.Clear();
                main.pnlMain.Controls.Add(itemInfo);
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }
    }
}
