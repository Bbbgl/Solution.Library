using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Library
{
    public class DBConnection
    {
        public class DB
        {
            public static string ConnectionString
            {
                get
                {
                    string connStr = ConfigurationManager.ConnectionStrings["AWConnection"].ToString();

                    SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder(connStr);
                    sb.ApplicationName = ApplicationName ?? sb.ApplicationName;
                    sb.ConnectTimeout = (ConnectionTimeout > 0) ? ConnectionTimeout : sb.ConnectTimeout;
                    return sb.ToString();
                }
            }
            public static SqlConnection GetSqlConnection()
            {
                SqlConnection conn = new SqlConnection(ConnectionString);
                conn.Open();
                return conn;
            }
            public static string ApplicationName
            {
                get;
                set;
            }
            public static int ConnectionTimeout
            {
                get;
                set;
            }
        }
    }
}
