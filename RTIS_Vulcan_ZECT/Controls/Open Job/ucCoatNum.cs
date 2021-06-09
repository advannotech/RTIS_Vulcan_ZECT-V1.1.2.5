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
using System.Drawing;

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
               // cmd.CommandText = "SELECT * FROM [tbl_RTIS_Zect_Jobs] WHERE " + "'" + cCode + "' LIKE '%1st%' AND " + "'" + cCode + "'  NOT LIKE '%2nd%' AND " + "'" + cCode + "' NOT LIKE '%3rd%' AND " + "'" + cCode + "'  NOT LIKE '%4th%' AND vLotNumber = " + "'" + lNum + "' ORDER BY vLotNumber";
                cmd.CommandText = "SELECT [vCoat] from [tbl_RTIS_Zect_Jobs]  WHERE [vCoat]='1st' AND [vLotNumber]= " + "'" + lNum + "'";
                SqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                if (dataReader.HasRows == true)
                {
                    msg = new frmMsg(lNum,
                          "Lot number already used for |First Coat|",
                          GlobalVars.msgState.Info);
                    msg.ShowDialog();
                    conn.Close();
                    btnfirst.Enabled = false;
                }
                else if(dataReader.HasRows == false)
                {
                    msg = new frmMsg(lNum,
                         "Invalid Lot Number",
                    GlobalVars.msgState.Info);
                    msg.ShowDialog();
                    conn.Close();
                   
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
                // cmd.CommandText = "SELECT * FROM [tbl_RTIS_Zect_Jobs] WHERE " + "'" + cCode + "' LIKE '%1st%' AND " + "'" + cCode + "'  NOT LIKE '%2nd%' AND " + "'" + cCode + "' NOT LIKE '%3rd%' AND " + "'" + cCode + "'  NOT LIKE '%4th%' AND vLotNumber = " + "'" + lNum + "' ORDER BY vLotNumber";
                cmd.CommandText = "SELECT [vCoat] from [tbl_RTIS_Zect_Jobs]  WHERE [vCoat]='2nd' AND [vLotNumber]= " + "'" + lNum + "'";

                SqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                if (dataReader.HasRows == true)
                {
                    msg = new frmMsg(lNum,
                          "Lot number already used for |Second Coat|",
                          GlobalVars.msgState.Info);
                    msg.ShowDialog();
                    conn.Close();
                    btnSecond.Enabled = false;
                }
                else if (dataReader.HasRows == false)
                {
                    msg = new frmMsg(lNum,
                         "Invalid Lot Number",
                    GlobalVars.msgState.Info);
                    msg.ShowDialog();
                    conn.Close();
                    
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
                // cmd.CommandText = "SELECT * FROM [tbl_RTIS_Zect_Jobs] WHERE " + "'" + cCode + "' LIKE '%1st%' AND " + "'" + cCode + "'  NOT LIKE '%2nd%' AND " + "'" + cCode + "' NOT LIKE '%3rd%' AND " + "'" + cCode + "'  NOT LIKE '%4th%' AND vLotNumber = " + "'" + lNum + "' ORDER BY vLotNumber";
                cmd.CommandText = "SELECT [vCoat] from [tbl_RTIS_Zect_Jobs]  WHERE [vCoat]='3rd' AND [vLotNumber]= " + "'" + lNum + "'";

                SqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                if (dataReader.HasRows == true)
                {
                    msg = new frmMsg(lNum,
                          "Lot number already used for |Third Coat|",
                          GlobalVars.msgState.Info);
                    msg.ShowDialog();
                    conn.Close();
                    btnThird.Enabled = false;
                }
                else if (dataReader.HasRows == false)
                {
                    msg = new frmMsg(lNum,
                         "Invalid Lot Number",
                    GlobalVars.msgState.Info);
                    msg.ShowDialog();
                    conn.Close();
                   
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
                // cmd.CommandText = "SELECT * FROM [tbl_RTIS_Zect_Jobs] WHERE " + "'" + cCode + "' LIKE '%1st%' AND " + "'" + cCode + "'  NOT LIKE '%2nd%' AND " + "'" + cCode + "' NOT LIKE '%3rd%' AND " + "'" + cCode + "'  NOT LIKE '%4th%' AND vLotNumber = " + "'" + lNum + "' ORDER BY vLotNumber";
                cmd.CommandText = "SELECT [vCoat] from [tbl_RTIS_Zect_Jobs]  WHERE [vCoat]='4th' AND [vLotNumber]= " + "'" + lNum + "'";

                SqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();
                if (dataReader.HasRows == true)
                {
                    msg = new frmMsg(lNum,
                          "Lot number already used for |Fourth Coat|",
                          GlobalVars.msgState.Info);
                    msg.ShowDialog();
                    conn.Close();
                    btnForth.Enabled = false;
                }
                else if (dataReader.HasRows == false)
                {
                    msg = new frmMsg(lNum,
                         "Invalid Lot Number",
                    GlobalVars.msgState.Info);
                    msg.ShowDialog();
                    conn.Close();
                   
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
