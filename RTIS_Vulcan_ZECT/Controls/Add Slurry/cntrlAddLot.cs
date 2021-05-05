using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTIS_Vulcan_ZECT.Controls
{
    public partial class cntrlAddLot : UserControl
    {
        public string tankType { get; set; }
        public string tankcode { get; set; }
        public string code { get; set; }
        public string typeCode { get; set; }
        public string wetWeight { get; set; }
        public string dryWeight { get; set; }
        public bool selected { get; set; }
        ucScanAdditionalSlurries parent { get; set; }
        public cntrlAddLot(string _tankType, string _tankCode, string _code, string _typeCode, string _wetWeight, string _dryWeight, ucScanAdditionalSlurries _parent)
        {
            InitializeComponent();
            code = _code;
            tankType = _tankType;
            tankcode = _tankCode;
            typeCode = _typeCode;
            wetWeight = _wetWeight;
            dryWeight = _dryWeight;
            parent = _parent;
        }

        private void cntrlAddLot_Load(object sender, EventArgs e)
        {
            lblTankType.Text = tankType;
            lblTankCode.Text = tankcode;
            lblLot.Text = code;
        }

        private void lblLot_Click(object sender, EventArgs e)
        {
            try
            {
                selected = true;
                pnlBack.BackColor = Color.LightBlue;
                lblLot.BackColor = Color.LightBlue;
                foreach (cntrlAddLot item in parent.pnlItems.Controls)
                {
                    if (item != this)
                    {
                        item.selected = false;
                        item.pnlBack.BackColor = Color.White;
                        item.lblLot.BackColor = Color.White;
                    }

                }
            }
            catch (Exception)
            {

            }
        }

        private void pnlBack_Click(object sender, EventArgs e)
        {
            try
            {
                selected = true;
                pnlBack.BackColor = Color.LightBlue;
                lblLot.BackColor = Color.LightBlue;
                foreach (cntrlAddLot item in parent.pnlItems.Controls)
                {
                    if (item != this)
                    {
                        item.selected = false;
                        item.pnlBack.BackColor = Color.White;
                        item.lblLot.BackColor = Color.White;
                    }

                }
            }
            catch (Exception)
            {

            }
        }

        private void lblTankCode_Click(object sender, EventArgs e)
        {
            try
            {
                selected = true;
                pnlBack.BackColor = Color.LightBlue;
                lblLot.BackColor = Color.LightBlue;
                foreach (cntrlAddLot item in parent.pnlItems.Controls)
                {
                    if (item != this)
                    {
                        item.selected = false;
                        item.pnlBack.BackColor = Color.White;
                        item.lblLot.BackColor = Color.White;
                    }

                }
            }
            catch (Exception)
            {

            }
        }

        private void lblTankType_Click(object sender, EventArgs e)
        {
            try
            {
                selected = true;
                pnlBack.BackColor = Color.LightBlue;
                lblLot.BackColor = Color.LightBlue;
                foreach (cntrlAddLot item in parent.pnlItems.Controls)
                {
                    if (item != this)
                    {
                        item.selected = false;
                        item.pnlBack.BackColor = Color.White;
                        item.lblLot.BackColor = Color.White;
                    }

                }
            }
            catch (Exception)
            {

            }
        }
    }
}
