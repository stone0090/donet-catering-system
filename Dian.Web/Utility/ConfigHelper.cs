using System;
using System.Configuration;

namespace Dian.Web.Utility
{
    /// <summary>
    /// web.config操作类
    /// </summary>
    public sealed class ConfigHelper
    {
        /// <summary>
        /// 得到AppSettings中的配置信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetAppSettings(string key)
        {
            string cacheKey = "AppSettings-" + key;
            object objModel = DataCache.GetCache(cacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = ConfigurationManager.AppSettings[key];
                    if (objModel != null)
                    {
                        DataCache.SetCache(cacheKey, objModel, DateTime.Now.AddMinutes(180), TimeSpan.Zero);
                    }
                }
                catch { ;}
            }
            return objModel != null ? objModel.ToString() : null;
        }
        /// <summary>
        /// 得到AppSettings中的配置String信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetConfigString(string key)
        {
            return GetAppSettings(key);
        }
        /// <summary>
        /// 得到AppSettings中的配置Bool信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool GetConfigBool(string key)
        {
            bool result = false;
            string cfgVal = GetAppSettings(key);
            if (!string.IsNullOrEmpty(cfgVal))
            {
                try
                {
                    result = bool.Parse(cfgVal);
                }
                catch (FormatException)
                {
                    // Ignore format exceptions.
                }
            }
            return result;
        }
        /// <summary>
        /// 得到AppSettings中的配置int信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static int GetConfigInt(string key)
        {
            int result = 0;
            string cfgVal = GetAppSettings(key);
            if (!string.IsNullOrEmpty(cfgVal))
            {
                try
                {
                    result = int.Parse(cfgVal);
                }
                catch (FormatException)
                {
                    // Ignore format exceptions.
                }
            }
            return result;
        }
        /// <summary>
        /// 得到AppSettings中的配置Decimal信息
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static decimal GetConfigDecimal(string key)
        {
            decimal result = 0;
            string cfgVal = GetAppSettings(key);
            if (!string.IsNullOrEmpty(cfgVal))
            {
                try
                {
                    result = decimal.Parse(cfgVal);
                }
                catch (FormatException)
                {
                    // Ignore format exceptions.
                }
            }
            return result;
        }

        public static ConnectionStringSettings GetConnectionStrings(string key)
        {
            string cacheKey = "ConnectionStrings-" + key;
            object objModel = DataCache.GetCache(cacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = ConfigurationManager.ConnectionStrings[key];
                    if (objModel != null)
                    {
                        DataCache.SetCache(cacheKey, objModel, DateTime.Now.AddMinutes(180), TimeSpan.Zero);
                    }
                }
                catch { ;}
            }
            return objModel != null ? (ConnectionStringSettings)objModel : null;
        }
        public static ConnectionStringSettings GetConnectionStrings(int index)
        {
            string cacheKey = "ConnectionStrings-" + index;
            object objModel = DataCache.GetCache(cacheKey);
            if (objModel == null)
            {
                try
                {
                    objModel = ConfigurationManager.ConnectionStrings[index];
                    DataCache.SetCache(cacheKey, objModel, DateTime.Now.AddMinutes(180), TimeSpan.Zero);
                }
                catch { ;}
            }
            return objModel != null ? (ConnectionStringSettings)objModel : null;
        }

        public static string GetDbString(string key)
        {
            var result = GetConnectionStrings(key);
            if (result != null)
            {
                return result.ConnectionString;
            }
            return string.Empty;
        }
        public static string GetDbString(int key)
        {
            var result = GetConnectionStrings(key);
            if (result != null)
            {
                return result.ConnectionString;
            }
            return string.Empty;
        }

        public static string GetDbProviderName(string key)
        {
            var result = GetConnectionStrings(key);
            if (result != null)
            {
                return result.ProviderName;
            }
            return string.Empty;
        }
        public static string GetDbProviderName(int index)
        {
            var result = GetConnectionStrings(index);
            if (result != null)
            {
                return result.ProviderName;
            }
            return string.Empty;
        }

        public static string GetDbName(string key)
        {
            var result = GetConnectionStrings(key);
            if (result != null)
            {
                return result.Name;
            }
            return string.Empty;
        }
        public static string GetDbName(int index)
        {
            var result = GetConnectionStrings(index);
            if (result != null)
            {
                return result.Name;
            }
            return string.Empty;
        }

    }
}
