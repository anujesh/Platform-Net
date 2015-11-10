using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Platform.Core;
using Platform.Core.Interface;

namespace Platform.Base.Repository
{
    //public interface IAlonRepository<T, Ts> : IUkeyRepository<T> where T : AlonModel where Ts : CoreList<AlonModel>, new()
    public class AlonRepository<T, Ts> : UkeyRepository<T, Ts>, IAlonRepository<T, Ts> where Ts : CoreList<T>, new() where T : AlonModel, new()
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



        protected virtual T DecorateOne(T item)
        {
            return item;
        }

        public Ts GetList(string onWhere = "")
        {
            Ts lists = new Ts();

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

        public virtual Ts GetList()
        {
            return GetList(string.Empty);
        }
    }
}
