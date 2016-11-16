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
	    private const string pkDestinations = "[id]";
        private const string whereDestinations_byid = "[id]={0}";
        private const string tableDestinations = "Destinations";
        private const string Destinationsfileds = "[destName],[ownname],[tel],[username],[userpassword],[age],[sex],[address],[emergency],[bank],[bankcard],[comment],[createdate],[lastupdatetime],[lastupdateuser]";
        private const string DestinationsfiledsList = "[destName],[ownname],[tel],[username],[userpassword],[age],[sex],[address],[emergency],[bank],[bankcard],[comment],[createdate],[lastupdatetime],[lastupdateuser]";
        #region 读
        public Entity.Destinations Destinations_ReaderBind(IDataReader dataReader)
        {
            Entity.Destinations model = new Entity.Destinations();
            object ojb;
             
            ojb = ReaderExists(dataReader, "id");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = Convert.ToInt32(ojb);
            } 
			 
            ojb = ReaderExists(dataReader, "destName");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.destName = (string)ojb;
            } 
			 
            ojb = ReaderExists(dataReader, "ownname");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ownname = (string)ojb;
            } 
			 
            ojb = ReaderExists(dataReader, "tel");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.tel = (string)ojb;
            } 
			 
            ojb = ReaderExists(dataReader, "username");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.username = (string)ojb;
            } 
			 
            ojb = ReaderExists(dataReader, "userpassword");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.userpassword = (string)ojb;
            } 
			 
            ojb = ReaderExists(dataReader, "age");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.age = Convert.ToInt32(ojb);
            } 
			 
            ojb = ReaderExists(dataReader, "sex");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.sex = Convert.ToInt32(ojb);
            } 
			 
            ojb = ReaderExists(dataReader, "address");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.address = (string)ojb;
            } 
			 
            ojb = ReaderExists(dataReader, "emergency");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.emergency = (string)ojb;
            } 
			 
            ojb = ReaderExists(dataReader, "bank");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.bank = (string)ojb;
            } 
			 
            ojb = ReaderExists(dataReader, "bankcard");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.bankcard = (string)ojb;
            } 
			 
            ojb = ReaderExists(dataReader, "comment");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.comment = (string)ojb;
            } 
			 
            ojb = ReaderExists(dataReader, "createdate");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.createdate = (string)ojb;
            } 
			 
            ojb = ReaderExists(dataReader, "lastupdatetime");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.lastupdatetime = (string)ojb;
            } 
			 
            ojb = ReaderExists(dataReader, "lastupdateuser");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.lastupdateuser = (string)ojb;
            } 
			            return model;
        }
   		
   		/// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.Destinations Destinations_GetModel(string ID)
        {
            Entity.Destinations model = new Destinations();
            using (IDataReader dataReader = getDataReader( string.Concat(sPre, tableDestinations), string.Concat(pkDestinations, ",", Destinationsfileds), "id", 1, true, string.Format(whereDestinations_byid, ID)))
            {
                if (dataReader.Read())
                {
                    model = Destinations_ReaderBind(dataReader);
                }
            }
            return model;
        }
        
        /// <summary>
        /// 分页获取数据列表 
        /// </summary>
        public List<Entity.Destinations> Destinations_GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, bool ascending,out long recordCount)
        {
            List<Entity.Destinations> list = new List<Entity.Destinations>();
            DbParameter[] parameters = getParmeters(string.Concat(sPre, tableDestinations), string.Concat(pkDestinations, ",", DestinationsfiledsList), oderby, PageSize, PageIndex, ascending, strWhere);

            using (DbDataReader dr = DbHelperCms.Instance.ExecuteReader(CommandType.StoredProcedure, string.Concat(sPre, "pro_selectByPage"), parameters))
            {
                while (dr.Read())
                {
                    list.Add(Destinations_ReaderBind(dr));
                }
            }
            recordCount = long.Parse(parameters[7].Value.ToString());
            return list;
        }
        
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Destinations> Destinations_GetListArray(string strWhere, int iTop, string OrderBy, bool ascORdesc)
        {
            List<Entity.Destinations> list = new List<Entity.Destinations>();
            using (IDataReader dataReader = getDataReader(string.Concat(sPre, tableDestinations), string.Concat(pkDestinations, ",", DestinationsfiledsList), OrderBy, iTop, ascORdesc, strWhere))
            {
                while (dataReader.Read())
                {
                    list.Add(Destinations_ReaderBind(dataReader));
                }
            }
            return list;
        }
        
        /// <summary>
        /// 根据sql获取列表
        /// </summary>
        public List<Entity.Destinations> Destinations_GetListArrayBySql(string sql)
        {
            List<Entity.Destinations> list = new List<Entity.Destinations>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, sql))
            {
                while (dataReader.Read())
                {
                    list.Add(Destinations_ReaderBind(dataReader));
                }
            }
            return list;
        }
         #endregion 读
         
        #region 写

        public long Destinations_Add(Entity.Destinations model)
        {
            List<TableFile> list = new List<TableFile>();
            TableFile tf = new TableFile();
                        tf.Name = "destName";
            tf.Value = model.destName;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "ownname";
            tf.Value = model.ownname;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "tel";
            tf.Value = model.tel;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "username";
            tf.Value = model.username;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "userpassword";
            tf.Value = model.userpassword;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "age";
            tf.Value = model.age;
            tf.dbType = SqlDbType.Int;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "sex";
            tf.Value = model.sex;
            tf.dbType = SqlDbType.Int;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "address";
            tf.Value = model.address;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "emergency";
            tf.Value = model.emergency;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "bank";
            tf.Value = model.bank;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "bankcard";
            tf.Value = model.bankcard;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "comment";
            tf.Value = model.comment;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "createdate";
            tf.Value = model.createdate;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "lastupdatetime";
            tf.Value = model.lastupdatetime;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "lastupdateuser";
            tf.Value = model.lastupdateuser;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf); 
            tf = new TableFile();
                       
            return Tools.Utils.ObjectToLong(Add(list, tableDestinations));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Destinations_Update(Entity.Destinations model)
        {

            List<TableFile> list = new List<TableFile>();

            TableFile tf = new TableFile();
                        tf.Name = "destName";
            tf.Value = model.destName;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "ownname";
            tf.Value = model.ownname;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "tel";
            tf.Value = model.tel;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "username";
            tf.Value = model.username;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "userpassword";
            tf.Value = model.userpassword;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "age";
            tf.Value = model.age;
            tf.dbType = SqlDbType.Int;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "sex";
            tf.Value = model.sex;
            tf.dbType = SqlDbType.Int;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "address";
            tf.Value = model.address;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "emergency";
            tf.Value = model.emergency;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "bank";
            tf.Value = model.bank;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "bankcard";
            tf.Value = model.bankcard;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "comment";
            tf.Value = model.comment;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "createdate";
            tf.Value = model.createdate;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "lastupdatetime";
            tf.Value = model.lastupdatetime;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf); 
            tf = new TableFile();
                        tf.Name = "lastupdateuser";
            tf.Value = model.lastupdateuser;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf); 
            tf = new TableFile();
                        List<TableFile> listwhere = new List<TableFile>();
            tf.Name = "id";
            tf.Value = model.id;
            tf.dbType = SqlDbType.Int;
            listwhere.Add(tf);
            return update(list, tableDestinations, listwhere);
        }
        /// <summary>
        /// 更新一列数据
        /// </summary>
        public void Destinations_Update(string Where, string Col, string sValue)
        {
            if (!string.IsNullOrEmpty(Where))
            {
                StringBuilder strSql = new StringBuilder();
                if (!Col.Contains(","))
                {
                    strSql.AppendFormat("update {0}" + tableDestinations + " set {1}={2} where {3}", sPre, Col, sValue, Where);
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
                        strSql.AppendFormat("update {0}" + tableDestinations + " set {1} where {2}", sPre, setsql, Where);
                        DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
                    }
                }
            }
        }
        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="IDs">ID列表，用逗号分开</param>
        public void Destinations_Deletes(string IDs)
        {
            DeleteS(IDs, tableDestinations, null, null);

        }
        /// <summary>
        /// 删除分类时要更新比当前分类排序ID大的orderid - 1
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public void Destinations_Delete(long id)
        {
            List<TableFile> listwhere = new List<TableFile>();
            TableFile tf = new TableFile();
            tf.Name = "id";
            tf.Value = id;
            tf.dbType = SqlDbType.BigInt;
            listwhere.Add(tf);
            Delete(tableDestinations, listwhere);
        }
        #endregion 写
        


        public DataTable Destinations_DataSet(string sql)
        {
            DataSet ds = DbHelperCms.Instance.ExecuteDataset(CommandType.Text, sql);
            if (ds != null && ds.Tables.Count > 0)
            {
                return ds.Tables[0];
            }
            return null;
        }
        

	}
}