using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace To_Do_List_Manager.Helpers
{
    public class DBHelper
    {
        public static string conStr = "YOUR CONNECTION STRING";

        public static SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(conStr);
            connection.Open();
            
            return connection;
        }
    }
}
