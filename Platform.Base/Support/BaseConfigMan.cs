using Platform.Core.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Caching;
using MySql.Data.MySqlClient;
using Dapper;

namespace Platform.Base.Support
{
    public class BaseConfigMan : CoreConfigMan
    {
        protected override List<Config> GetConfigsFromCache()
        {
            const string CONFIG_CACHE = "CONFIG_CACHE";
            const string TABLE_NAME = "";

            ObjectCache cache = MemoryCache.Default;
            CacheItem cached = cache.GetCacheItem(CONFIG_CACHE);

            List<Config> lists = null;

            if (cached == null)
            {
                try
                {
                    MySqlConnection conn = new MySqlConnection(this.ConnectionString);
                    CacheItemPolicy policy = new CacheItemPolicy();
                    policy.AbsoluteExpiration = DateTime.Now.AddMinutes(5);
                    using (SqlMapper.GridReader multi = conn.QueryMultiple(string.Format(@"SELECT * FROM {0}", TABLE_NAME)))
                    {
                        lists = multi.Read<Config>().AsList();
                    }
                    cached = new CacheItem(CONFIG_CACHE, lists);
                    cache.Set(cached, policy);
                }
                catch (Exception ex)
                {
                    //Log.Error("Error creating cache from DB", ex);
                }
            }
            else
            {
                lists = (List<Config>)cached.Value;
            }

            return lists;
        }
    }
}
