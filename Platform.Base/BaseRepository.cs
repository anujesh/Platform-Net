using Dapper;
using Platform.Base.Repository;
using Platform.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Platform.Core
{
    public class AdminRepo<T, Ts> : AlonRepo<T, Ts>, IAdminRepo<T, Ts> where T : AdminModel where Ts : CoreList<T>, new()
    {
        public IList<T> GetForModeration()
        {
            throw new NotImplementedException();
        }

        public bool SetStatusTo()
        {
            throw new NotImplementedException();
        }

        public bool ValidateStatusChange()
        {
            throw new NotImplementedException();
        }

        public Ts GetList()
        {
            return base.GetList();
        }
    }

    public class UkeyRepo<T, Ts> : AdminRepo<T, Ts>, IUkeyRepo<T, Ts> where T : UkeyModel where Ts : CoreList<T>, new()
    {
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

            return DecorateOne(output);
        }

        public T GetByUKey(string ukey)
        {
            throw new NotImplementedException();
        }

        public bool UpdateUkey(int id, string ukey)
        {
            throw new NotImplementedException();
        }
    }
}