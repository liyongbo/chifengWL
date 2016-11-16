using System;
using System.Collections.Generic;
using System.Text;

namespace Data.DataProfile
{
    public class FastPaging
    {
        private FastPaging()
        {

        }
        /// <summary>
        /// 获取根据指定字段排序并分页查询的 SELECT 语句。
        /// </summary>
        /// <param name="pageSize">每页要显示的记录的数目。</param>
        /// <param name="pageIndex">要显示的页的索引。</param>
        /// <param name="recordCount">数据表中的记录总数。</param>
        /// <param name="tableName">要查询的数据表。</param>
        /// <param name="queryFields">要查询的字段。</param>
        /// <param name="primaryKey">主键字段。</param>
        /// <param name="ascending">是否为升序排列。</param>
        /// <param name="condition">查询的筛选条件。</param>
        /// <returns>返回排序并分页查询的 SELECT 语句。</returns>
        public static String Paging(
            int pageSize,
            int pageIndex,
            int recordCount,
            String tableName,
            String queryFields,
            String primaryKey,
            bool ascending,
            String condition)
        {
            #region 实现

            StringBuilder sb = new StringBuilder();
            int pageCount = GetPageCount(recordCount, pageSize);   //分页的总数
            int middleIndex = GetMidPageIndex(pageCount);           //中间页的索引
            int firstIndex = 0;                                    //第一页的索引
            int lastIndex = pageCount - 1;                        //最后一页的索引

            #region @PageIndex <= @FirstIndex
            if (pageIndex <= firstIndex)
            {
                sb.Append("SELECT TOP ").Append(pageSize).Append(" ").Append(queryFields)
                    .Append(" FROM ").Append(tableName);

                if (condition != String.Empty)
                    sb.Append(" WHERE ").Append(condition);

                sb.Append(" ORDER BY ").Append(primaryKey).Append(" ")
                    .Append(GetSortType(ascending));
            }
            #endregion

            #region @FirstIndex < @PageIndex <= @MiddleIndex
            else if (pageIndex > firstIndex && pageIndex <= middleIndex)
            {
                sb.Append("SELECT TOP ").Append(pageSize).Append(" ").Append(queryFields)
                    .Append(" FROM ").Append(tableName)
                    .Append(" WHERE ").Append(primaryKey);

                if (ascending)
                    sb.Append(" > (").Append(" SELECT MAX(");
                else
                    sb.Append(" < (").Append(" SELECT MIN(");

                sb.Append(primaryKey).Append(") FROM ( SELECT TOP ")
                    .Append(pageSize * pageIndex).Append(" ").Append(primaryKey)
                    .Append(" FROM ").Append(tableName);

                if (condition != String.Empty)
                    sb.Append(" WHERE ").Append(condition);

                sb.Append(" ORDER BY ").Append(primaryKey).Append(" ")
                    .Append(GetSortType(ascending))
                    .Append(" ) TableA )");

                if (condition != String.Empty)
                    sb.Append(" AND ").Append(condition);

                sb.Append(" ORDER BY ").Append(primaryKey).Append(" ")
                    .Append(GetSortType(ascending));
            }
            #endregion

            #region @MiddleIndex < @PageIndex < @LastIndex
            else if (pageIndex > middleIndex && pageIndex < lastIndex)
            {
                sb.Append("SELECT * FROM ( SELECT TOP ")
                    .Append(pageSize).Append(" ").Append(queryFields)
                    .Append(" FROM ").Append(tableName)
                    .Append(" WHERE ").Append(primaryKey);

                if (ascending)
                    sb.Append(" < (").Append(" SELECT MIN(");
                else
                    sb.Append(" > (").Append(" SELECT MAX(");

                sb.Append(primaryKey).Append(") FROM ( SELECT TOP ")
                    .Append(recordCount - pageSize * (pageIndex + 1)).Append(" ").Append(primaryKey)
                    .Append(" FROM ").Append(tableName);

                if (condition != String.Empty)
                    sb.Append(" WHERE ").Append(condition);

                sb.Append(" ORDER BY ").Append(primaryKey).Append(" ")
                    .Append(GetSortType(!ascending))
                    .Append(" ) TableA )");

                if (condition != String.Empty)
                    sb.Append(" AND ").Append(condition);

                sb.Append(" ORDER BY ").Append(primaryKey).Append(" ")
                    .Append(GetSortType(!ascending))
                    .Append(" ) TableB ORDER BY ").Append(primaryKey).Append(" ")
                    .Append(GetSortType(ascending));
            }
            #endregion

            #region @PageIndex >= @LastIndex
            else if (pageIndex >= lastIndex)
            {
                sb.Append("SELECT * FROM ( SELECT TOP ").Append(recordCount - pageSize * lastIndex)
                    .Append(" ").Append(queryFields)
                    .Append(" FROM ").Append(tableName);

                if (condition != String.Empty)
                    sb.Append(" WHERE ").Append(condition);

                sb.Append(" ORDER BY ").Append(primaryKey).Append(" ")
                    .Append(GetSortType(!ascending))
                    .Append(" ) TableA ORDER BY ").Append(primaryKey).Append(" ")
                    .Append(GetSortType(ascending));
            }
            #endregion

            return sb.ToString();
            #endregion
        }

        /// <summary>
        /// 获取根据指定字段排序并分页查询的 SELECT 语句。
        /// </summary>
        /// <param name="pageSize">每页要显示的记录的数目。</param>
        /// <param name="pageIndex">要显示的页的索引。</param>
        /// <param name="recordCount">数据表中的记录总数。</param>
        /// <param name="tableName">要查询的数据表。</param>
        /// <param name="queryFields">要查询的字段。</param>
        /// <param name="primaryKey">主键字段。</param>
        public static String Paging(
            int pageSize,
            int pageIndex,
            int recordCount,
            String tableName,
            String queryFields,
            String primaryKey)
        {
            return Paging(pageSize, pageIndex, recordCount, tableName, queryFields, primaryKey,
                true, String.Empty);
        }

        /// <summary>
        /// 获取根据指定字段排序并分页查询的 SELECT 语句。
        /// </summary>
        /// <param name="pageSize">每页要显示的记录的数目。</param>
        /// <param name="pageIndex">要显示的页的索引。</param>
        /// <param name="recordCount">数据表中的记录总数。</param>
        /// <param name="tableName">要查询的数据表。</param>
        /// <param name="queryFields">要查询的字段。</param>
        /// <param name="primaryKey">主键字段。</param>
        /// <param name="ascending">是否为升序排列。</param>
        /// <returns>返回排序并分页查询的 SELECT 语句。</returns>
        public static String Paging(
            int pageSize,
            int pageIndex,
            int recordCount,
            String tableName,
            String queryFields,
            String primaryKey,
            bool ascending)
        {
            return Paging(pageSize, pageIndex, recordCount, tableName, queryFields, primaryKey,
                ascending, String.Empty);
        }

        /// <summary>
        /// 获取根据指定字段排序并分页查询的 SELECT 语句。
        /// </summary>
        /// <param name="pageSize">每页要显示的记录的数目。</param>
        /// <param name="pageIndex">要显示的页的索引。</param>
        /// <param name="recordCount">数据表中的记录总数。</param>
        /// <param name="tableName">要查询的数据表。</param>
        /// <param name="queryFields">要查询的字段。</param>
        /// <param name="primaryKey">主键字段。</param>
        /// <param name="condition">查询的筛选条件。</param>
        /// <returns>返回排序并分页查询的 SELECT 语句。</returns>
        public static String Paging(
            int pageSize,
            int pageIndex,
            int recordCount,
            String tableName,
            String queryFields,
            String primaryKey,
            String condition)
        {
            return Paging(pageSize, pageIndex, recordCount, tableName, queryFields, primaryKey,
                true, condition);
        }


        /// <summary>
        /// 计算分页数。
        /// </summary>
        /// <param name="recordCount">表中得记录总数。</param>
        /// <param name="pageSize">每页显示的记录数。</param>
        /// <returns>分页数。</returns>
        public static int GetPageCount(int recordCount, int pageSize)
        {
            return (int)Math.Ceiling((double)recordCount / pageSize);
        }

        /// <summary>
        /// 计算中间页的页索引。
        /// </summary>
        /// <param name="pageCount">分页数。</param>
        /// <returns>中间页的页索引。</returns>
        public static int GetMidPageIndex(int pageCount)
        {
            return (int)Math.Ceiling((double)pageCount / 2) - 1;
        }

        /// <summary>
        /// 获取排序的方式（"ASC" 表示升序，"DESC" 表示降序）。
        /// </summary>
        /// <param name="ascending">是否为升序。</param>
        /// <returns>排序的方式（"ASC" 表示升序，"DESC" 表示降序）。</returns>
        public static String GetSortType(bool ascending)
        {
            return (ascending ? "ASC" : "DESC");
        }

        /// <summary>
        /// 获取一个布尔值，该值指示排序的方式是否为升序。
        /// </summary>
        /// <param name="orderType">排序的方式（"ASC" 表示升序，"DESC" 表示降序）。</param>
        /// <returns>"ASC"则为 true；"DESC"则为 false；其它的为 true。</returns>
        public static bool IsAscending(String orderType)
        {
            return ((orderType.ToUpper() == "DESC") ? false : true);
        }
    }
}
