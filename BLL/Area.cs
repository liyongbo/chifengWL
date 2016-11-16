using BLL.Base;
using Entity;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL
{

    public class Area
    {
        private const string cacheclass = "Area";
        static Area()
        {
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        static public long Add(Entity.Area model)
        {

            long cid = Host.Instance.DALCMS.Area_Add(model);
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
        static public void Update(Entity.Area model)
        {
            Host.Instance.DALCMS.Area_Update(model);
            //Host.CacheApp.InvalidateCache(cacheclass);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        static public void Update(string where, string colunm, string value)
        {
            Host.Instance.DALCMS.Area_Update(where, colunm, value);
            //Host.CacheApp.InvalidateCache(cacheclass);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        static public void Delete(long id)
        {
            Host.Instance.DALCMS.Area_Delete(id);
        }
        static public void Delete(string ids)
        {
            Host.Instance.DALCMS.Area_Deletes(ids);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        static public Entity.Area GetModel(string id)
        {
            return Host.Instance.DALCMS.Area_GetModel(id); ;
        }


        static public List<Entity.Area> Area_GetListArray(string strWhere, int top, string orderby, bool ascORdesc)
        {
            return Host.Instance.DALCMS.Area_GetListArray(strWhere, top, orderby, ascORdesc); ;
        }
        static public List<Entity.Area> Area_GetListArrayBySql(string sql)
        {
            return Host.Instance.DALCMS.Area_GetListArrayBySql(sql);
        }
        static public List<Entity.Area> Area_GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, bool ascending, out long rc)
        {
            return Host.Instance.DALCMS.Area_GetListPages(PageIndex, PageSize, strWhere, oderby, ascending, out  rc);
        }
    }
}
