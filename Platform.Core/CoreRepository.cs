﻿using Dapper;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;

namespace Platform.Core
{
    public interface IBaseRepository<T, TS>
    {
        T Find(int id);
        T Find(string ukey);
        TS GetAll();
    }

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
            IDbConnection conn = new MySqlConnection(ConfigurationManager.ConnectionStrings["MySqlDB"].ConnectionString);
            return conn;
        }
    }

    public class BaseRepository<T, TS> where T : class where TS : CoreList<T>, new()
    {
        public string tableName = "~";
        protected string fieldList = "*";
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
                
                if (conn.Query<T>(query).Count()>0)
                {
                    output = conn.Query<T>(query).SingleOrDefault();
                    output = FindItem(output);
                }
            }

            return output;
        }

        public T Find(string ukey)
        {
            T output = null;
            using (var conn = GetOpenConnection())
            {
                string query = string.Format(@"SELECT {2} FROM {0} WHERE Ukey = '{1}'", tableName, ukey, fieldList);
                if (conn.Query<T>(query).Count() > 0)
                {
                    output = conn.Query<T>(query).SingleOrDefault();
                    output = FindItem(output);
                }
            }

            return output;
        }

        protected virtual T FindItem(T t)
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

        public TS GetAll()
        {
            TS lists = new TS();

            using (SqlMapper.GridReader multi = GetConnection().QueryMultiple(string.Format(
                    @"
                    SELECT COUNT(*) as Total FROM {0};
                    SELECT * FROM {0} LIMIT 0, 100000"
                    , tableName)))
            {
                lists.summ = multi.Read<Summary>().Single();
                lists.list = multi.Read<T>().AsList();
            }

            return lists;
        }
    }
}
