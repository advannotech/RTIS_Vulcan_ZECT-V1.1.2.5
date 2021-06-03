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
            try
            {
                string cCode = GlobalVars.OJCheckSheet;
                string lNum = GlobalVars.OJLotNumber;

                SqlConnection conn = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "SELECT * FROM [tbl_RTIS_Zect_Jobs] WHERE " + "'" + cCode + "' LIKE '%1st%' AND " + "'" + cCode + "'  NOT LIKE '%2nd%' AND " + "'" + cCode + "' NOT LIKE '%3rd%' AND " + "'" + cCode + "'  NOT LIKE '%4th%' AND vLotNumber = " + "'" + lNum + "' ORDER BY vLotNumber";
                //cmd.CommandText = "SELECT * FROM [tbl_RTIS_Zect_Jobs]  WHERE vCatalystCode= " + "'" + cCode + "'";

                SqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                if (dataReader.HasRows == true)
                {
                    msg = new frmMsg(lNum,
                          "Lot number is already used in first coat",
                          GlobalVars.msgState.Info);
                    msg.ShowDialog();
                    btnfirst.Visible = false;
                    btnThird.Visible = false;
                    btnForth.Visible = false;
                }
                else
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
            try
            {
                string cCode = GlobalVars.OJCheckSheet;
                string lNum = GlobalVars.OJLotNumber;

                SqlConnection conn = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "SELECT * FROM [tbl_RTIS_Zect_Jobs] WHERE " + "'" + cCode + "' LIKE '%2nd%' AND " + "'" + cCode + "'  NOT LIKE '%1st%' AND " + "'" + cCode + "' NOT LIKE '%3rd%' AND " + "'" + cCode + "'  NOT LIKE '%4th%' AND vLotNumber = " + "'" + lNum + "' ORDER BY vLotNumber";
                //cmd.CommandText = "SELECT * FROM [tbl_RTIS_Zect_Jobs]  WHERE vCatalystCode= " + "'" + cCode + "'";

                SqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                if (dataReader.HasRows == true)
                {
                    msg = new frmMsg(lNum,
                          "Lot number is already used in second coat",
                          GlobalVars.msgState.Info);
                    msg.ShowDialog();
                    btnfirst.Visible = false;
                    btnSecond.Visible = false;
                    btnForth.Visible = false;
                }
                else
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
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
           
        }

        private void btnThird_Click(object sender, EventArgs e)
        {
            try
            {
                string cCode = GlobalVars.OJCheckSheet;
                string lNum = GlobalVars.OJLotNumber;

                SqlConnection conn = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "SELECT * FROM [tbl_RTIS_Zect_Jobs] WHERE " + "'" + cCode + "' LIKE '%3rd%' AND " + "'" + cCode + "'  NOT LIKE '%1st%' AND " + "'" + cCode + "' NOT LIKE '%2nd%' AND " + "'" + cCode + "'  NOT LIKE '%4th%' AND vLotNumber = " + "'" + lNum + "' ORDER BY vLotNumber";
                //cmd.CommandText = "SELECT * FROM [tbl_RTIS_Zect_Jobs]  WHERE vCatalystCode= " + "'" + cCode + "'";

                SqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                if (dataReader.HasRows == true)
                {
                    msg = new frmMsg(lNum,
                          "Lot number is already used in third coat",
                          GlobalVars.msgState.Info);
                    msg.ShowDialog();
                    btnfirst.Visible = false;
                    btnSecond.Visible = false;
                    btnThird.Visible = false;
                }
                else
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
            catch (Exception ex)
            {
                ExHandler.showErrorEx(ex);
            }
        }

        private void btnForth_Click(object sender, EventArgs e)
        {
            try
            {
                string cCode = GlobalVars.OJCheckSheet;
                string lNum = GlobalVars.OJLotNumber;

                SqlConnection conn = new SqlConnection(strcon);
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                conn.Open();
                cmd.CommandText = "SELECT * FROM [tbl_RTIS_Zect_Jobs] WHERE " + "'" + cCode + "' LIKE '%4th%' AND " + "'" + cCode + "'  NOT LIKE '%1st%' AND " + "'" + cCode + "' NOT LIKE '%2nd%' AND " + "'" + cCode + "'  NOT LIKE '%3rd%' AND vLotNumber = " + "'" + lNum + "' ORDER BY vLotNumber";
                //cmd.CommandText = "SELECT * FROM [tbl_RTIS_Zect_Jobs]  WHERE vCatalystCode= " + "'" + cCode + "'";

                SqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                if (dataReader.HasRows == true)
                {
                    msg = new frmMsg(lNum,
                          "Lot number is already used in fourth coat",
                          GlobalVars.msgState.Info);
                    msg.ShowDialog();
                    btnfirst.Enabled = false;
                    btnSecond.Enabled = false;
                    btnThird.Enabled = false;
                    btnForth.Enabled = false;
                }
                else
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
