using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Data.DataProfile;
using System.Data.SqlClient;
using Entity;
using System.Data.Common;

namespace Data
{
	public partial class DataProviderCms
	{
	    private const string pkRoleRTree = "[id]";
        private const string whereRoleRTree_byid = "[id]={0}";
        private const string tableRoleRTree = "RoleRTree";
        private const string RoleRTreefileds = "[treename],[treeid],[roleid],[rolename]";
        private const string RoleRTreefiledsList = "[treename],[treeid],[roleid],[rolename]";
        #region 读
        public Entity.RoleRTree RoleRTree_ReaderBind(IDataReader dataReader)
        {
            Entity.RoleRTree model = new Entity.RoleRTree();
            object ojb;
             
            ojb = ReaderExists(dataReader, "id");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            } 
			 
            ojb = ReaderExists(dataReader, "treename");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.treename = (string)ojb;
            } 
			 
            ojb = ReaderExists(dataReader, "treeid");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.treeid = (int)ojb;
            } 
			 
            ojb = ReaderExists(dataReader, "roleid");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.roleid = (int)ojb;
            } 
			 
            ojb = ReaderExists(dataReader, "rolename");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.rolename = (string)ojb;
            } 
			            return model;
        }
   		
   		/// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.RoleRTree RoleRTree_GetModel(string ID)
        {
            Entity.RoleRTree model = new RoleRTree();
            using (IDataReader dataReader = getDataReader( string.Concat(sPre, tableRoleRTree), string.Concat(pkRoleRTree, ",", RoleRTreefileds), "id", 1, true, string.Format(whereRoleRTree_byid, ID)))
            {
                if (dataReader.Read())
                {
                    model = RoleRTree_ReaderBind(dataReader);
                }
            }
            return model;
        }
        
        /// <summary>
        /// 分页获取数据列表 
        /// </summary>
        public List<Entity.RoleRTree> RoleRTree_GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, bool ascending,out long recordCount)
        {
            List<Entity.RoleRTree> list = new List<Entity.RoleRTree>();
            DbParameter[] parameters = getParmeters(string.Concat(sPre, tableRoleRTree), string.Concat(pkRoleRTree, ",", RoleRTreefiledsList), oderby, PageSize, PageIndex, ascending, strWhere);

            using (DbDataReader dr = DbHelperCms.Instance.ExecuteReader(CommandType.StoredProcedure, string.Concat(sPre, "pro_selectByPage"), parameters))
            {
                while (dr.Read())
                {
                    list.Add(RoleRTree_ReaderBind(dr));
                }
            }
            recordCount = long.Parse(parameters[7].Value.ToString());
            return list;
        }
        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.RoleRTree> RoleRTree_GetListArray(string strWhere, int iTop, string OrderBy, bool ascORdesc)
        {
            List<Entity.RoleRTree> list = new List<Entity.RoleRTree>();
            using (IDataReader dataReader = getDataReader(string.Concat(sPre, tableRoleRTree), string.Concat(pkRoleRTree, ",", RoleRTreefiledsList), OrderBy, iTop, ascORdesc, strWhere))
            {
                while (dataReader.Read())
                {
                    list.Add(RoleRTree_ReaderBind(dataReader));
                }
            }
            return list;
        }
        
        /// <summary>
        /// 根据sql获取列表
        /// </summary>
        public List<Entity.RoleRTree> RoleRTree_GetListArrayBySql(string sql)
        {
            List<Entity.RoleRTree> list = new List<Entity.RoleRTree>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, sql))
            {
                while (dataReader.Read())
                {
                    list.Add(RoleRTree_ReaderBind(dataReader));
                }
            }
            return list;
        }
         #endregion 读
         
        #region 写

        public long RoleRTree_Add(Entity.RoleRTree model)
        {
            List<TableFile> list = new List<TableFile>();
            TableFile tf = new TableFile();
                        tf.Name = "treename";
            tf.Value = model.treename;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "treeid";
            tf.Value = model.treeid;
            tf.dbType = SqlDbType.Int;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "roleid";
            tf.Value = model.roleid;
            tf.dbType = SqlDbType.Int;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "rolename";
            tf.Value = model.rolename;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf); 
            tf = new TableFile();
                       
            return Tools.Utils.ObjectToLong(Add(list, tableRoleRTree));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int RoleRTree_Update(Entity.RoleRTree model)
        {

            List<TableFile> list = new List<TableFile>();

            TableFile tf = new TableFile();
                        tf.Name = "treename";
            tf.Value = model.treename;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "treeid";
            tf.Value = model.treeid;
            tf.dbType = SqlDbType.Int;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "roleid";
            tf.Value = model.roleid;
            tf.dbType = SqlDbType.Int;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "rolename";
            tf.Value = model.rolename;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf); 
            tf = new TableFile();
                        List<TableFile> listwhere = new List<TableFile>();
            tf.Name = "id";
            tf.Value = model.id;
            tf.dbType = SqlDbType.Int;
            listwhere.Add(tf);
            return update(list, tableRoleRTree, listwhere);
        }
        /// <summary>
        /// 更新一列数据
        /// </summary>
        public void RoleRTree_Update(string Where, string Col, string sValue)
        {
            if (!string.IsNullOrEmpty(Where))
            {
                StringBuilder strSql = new StringBuilder();
                if (!Col.Contains(","))
                {
                    strSql.AppendFormat("update {0}" + tableRoleRTree + " set {1}={2} where {3}", sPre, Col, sValue, Where);
                    DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
                }
                else
                {
                    string setsql = string.Empty;
                    string[] arrCol=Col.Split(',');
                    string[] arrValue=sValue.Split(',');
                    for (int i = 0; i < arrCol.Length; i++)
                    {
                        setsql += arrCol[i] + "=" + arrValue[i];
                        if (i < arrCol.Length - 1)
                            setsql += " , ";
                    }
                    if (!string.IsNullOrEmpty(setsql))
                    {
                        strSql.AppendFormat("update {0}" + tableRoleRTree + " set {1} where {2}", sPre, setsql, Where);
                        DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
                    }
                }
            }
        }
        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="IDs">ID列表，用逗号分开</param>
        public void RoleRTree_Deletes(string IDs)
        {
            DeleteS(IDs, tableRoleRTree, null, null);

        }
        /// <summary>
        /// 删除分类时要更新比当前分类排序ID大的orderid - 1
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public void RoleRTree_Delete(long id)
        {
            List<TableFile> listwhere = new List<TableFile>();
            TableFile tf = new TableFile();
            tf.Name = "id";
            tf.Value = id;
            tf.dbType = SqlDbType.BigInt;
            listwhere.Add(tf);
            Delete(tableRoleRTree, listwhere);
        }
        #endregion 写
	}
}