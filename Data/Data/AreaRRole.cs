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
	    private const string pkAreaRRole = "[id]";
        private const string whereAreaRRole_byid = "[id]={0}";
        private const string tableAreaRRole = "AreaRRole";
        private const string AreaRRolefileds = "[regonid],[regonname],[roleid],[rolename]";
        private const string AreaRRolefiledsList = "[regonid],[regonname],[roleid],[rolename]";
        #region 读
        public Entity.AreaRRole AreaRRole_ReaderBind(IDataReader dataReader)
        {
            Entity.AreaRRole model = new Entity.AreaRRole();
            object ojb;
             
            ojb = ReaderExists(dataReader, "id");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            } 
			 
            ojb = ReaderExists(dataReader, "regonid");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.regonid = (int)ojb;
            } 
			 
            ojb = ReaderExists(dataReader, "regonname");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.regonname = (string)ojb;
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
        public Entity.AreaRRole AreaRRole_GetModel(string ID)
        {
            Entity.AreaRRole model = new AreaRRole();
            using (IDataReader dataReader = getDataReader( string.Concat(sPre, tableAreaRRole), string.Concat(pkAreaRRole, ",", AreaRRolefileds), "id", 1, true, string.Format(whereAreaRRole_byid, ID)))
            {
                if (dataReader.Read())
                {
                    model = AreaRRole_ReaderBind(dataReader);
                }
            }
            return model;
        }
        
        /// <summary>
        /// 分页获取数据列表 
        /// </summary>
        public List<Entity.AreaRRole> AreaRRole_GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, bool ascending,out long recordCount)
        {
            List<Entity.AreaRRole> list = new List<Entity.AreaRRole>();
            DbParameter[] parameters = getParmeters(string.Concat(sPre, tableAreaRRole), string.Concat(pkAreaRRole, ",", AreaRRolefiledsList), oderby, PageSize, PageIndex, ascending, strWhere);

            using (DbDataReader dr = DbHelperCms.Instance.ExecuteReader(CommandType.StoredProcedure, string.Concat(sPre, "pro_selectByPage"), parameters))
            {
                while (dr.Read())
                {
                    list.Add(AreaRRole_ReaderBind(dr));
                }
            }
            recordCount = long.Parse(parameters[7].Value.ToString());
            return list;
        }
        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.AreaRRole> AreaRRole_GetListArray(string strWhere, int iTop, string OrderBy, bool ascORdesc)
        {
            List<Entity.AreaRRole> list = new List<Entity.AreaRRole>();
            using (IDataReader dataReader = getDataReader(string.Concat(sPre, tableAreaRRole), string.Concat(pkAreaRRole, ",", AreaRRolefiledsList), OrderBy, iTop, ascORdesc, strWhere))
            {
                while (dataReader.Read())
                {
                    list.Add(AreaRRole_ReaderBind(dataReader));
                }
            }
            return list;
        }
        
        /// <summary>
        /// 根据sql获取列表
        /// </summary>
        public List<Entity.AreaRRole> AreaRRole_GetListArrayBySql(string sql)
        {
            List<Entity.AreaRRole> list = new List<Entity.AreaRRole>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, sql))
            {
                while (dataReader.Read())
                {
                    list.Add(AreaRRole_ReaderBind(dataReader));
                }
            }
            return list;
        }
         #endregion 读
         
        #region 写

        public long AreaRRole_Add(Entity.AreaRRole model)
        {
            List<TableFile> list = new List<TableFile>();
            TableFile tf = new TableFile();
                        tf.Name = "regonid";
            tf.Value = model.regonid;
            tf.dbType = SqlDbType.Int;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "regonname";
            tf.Value = model.regonname;
            tf.dbType = SqlDbType.VarChar;
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
                       
            return Tools.Utils.ObjectToLong(Add(list, tableAreaRRole));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int AreaRRole_Update(Entity.AreaRRole model)
        {

            List<TableFile> list = new List<TableFile>();

            TableFile tf = new TableFile();
                        tf.Name = "regonid";
            tf.Value = model.regonid;
            tf.dbType = SqlDbType.Int;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "regonname";
            tf.Value = model.regonname;
            tf.dbType = SqlDbType.VarChar;
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
            return update(list, tableAreaRRole, listwhere);
        }
        /// <summary>
        /// 更新一列数据
        /// </summary>
        public void AreaRRole_Update(string Where, string Col, string sValue)
        {
            if (!string.IsNullOrEmpty(Where))
            {
                StringBuilder strSql = new StringBuilder();
                if (!Col.Contains(","))
                {
                    strSql.AppendFormat("update {0}" + tableAreaRRole + " set {1}={2} where {3}", sPre, Col, sValue, Where);
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
                        strSql.AppendFormat("update {0}" + tableAreaRRole + " set {1} where {2}", sPre, setsql, Where);
                        DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
                    }
                }
            }
        }
        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="IDs">ID列表，用逗号分开</param>
        public void AreaRRole_Deletes(string IDs)
        {
            DeleteS(IDs, tableAreaRRole, null, null);

        }
        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="IDs">ID列表，用逗号分开</param>
        public void AreaRRole_DeleteBySql(string sql)
        {
            DbHelperCms.Instance.ExecuteNonQuery(CommandType.Text, sql);
        }
        
        /// <summary>
        /// 删除分类时要更新比当前分类排序ID大的orderid - 1
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public void AreaRRole_Delete(long id)
        {
            List<TableFile> listwhere = new List<TableFile>();
            TableFile tf = new TableFile();
            tf.Name = "id";
            tf.Value = id;
            tf.dbType = SqlDbType.BigInt;
            listwhere.Add(tf);
            Delete(tableAreaRRole, listwhere);
        }
        #endregion 写
	}
}