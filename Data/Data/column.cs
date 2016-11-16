using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Data.DataProfile;
using System.Data.SqlClient;
using Entity;
using System.Data.Common;

//请先添加引用
namespace Data
{
    /// <summary>
    /// 数据访问类Column。
    /// </summary>
    public partial class DataProviderCms
    {
        private const string pkColumn = "[id]";
        private const string whereColumn_byid = "[id]={0}";
        private const string tableColumn = "Column";
        private const string Columnfileds = "[name],[timedate],[rootid],[parentid],[categoryid],[url]";
        #region 读

        public Entity.Column Column_ReaderBind(IDataReader dataReader)
        {
            Entity.Column model = new Entity.Column();
            object ojb;
            ojb = ReaderExists(dataReader, "ID");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ID = (int)ojb;
            }
            ojb = ReaderExists(dataReader, "name");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Name = (string)ojb;
            }
            ojb = ReaderExists(dataReader, "timedate");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.TimeDate = (DateTime)ojb;
            }
            ojb = ReaderExists(dataReader, "rootid");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Rootid = (int)ojb;

            }
            ojb = ReaderExists(dataReader, "parentid");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Parentid = (int)ojb;
            }

            ojb = ReaderExists(dataReader, "categoryid");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Categoryid = (int)ojb;
            }

            ojb = ReaderExists(dataReader, "url");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Url = (string)ojb;
            }
            ojb = ReaderExists(dataReader, "isQuick");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.IsQuick = (bool)ojb;
            }

            return model;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.Column Column_GetModel(long ID)
        {
            Entity.Column model = new Column();
            using (IDataReader dataReader = getDataReader(string.Concat(sPre, tableColumn), string.Concat(pkColumn, ",", Columnfileds), "id", 1, true, string.Format(whereColumn_byid, ID)))
            {
                if (dataReader.Read())
                {
                    model = Column_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 分页获取数据列表 
        /// </summary>
        public List<Column> Column_GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, bool ascending, out long rc)
        {
            List<Entity.Column> list = new List<Entity.Column>();
            DbParameter[] parameters = getParmeters(string.Concat(sPre, tableColumn), string.Concat(pkColumn, ",", Columnfileds), oderby, PageSize, PageIndex, ascending, strWhere);

            using (DbDataReader dr = DbHelperCms.Instance.ExecuteReader(CommandType.StoredProcedure, string.Concat(sPre, "pro_selectByPage"), parameters))
            {
                while (dr.Read())
                {
                    list.Add(Column_ReaderBind(dr));
                }
            }
            rc = long.Parse(parameters[7].Value.ToString());
            return list;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Column> Column_GetListArray(string strWhere, int iTop, string OrderBy, bool ascORdesc)
        {
            List<Entity.Column> list = new List<Entity.Column>();
            using (IDataReader dataReader = getDataReader(string.Concat(sPre, tableColumn), string.Concat(pkColumn, ",", Columnfileds), OrderBy, iTop, ascORdesc, strWhere))
            {
                while (dataReader.Read())
                {
                    list.Add(Column_ReaderBind(dataReader));
                }
            }
            return list;
        }

        #endregion 读

        #region 写

        public long Column_Add(Entity.Column model)
        {
            List<TableFile> list = new List<TableFile>();

            TableFile tf = new TableFile();// "[id],[name],[timedate],[rootid],[parentid],[categoryid],[url]"
            tf.Name = "id";
            tf.Value = model.ID;
            tf.dbType = SqlDbType.Int;
            list.Add(tf);
            tf.Name = "name";
            tf.Value = model.Name;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf);
            tf.Name = "timedate";
            tf.Value = model.TimeDate;
            tf.dbType = SqlDbType.DateTime;
            list.Add(tf);
            tf.Name = "rootid";
            tf.Value = model.Rootid;
            tf.dbType = SqlDbType.Int;
            list.Add(tf);
            tf.Name = "parentid";
            tf.Value = model.Parentid;
            tf.dbType = SqlDbType.Int; ;
            list.Add(tf);
            tf.Name = "categoryid";
            tf.Value = model.Categoryid;
            tf.dbType = SqlDbType.Int;
            list.Add(tf);
            tf.Name = "url";
            tf.Value = model.Url;
            tf.dbType = SqlDbType.Int;
            list.Add(tf);
            tf.Name = "isQuick";
            tf.Value = model.IsQuick;
            tf.dbType = SqlDbType.Bit;
            list.Add(tf);

            return Tools.Utils.ObjectToLong(Add(list, string.Concat(sPre, tableColumn)));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Column_Update(Entity.Column model)
        {

            List<TableFile> list = new List<TableFile>();

            TableFile tf = new TableFile();// "[id],[name],[timedate],[rootid],[parentid],[categoryid],[url]"
            tf.Name = "id";
            tf.Value = model.ID;
            tf.dbType = SqlDbType.Int;
            list.Add(tf);
            tf.Name = "name";
            tf.Value = model.Name;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf);
            tf.Name = "timedate";
            tf.Value = model.TimeDate;
            tf.dbType = SqlDbType.DateTime;
            list.Add(tf);
            tf.Name = "rootid";
            tf.Value = model.Rootid;
            tf.dbType = SqlDbType.Int;
            list.Add(tf);
            tf.Name = "parentid";
            tf.Value = model.Parentid;
            tf.dbType = SqlDbType.Int; ;
            list.Add(tf);
            tf.Name = "categoryid";
            tf.Value = model.Categoryid;
            tf.dbType = SqlDbType.Int;
            list.Add(tf);
            tf.Name = "url";
            tf.Value = model.Url;
            tf.dbType = SqlDbType.Int;
            list.Add(tf);
            tf.Name = "isQuick";
            tf.Value = model.IsQuick;
            tf.dbType = SqlDbType.Bit;
            list.Add(tf);
            List<TableFile> listwhere = new List<TableFile>();
            tf.Name = "id";
            tf.Value = model.ID;
            tf.dbType = SqlDbType.BigInt;
            listwhere.Add(tf);
            return update(list, string.Concat(sPre, tableColumn), listwhere);
        }
        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="IDs">ID列表，用逗号分开</param>
        public void Column_Deletes(string IDs)
        {
            DeleteS(IDs, string.Concat(sPre, tableColumn), null, null);

        }
        /// <summary>
        /// 删除分类时要更新比当前分类排序ID大的orderid - 1
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public void Column_Delete(long id)
        {
            List<TableFile> listwhere = new List<TableFile>();
            TableFile tf = new TableFile();
            tf.Name = "id";
            tf.Value = id;
            tf.dbType = SqlDbType.BigInt;
            listwhere.Add(tf);
            Delete(string.Concat(sPre, tableColumn), listwhere);
        }
        #endregion 写



    }
}

