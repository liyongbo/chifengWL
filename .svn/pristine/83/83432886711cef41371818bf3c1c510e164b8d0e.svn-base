using System;
using System.Collections.Generic;

using Tools;

namespace Configs.ConfigsBase
{
    public class ListConfigsManager<IConfigModel>
    {
        //private  List<IConfigModel> m_configinfo;

        /// <summary>
        /// 文件修改时间
        /// </summary>
        private bool isChange;
        /// <summary>
        /// 配置文件所在路径
        /// </summary>
        private string _filename;



        const double CacheDuration = 60.0;
        private const string CacheListConfig = "listconfig";// private readonly string[] MasterCacheKeyArray = { "ListConfigCache" };
        // private CacheManager ConfigCache;
        /// <summary>
        /// 初始化文件修改时间和对象实例
        /// </summary>
        public ListConfigsManager(string filename)
        {
            _filename = filename;


            DateTime dtNew = System.IO.File.GetLastWriteTime(_filename);


            string rawKey = string.Concat("Date-", filename);
            //string sOld = Host.CacheApp.GetCacheItem<string>(rawKey, CacheListConfig);  

            //if (sOld == null || (DateTime.Parse(sOld)!= dtNew))
            //{
            //    Host.CacheApp.AddCacheItem(rawKey, dtNew, CacheDuration, ETimeSpanModel.秒, CacheListConfig);//  ConfigCache.AddCacheItem(rawKey, dtNew.ToString());
            //    isChange = true;
            //}
            //else
            //{
            //    isChange = false;
            //}
        }

        /// <summary>
        /// 返回配置类实例
        /// </summary>
        /// <returns></returns>
        public List<IConfigModel> LoadConfig()
        {
            //string rawKey = string.Concat("Model-", _filename);
            //List<IConfigModel> lst = Host.CacheApp.GetCacheItem<List<IConfigModel>>(rawKey, CacheListConfig);//(List<IConfigModel>)ConfigCache.GetCacheItem(rawKey);

            //if (lst == null || isChange)
            //{
            //    lst = DeserializeInfo();
            //    if (lst.Count > 0) Host.CacheApp.AddCacheItem(rawKey, lst, CacheDuration, ETimeSpanModel.秒, CacheListConfig);//ConfigCache.AddCacheItem(rawKey, lst);
            //}
            //return lst;

            return null;
        }
        private List<IConfigModel> DeserializeInfo()
        {
            return (List<IConfigModel>)SerializationHelper.Load(typeof(List<IConfigModel>), _filename);
        }

        /// <summary>
        /// 保存配置类实例
        /// </summary>
        /// <returns></returns>
        public bool Save(List<IConfigModel> List)
        {
            return SerializationHelper.Save(List, _filename);
        }
    }
}
