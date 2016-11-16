using System;
using System.Collections.Generic;
using System.Linq;
using Tools;

namespace Configs
{
    public class Utity
    {
        static public string IISPath
        {
            get { return "/"; }
        }

        static public string AdminPath
        {
            get { return "/adminht/"; }
        }

        static public string UserUploadPath
        {
            get { return "/UploadFile"; }
        }
        /// <summary>
        /// 获取ebsite数据库表前缀
        /// </summary>
        static public string GetSysTablePrefix
        {
            get
            {
                return Configs.BaseCinfigs.ConfigsControl.Instance.TablePrefix;
            }
        }
        static public string DomainName
        {
            get { return Configs.SysConfigs.ConfigsControl.Instance.DomainName; }
        }
        //yhl 2014-09-15
        private const string sCookieHeader_Online = "ol";
        private const string sOnlineidMark = "olid";

        private const string sCookieHeader_User = "ebu";
        private const string sUserIDMark = "uid";//保存用户ID

        static public int OnlineID
        {
            get
            {
                string sOlid = Utils.GetSingleVlue(sCookieHeader_Online, sOnlineidMark); ;
                if (!string.IsNullOrEmpty(sOlid))
                {
                    return int.Parse(sOlid);
                }
                return 0;
            }
        }

        static public int UserID
        {

            get
            {
                string sid = Utils.GetSingleVlue(sCookieHeader_User, sUserIDMark);

                if (!string.IsNullOrEmpty(sid))
                {
                    return int.Parse(sid);
                }
                else
                {
                    return -1;
                }

            }
        }

    }
}
