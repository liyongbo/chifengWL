using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tools
{
    public class Cookie
    {
        /// <summary>
        /// 创建Cookie 并对值加密
        /// </summary>
        /// <param name="name">cookie 名</param>
        /// <param name="key">名包含的键</param>
        /// <param name="value">名包含的值</param>
        public static void CookieEncryption(String name, String key, String value, int time)
        {
            value = StringEncrypt.Encrypt(value);
            System.Web.HttpCookie cookie = null;
            if (Object.Equals(System.Web.HttpContext.Current.Request.Cookies[name], null))
                cookie = new System.Web.HttpCookie(name);
            else
                cookie = System.Web.HttpContext.Current.Request.Cookies[name];
            if (Object.Equals(cookie.Values[key], null))
                cookie.Values.Add(key, value);
            else
                cookie.Values[key] = value;
            //发布时必须注视掉cookie时间
            if (time > 0)
            {
                cookie.Expires = DateTime.Now.AddDays(time);
            }
            System.Web.HttpContext.Current.Response.AppendCookie(cookie);
        }
        /// <summary>
        /// Cookie解密
        /// </summary>
        /// <param name="name">cookie 名</param>
        /// <param name="key">名包含的键</param>
        /// <returns></returns>
        public static String CookieDecrypt(String name, String key)
        {
            try
            {
                return StringEncrypt.Decrypt(System.Web.HttpContext.Current.Request.Cookies[name].Values[key]);
            }
            catch
            {
                return string.Empty;
            }
        }
    }
}
