using Dapper;
using Platform.Core;
using System.Collections.Generic;
using System.Linq;

namespace Platform.Base
{
    public interface ISimpleUkeyRepo<T>
    {
        List<T> GetAll(string where = "");

        T GetById(int Id);

        T GetByUKey(string uKey);
    }

    public class SimpleUkeyRepo<T> : DBAccess, ISimpleUkeyRepo<T> where T : UkeyModel, new() 
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

        public virtual T GetById(int Id)
        {
            T item; // = new T();

            if (Id == 0)
            {
                return new T();
            }

            List<T> lists = GetAll();

            item = lists.Where(x => x.Id == Id).FirstOrDefault();
            if (item == null)
            {
                item = new T();
            }

            return item;
        }

        public virtual T GetByUKey(string ukey)
        {
            T item; // = new T();

            if (ukey == "")
            {
                return new T();
            }

            List<T> lists = GetAll();

            item = lists.Where(x => x.Ukey == ukey).FirstOrDefault();
            if (item == null)
            {
                item = new T();
            }

            return item;
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
