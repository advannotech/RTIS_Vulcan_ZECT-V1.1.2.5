using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace RTIS_Vulcan_ZECT
{
    public class csDAL
    {
        private string strConn = ConfigurationManager.ConnectionStrings["csConnectionString"].ConnectionString.ToString();

        private SqlConnection conn;
        private string err = string.Empty;

        public csDAL()
        {
            conn = new SqlConnection();
        }
        public string Connection_String
        {
            get
            {
                return strConn;
            }
            set
            {
                strConn = value;
            }
        }
        // Open the conection to the database
        private bool Open_Connection()
        {
            if (conn.State == ConnectionState.Closed)
            {
                try
                {
                    conn.ConnectionString = Connection_String;
                    conn.Open();
                    return true;
                }
                catch (Exception ex)
                {
                    err = "" + ex.Message;
                    return false;
                }
            }
            else
            {
                return true;
            }
        }
        // Close the conection to the database
        private void Close_Conn()
        {
            if (conn.State == ConnectionState.Open)
            {
                conn.Close();
            }
            conn = null;

        }
        //Add SQL Parameters
        public SqlParameter add_parameters(csParameterListType obj)
        {
            SqlParameter sqlpar = new SqlParameter();
            sqlpar.ParameterName = obj.Name;
            sqlpar.SqlDbType = obj.Sqltype;
            sqlpar.SqlValue = obj.Value;
            return sqlpar;
        }
        public void executespreturnndr(string spname)
        {
            SqlCommand cmd = new SqlCommand();
            try
            {
                if (Open_Connection())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = spname;
                    cmd.ExecuteNonQuery();
                    Close_Conn();
                }
            }
            catch (Exception ex)
            {
                err = "" + ex.Message;
            }
        }
        // Select Query
        //Using Data set
        public System.Data.DataSet executespreturnds(string spname, List<csParameterListType> objlist)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                if (Open_Connection())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = spname;
                    foreach (csParameterListType par in objlist)
                    {
                        cmd.Parameters.Add(add_parameters(par));
                    }
                    sda.SelectCommand = cmd;
                    sda.Fill(ds);
                }
                Close_Conn();
                return ds;
            }
            catch (Exception ex)
            {
                err = "" + ex.Message;
                return null;
            }
        }
        public System.Data.DataSet executespreturnds(string spname)
        {
            SqlCommand cmd = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter();
            DataSet ds = new DataSet();
            try
            {
                if (Open_Connection())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = spname;
                    sda.SelectCommand = cmd;
                    sda.Fill(ds);
                }
                Close_Conn();
                return ds;
            }
            catch (Exception ex)
            {
                err = "" + ex.Message;
                return null;
            }
        }

        //To ADD, UPDATE and DELETE Method
        public void executespreturnndr(string spname, List<csParameterListType> objlist)
        {
            SqlCommand cmd = new SqlCommand();

            try
            {
                if (Open_Connection())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.CommandText = spname;

                    foreach (csParameterListType par in objlist)
                    {
                        cmd.Parameters.Add(add_parameters(par));
                    }

                    cmd.ExecuteNonQuery();

                }
            }
            catch (Exception e)
            {
                err += " " + e.Message;
            }
        }

        // Return Data Reader
        public IDataReader executesoreturndr(string spname, List<csParameterListType> objlist)
        {
            SqlCommand cmd = new SqlCommand();
            System.Data.IDataReader dr = null;
            try
            {
                if (Open_Connection())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = spname;
                    foreach (csParameterListType par in objlist)
                    {
                        cmd.Parameters.Add(add_parameters(par));
                    }
                    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                }
                return dr;
            }
            catch (Exception ex)
            {
                err = "" + ex.Message;
                return null;
            }
        }
        public IDataReader executesoreturndr(string spname)
        {
            SqlCommand cmd = new SqlCommand();
            System.Data.IDataReader dr = null;
            try
            {
                if (Open_Connection())
                {
                    cmd.Connection = conn;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.CommandText = spname;
                    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                }
                return dr;
            }
            catch (Exception ex)
            {
                err = "" + ex.Message;
                return null;
            }
        }


    }
}
