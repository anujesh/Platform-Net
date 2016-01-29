using System.Configuration;
using System.Data;
using Dapper;
using MySql.Data.MySqlClient;

namespace Platform.Test
{
    class TestDbAccess
    {
        protected IDbConnection GetOpenConnection()
        {
            IDbConnection conn = GetConnection();
            conn.Open();
            return conn;
        }

        protected IDbConnection GetConnection()
        {
            IDbConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlDBTest"].ConnectionString);
            return conn;
        }
        public void ExecuteSQL(string sqlin)
        {
            using (SqlMapper.GridReader multi = GetConnection().QueryMultiple(sqlin))
            {
            }
        }

    }
}
