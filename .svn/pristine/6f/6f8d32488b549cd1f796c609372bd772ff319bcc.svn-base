using BLL.Base;
using Entity;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL
{

    public class Admin
    {

        public static readonly Admin Instance = new Admin();
        //const double CacheDuration = 60.0;
        //private static readonly string[] MasterCacheKeyArray = { "AdminCache" };
        //private static CacheManager bllCache;
        //private static CacheBase bllCache;
        private const string cacheclass = "Admin";
        static Admin()
        {
            //bllCache = CacheInstance.GetCacheObj(60.0, "Admin", ETimeSpanModel.秒);
            //bllCache = new CacheManager(CacheDuration, MasterCacheKeyArray);
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        static public long Add(Entity.Admin model)
        {

            long cid = Host.Instance.DALCMS.Admin_Add(model);
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
        /// 获取用户-根据真实姓名
        /// </summary>
        /// <param name="key">真实姓名</param>
        /// <returns></returns>
        public int GetManagerID(string sUserName)
        {
            return Host.Instance.DALCMS.AdminUser_GetManagerID(sUserName);
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        static public void Update(Entity.Admin model)
        {
            Host.Instance.DALCMS.Admin_Update(model);
            //Host.CacheApp.InvalidateCache(cacheclass);
        }




        /// <summary>
        /// 删除一条数据
        /// </summary>
        static public void Delete(long id)
        {
            Host.Instance.DALCMS.Admin_Delete(id);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        static public Entity.Admin GetModel(long id)
        {
            return Host.Instance.DALCMS.Admin_GetModel(id); ;
        }


        static public List<Entity.Admin> Admin_GetListArray(string strWhere, int top, string orderby, bool ascORdesc)
        {
            return Host.Instance.DALCMS.admin_GetListArray(strWhere, top, orderby, ascORdesc); ;
        }

        static public List<Entity.Admin> Admin_GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, bool ascending, out long rc)
        {
            return Host.Instance.DALCMS.admin_GetListPages(PageIndex, PageSize, strWhere, oderby, ascending,out  rc); 
        }


        static public void Delete(string ids)
        {
            Host.Instance.DALCMS.Admin_Deletes(ids);
        }

    }
}
