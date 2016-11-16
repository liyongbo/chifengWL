using BLL.Base;
using Entity;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace BLL
{

    public class Destinations
    {
        private const string cacheclass = "Destinations";
        static Destinations()
        {
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        static public long Add(Entity.Destinations model)
        {

            long cid = Host.Instance.DALCMS.Destinations_Add(model);
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
        static public void Update(Entity.Destinations model)
        {
            Host.Instance.DALCMS.Destinations_Update(model);
            //Host.CacheApp.InvalidateCache(cacheclass);
        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        static public void Update(string where, string colunm, string value)
        {
            Host.Instance.DALCMS.Destinations_Update(where, colunm, value);
            //Host.CacheApp.InvalidateCache(cacheclass);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        static public void Delete(long id)
        {
            Host.Instance.DALCMS.Destinations_Delete(id);
        }
        static public void Delete(string ids)
        {
            Host.Instance.DALCMS.Destinations_Deletes(ids);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        static public Entity.Destinations GetModel(string id)
        {
            return Host.Instance.DALCMS.Destinations_GetModel(id); ;
        }


        static public List<Entity.Destinations> Destinations_GetListArray(string strWhere, int top, string orderby, bool ascORdesc)
        {
            return Host.Instance.DALCMS.Destinations_GetListArray(strWhere, top, orderby, ascORdesc); ;
        }
        static public List<Entity.Destinations> Destinations_GetListArrayBySql(string sql)
        {
            return Host.Instance.DALCMS.Destinations_GetListArrayBySql(sql);
        }
        static public List<Entity.Destinations> Destinations_GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, bool ascending, out long rc)
        {
            return Host.Instance.DALCMS.Destinations_GetListPages(PageIndex, PageSize, strWhere, oderby, ascending, out  rc);
        }


        /// <summary>
        /// 获得一个datatable
        /// </summary>
        static public DataTable getDataSet(string sql)
        {
           return Host.Instance.DALCMS.Destinations_DataSet(sql);
        }
    }
}