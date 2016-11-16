using Entity;
using System;
using System.Web;
using Tools;

namespace DataUser
{
    public class UserCookieInfo
    {
        public string uid { get; set; }
        public string un { get; set; }
        public string uni { get; set; }
        public string pa { get; set; }
        public string rid { get; set; }
        public string code008 { get; set; }
        public string code009 { get; set; }
        public string code036 { get; set; }
        public string base036 { get; set; }
        public string cusAbbname { get; set; }
    }
    public partial class DataProviderUser
    {
        private const string sCookieHeader_User = "ebu";
        private const string sCookieHeader_User2 = "ebu2";

        private const string sUserIDMark = "uid";//保存用户ID
        private const string sUsernameMark = "un";//保存用户帐号
        private const string sUserNinameMark = "uni";//保存用户昵称
        private const string sUserPassMark = "pa";//保存用户密码
        private const string sUserRoleIDMark = "rid";//保存用户组ID
        //private const string sManagerID = "mid";//保存用户密码

        private string EncodeByKey(string str)
        {
            return DES.Encode(str, Configs.SysConfigs.ConfigsControl.Instance.EncryptionKey);
        }
        public void WriteUserIdentity(string UserID, string UserName, string UserNiName, string UserPass, int ExpiresTime, string RoleID)
        {
            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(UserNiName) && !string.IsNullOrEmpty(UserPass))
            {
                HttpCookie cookie = new HttpCookie(sCookieHeader_User);
                cookie.Values[sUserIDMark] = UserID;
                cookie.Values[sUsernameMark] = UserName;
                cookie.Values[sUserNinameMark] = Utils.UrlEncode(UserNiName);
                cookie.Values[sUserPassMark] = Utils.UrlEncode(EncodeByKey(UserPass));
                cookie.Values[sUserRoleIDMark] = Utils.UrlEncode(EncodeByKey(RoleID));


                cookie.Values["expires"] = ExpiresTime.ToString();
                cookie.Expires = DateTime.Now.AddMinutes(ExpiresTime);

                string cookieDomain = Configs.SysConfigs.ConfigsControl.Instance.CookieDomain.Trim();
                if (!string.IsNullOrEmpty(cookieDomain) && System.Web.HttpContext.Current.Request.Url.Host.IndexOf(cookieDomain) > -1 && Validate.IsValidDomain(System.Web.HttpContext.Current.Request.Url.Host))
                {
                    cookie.Domain = cookieDomain;
                }

                HttpContext.Current.Response.AppendCookie(cookie);
                //兼容java
                WriteUserIdentity2(UserID, UserName, UserNiName, UserPass, ExpiresTime, RoleID);
            }


        }
        public void WriteUserIdentity2(string UserID, string UserName, string UserNiName, string UserPass, int ExpiresTime, string RoleID)
        {
            if (!string.IsNullOrEmpty(UserName) && !string.IsNullOrEmpty(UserNiName) && !string.IsNullOrEmpty(UserPass))
            {
                UserCookieInfo userInfo = new UserCookieInfo();
                userInfo.pa = UserPass;
                userInfo.rid = RoleID;
                userInfo.uid = UserID;
                userInfo.un = UserName;
                userInfo.uni = UserNiName;
                string jsonUser = JsonHelper.DataContractJsonSerialize(userInfo);
                //TODO 加密是最好的

                HttpCookie cookie = new HttpCookie(sCookieHeader_User2, jsonUser);
                cookie.Expires = DateTime.Now.AddMinutes(ExpiresTime);

                string cookieDomain = Configs.SysConfigs.ConfigsControl.Instance.CookieDomain.Trim();
                if (!string.IsNullOrEmpty(cookieDomain) && System.Web.HttpContext.Current.Request.Url.Host.IndexOf(cookieDomain) > -1 && Validate.IsValidDomain(System.Web.HttpContext.Current.Request.Url.Host))
                {
                    cookie.Domain = cookieDomain;
                }

                HttpContext.Current.Response.AppendCookie(cookie);
            }
        }
       
        /// <summary>
        /// 获取当前登录用户的用户帐号
        /// </summary>
        /// <returns></returns>
        public string GetUserName()
        {
            return Utils.GetSingleVlue(sCookieHeader_User, sUsernameMark);
        }
        /// <summary>
        /// 获取当前登录用户的昵称
        /// </summary>
        public string GetUserNiName()
        {
            return Utils.GetSingleVlue(sCookieHeader_User, sUserNinameMark);
        }

        /// <summary>
        /// 获取当前登录的用户密码(已解密),未登录为空
        /// </summary>
        public string GetUserPass()
        {
            string Pass =Utils.GetSingleVlue(sCookieHeader_User, sUserPassMark);

            if (!string.IsNullOrEmpty(Pass))
            {
                string sKey = Configs.SysConfigs.ConfigsControl.Instance.EncryptionKey;
                if (string.IsNullOrEmpty(Pass)) return string.Empty;
                return DESCrypto.Decode(Pass, sKey);
            }
            return "";
        }

        /// <summary>
        /// 获取当前登录的用户的id,未登录等于-1
        /// </summary>
        public int GetUserId()
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

        private string DecodeByKey(string str)
        {
            return DES.Decode(str, Configs.SysConfigs.ConfigsControl.Instance.EncryptionKey);
        }
        public int GetRoleID()
        {
            string sid = Utils.GetSingleVlue(sCookieHeader_User, sUserRoleIDMark);

            if (!string.IsNullOrEmpty(sid))
            {
                string drid = DecodeByKey(sid);
                if (!string.IsNullOrEmpty(drid))
                    return int.Parse(Utils.UrlDecode(drid));
            }
            return 0;
        }

        /// <summary>
        /// 获取加密后的密码md5等
        /// </summary>
        /// <param name="Pass"></param>
        /// <returns></returns>
        public string PassWordEncode(string Pass)
        {
            PassWordType passWordType = Configs.SysConfigs.ConfigsControl.Instance.PassType;
            string pass;
            if (passWordType == PassWordType.MD5)
            {
                pass = Utils.MD5(Pass);
            }
            else if (passWordType == PassWordType.Hashed)
            {
                pass = StringEncrypt.SHA256(Pass);
            }
            else if (passWordType == PassWordType.MD5MD5)
            {
                pass = Utils.MD5(Utils.MD5(Pass));
            }
            else // (passWordType == PassWordType.MD5Hashed)
            {
                pass = StringEncrypt.SHA256(Utils.MD5(Pass));
            }

            return pass;
        }


    }
}
