using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RTIS_Vulcan_ZECT.Controls.Open_Job
{
    public partial class cntrlSlurryTank : UserControl
    {
        public string tank { get; set; }
        public string weight { get; set; }
        public bool selected { get; set; }
        ucSlurryTank parent { get; set; }
        public cntrlSlurryTank(string _tank, string _weight, ucSlurryTank _parent)
        {
            InitializeComponent();
            tank = _tank;
            weight = _weight;
            parent = _parent;
        }

        private void cntrlSlurryTank_Load(object sender, EventArgs e)
        {
            lblTank.Text = tank;
            lblWeight.Text = weight;
        }

        private void pnlBack_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                selected = true;
                pnlBack.BackColor = Color.LightBlue;
                lblTank.BackColor = Color.LightBlue;
                lblWeight.BackColor = Color.LightBlue;
                foreach (cntrlSlurryTank item in parent.pnlItems.Controls)
                {
                    if (item != this)
                    {
                        item.selected = false;
                        item.pnlBack.BackColor = Color.White;
                        item.lblTank.BackColor = Color.White;
                        item.lblWeight.BackColor = Color.White;
                    }

                }
            }
            catch (Exception)
            {

            }
        }

        private void lblTank_Click(object sender, EventArgs e)
        {
            try
            {
                selected = true;
                pnlBack.BackColor = Color.LightBlue;
                lblTank.BackColor = Color.LightBlue;
                lblWeight.BackColor = Color.LightBlue;
                foreach (cntrlSlurryTank item in parent.pnlItems.Controls)
                {
                    if (item != this)
                    {
                        item.selected = false;
                        item.pnlBack.BackColor = Color.White;
                        item.lblTank.BackColor = Color.White;
                        item.lblWeight.BackColor = Color.White;
                    }

                }
            }
            catch (Exception)
            {

            }
        }

        private void lblWeight_Click(object sender, EventArgs e)
        {
            try
            {
                selected = true;
                pnlBack.BackColor = Color.LightBlue;
                lblTank.BackColor = Color.LightBlue;
                lblWeight.BackColor = Color.LightBlue;
                foreach (cntrlSlurryTank item in parent.pnlItems.Controls)
                {
                    if (item != this)
                    {
                        item.selected = false;
                        item.pnlBack.BackColor = Color.White;
                        item.lblTank.BackColor = Color.White;
                        item.lblWeight.BackColor = Color.White;
                    }

                }
            }
            catch (Exception)
            {

            }
        }
    }
}
