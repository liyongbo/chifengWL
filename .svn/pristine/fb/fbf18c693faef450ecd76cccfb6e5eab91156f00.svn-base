using System;
using Tools;

namespace Data.DataProfile
{
    public class ConfigsManager<ConfigModel>
    {
        /// <summary>
        /// 文件修改时间
        /// </summary>
        private bool isChange;
        /// <summary>
        /// 配置文件所在路径
        /// </summary>
        private string _filename;


        const double CacheDuration = 60.0;
        private readonly string[] MasterCacheKeyArray = { "ConfigCache" };
        private CacheRaw ConfigCache;
        /// <summary>
      

      
        private ConfigModel DeserializeInfo()
        {
            try
            {
                return (ConfigModel)SerializationHelper.Load(typeof(ConfigModel), _filename);
            }
            catch (Exception e)
            {

                throw new Exception(string.Format("配件文件反序列出错，可能是配置文件格式不规范造成,文件:{0},出错信息:{1}", _filename, e.Message));
            }

        }

        /// <summary>
        /// 保存配置类实例
        /// </summary>
        /// <returns></returns>
        public bool Save(ConfigModel ConfigInfo)
        {
            //ConfigCache.InvalidateCache();
            return SerializationHelper.Save(ConfigInfo, _filename);
        }
    }
}
