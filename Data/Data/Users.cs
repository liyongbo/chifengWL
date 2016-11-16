using Data.DataProfile;
using Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Data
{
    public partial class DataProviderCms
    {
        private const string pkUsers = "[id]";
        private const string whereUsers_byid = "[id]={0}";
        private const string tableUsers = "Users";
        private const string Usersfileds = "[username],[userpassword],[tel],[email],[qq],[name],[createdate],[lastloginip],[lastlogintime]";
        private const string UsersfiledsList = "[username],[userpassword],[tel],[email],[qq],[name],[createdate],[lastloginip],[lastlogintime]";

        #region 读

        public Users Users_ReaderBind(IDataReader dataReader)
        {
            Users model = new Users();
            object ojb;

            ojb = ReaderExists(dataReader, "id");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.id = Convert.ToInt32(ojb);
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

            ojb = ReaderExists(dataReader, "tel");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.tel = (string)ojb;
            }

            ojb = ReaderExists(dataReader, "email");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.email = (string)ojb;
            }

            ojb = ReaderExists(dataReader, "qq");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.qq = (string)ojb;
            }

            ojb = ReaderExists(dataReader, "name");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.name = (string)ojb;
            }

            ojb = ReaderExists(dataReader, "createdate");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.createdate = (string)ojb;
            }

            ojb = ReaderExists(dataReader, "lastloginip");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.lastloginip = (string)ojb;
            }

            ojb = ReaderExists(dataReader, "lastlogintime");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.lastlogintime = (string)ojb;
            }
            return model;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Users Users_GetModel(string ID)
        {
            Users model = new Users();
            using (IDataReader dataReader = getDataReader(string.Concat(sPre, tableUsers), string.Concat(pkUsers, ",", Usersfileds), "id", 1, true, string.Format(whereUsers_byid, ID)))
            {
                if (dataReader.Read())
                {
                    model = Users_ReaderBind(dataReader);
                }
            }
            return model;
        }

        /// <summary>
        /// 分页获取数据列表 
        /// </summary>
        public List<Users> Users_GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, bool ascending, out long recordCount)
        {
            List<Users> list = new List<Users>();
            DbParameter[] parameters = getParmeters(string.Concat(sPre, tableUsers), string.Concat(pkUsers, ",", UsersfiledsList), oderby, PageSize, PageIndex, ascending, strWhere);

            using (DbDataReader dr = DbHelperCms.Instance.ExecuteReader(CommandType.StoredProcedure, string.Concat(sPre, "pro_selectByPage"), parameters))
            {
                while (dr.Read())
                {
                    list.Add(Users_ReaderBind(dr));
                }
            }
            recordCount = long.Parse(parameters[7].Value.ToString());
            return list;
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Users> Users_GetListArray(string strWhere, int iTop, string OrderBy, bool ascORdesc)
        {
            List<Users> list = new List<Users>();
            using (IDataReader dataReader = getDataReader(string.Concat(sPre, tableUsers), string.Concat(pkUsers, ",", UsersfiledsList), OrderBy, iTop, ascORdesc, strWhere))
            {
                while (dataReader.Read())
                {
                    list.Add(Users_ReaderBind(dataReader));
                }
            }
            return list;
        }

        /// <summary>
        /// 根据sql获取列表
        /// </summary>
        public List<Users> Users_GetListArrayBySql(string sql)
        {
            List<Users> list = new List<Users>();
            using (IDataReader dataReader = DbHelperCms.Instance.ExecuteReader(CommandType.Text, sql))
            {
                while (dataReader.Read())
                {
                    list.Add(Users_ReaderBind(dataReader));
                }
            }
            return list;
        }
        #endregion 读

        #region 写

        public long Users_Add(Users model)
        {
            List<TableFile> list = new List<TableFile>();
            TableFile tf = new TableFile();
            tf.Name = "username";
            tf.Value = model.username;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "userpassword";
            tf.Value = model.userpassword;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "tel";
            tf.Value = model.tel;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "email";
            tf.Value = model.email;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "qq";
            tf.Value = model.qq;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "name";
            tf.Value = model.name;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "createdate";
            tf.Value = model.createdate;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "lastloginip";
            tf.Value = model.lastloginip;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "lastlogintime";
            tf.Value = model.lastlogintime;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf);
            tf = new TableFile();

            return Tools.Utils.ObjectToLong(Add(list, tableUsers));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Users_Update(Users model)
        {

            List<TableFile> list = new List<TableFile>();

            TableFile tf = new TableFile();
            tf.Name = "username";
            tf.Value = model.username;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "userpassword";
            tf.Value = model.userpassword;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "tel";
            tf.Value = model.tel;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "email";
            tf.Value = model.email;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "qq";
            tf.Value = model.qq;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "name";
            tf.Value = model.name;
            tf.dbType = SqlDbType.NVarChar;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "createdate";
            tf.Value = model.createdate;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "lastloginip";
            tf.Value = model.lastloginip;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "lastlogintime";
            tf.Value = model.lastlogintime;
            tf.dbType = SqlDbType.VarChar;
            list.Add(tf);
            tf = new TableFile();
            List<TableFile> listwhere = new List<TableFile>();
            tf.Name = "id";
            tf.Value = model.id;
            tf.dbType = SqlDbType.Int;
            listwhere.Add(tf);
            return update(list, tableUsers, listwhere);
        }
        /// <summary>
        /// 更新一列数据
        /// </summary>
        public void Users_Update(string Where, string Col, string sValue)
        {
            if (!string.IsNullOrEmpty(Where))
            {
                StringBuilder strSql = new StringBuilder();
                if (!Col.Contains(","))
                {
                    strSql.AppendFormat("update {0}" + tableUsers + " set {1}={2} where {3}", sPre, Col, sValue, Where);
                    DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
                }
                else
                {
                    string setsql = string.Empty;
                    string[] arrCol = Col.Split(',');
                    string[] arrValue = sValue.Split(',');
                    for (int i = 0; i < arrCol.Length; i++)
                    {
                        setsql += arrCol[i] + "=" + arrValue[i];
                        if (i < arrCol.Length - 1)
                            setsql += " , ";
                    }
                    if (!string.IsNullOrEmpty(setsql))
                    {
                        strSql.AppendFormat("update {0}" + tableUsers + " set {1} where {2}", sPre, setsql, Where);
                        DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
                    }
                }
            }
        }
        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="IDs">ID列表，用逗号分开</param>
        public void Users_Deletes(string IDs)
        {
            DeleteS(IDs, tableUsers, null, null);

        }
        /// <summary>
        /// 删除分类时要更新比当前分类排序ID大的orderid - 1
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public void Users_Delete(long id)
        {
            List<TableFile> listwhere = new List<TableFile>();
            TableFile tf = new TableFile();
            tf.Name = "id";
            tf.Value = id;
            tf.dbType = SqlDbType.BigInt;
            listwhere.Add(tf);
            Delete(tableUsers, listwhere);
        }
        #endregion 写



        public DataTable Users_DataSet(string sql)
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