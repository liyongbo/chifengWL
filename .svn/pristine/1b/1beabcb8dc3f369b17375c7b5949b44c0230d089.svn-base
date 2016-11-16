using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Data.DataProfile
{

    public class SqlProvider : IDbProvider
    {
        public DbProviderFactory Instance()
        {

            // return SqlClientFactory.Instance;

            return SqlClientFactory.Instance;
        }

        public void DeriveParameters(IDbCommand cmd)
        {
            //if ((cmd as SqlCommand) != null)
            //{
            //    SqlCommandBuilder.DeriveParameters(cmd as SqlCommand);
            //}

            if ((cmd as SqlCommand) != null)
            {
                SqlCommandBuilder.DeriveParameters(cmd as SqlCommand);
            }
        }

        public DbParameter MakeParam(string ParamName, SqlDbType DbType, Int32 Size)
        {
            SqlParameter param;

            if (Size > 0)
                param = new SqlParameter(ParamName, DbType, Size);
            else
                param = new SqlParameter(ParamName,DbType);

            return param;
        }

        public bool IsFullTextSearchEnabled()
        {
            return true;
        }

        public bool IsCompactDatabase()
        {
            return true;
        }

        public bool IsBackupDatabase()
        {
            return true;
        }

        public string GetLastIdSql()
        {
            return "SELECT SCOPE_IDENTITY()";
        }
        public bool IsDbOptimize()
        {

            return false;
        }
        public bool IsShrinkData()
        {


            return true;
        }

        public bool IsStoreProc()
        {

            return true;
        }
    }
}
