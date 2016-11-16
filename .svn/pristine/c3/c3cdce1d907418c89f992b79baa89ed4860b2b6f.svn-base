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
	    private const string pkTree = "[id]";
        private const string whereTree_byid = "[id]={0}";
        private const string tableTree = "Tree";
        private const string Treefileds = "[position],[treename],[parentid],[category],[linkurl],[strwhere]";
        private const string TreefiledsList = "[position],[treename],[parentid],[category],[linkurl],[strwhere]";
        #region 读
        public Entity.Tree Tree_ReaderBind(IDataReader dataReader)
        {
            Entity.Tree model = new Entity.Tree();
            object ojb;

            ojb = ReaderExists(dataReader, "position");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.position = (string)ojb;
            } 

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
			 
            ojb = ReaderExists(dataReader, "parentid");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.parentid = (int)ojb;
            } 
			 
            ojb = ReaderExists(dataReader, "category");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.category = (int)ojb;
            } 
			 
            ojb = ReaderExists(dataReader, "linkurl");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.linkurl = (string)ojb;
            }
            ojb = ReaderExists(dataReader, "strwhere");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.strwhere = (string)ojb;
            } 
			            return model;
        }
   		
   		/// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.Tree Tree_GetModel(string ID)
        {
            Entity.Tree model = new Tree();
            using (IDataReader dataReader = getDataReader( string.Concat(sPre, tableTree), string.Concat(pkTree, ",", Treefileds), "id", 1, true, string.Format(whereTree_byid, ID)))
            {
                if (dataReader.Read())
                {
                    model = Tree_ReaderBind(dataReader);
                }
            }
            return model;
        }
        
        /// <summary>
        /// 分页获取数据列表 
        /// </summary>
        public List<Entity.Tree> Tree_GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, bool ascending,out long recordCount)
        {
            List<Entity.Tree> list = new List<Entity.Tree>();
            DbParameter[] parameters = getParmeters(string.Concat(sPre, tableTree), string.Concat(pkTree, ",", TreefiledsList), oderby, PageSize, PageIndex, ascending, strWhere);

            using (DbDataReader dr = DbHelperCms.Instance.ExecuteReader(CommandType.StoredProcedure, string.Concat(sPre, "pro_selectByPage"), parameters))
            {
                while (dr.Read())
                {
                    list.Add(Tree_ReaderBind(dr));
                }
            }
            recordCount = long.Parse(parameters[7].Value.ToString());
            return list;
        }
        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Tree> Tree_GetListArray(string strWhere, int iTop, string OrderBy, bool ascORdesc)
        {
            List<Entity.Tree> list = new List<Entity.Tree>();
            using (IDataReader dataReader = getDataReader(string.Concat(sPre, tableTree), string.Concat(pkTree, ",", TreefiledsList), OrderBy, iTop, ascORdesc, strWhere))
            {
                while (dataReader.Read())
                {
                    list.Add(Tree_ReaderBind(dataReader));
                }
            }
            return list;
        }
        
        /// <summary>
        /// 根据sql获取列表
        /// </summary>
        public List<Entity.Tree> Tree_GetListArrayBySql(string sql)
        {
            List<Entity.Tree> list = new List<Entity.Tree>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, sql))
            {
                while (dataReader.Read())
                {
                    list.Add(Tree_ReaderBind(dataReader));
                }
            }
            return list;
        }
         #endregion 读
         
        #region 写

        public long Tree_Add(Entity.Tree model)
        {
            List<TableFile> list = new List<TableFile>();
            TableFile tf = new TableFile();
                        tf.Name = "treename";
            tf.Value = model.treename;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "position";
            tf.Value = model.position;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "parentid";
            tf.Value = model.parentid;
            tf.dbType = SqlDbType.Int;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "category";
            tf.Value = model.category;
            tf.dbType = SqlDbType.Int;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "linkurl";
            tf.Value = model.linkurl;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "strwhere";
            tf.Value = model.strwhere;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf);
            
            tf = new TableFile();
                       
            return Tools.Utils.ObjectToLong(Add(list, tableTree));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Tree_Update(Entity.Tree model)
        {

            List<TableFile> list = new List<TableFile>();

            TableFile tf = new TableFile();
            tf.Name = "treename";
            tf.Value = model.treename;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "position";
            tf.Value = model.position;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf); 
            tf = new TableFile();
            tf.Name = "parentid";
            tf.Value = model.parentid;
            tf.dbType = SqlDbType.Int;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "category";
            tf.Value = model.category;
            tf.dbType = SqlDbType.Int;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "linkurl";
            tf.Value = model.linkurl;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "strwhere";
            tf.Value = model.strwhere;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf);
            tf = new TableFile();
                        List<TableFile> listwhere = new List<TableFile>();
            tf.Name = "id";
            tf.Value = model.id;
            tf.dbType = SqlDbType.Int;
            listwhere.Add(tf);
            return update(list, tableTree, listwhere);
        }
        /// <summary>
        /// 更新一列数据
        /// </summary>
        public void Tree_Update(string Where, string Col, string sValue)
        {
            if (!string.IsNullOrEmpty(Where))
            {
                StringBuilder strSql = new StringBuilder();
                if (!Col.Contains(","))
                {
                    strSql.AppendFormat("update {0}" + tableTree + " set {1}={2} where {3}", sPre, Col, sValue, Where);
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
                        strSql.AppendFormat("update {0}" + tableTree + " set {1} where {2}", sPre, setsql, Where);
                        DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
                    }
                }
            }
        }
        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="IDs">ID列表，用逗号分开</param>
        public void Tree_Deletes(string IDs)
        {
            DeleteS(IDs, tableTree, null, null);

        }
        /// <summary>
        /// 删除分类时要更新比当前分类排序ID大的orderid - 1
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public void Tree_Delete(long id)
        {
            List<TableFile> listwhere = new List<TableFile>();
            TableFile tf = new TableFile();
            tf.Name = "id";
            tf.Value = id;
            tf.dbType = SqlDbType.BigInt;
            listwhere.Add(tf);
            Delete(tableTree, listwhere);
        }
        #endregion 写
	}
}