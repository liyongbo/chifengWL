using BLL.Base;
using Entity;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL
{

    public class Role
    {
        private const string cacheclass = "Role";
        static Role()
        {
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        static public long Add(Entity.Role model)
        {

            long cid = Host.Instance.DALCMS.Role_Add(model);
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
        static public void Update(Entity.Role model)
        {
            Host.Instance.DALCMS.Role_Update(model);
            //Host.CacheApp.InvalidateCache(cacheclass);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        static public void Update(string where, string colunm, string value)
        {
            Host.Instance.DALCMS.Role_Update(where, colunm, value);
            //Host.CacheApp.InvalidateCache(cacheclass);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        static public void Delete(long id)
        {
            Host.Instance.DALCMS.Role_Delete(id);
        }
        static public void Delete(string ids)
        {
            Host.Instance.DALCMS.Role_Deletes(ids);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        static public Entity.Role GetModel(string id)
        {
            return Host.Instance.DALCMS.Role_GetModel(id); ;
        }


        static public List<Entity.Role> Role_GetListArray(string strWhere, int top, string orderby, bool ascORdesc)
        {
            return Host.Instance.DALCMS.Role_GetListArray(strWhere, top, orderby, ascORdesc); ;
        }
        static public List<Entity.Role> Role_GetListArrayBySql(string sql)
        {
            return Host.Instance.DALCMS.Role_GetListArrayBySql(sql);
        }
        static public List<Entity.Role> Role_GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, bool ascending, out long rc)
        {
            return Host.Instance.DALCMS.Role_GetListPages(PageIndex, PageSize, strWhere, oderby, ascending, out  rc);
        }
    }
}
