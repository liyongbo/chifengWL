
using BLL.Base;

using System.Collections.Generic;
using System.Text;

namespace BLL
{

    public class Columns
    {
        //const double CacheDuration = 60.0;
        //private static readonly string[] MasterCacheKeyArray = { "ColumnCache" };
        //private static CacheManager bllCache;
        //private static CacheBase bllCache;
        private const string cacheclass = "Column";
        static Columns()
        {
            //bllCache = CacheInstance.GetCacheObj(60.0, "Column", ETimeSpanModel.秒);
            //bllCache = new CacheManager(CacheDuration, MasterCacheKeyArray);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        static public long Add(Entity.Column model)
        {

            long cid = Host.Instance.DALCMS.Column_Add(model);
            if (cid > 0)
            {
                return cid;
            }
            else
            {
                return -1;
            }

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        static public void Update(Entity.Column model)
        {
            Host.Instance.DALCMS.Column_Update(model);
            //Host.CacheApp.InvalidateCache(cacheclass);
        }




        /// <summary>
        /// 删除一条数据
        /// </summary>
        static public void Delete(long id)
        {
            Host.Instance.DALCMS.Column_Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        static public Entity.Column GetModel(long id)
        {
            return Host.Instance.DALCMS.Column_GetModel(id); ;
        }


        static public List<Entity.Column> Column_GetListArray(string strWhere, int top, string orderby, bool ascORdesc)
        {
            return Host.Instance.DALCMS.Column_GetListArray(strWhere, top, orderby, ascORdesc); ;
        }
    }
}
