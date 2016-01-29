using Dapper;
using Platform.Core;
using Platform.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Platform.Base.Repository
{
    public class CoreRepository<T> : DBAccess, ICoreRepository<T>
        where T : CoreModel
    {
        public string tableName = "~";
        protected string fieldList = "*";
        protected string primaryKey = "~";

        public string GetFieldList()
        {
            string ss = "";
            foreach (var prop in typeof(T).GetProperties())
            {
                ss = ss + prop.Name;
            }

            return ss;
        }

        private string getSelectList()
        {
            return fieldList.Replace('|', ','); // .Split("|").ToList().ForEach(s => "@" + s.Trim());
        }

        private string getInsertValues()
        {
            return "@" + fieldList.Replace(",", ",@");
        }

        private string getUpdateValues()
        {
            List<string> tempList = fieldList.Split(',').ToList();

            string output = "";
            foreach (string field in tempList)
            {
                output = output + string.Format("{0} = @{0}", field);
            }

            return output;
        }

        public T GetById(int id)
        {
            T output = null;
            using (var conn = GetOpenConnection())
            {
                string query = string.Format(@"SELECT * FROM {0} WHERE Id = {1}", tableName, id);

                if (conn.Query<T>(query).Count() > 0)
                {
                    output = conn.Query<T>(query).SingleOrDefault();
                    output = FindItem(output);
                }
            }

            return output;

            //return DecorateOne(output);
        }

        // cache able ?
        //public virtual T GetById(int Id)
        //{
        //    T item; // = new T();

        //    if (Id == 0)
        //    {
        //        return new T();
        //    }

        //    List<T> lists = GetAll();

        //    item = lists.Where(x => x.Id == Id).FirstOrDefault();
        //    if (item == null)
        //    {
        //        item = new T();
        //    }

        //    return item;
        //}

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

  



        public T GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetItems(string onWhere = "")
        {
            IEnumerable<T> lists = null;// = new IList<T>();

            if (!string.IsNullOrEmpty(onWhere))
            {
                onWhere = " AND " + onWhere;
            }

            using (SqlMapper.GridReader multi = GetConnection().QueryMultiple(string.Format(
                    @"
                    SELECT * FROM {0} WHERE 1=1 {1} LIMIT 0, 3"
                    , tableName, onWhere)))
            {
                lists = multi.Read<T>().AsList();
            }

            return lists;// DecorateAll(lists);
        }

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllDeleted()
        {
            throw new NotImplementedException();
        }
        //public virtual List<T> GetItems(string onWhere = "")
        //{
        //    List<T> list = new List<T>();

        //    if (!string.IsNullOrEmpty(onWhere))
        //    {
        //        onWhere = " AND " + onWhere;
        //    }

        //    using (SqlMapper.GridReader multi = GetConnection().QueryMultiple(string.Format(
        //            @"
        //            SELECT * FROM {0} WHERE 1=1 {1}"
        //            , tableName, onWhere)))
        //    {
        //        list = multi.Read<T>().AsList();
        //    }

        //    return list;
        //}
    }
}
