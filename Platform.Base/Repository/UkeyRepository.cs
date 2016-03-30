using System;
using System.Collections.Generic;
using System.Linq;
using Platform.Core;
using Platform.Core.Interface;
using Dapper;

namespace Platform.Base.Repository
{
    public class UkeyRepository<T, Ts> : CoreRepository<T>, IUkeyRepository<T, Ts> 
        where Ts : CoreList<T>, new()
        where T : UkeyModel, new()
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger("UkeyRepository");

        public UkeyRepository() : base() { }

        public virtual Ts GetList()
        {
            return GetList(string.Empty);
        }

        public virtual Ts GetList(string onWhere = "")
        {
            

            Ts lists = new Ts();

            if (!string.IsNullOrEmpty(onWhere))
            {
                onWhere = " AND " + onWhere;
            }

            string sql = string.Format(
                    @"
                    SELECT COUNT(*) as Total FROM {0} WHERE 1=1 {1};
                    SELECT * FROM {0} WHERE 1=1 {1} LIMIT 0, 30"
                    , tableName, onWhere);

            log.InfoFormat("GetList : {0}", sql);

            using (SqlMapper.GridReader multi = GetConnection().QueryMultiple(sql))
            {
                lists.summ = multi.Read<Summary>().Single();
                lists.list = multi.Read<T>().AsList();
            }

            return DecorateAll(lists);
        }

        public virtual T GetByUKey(string ukey)
        {
            T item;

            if (ukey == "")
            {
                return new T();
            }

            IEnumerable<T> lists = GetItems(string.Format("ukey = '{0}'", ukey));

            item = lists.Where(x => x.Ukey == ukey).FirstOrDefault();
            if (item == null)
            {
                item = new T();
            }

            return DecorateOne(item);
        }

        protected virtual T DecorateOne(T item)
        {
            return item;
        }

        public bool UpdateUkey(int id, string ukey)
        {
            throw new NotImplementedException();
        }

        protected virtual Ts DecorateAll(Ts lists)
        {
            return lists;
        }
    }
}
