using System;
using System.Web;
using System.Web.Security;
using BLL.Base;
using BLL.Base;
using Tools;
using Entity;



namespace BLL
{
    /// <summary>
    /// 业务逻辑类EB_FriendList 的摘要说明。
    /// </summary>
    public class UserIdentity
    {

        #region 加密算法


        private string EncodeByKey(string str)
        {
            return DES.Encode(str, Configs.SysConfigs.ConfigsControl.Instance.EncryptionKey);
        }

        private string DecodeByKey(string str)
        {
            return DES.Decode(str, Configs.SysConfigs.ConfigsControl.Instance.EncryptionKey);
        }

        /// <summary>
        /// 获取加密后的密码md5等
        /// </summary>
        /// <param name="Pass"></param>
        /// <returns></returns>
        public static string PassWordEncode(string Pass)
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
        #endregion

        #region 管理员登录cookie管理

        private const string sCookieHeader_admin = "ebadm";
        private const string sIsadminMark = "isadm";


        /// <summary>
        /// 写入管理员登录cookie
        /// </summary>
        public static void WriteAdminLogInTag()
        {
            WriteAdminLogInTag("adm");
        }
        /// <summary>
        /// 对管理员登录 cookie的操作
        /// </summary>
        /// <param name="Tag"></param>
        public static void WriteAdminLogInTag(string Tag)
        {
            HttpCookie cookie = new HttpCookie(sCookieHeader_admin);
            cookie.Values[sIsadminMark] = Tag;

            string cookieDomain = Configs.SysConfigs.ConfigsControl.Instance.CookieDomain.Trim();
            if (cookieDomain != string.Empty && HttpContext.Current.Request.Url.Host.IndexOf(cookieDomain) > -1 && Validate.IsValidDomain(HttpContext.Current.Request.Url.Host))
            {
                cookie.Domain = cookieDomain;
            }

            HttpContext.Current.Response.AppendCookie(cookie);
        }
        /// <summary>
        /// 检测管理员是不是已经登录
        /// </summary>
        /// <returns></returns>
        public static bool IsAdminLogIn()
        {
            string sIsLogin = Tools.Utils.GetSingleVlue(sCookieHeader_admin, sIsadminMark);

            return !string.IsNullOrEmpty(sIsLogin);
        }
        /// <summary>
        /// 登出管理员登录
        /// </summary>
        public static void SignOutAdmin()
        {
            HttpCookie cookie = new HttpCookie(sCookieHeader_admin);
            cookie.Values.Clear();
            cookie.Expires = DateTime.Now.AddYears(-1);
            string cookieDomain = Configs.SysConfigs.ConfigsControl.Instance.CookieDomain.Trim();
            if (cookieDomain != string.Empty && HttpContext.Current.Request.Url.Host.IndexOf(cookieDomain) > -1 && Validate.IsValidDomain(HttpContext.Current.Request.Url.Host))
                cookie.Domain = cookieDomain;
            HttpContext.Current.Response.AppendCookie(cookie);

        }

        #endregion

        #region 对在线用户cookie的管理


        private const string sCookieHeader_Online = "ol";
        private const string sOnlineidMark = "olid";

        /// <summary>
        /// 写入一个用户的在线ID
        /// </summary>
        /// <param name="OnlineID"></param>
        public static void WriteUserOnlineID(string OnlineID)
        {

            HttpCookie cookie = new HttpCookie(sCookieHeader_Online);
            cookie.Values[sOnlineidMark] = OnlineID;

            string cookieDomain = Configs.SysConfigs.ConfigsControl.Instance.CookieDomain.Trim();
            if (cookieDomain != string.Empty && HttpContext.Current.Request.Url.Host.IndexOf(cookieDomain) > -1 && Validate.IsValidDomain(HttpContext.Current.Request.Url.Host))
            {
                cookie.Domain = cookieDomain;
            }

            int LoginExpires = Configs.SysConfigs.ConfigsControl.Instance.LoginExpires;

            cookie.Expires = DateTime.Now.AddMinutes(LoginExpires);

            HttpContext.Current.Response.AppendCookie(cookie);
        }

     

        /// <summary>
        /// 获取当前用户的在线ID
        /// </summary>
        /// <returns></returns>
        public static string GetUserOnlineID()
        {
            return Tools.Utils.GetSingleVlue(sCookieHeader_Online, sOnlineidMark);
        }

        #endregion

        #region 安全登录相关的一此辅助操作

        //////////////////////////////安全登录相关的一此辅助操作/////////////////////////////
        /// <summary>
        /// 检测是否超过预定错误登录次数
        /// </summary>
        /// <returns></returns>
        public static bool IsOverErrLoginNum()
        {
            bool bl = false;
            if ((HttpContext.Current.Session!=null && HttpContext.Current.Session["PassErrorCountAdmin"] != null) && (HttpContext.Current.Session["PassErrorCountAdmin"].ToString() != ""))
            {
                int PassErroeCount = Convert.ToInt32(HttpContext.Current.Session["PassErrorCountAdmin"]);
                if (PassErroeCount > (Configs.SysConfigs.ConfigsControl.Instance.ErrLoginNum - 1))
                {
                    bl = true;
                }

            }
            return bl;
        }
        /// <summary>
        /// 累加错误登录次数
        /// </summary>
        public static void AddErrLoginNum()
        {
            if (GetErrNum > 0)
            {

                HttpContext.Current.Session["PassErrorCountAdmin"] = GetErrNum + 1;
            }
            else
            {
                HttpContext.Current.Session["PassErrorCountAdmin"] = 1;
            }
        }
        /// <summary>
        /// 获取错误登录次数
        /// </summary>
        public static int GetErrNum
        {
            get
            {
                int inum = 0;
                if ((HttpContext.Current.Session != null && HttpContext.Current.Session["PassErrorCountAdmin"] != null) && (HttpContext.Current.Session["PassErrorCountAdmin"].ToString() != ""))
                {
                    inum = Convert.ToInt32(HttpContext.Current.Session["PassErrorCountAdmin"]);

                }

                return inum;
            }
        }
        public static bool ValidateSafeCode(string Code)
        {
            return ValidateSafeCode(Code, true);
        }

        /// <summary>
        /// 验证用户输入的安全码是否正确
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public static bool ValidateSafeCode(string Code, bool IsOKSetNull)
        {
            bool bl = false;
            if (!string.IsNullOrEmpty(Code))
            {
                if (!Equals(HttpContext.Current.Session["CheckCode"], null) && HttpContext.Current.Session["CheckCode"].ToString().Trim() != string.Empty)
                {
                    if (HttpContext.Current.Session["CheckCode"].ToString().ToLower() == Code.ToLower())
                    {

                        bl = true;
                        if (IsOKSetNull)
                            HttpContext.Current.Session["CheckCode"] = null;
                    }


                }
            }

            return bl;
        }

        /// <summary>
        /// 验证用户输入的安全码是否正确
        /// </summary>
        /// <param name="Code"></param>
        /// <returns></returns>
        public static bool ValidateMobileCode(string Code, string mobile)
        {
            HttpCookie cook = HttpContext.Current.Request.Cookies[mobile];
            if (cook != null && cook.Value == Code)
            {
                return true;
            }
            return false;
        }

        #endregion

    }
}

