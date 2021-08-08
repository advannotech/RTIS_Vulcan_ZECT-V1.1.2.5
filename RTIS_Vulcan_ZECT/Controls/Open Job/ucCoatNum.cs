using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Diagnostics;
using RTIS_Vulcan_ZECT.Forms;
using RTIS_Vulcan_ZECT.Classes;
using System.Configuration;

namespace RTIS_Vulcan_ZECT.Controls
{

    public partial class ucCoatNum : UserControl
    {


        string cCode = GlobalVars.OJCheckSheet;
        string lNum = GlobalVars.OJLotNumber;

        string strcon = ConfigurationManager.ConnectionStrings["cataConnectionString"].ConnectionString.ToString();
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
            //try
            //{

            //    SqlConnection conn = new SqlConnection(strcon);
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.Connection = conn;
            //    conn.Open();
            //    cmd.CommandText = "SELECT vCoat, COUNT(vCoat) AS 'Coat' FROM [tbl_RTIS_Zect_Jobs] WHERE vLotNumber=" + "'" + lNum + "' GROUP BY vCoat";
            //    SqlDataReader dataReader = cmd.ExecuteReader();
            //    dataReader.Read();
            //    if (dataReader.HasRows == true)
            //    {
            //        try
            //        {

            //            SqlConnection conn2 = new SqlConnection(strcon);
            //            SqlCommand cmd2 = new SqlCommand();
            //            cmd2.Connection = conn2;
            //            conn2.Open();
            //            cmd2.CommandText = "SELECT vCoat, COUNT(vCoat) AS 'Coat' FROM [tbl_RTIS_Zect_Jobs] WHERE vLotNumber=" + "'" + lNum + "' AND vCoat='1st' GROUP BY vCoat";
            //            SqlDataReader dataReader2 = cmd2.ExecuteReader();
            //            dataReader2.Read();

            //            if (dataReader2.HasRows == true)
            //            {
            //                msg = new frmMsg(lNum, "Lot number already used in first coat",
            //             GlobalVars.msgState.Info);
            //                msg.ShowDialog();
            //                btnfirst.Enabled = false;
            //            }

            //            else
            //            {

            //                try
            //                {
            //                    GlobalVars.OJCoatNumber = GlobalVars.CoatNumber.first;
            //                    ucSelectCoatSlurry slurry = new ucSelectCoatSlurry(parent, main);
            //                    main.pnlMain.Controls.Clear();
            //                    main.pnlMain.Controls.Add(slurry);
            //                }
            //                catch (Exception ex)
            //                {
            //                    ExHandler.showErrorEx(ex);
            //                }
            //            }
            //        }
            //        catch (Exception ex)
            //        {
            //            ExHandler.showErrorEx(ex);
            //        }

            //   }
            //    else
            //    {
            //        msg = new frmMsg(lNum,
            //                "Invalid lot number",
            //                GlobalVars.msgState.Info);
            //        msg.ShowDialog();

            //    }
            //}
            //catch (Exception ex)
            //{
            //    ExHandler.showErrorEx(ex);
            //}
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

        public bool ShowButton()
        {
            return true;
        }

        private void btnSecond_Click(object sender, EventArgs e)
        {
            if (ValidateCoat("1st", "2nd"))
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
        }

        private void btnThird_Click(object sender, EventArgs e)
        {
            if (ValidateCoat("2nd", "3rd"))
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
        }

        private void btnForth_Click(object sender, EventArgs e)
        {
            if (ValidateCoat("3rd", "4th"))
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
        }

        private bool ValidateCoat(string previous, string current)
        {
            try
            {
                SqlConnection conn = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "SELECT vCoat FROM [tbl_RTIS_Zect_Jobs] WHERE vLotNumber=" + "'" + lNum + "' GROUP BY vCoat";
                SqlDataReader dataReader = cmd.ExecuteReader();

                List<string> coats = new List<string>();

                if (dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        coats.Add(dataReader.GetString(0));
                    }

                    if (coats.Contains(previous))
                    {
                        if (!coats.Contains(current))
                        {
                            return true;
                        }
                        else
                        {
                            msg = new frmMsg(lNum, $"Lot number already exist on {current} coat",
                            GlobalVars.msgState.Info);
                            msg.ShowDialog();
                        }
                    }
                    else
                    {
                        msg = new frmMsg(lNum, "Lot number is missing in previous coat",
                        GlobalVars.msgState.Info);
                        msg.ShowDialog();
                    }
                }
                else
                {
                    msg = new frmMsg(lNum, "Lot number is missing in previous coat",
                    GlobalVars.msgState.Info);
                    msg.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }

            return false;

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
