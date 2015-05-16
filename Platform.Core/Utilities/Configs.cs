

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Runtime.Caching;

using Dapper;

using MySql.Data.MySqlClient;

namespace Platform.Core.Utilities
{

    public interface IConfigManager
    {
        string App_Path_Root { get; }
        string DbPrefix { get; }
        string ConnectionString { get; }
    }

    public enum configSection
    {
        ConnectionConfig,
        AppConfig,
        Platform,
        DbConfig,
        Custom,
        UserSetting
    }

    public abstract class ConfigManager
    {
        public bool IsESBSwitchEnabled
        {
            get { return GetBoolConfig(configSection.AppConfig, "ESB_Switch_Status"); }
        }

        public int DaysToRemember
        {
            get { return GetIntConfig(configSection.AppConfig, "Days_To_Remember"); }
        }

        public string ApplicationName
        {
            get { return GetStringConfig(configSection.AppConfig, "Application_Name"); }
        }

        public string ConnectionString
        {
            get { return GetStringConfig(configSection.ConnectionConfig, "ConnectionString"); }
        }

        public string DbPrefix
        {
            get { return GetStringConfig(configSection.AppConfig, "DB_Object_Prefix"); }
        }

        #region "Core_Functions"
        protected abstract List<Config> GetConfigsFromCache();
        
        protected string GetStringConfig(configSection section, string configKey)
        {
            try
            {
                if (section == configSection.ConnectionConfig)
                {
                    return ConfigurationManager.AppSettings[configKey].ToString();
                }
                else if (section == configSection.ConnectionConfig)
                {
                    return ConfigurationManager.ConnectionStrings[configKey].ConnectionString;
                }
                else
                {
                    List<Config> configs = GetConfigsFromCache();

                    Config config = new Config();
                    config = configs.Where(c => c.ConfigKey == section.ToString() && c.ConfigKey == configKey).SingleOrDefault();
                    return String.IsNullOrEmpty(config.ConfigValue) ? string.Empty : config.ConfigValue;
                }
            }
            catch (Exception ex)
            {
                //ex.Message()
                return string.Empty;
            }
        }

        protected bool GetBoolConfig(configSection section, string configKey)
        {
            bool config = false;

            string value = GetStringConfig(section, configKey);
            bool.TryParse(value, out config);

            return config;
        }

        protected int GetIntConfig(configSection section, string configKey)
        {
            int config = -1;

            string value = GetStringConfig(section, configKey);
            int.TryParse(value, out config);

            return config;
        }
        #endregion Core_Functions
    }

    public class Config
    {
        public string Section { get; set; }
        public string ConfigKey { get; set; }
        public string ConfigValue { get; set; }
        public string Descript { get; set; }
        public DateTime TimeStamp { get; set; }
    }

    public class ConfigMan : ConfigManager
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
                    using (SqlMapper.GridReader multi = conn.QueryMultiple(string.Format(@"
                                                SELECT * FROM {0}", TABLE_NAME)))
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

//Parent object should be listed with only namespace number of child objects}