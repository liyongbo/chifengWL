
using System;
namespace Data.DataProfile
{

    /// <summary>
    /// 数据访问助手类
    /// </summary>
    public class DbHelperU8 : DbHelperBase
    {
        static public readonly DbHelperU8 Instance = new DbHelperU8();
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public override string ConnectionString()
        {
            if (string.IsNullOrEmpty(base.m_connectionstring))
            {
                base.m_connectionstring = Configs.BaseCinfigs.ConfigsControl.Instance.GetConnectionStringU8();
            }
            return base.m_connectionstring;
        }
        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public override string ConnectionString(string sqlname, string dbName)
        {
            return "server=" + sqlname + ";database=" + dbName + ";uid=sa;pwd=Sa123";
        }
        /// <summary>
        /// IDbProvider接口
        /// </summary>
        public override IDbProvider Provider()
        {
            if (m_provider == null)
            {
                lock (lockHelper)
                {
                    if (m_provider == null)
                    {
                        try
                        {
                            m_provider = new MySqlProvider();
                            //m_provider = (IDbProvider)Activator.CreateInstance(Type.GetType(string.Format("Data.{0}Provider, Data.{0}", Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerType), false, true));
                        }
                        catch
                        {
                            throw new Exception("请检查Base.config中Dbtype节点数据库类型是否正确，例如：SqlServer、Access、MySql");
                        }

                    }
                }
            }
            return m_provider;
        }

    }

}