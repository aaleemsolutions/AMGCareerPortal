using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BAL.Ado.Net
{
    public class AdoDbClass
    {
        SqlConnection dbconn;
        SqlCommand sqlCmd;
        SqlDataAdapter sdp;
        SqlDataReader sdr;

        public string ConnectionString { get; set; }

        public AdoDbClass()
        {
            ConnectionString =  GlobalFields.GetConnectionString(true);
            dbconn = new SqlConnection(ConnectionString);
            sqlCmd = new SqlCommand();
            sdp = new SqlDataAdapter();
   
        }

        public AdoDbClass(string connectionS)
        {
            
            dbconn = new SqlConnection(connectionS);
            sqlCmd = new SqlCommand();

        }

        public void CallSqlConnection( string ConnectionString = "")
        {

            if (ConnectionString!=null && ConnectionString!="")
            {
                dbconn.ConnectionString = ConnectionString;
            }
            
            if (dbconn.State==System.Data.ConnectionState.Open)
            {
                dbconn.Close();
            }

            dbconn.Open();
        }

        public void CloseSqlConnection(string ConnectionString = "")
        {           
                dbconn.Close();

                
        }

        public int ExecuteNonquery(string query,string connectionstring, SqlParameter[] Params)
        {
            try
            {

                sqlCmd.CommandText = query;
                if (Params!=null)
                {
                    sqlCmd.Parameters.Add(Params);
                }
                CallSqlConnection();
                sqlCmd.ExecuteNonQuery();
                CloseSqlConnection();

                return 1;

            }
            catch (Exception ex)
            {

                return 0;
            }

        }

        public DataTable GetDT(string query,  SqlParameter[] Params, string connectionstring = "")
        {
            try
            {
                DataTable dt = new DataTable();
                sqlCmd.CommandText = query;
                sqlCmd.Connection = dbconn;
                if (Params != null)
                {
                    sqlCmd.Parameters.Add(Params);
                }
                sdp.SelectCommand  = sqlCmd;
                
                CallSqlConnection();
                sdp.Fill(dt);
                CloseSqlConnection();

                return dt;

            }
            catch (Exception ex)
            {

                return null;
            }

        }

        public SqlDataReader GetReader(string query, SqlParameter[] Params, CommandType commandType = CommandType.Text, string connectionstring = "")
        {
            try
            {
                
                sqlCmd.CommandText = query;
                sqlCmd.CommandType = commandType;
                sqlCmd.Connection = dbconn;
                if (Params != null)
                {
                    sqlCmd.Parameters.Add(Params);
                }
                sdp.SelectCommand = sqlCmd;

                CallSqlConnection();
                sdr =  sqlCmd.ExecuteReader();
             
                return sdr;

            }
            catch (Exception ex)
            {

                return null;
            }

        }



    }
}
