using Dapper;
using Platform.Core;
using Platform.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Platform.Base.Repository
{
    public class AlonRepository<T, Ts> : UkeyRepository<T, Ts>, IAlonRepository<T, Ts> where Ts : CoreList<T>, new() where T : AlonModel, new()
    {

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



        public virtual Ts GetList()
        {
            return GetList(string.Empty);
        }
    }
}
