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
    /// 数据访问类Admin。
    /// </summary>
    public partial class DataProviderCms
    {
        private const string pkadmin = "[id]";
        private const string whereadmin_byid = "[id]={0}";
        private const string tableadmin = "Admin";
        private const string adminfileds = "[username],[userpassword],[name],[timedate],[Roles],[Department],[levels],[tel],[address],[email],[qq],[addressid],[endtime]";
        private const string adminfiledsList = "[username],[userpassword],[name],[timedate],[Roles],[Department],[levels],[tel],[address],[email],[qq],[addressid],[endtime]";
        
        #region 读
        public int AdminUser_GetManagerID(string sUserName)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("select top 1 [id]");
            strSql.AppendFormat(" FROM {0}{1} where UserName=@UserName", sPre, tableadmin);

            SqlParameter[] parameters = {
					new SqlParameter("@UserName", SqlDbType.VarChar,100)};
            parameters[0].Value = sUserName;

            object ob = DbHelperCms.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), parameters);

            if (!Equals(ob, null))
            {
                return Int32.Parse(ob.ToString());
            }
            else
            {
                return 0;
            }

        }
        public Entity.Admin Admin_ReaderBind(IDataReader dataReader)
        {
            Entity.Admin model = new Entity.Admin();
            object ojb;
            ojb = ReaderExists(dataReader, "ID");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.ID = (long)ojb;
            }
            ojb = ReaderExists(dataReader, "username");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserName = (string)ojb;
            }
            ojb = ReaderExists(dataReader, "userpassword");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.UserPassword = (string)ojb;
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

            ojb = ReaderExists(dataReader, "Roles");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Roles = (string)ojb;
            }

            ojb = ReaderExists(dataReader, "Department");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Department = (int)ojb;
            }

            ojb = ReaderExists(dataReader, "levels");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Levels = (int)ojb;
            }
            ojb = ReaderExists(dataReader, "tel");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Tel = (string)ojb;
            }
            ojb = ReaderExists(dataReader, "address");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Address = (string)ojb;
            }
            ojb = ReaderExists(dataReader, "email");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Email = (string)ojb;
            }
            ojb = ReaderExists(dataReader, "qq");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.QQ = (string)ojb;
            }
            ojb = ReaderExists(dataReader, "addressid");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.Addressid = (int)ojb;
            }
            ojb = ReaderExists(dataReader, "endtime");
            if (ojb != null && ojb != DBNull.Value)
            {
                model.EndTime = (DateTime)ojb;
            }
            return model;
        }
        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Entity.Admin Admin_GetModel(long ID)
        {
            Entity.Admin model = new Admin();
            using (IDataReader dataReader = getDataReader(string.Concat(sPre, tableadmin), string.Concat(pkadmin, ",", adminfileds), "id", 1, true, string.Format(whereadmin_byid, ID)))
            {
                if (dataReader.Read())
                {
                    model = Admin_ReaderBind(dataReader);
                }
            }
            return model;
        }
        /// <summary>
        /// 分页获取数据列表 
        /// </summary>
        public List<Admin> admin_GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, bool ascending, out long rc)
        {
            List<Entity.Admin> list = new List<Entity.Admin>();
            DbParameter[] parameters = getParmeters(string.Concat(sPre, tableadmin), string.Concat(pkadmin, ",", adminfiledsList), oderby, PageSize, PageIndex, ascending, strWhere);

            using (DbDataReader dr = DbHelperCms.Instance.ExecuteReader(CommandType.StoredProcedure, string.Concat(sPre, "pro_selectByPage"), parameters))
            {
                while (dr.Read())
                {
                    list.Add(Admin_ReaderBind(dr));
                }
            }
            rc = long.Parse(parameters[7].Value.ToString());
            return list;
        }
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public List<Entity.Admin> admin_GetListArray(string strWhere, int iTop, string OrderBy, bool ascORdesc)
        {
            List<Entity.Admin> list = new List<Entity.Admin>();
            using (IDataReader dataReader = getDataReader(string.Concat(sPre, tableadmin), string.Concat(pkadmin, ",", adminfileds), OrderBy, iTop, ascORdesc, strWhere))
            {
                while (dataReader.Read())
                {
                    list.Add(Admin_ReaderBind(dataReader));
                }
            }
            return list;
        }

        #endregion 读

        #region 写

        public long Admin_Add(Entity.Admin model)
        {
            List<TableFile> list = new List<TableFile>();

            TableFile tf = new TableFile();
            tf.Name = "username";
            tf.Value = model.UserName;
            tf.dbType = SqlDbType.VarChar;
            tf.Length = 50;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "userpassword";
            tf.Value = model.UserPassword;
            tf.dbType = SqlDbType.VarChar;
            tf.Length = 50;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "name";
            tf.Value = model.Name;
            tf.dbType = SqlDbType.VarChar;
            tf.Length = 50;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "timedate";
            tf.Value = model.TimeDate;
            tf.dbType = SqlDbType.DateTime;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "Roles";
            tf.Value = model.Roles;
            tf.dbType = SqlDbType.VarChar; ;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "Department";
            tf.Value = model.Department;
            tf.dbType = SqlDbType.Int;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "levels";
            tf.Value = model.Levels;
            tf.dbType = SqlDbType.Int;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "tel";
            tf.Value = model.Tel;
            tf.dbType = SqlDbType.VarChar;
            tf.Length = 50;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "address";
            tf.Value = model.Address;
            tf.dbType = SqlDbType.VarChar;
            tf.Length = 150;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "email";
            tf.Value = model.Email;
            tf.dbType = SqlDbType.VarChar;
            tf.Length = 50;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "qq";
            tf.Value = model.QQ;
            tf.dbType = SqlDbType.VarChar;
            tf.Length = 20;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "addressid";
            tf.Value = model.Addressid;
            tf.dbType = SqlDbType.Int;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "endtime";
            tf.Value = model.EndTime;
            tf.dbType = SqlDbType.DateTime;
            list.Add(tf);
            return Tools.Utils.ObjectToLong(Add(list, tableadmin));
        }
        /// <summary>
        /// 更新一条数据
        /// </summary>
        public int Admin_Update(Entity.Admin model)
        {

            List<TableFile> list = new List<TableFile>();

            TableFile tf = new TableFile();
            tf.Name = "username";
            tf.Value = model.UserName;
            tf.dbType = SqlDbType.VarChar;
            tf.Length = 50;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "userpassword";
            tf.Value = model.UserPassword;
            tf.dbType = SqlDbType.VarChar;
            tf.Length = 50;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "name";
            tf.Value = model.Name;
            tf.dbType = SqlDbType.VarChar;
            tf.Length = 50;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "timedate";
            tf.Value = model.TimeDate;
            tf.dbType = SqlDbType.DateTime;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "Roles";
            tf.Value = model.Roles;
            tf.dbType = SqlDbType.VarChar; ;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "Department";
            tf.Value = model.Department;
            tf.dbType = SqlDbType.Int;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "levels";
            tf.Value = model.Levels;
            tf.dbType = SqlDbType.Int;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "tel";
            tf.Value = model.Tel;
            tf.dbType = SqlDbType.VarChar;
            tf.Length = 50;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "address";
            tf.Value = model.Address;
            tf.dbType = SqlDbType.VarChar;
            tf.Length = 150;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "email";
            tf.Value = model.Email;
            tf.dbType = SqlDbType.VarChar;
            tf.Length = 50;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "qq";
            tf.Value = model.QQ;
            tf.dbType = SqlDbType.VarChar;
            tf.Length = 20;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "addressid";
            tf.Value = model.Addressid;
            tf.dbType = SqlDbType.Int;
            list.Add(tf);
            tf = new TableFile();
            tf.Name = "endtime";
            tf.Value = model.EndTime;
            tf.dbType = SqlDbType.DateTime;
            list.Add(tf);
            tf = new TableFile();
            List<TableFile> listwhere = new List<TableFile>();
            tf.Name = "id";
            tf.Value = model.ID;
            tf.dbType = SqlDbType.BigInt;
            listwhere.Add(tf);
            return update(list, tableadmin, listwhere);
        }
        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="IDs">ID列表，用逗号分开</param>
        public void Admin_Deletes(string IDs)
        {
            DeleteS(IDs, string.Concat(sPre, tableadmin), null, null);

        }
        /// <summary>
        /// 删除分类时要更新比当前分类排序ID大的orderid - 1
        /// </summary>
        /// <param name="OrderID"></param>
        /// <returns></returns>
        public void Admin_Delete(long id)
        {
            List<TableFile> listwhere = new List<TableFile>();
            TableFile tf = new TableFile();
            tf.Name = "id";
            tf.Value = id;
            tf.dbType = SqlDbType.BigInt;
            listwhere.Add(tf);
            Delete(string.Concat(sPre, tableadmin), listwhere);
        }
        #endregion 写



    }
}

