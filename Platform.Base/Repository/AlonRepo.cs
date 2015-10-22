using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Platform.Core;
using Platform.Core.Interface;

namespace Platform.Base.Repository
{

    public class AlonRepo<T, TS> : CoreRepo<T>, IAlonRepo<T> where T : AlonModel where TS : CoreList<T>, new()
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAllDeleted()
        {
            throw new NotImplementedException();
        }

        public bool Lock(int id)
        {
            throw new NotImplementedException();
        }

        public bool Recall(int id)
        {
            throw new NotImplementedException();
        }

        public bool SetOffLine(int id)
        {
            throw new NotImplementedException();
        }

        public bool SetOnline(int id)
        {
            throw new NotImplementedException();
        }

        public bool UnLock(int id)
        {
            throw new NotImplementedException();
        }

        protected virtual TS DecorateAll(TS lists)
        {
            return lists;
        }

        protected virtual T DecorateOne(T item)
        {
            return item;
        }

        public TS GetList(string onWhere = "")
        {
            TS lists = new TS();

            if (!string.IsNullOrEmpty(onWhere))
            {
                onWhere = " AND " + onWhere;
            }

            using (SqlMapper.GridReader multi = GetConnection().QueryMultiple(string.Format(
                    @"
                    SELECT COUNT(*) as Total FROM {0} WHERE 1=1 {1};
                    SELECT * FROM {0} WHERE 1=1 {1} LIMIT 0, 3"
                    , tableName, onWhere)))
            {
                lists.summ = multi.Read<Summary>().Single();
                lists.list = multi.Read<T>().AsList();
            }

            return DecorateAll(lists);

        }
    }
}
