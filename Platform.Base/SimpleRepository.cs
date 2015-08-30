using Dapper;
using MySql.Data.MySqlClient;
using Platform.Core;
using Platform.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Base
{
    public interface ISimpleRepository<T>
    {
        List<T> GetAll(string where = "");
    }

    public class SimpleRepository<T> : DBAccess, ISimpleRepository<T> where T : AloModel, new() 
    {
        public string tableName = "~";

        public virtual List<T> GetAll(string onWhere = "")
        {
            List<T> list = new List<T>();

            if (!string.IsNullOrEmpty(onWhere))
            {
                onWhere = " AND " + onWhere;
            }

            using (SqlMapper.GridReader multi = GetConnection().QueryMultiple(string.Format(
                    @"
                    SELECT * FROM {0} WHERE 1=1 {1}"
                    , tableName, onWhere)))
            {
                list = multi.Read<T>().AsList();
            }

            return list;
        }
    }

    //public class MyRepository
    //{
    //    protected IDbConnection GetOpenConnection()
    //    {
    //        IDbConnection conn = GetConnection();
    //        conn.Open();
    //        return conn;
    //    }

    //    protected IDbConnection GetConnection()
    //    {
    //        IDbConnection conn = new MySqlConnection(ConnectConfig.MySqlDB);
    //        return conn;
    //    }
    //}
}
