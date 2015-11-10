using System;
using System.Collections.Generic;
using System.Linq;
using Platform.Core;
using Platform.Core.Interface;

namespace Platform.Base.Repository
{
    public class UkeyRepository<T, Ts> : CoreRepository<T>, IUkeyRepository<T> where Ts : CoreList<T> where T : UkeyModel, new()
    {
        //public T Find(string ukey)
        //{
        //    T output = null;
        //    using (var conn = GetOpenConnection())
        //    {
        //        string query = string.Format(@"SELECT {2} FROM {0} WHERE Ukey = '{1}'", tableName, ukey, fieldList);
        //        if (conn.Query<T>(query).Count() > 0)
        //        {
        //            output = conn.Query<T>(query).SingleOrDefault();
        //            output = FindItem(output);
        //        }
        //    }

        //    return output;
        //    //return DecorateOne(output);
        //}

        public virtual T GetByUKey(string ukey)
        {
            T item; // = new T();

            if (ukey == "")
            {
                return new T();
            }

            IEnumerable<T> lists = GetItems();

            item = lists.Where(x => x.Ukey == ukey).FirstOrDefault();
            if (item == null)
            {
                item = new T();
            }

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
