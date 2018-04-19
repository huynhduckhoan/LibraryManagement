using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management
{
    class DBSQLServerUtils
    {
        public static SqlConnection GetDBConnection(string datasource, string database, string username, string password)
        {
            //
            // Data Source=KHOAN\SQLEXPRESS;Initial Catalog=LibraryManagement;Persist Security Info=True;User ID=sa;Password=123
            //
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;User ID=" + username + ";Password=" + password + ";MultipleActiveResultSets=True";

            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }

        public static SqlConnection DBConnection()
        {
            string datasource = @"WINDOWS\SQLEXPRESS";

            string database = "LibraryManagement";
            string username = "sa";
            string password = "123";

            return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
        }

    }
}
