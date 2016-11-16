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
	    private const string pkRole = "[id]";
        private const string whereRole_byid = "[id]={0}";
        private const string tableRole = "Role";
        private const string Rolefileds = "[rolename],[param1],[param2]";
        private const string RolefiledsList = "[rolename],[param1],[param2]";
        #region 读
        public Entity.Role Role_ReaderBind(IDataReader dataReader)
        {
            Entity.Role model = new Entity.Role();
            object ojb;
             
            ojb = ReaderExists(dataReader, "id");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            } 
			 
            ojb = ReaderExists(dataReader, "rolename");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.rolename = (string)ojb;
            } 
			 
            ojb = ReaderExists(dataReader, "param1");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.param1 = (string)ojb;
            } 
			 
            ojb = ReaderExists(dataReader, "param2");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.param2 = (string)ojb;
            } 
			            return model;
        }
   		
   		/// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.Role Role_GetModel(string ID)
        {
            Entity.Role model = new Role();
            using (IDataReader dataReader = getDataReader( string.Concat(sPre, tableRole), string.Concat(pkRole, ",", Rolefileds), "id", 1, true, string.Format(whereRole_byid, ID)))
            {
                if (dataReader.Read())
                {
                    model = Role_ReaderBind(dataReader);
                }
            }
            return model;
        }
        
        /// <summary>
        /// 分页获取数据列表 
        /// </summary>
        public List<Entity.Role> Role_GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, bool ascending,out long recordCount)
        {
            List<Entity.Role> list = new List<Entity.Role>();
            DbParameter[] parameters = getParmeters(string.Concat(sPre, tableRole), string.Concat(pkRole, ",", RolefiledsList), oderby, PageSize, PageIndex, ascending, strWhere);

            using (DbDataReader dr = DbHelperCms.Instance.ExecuteReader(CommandType.StoredProcedure, string.Concat(sPre, "pro_selectByPage"), parameters))
            {
                while (dr.Read())
                {
                    list.Add(Role_ReaderBind(dr));
                }
            }
            recordCount = long.Parse(parameters[7].Value.ToString());
            return list;
        }
        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Role> Role_GetListArray(string strWhere, int iTop, string OrderBy, bool ascORdesc)
        {
            List<Entity.Role> list = new List<Entity.Role>();
            using (IDataReader dataReader = getDataReader(string.Concat(sPre, tableRole), string.Concat(pkRole, ",", RolefiledsList), OrderBy, iTop, ascORdesc, strWhere))
            {
                while (dataReader.Read())
                {
                    list.Add(Role_ReaderBind(dataReader));
                }
            }
            return list;
        }
        
        /// <summary>
        /// 根据sql获取列表
        /// </summary>
        public List<Entity.Role> Role_GetListArrayBySql(string sql)
        {
            List<Entity.Role> list = new List<Entity.Role>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, sql))
            {
                while (dataReader.Read())
                {
                    list.Add(Role_ReaderBind(dataReader));
                }
            }
            return list;
        }
         #endregion 读
         
        #region 写

        public long Role_Add(Entity.Role model)
        {
            List<TableFile> list = new List<TableFile>();
            TableFile tf = new TableFile();
                        tf.Name = "rolename";
            tf.Value = model.rolename;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "param1";
            tf.Value = model.param1;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "param2";
            tf.Value = model.param2;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf); 
            tf = new TableFile();
                       
            return Tools.Utils.ObjectToLong(Add(list, tableRole));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Role_Update(Entity.Role model)
        {

            List<TableFile> list = new List<TableFile>();

            TableFile tf = new TableFile();
                        tf.Name = "rolename";
            tf.Value = model.rolename;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "param1";
            tf.Value = model.param1;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "param2";
            tf.Value = model.param2;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf); 
            tf = new TableFile();
                        List<TableFile> listwhere = new List<TableFile>();
            tf.Name = "id";
            tf.Value = model.id;
            tf.dbType = SqlDbType.Int;
            listwhere.Add(tf);
            return update(list, tableRole, listwhere);
        }
        /// <summary>
        /// 更新一列数据
        /// </summary>
        public void Role_Update(string Where, string Col, string sValue)
        {
            if (!string.IsNullOrEmpty(Where))
            {
                StringBuilder strSql = new StringBuilder();
                if (!Col.Contains(","))
                {
                    strSql.AppendFormat("update {0}" + tableRole + " set {1}={2} where {3}", sPre, Col, sValue, Where);
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
                        strSql.AppendFormat("update {0}" + tableRole + " set {1} where {2}", sPre, setsql, Where);
                        DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
                    }
                }
            }
        }
        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="IDs">ID列表，用逗号分开</param>
        public void Role_Deletes(string IDs)
        {
            DeleteS(IDs, tableRole, null, null);

        }
        /// <summary>
        /// 删除分类时要更新比当前分类排序ID大的orderid - 1
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public void Role_Delete(long id)
        {
            List<TableFile> listwhere = new List<TableFile>();
            TableFile tf = new TableFile();
            tf.Name = "id";
            tf.Value = id;
            tf.dbType = SqlDbType.BigInt;
            listwhere.Add(tf);
            Delete(tableRole, listwhere);
        }
        #endregion 写
	}
}