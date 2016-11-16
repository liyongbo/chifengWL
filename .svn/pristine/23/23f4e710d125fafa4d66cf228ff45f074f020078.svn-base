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
	    private const string pkArea = "[id]";
        private const string whereArea_byid = "[id]={0}";
        private const string tableArea = "Area";
        private const string Areafileds = "[regionname],[param1],[param2]";
        private const string AreafiledsList = "[regionname],[param1],[param2]";
        #region 读
        public Entity.Area Area_ReaderBind(IDataReader dataReader)
        {
            Entity.Area model = new Entity.Area();
            object ojb;
             
            ojb = ReaderExists(dataReader, "id");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = (int)ojb;
            } 
			 
            ojb = ReaderExists(dataReader, "regionname");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.typename = (string)ojb;
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
        public Entity.Area Area_GetModel(string ID)
        {
            Entity.Area model = new Area();
            using (IDataReader dataReader = getDataReader( string.Concat(sPre, tableArea), string.Concat(pkArea, ",", Areafileds), "id", 1, true, string.Format(whereArea_byid, ID)))
            {
                if (dataReader.Read())
                {
                    model = Area_ReaderBind(dataReader);
                }
            }
            return model;
        }
        
        /// <summary>
        /// 分页获取数据列表 
        /// </summary>
        public List<Entity.Area> Area_GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, bool ascending,out long recordCount)
        {
            List<Entity.Area> list = new List<Entity.Area>();
            DbParameter[] parameters = getParmeters(string.Concat(sPre, tableArea), string.Concat(pkArea, ",", AreafiledsList), oderby, PageSize, PageIndex, ascending, strWhere);

            using (DbDataReader dr = DbHelperCms.Instance.ExecuteReader(CommandType.StoredProcedure, string.Concat(sPre, "pro_selectByPage"), parameters))
            {
                while (dr.Read())
                {
                    list.Add(Area_ReaderBind(dr));
                }
            }
            recordCount = long.Parse(parameters[7].Value.ToString());
            return list;
        }
        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Area> Area_GetListArray(string strWhere, int iTop, string OrderBy, bool ascORdesc)
        {
            List<Entity.Area> list = new List<Entity.Area>();
            using (IDataReader dataReader = getDataReader(string.Concat(sPre, tableArea), string.Concat(pkArea, ",", AreafiledsList), OrderBy, iTop, ascORdesc, strWhere))
            {
                while (dataReader.Read())
                {
                    list.Add(Area_ReaderBind(dataReader));
                }
            }
            return list;
        }
        
        /// <summary>
        /// 根据sql获取列表
        /// </summary>
        public List<Entity.Area> Area_GetListArrayBySql(string sql)
        {
            List<Entity.Area> list = new List<Entity.Area>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, sql))
            {
                while (dataReader.Read())
                {
                    list.Add(Area_ReaderBind(dataReader));
                }
            }
            return list;
        }
         #endregion 读
         
        #region 写

        public long Area_Add(Entity.Area model)
        {
            List<TableFile> list = new List<TableFile>();
            TableFile tf = new TableFile();
                        tf.Name = "regionname";
            tf.Value = model.typename;
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
                       
            return Tools.Utils.ObjectToLong(Add(list, tableArea));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Area_Update(Entity.Area model)
        {

            List<TableFile> list = new List<TableFile>();

            TableFile tf = new TableFile();
                        tf.Name = "regionname";
            tf.Value = model.typename;
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
            tf.dbType = SqlDbType.BigInt;
            listwhere.Add(tf);
            return update(list, tableArea, listwhere);
        }
        /// <summary>
        /// 更新一列数据
        /// </summary>
        public void Area_Update(string Where, string Col, string sValue)
        {
            if (!string.IsNullOrEmpty(Where))
            {
                StringBuilder strSql = new StringBuilder();
                if (!Col.Contains(","))
                {
                    strSql.AppendFormat("update {0}" + tableArea + " set {1}={2} where {3}", sPre, Col, sValue, Where);
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
                        strSql.AppendFormat("update {0}" + tableArea + " set {1} where {2}", sPre, setsql, Where);
                        DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
                    }
                }
            }
        }
        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="IDs">ID列表，用逗号分开</param>
        public void Area_Deletes(string IDs)
        {
            DeleteS(IDs, tableArea, null, null);

        }
        /// <summary>
        /// 删除分类时要更新比当前分类排序ID大的orderid - 1
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public void Area_Delete(long id)
        {
            List<TableFile> listwhere = new List<TableFile>();
            TableFile tf = new TableFile();
            tf.Name = "id";
            tf.Value = id;
            tf.dbType = SqlDbType.BigInt;
            listwhere.Add(tf);
            Delete(tableArea, listwhere);
        }
        #endregion 写
	}
}