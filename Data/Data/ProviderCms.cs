using System.Data.Common;
using Data.DataProfile;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Data
{
    public partial class DataProviderCms
    {
        private const string sPre = "";
        private const string udt = ",{0}=@{0}";
        private const string udw = " and {0}=@{0}";
        private const string pram = "@{0}";
        private const string infile = ",{0}";
        private const string inpro = ",@{0}";




        /// <summary>
        /// 判断 DataReader 里面是否包含指定的列
        /// </summary>
        /// <param name="dr"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static object ReaderExists(IDataReader dr, string columnName)
        {
            int count = dr.FieldCount;
            for (int i = 0; i < count; i++)
            {
                if (dr.GetName(i).ToLower().Equals(columnName.ToLower()))
                {
                    return dr[columnName];
                }
            }
            return null;
        }

        /// <summary>
        /// 分页参数
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="strGetFields">字段</param>
        /// <param name="fldName">排序的字段 不加order by</param>
        /// <param name="PageSize">每页显示个数</param>
        /// <param name="PageIndex">页码</param>
        /// <param name="OrderType">设置排序类型, true则降序</param>
        /// <param name="strWhere">查询条件 不加where</param>
        /// <returns></returns>
        private DbParameter[] getParmeters(string tablename, string strGetFields, string fldName, int PageSize, int PageIndex, bool OrderType, string strWhere)
        {
            DbParameter[] parameters = {
					new SqlParameter("@tblName",  SqlDbType.VarChar),
					new SqlParameter("@strGetFields",  SqlDbType.VarChar),
					new SqlParameter("@fldName",  SqlDbType.VarChar),
					new SqlParameter("@PageSize",  SqlDbType.Int),
					new SqlParameter("@PageIndex",  SqlDbType.Int),
					new SqlParameter("@OrderType",  SqlDbType.Bit),
					new SqlParameter("@strWhere",  SqlDbType.VarChar),
					new SqlParameter("@doCount",  SqlDbType.BigInt)};
            parameters[0].Value = tablename;
            parameters[1].Value = strGetFields;
            parameters[2].Value = fldName;
            parameters[3].Value = PageSize;
            parameters[4].Value = PageIndex;
            parameters[5].Value = OrderType;
            parameters[6].Value = strWhere;
            parameters[7].Direction = ParameterDirection.Output;
            return parameters;
        }



        /// <summary>
        /// 查询前几条
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="strGetFields">字段</param>
        /// <param name="fldName">排序的字段 不加order by</param>
        /// <param name="topSize">每页显示个数</param>
        /// <param name="OrderType">设置排序类型, true则降序</param>
        /// <param name="strWhere">查询条件 不加where</param>
        /// <param name="parameters">参数，以上值为参数</param>
        /// <returns></returns>
        private SqlDataReader getDataReader(string tablename, string strGetFields, string fldName, int topSize, bool OrderType, string strWhere)
        {
            //            @tblName varchar(255), -- 表名
            //@strGetFields varchar(1000) = '*', -- 需要返回的列 
            //@fldName varchar(255)='', -- 排序的字段名
            //@topSize int = 10, -- 每页显示个数
            //@OrderType bit = 0, -- 设置排序类型, 非 0 值则降序
            //@strWhere varchar(1500) = '' -- 查询条件 (注意: 不要加 where)
            DbParameter[] parameters = {
					new SqlParameter("@tblName",  SqlDbType.VarChar),
					new SqlParameter("@strGetFields",  SqlDbType.VarChar),
					new SqlParameter("@fldName",  SqlDbType.VarChar),
					new SqlParameter("@topSize",  SqlDbType.Int),
					new SqlParameter("@OrderType",  SqlDbType.Bit),
					new SqlParameter("@strWhere",  SqlDbType.VarChar)};
            parameters[0].Value = tablename;
            parameters[1].Value = strGetFields;
            parameters[2].Value = fldName;
            parameters[3].Value = topSize;
            parameters[4].Value = OrderType;
            parameters[5].Value = strWhere;
            return DbHelperCms.Instance.ExecuteReader(CommandType.StoredProcedure, string.Concat(sPre, "pro_selectToWhere"), parameters) as SqlDataReader;
        }

        /// <summary>
        /// 查询前几条
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="strGetFields">字段</param>
        /// <param name="fldName">排序的字段 不加order by</param>
        /// <param name="topSize">每页显示个数</param>
        /// <param name="OrderType">设置排序类型, true则降序</param>
        /// <param name="strWhere">查询条件 不加where</param>
        /// <param name="parameters">参数，以上值为参数</param>
        /// <returns></returns>
        private SqlDataReader getDataReader(string tablename, string strGetFields, string fldName, int topSize, bool OrderType, string strWhere,string sqlName,string dbName)
        {
            //            @tblName varchar(255), -- 表名
            //@strGetFields varchar(1000) = '*', -- 需要返回的列 
            //@fldName varchar(255)='', -- 排序的字段名
            //@topSize int = 10, -- 每页显示个数
            //@OrderType bit = 0, -- 设置排序类型, 非 0 值则降序
            //@strWhere varchar(1500) = '' -- 查询条件 (注意: 不要加 where)
            DbParameter[] parameters = {
					new SqlParameter("@tblName",  SqlDbType.VarChar),
					new SqlParameter("@strGetFields",  SqlDbType.VarChar),
					new SqlParameter("@fldName",  SqlDbType.VarChar),
					new SqlParameter("@topSize",  SqlDbType.Int),
					new SqlParameter("@OrderType",  SqlDbType.Bit),
					new SqlParameter("@strWhere",  SqlDbType.VarChar)};
            parameters[0].Value = tablename;
            parameters[1].Value = strGetFields;
            parameters[2].Value = fldName;
            parameters[3].Value = topSize;
            parameters[4].Value = OrderType;
            parameters[5].Value = strWhere;
            return DbHelperManyDb.Instance.ExecuteReader(CommandType.StoredProcedure, string.Concat(sPre, "pro_selectToWhere"), sqlName, dbName, parameters) as SqlDataReader;
        }

        /// <summary>
        /// 查询前几条
        /// </summary>
        /// <param name="tablename">表名</param>
        /// <param name="strGetFields">字段</param>
        /// <param name="fldName">排序的字段 不加order by</param>
        /// <param name="topSize">每页显示个数</param>
        /// <param name="OrderType">设置排序类型, true则降序</param>
        /// <param name="strWhere">查询条件 不加where</param>
        /// <param name="parameters">参数，以上值为参数</param>
        /// <returns></returns>
        private SqlDataReader getDataReaderUFSystem(string tablename, string strGetFields, string fldName, int topSize, bool OrderType, string strWhere)
        {
            //            @tblName varchar(255), -- 表名
            //@strGetFields varchar(1000) = '*', -- 需要返回的列 
            //@fldName varchar(255)='', -- 排序的字段名
            //@topSize int = 10, -- 每页显示个数
            //@OrderType bit = 0, -- 设置排序类型, 非 0 值则降序
            //@strWhere varchar(1500) = '' -- 查询条件 (注意: 不要加 where)
            DbParameter[] parameters = {
					new SqlParameter("@tblName",  SqlDbType.VarChar),
					new SqlParameter("@strGetFields",  SqlDbType.VarChar),
					new SqlParameter("@fldName",  SqlDbType.VarChar),
					new SqlParameter("@topSize",  SqlDbType.Int),
					new SqlParameter("@OrderType",  SqlDbType.Bit),
					new SqlParameter("@strWhere",  SqlDbType.VarChar)};
            parameters[0].Value = tablename;
            parameters[1].Value = strGetFields;
            parameters[2].Value = fldName;
            parameters[3].Value = topSize;
            parameters[4].Value = OrderType;
            parameters[5].Value = strWhere;
            return DbHelperUFSystem.Instance.ExecuteReader(CommandType.StoredProcedure, string.Concat(sPre, "pro_selectToWhere"), parameters) as SqlDataReader;
        }
        public int update(List<TableFile> tf, string tablename, List<TableFile> where)
        {
            StringBuilder strSql = new StringBuilder();
            List<SqlParameter> list = new List<SqlParameter>();
            strSql.AppendFormat("update {0}{1} set ", sPre, tablename);
            for (int i = 0; i < tf.Count; i++)
            {
                strSql.AppendFormat(i == 0 ? udt.Substring(1) : udt, tf[i].Name);
                SqlParameter sp = new SqlParameter(string.Format(pram, tf[i].Name), tf[i].dbType);
                sp.Value = tf[i].Value;
                list.Add(sp);
            }
            if (where.Count > 0)
            {
                strSql.Append(" where ");
                for (int i = 0; i < where.Count; i++)
                {
                    strSql.AppendFormat(i == 0 ? udt.Substring(1) : udt, where[i].Name);
                    SqlParameter sp = new SqlParameter(string.Format(pram, where[i].Name), where[i].dbType);
                    sp.Value = where[i].Value;
                    list.Add(sp);
                }
            }
            return DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), list.ToArray() as System.Data.Common.DbParameter[]);
        }
        public int update(List<TableFile> tf, string tablename, List<TableFile> where,string sqlName,string dbName)
        {
            StringBuilder strSql = new StringBuilder();
            List<SqlParameter> list = new List<SqlParameter>();
            strSql.AppendFormat("update {0}{1} set ", sPre, tablename);
            for (int i = 0; i < tf.Count; i++)
            {
                strSql.AppendFormat(i == 0 ? udt.Substring(1) : udt, tf[i].Name);
                SqlParameter sp = new SqlParameter(string.Format(pram, tf[i].Name), tf[i].dbType);
                sp.Value = tf[i].Value;
                list.Add(sp);
            }
            if (where.Count > 0)
            {
                strSql.Append(" where ");
                for (int i = 0; i < where.Count; i++)
                {
                    strSql.AppendFormat(i == 0 ? udt.Substring(1) : udt, where[i].Name);
                    SqlParameter sp = new SqlParameter(string.Format(pram, where[i].Name), where[i].dbType);
                    sp.Value = where[i].Value;
                    list.Add(sp);
                }
            }
            return DbHelperManyDb.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(),list.ToArray() as System.Data.Common.DbParameter[]);
        }
        public int updateUFSystem(List<TableFile> tf, string tablename, List<TableFile> where)
        {
            StringBuilder strSql = new StringBuilder();
            List<SqlParameter> list = new List<SqlParameter>();
            strSql.AppendFormat("update {0}{1} set ", sPre, tablename);
            for (int i = 0; i < tf.Count; i++)
            {
                strSql.AppendFormat(i == 0 ? udt.Substring(1) : udt, tf[i].Name);
                SqlParameter sp = new SqlParameter(string.Format(pram, tf[i].Name), tf[i].dbType);
                sp.Value = tf[i].Value;
                list.Add(sp);
            }
            if (where.Count > 0)
            {
                strSql.Append(" where ");
                for (int i = 0; i < where.Count; i++)
                {
                    strSql.AppendFormat(i == 0 ? udt.Substring(1) : udt, where[i].Name);
                    SqlParameter sp = new SqlParameter(string.Format(pram, where[i].Name), where[i].dbType);
                    sp.Value = where[i].Value;
                    list.Add(sp);
                }
            }
            return DbHelperUFSystem.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), list.ToArray() as System.Data.Common.DbParameter[]);
        }

        public object Add(List<TableFile> tf, string tableName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}{1}(", sPre, tableName);
            List<SqlParameter> list = new List<SqlParameter>();

            for (int i = 0; i < tf.Count; i++)
            {
                strSql.AppendFormat(i == 0 ? infile.Substring(1) : infile, tf[i].Name);
            }
            strSql.Append(") values (");
            for (int i = 0; i < tf.Count; i++)
            {
                strSql.AppendFormat(i == 0 ? inpro.Substring(1) : inpro, tf[i].Name);
                SqlParameter sp = new SqlParameter(string.Format(pram, tf[i].Name), tf[i].dbType);
                sp.Value = tf[i].Value;
                list.Add(sp);
            }
            strSql.Append(") ;SELECT @@identity");
            object obj = DbHelperCmsWrite.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), list.ToArray() as System.Data.Common.DbParameter[]);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return obj;
            }
        }

        public object Add(List<TableFile> tf, string tableName,string sqlName,string dbName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}{1}(", sPre, tableName);
            List<SqlParameter> list = new List<SqlParameter>();

            for (int i = 0; i < tf.Count; i++)
            {
                strSql.AppendFormat(i == 0 ? infile.Substring(1) : infile, tf[i].Name);
            }
            strSql.Append(") values (");
            for (int i = 0; i < tf.Count; i++)
            {
                strSql.AppendFormat(i == 0 ? inpro.Substring(1) : inpro, tf[i].Name);
                SqlParameter sp = new SqlParameter(string.Format(pram, tf[i].Name), tf[i].dbType);
                sp.Value = tf[i].Value;
                list.Add(sp);
            }
            strSql.Append(") ;SELECT @@identity");
            object obj = DbHelperManyDb.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), sqlName, dbName, list.ToArray() as System.Data.Common.DbParameter[]);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return obj;
            }
        }

        public object AddUFSystem(List<TableFile> tf, string tableName)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("insert into {0}{1}(", sPre, tableName);
            List<SqlParameter> list = new List<SqlParameter>();

            for (int i = 0; i < tf.Count; i++)
            {
                strSql.AppendFormat(i == 0 ? infile.Substring(1) : infile, tf[i].Name);
            }
            strSql.Append(") values (");
            for (int i = 0; i < tf.Count; i++)
            {
                strSql.AppendFormat(i == 0 ? inpro.Substring(1) : inpro, tf[i].Name);
                SqlParameter sp = new SqlParameter(string.Format(pram, tf[i].Name), tf[i].dbType);
                sp.Value = tf[i].Value;
                list.Add(sp);
            }
            strSql.Append(") ;SELECT @@identity");
            object obj = DbHelperUFSystem.Instance.ExecuteScalar(CommandType.Text, strSql.ToString(), list.ToArray() as System.Data.Common.DbParameter[]);
            if (obj == null)
            {
                return 1;
            }
            else
            {
                return obj;
            }
        }

        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="IDs"></param>
        /// <param name="tablename"></param>
        /// <param name="chidParent"></param>
        public void DeleteS(string IDs, string tablename, string chidtable, string chidParent)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}{1} ", sPre, tablename);
            strSql.Append(" where ID in(" + IDs + ")");
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());

            //同时删除与此分类相关的内容
            if (!string.IsNullOrWhiteSpace(chidtable))
            {
                strSql = new StringBuilder();
                strSql.AppendFormat("delete from {0}{1} ", sPre, chidtable);
                strSql.AppendFormat(" where {0} in({1})", chidtable, IDs);
            }
            DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 删除多条数据
        /// </summary>
        /// <param name="IDs"></param>
        /// <param name="tablename"></param>
        /// <param name="chidParent"></param>
        public void DeleteSUFSystem(string IDs, string tablename, string chidtable, string chidParent)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}{1} ", sPre, tablename);
            strSql.Append(" where ID in(" + IDs + ")");
            DbHelperUFSystem.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());

            //同时删除与此分类相关的内容
            if (!string.IsNullOrWhiteSpace(chidtable))
            {
                strSql = new StringBuilder();
                strSql.AppendFormat("delete from {0}{1} ", sPre, chidtable);
                strSql.AppendFormat(" where {0} in({1})", chidtable, IDs);
            }
            DbHelperUFSystem.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString());
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public object Delete(string tablename, List<TableFile> where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}NewsContent ", sPre);
            strSql.Append(" where ");

            List<SqlParameter> list = new List<SqlParameter>();
            if (where.Count > 0)
            {
                strSql.Append(" where ");
                for (int i = 0; i < where.Count; i++)
                {
                    strSql.AppendFormat(i == 0 ? udt.Substring(1) : udt, where[i].Name);
                    SqlParameter sp = new SqlParameter(string.Format(pram, where[i].Name), where[i].dbType);
                    sp.Value = where[i].Value;
                    list.Add(sp);
                }
            }
            return DbHelperCmsWrite.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), list.ToArray() as SqlParameter[]);
        }


        /// <summary>
        /// 删除一条数据
        /// </summary>
        public object DeleteUFSystem(string tablename, List<TableFile> where)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.AppendFormat("delete from {0}NewsContent ", sPre);
            strSql.Append(" where ");

            List<SqlParameter> list = new List<SqlParameter>();
            if (where.Count > 0)
            {
                strSql.Append(" where ");
                for (int i = 0; i < where.Count; i++)
                {
                    strSql.AppendFormat(i == 0 ? udt.Substring(1) : udt, where[i].Name);
                    SqlParameter sp = new SqlParameter(string.Format(pram, where[i].Name), where[i].dbType);
                    sp.Value = where[i].Value;
                    list.Add(sp);
                }
            }
            return DbHelperUFSystem.Instance.ExecuteNonQuery(CommandType.Text, strSql.ToString(), list.ToArray() as SqlParameter[]);
        }

        public class TableFile
        {
            public string Name { get; set; }
            public object Value { get; set; }
            public SqlDbType dbType { get; set; }
            public int Length { get; set; }
        }
    }
}
