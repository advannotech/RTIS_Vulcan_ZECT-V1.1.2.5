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
    public partial class cntrlSlurryItem : UserControl
    {
        public string code { get; set; }
        public bool selected { get; set; }
        ucSelectCoatSlurry parent { get; set; }
        public cntrlSlurryItem(string _code, ucSelectCoatSlurry _parent)
        {
            InitializeComponent();
            code = _code;
            parent = _parent;
        }

        private void cntrlSlurryItem_Load(object sender, EventArgs e)
        {
            lblItemCode.Text = code;          
        }

        private void pnlBack_Click(object sender, EventArgs e)
        {
            try
            {
                selected = true;
                pnlBack.BackColor = Color.LightBlue;
                lblItemCode.BackColor = Color.LightBlue;
                foreach (cntrlSlurryItem item in parent.pnlItems.Controls)
                {
                    if (item != this)
                    {
                        item.selected = false;
                        item.pnlBack.BackColor = Color.White;
                        item.lblItemCode.BackColor = Color.White;
                    }

                }
            }
            catch (Exception)
            {

            }
        }

        private void lblItemCode_Click(object sender, EventArgs e)
        {
            try
            {
                selected = true;
                pnlBack.BackColor = Color.LightBlue;
                lblItemCode.BackColor = Color.LightBlue;
                foreach (cntrlSlurryItem item in parent.pnlItems.Controls)
                {
                    if (item != this)
                    {
                        item.selected = false;
                        item.pnlBack.BackColor = Color.White;
                        item.lblItemCode.BackColor = Color.White;
                    }

                }
            }
            catch (Exception)
            {

            }
        }
    }
}
