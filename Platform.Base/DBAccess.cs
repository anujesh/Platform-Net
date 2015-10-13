using MySql.Data.MySqlClient;
using Platform.Core.Utilities;
using System.Data;

namespace Platform.Base
{
    public class DBAccess
    {
        protected IDbConnection GetOpenConnection()
        {
            IDbConnection conn = GetConnection();
            conn.Open();
            return conn;
        }

        protected IDbConnection GetConnection()
        {
            IDbConnection conn = new MySqlConnection(ConnectConfig.MySqlDB);
            return conn;
        }
    }
}
