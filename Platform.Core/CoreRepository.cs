using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Core
{
    public class CoreRepository
    {
    }
}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

using Dapper;

//using Dapper.Contrib.Extensions;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace Booolean.Base.Repository
{
    public interface IBaseRepository<T>
    {
        T Find(int id);
        T Find(string ukey);
    }

    public class BaseRepository<T> where T : class
    {
        protected string tableName = "~";
        protected string fieldList = "~";
        protected string primaryKey = "~";
        
        public string GetFieldList()
        {
            string ss = "";
            foreach (var prop in typeof(T).GetProperties())
            {
                ss = ss +  prop.Name;
            }
            return ss;
        }

        private string getSelectList()
        {
            return fieldList.Replace('|',','); // .Split("|").ToList().ForEach(s => "@" + s.Trim());
        }

        private string getInsertValues()
        {
            return "@" + fieldList.Replace(",", ",@");
        }

        private string getUpdateValues()
        {
            List<string> tempList = fieldList.Split(',').ToList();

            string output = "";
            foreach(string field in tempList)
            {
                output = output + string.Format("{0} = @{0}", field);
            }

            return output;
        }

        protected IDbConnection GetOpenConnection()
        {
            IDbConnection conn = GetConnection();
            conn.Open();
            return conn;
        }

        protected IDbConnection GetConnection()
        {
            IDbConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString);
            return conn;
        }


        public T Find(int id)
        {
            T output = null;
            using (var conn = GetOpenConnection())
            {
                string query = string.Format(@"SELECT * FROM {0} WHERE Id = {1}", tableName, id);
                output = conn.Query<T>(query).SingleOrDefault();
            }
            output = FindPost(output);

            return output;
        }

        public T Find(string ukey)
        {
            T output = null;
            using (var conn = GetOpenConnection())
            {
                string query = string.Format(@"SELECT {2} FROM {0} WHERE Id = {1}", tableName, ukey, fieldList);
                output = conn.Query<T>(query).SingleOrDefault();
            }
            output = FindPost(output);

            return output;
        }

        protected virtual T FindPost(T t)
        {
            return t;
        }
    
        
        public T Add(T page)
        {
            using (var conn = GetOpenConnection())
            {
                var sqlQuery = string.Format(
                @"INSERT INTO 
                            {0} 
                            ({1}) 
                            VALUES
                            ({2});
                        SELECT CAST(SCOPE_IDENTITY() as int)", tableName, fieldList, getInsertValues());
                var pageId = conn.Query<int>(sqlQuery, page).Single();
                //page.@PrimaryId = pageId;
            }
            return page;
        }

        public T Update(T page, int id)
        {
            using (var conn = GetOpenConnection())
            {
                var sqlQuery = string.Format(
                @"UPDATE {0} 
                        SET {3} 
                        WHERE {1} = @{2}", tableName, primaryKey, id, getUpdateValues());
                conn.Execute(sqlQuery, page);
                return page;
            }
        }

        public void Remove(int id)
        {
            using (var conn = GetOpenConnection())
            {
                var sqlQuery = string.Format("Delete From {0} Where EmpID = {1}", tableName, id);
                conn.Execute(sqlQuery);
            }
        }
    }
}
