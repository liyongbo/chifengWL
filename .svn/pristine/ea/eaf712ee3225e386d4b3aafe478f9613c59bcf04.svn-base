using BLL.Base;
using Entity;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL
{

    public class AreaRRole
    {
        private const string cacheclass = "AreaRRole";
        static AreaRRole()
        {
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        static public long Add(Entity.AreaRRole model)
        {

            long cid = Host.Instance.DALCMS.AreaRRole_Add(model);
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
        static public void Update(Entity.AreaRRole model)
        {
            Host.Instance.DALCMS.AreaRRole_Update(model);
            //Host.CacheApp.InvalidateCache(cacheclass);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        static public void Update(string where, string colunm, string value)
        {
            Host.Instance.DALCMS.AreaRRole_Update(where, colunm, value);
            //Host.CacheApp.InvalidateCache(cacheclass);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        static public void Delete(long id)
        {
            Host.Instance.DALCMS.AreaRRole_Delete(id);
        }
        static public void Delete(string ids)
        {
            Host.Instance.DALCMS.AreaRRole_Deletes(ids);
        }
        static public void DeleteBySql(string sql)
        {
            Host.Instance.DALCMS.AreaRRole_DeleteBySql(sql);
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        static public Entity.AreaRRole GetModel(string id)
        {
            return Host.Instance.DALCMS.AreaRRole_GetModel(id); ;
        }


        static public List<Entity.AreaRRole> AreaRRole_GetListArray(string strWhere, int top, string orderby, bool ascORdesc)
        {
            return Host.Instance.DALCMS.AreaRRole_GetListArray(strWhere, top, orderby, ascORdesc); ;
        }
        static public List<Entity.AreaRRole> AreaRRole_GetListArrayBySql(string sql)
        {
            return Host.Instance.DALCMS.AreaRRole_GetListArrayBySql(sql);
        }
        static public List<Entity.AreaRRole> AreaRRole_GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, bool ascending, out long rc)
        {
            return Host.Instance.DALCMS.AreaRRole_GetListPages(PageIndex, PageSize, strWhere, oderby, ascending, out  rc);
        }
    }
}
