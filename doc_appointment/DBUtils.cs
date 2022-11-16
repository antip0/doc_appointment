using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace doc_appointment
{
    class DBUtils
    {
        public static MySqlConnection GetDBConnection()
        {
            string host = "localhost";
            int port = 3306;
            string database = "doc_appointment";
            string user = "root";
            string password = "4076";
            return DBMySQLUtils.GetDBConnection(host, port, database, user, password);
        }
    }
}
