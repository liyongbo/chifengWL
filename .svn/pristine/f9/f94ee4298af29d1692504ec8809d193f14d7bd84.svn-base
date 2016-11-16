
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
using Tools;


namespace BLL
{
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class WebServiceBase : System.Web.Services.WebService
    {
        //public SecurityContext SecurityKey = null;
        protected readonly string NoAllowTips = "acess refuse.";

        public  WebServiceBase()
        {
            if (!IsAllow(true))
            {
                Context.Response.Write(NoAllowTips);
                Context.Response.End();
            }
        }
       

        /// <summary>
        /// 判断用户是否有权限访问web服务
        /// </summary>
        /// <param name="IsCheckUserLogin">是否验证登录</param>
        /// <returns></returns>
        protected bool IsAllow(bool IsCheckUserLogin, bool IsCheckAdminLogin)
        {

            bool isok = false;

            if (Configs.SysConfigs.ConfigsControl.Instance.WebServiceRequestModel == 0) //无验证
            {
                isok = true;
            }
            else if (Configs.SysConfigs.ConfigsControl.Instance.WebServiceRequestModel == 1) //验证安全码
            {
                string stUrlReferrer = Utils.GetUrlReferrer();
                string sHost = Utils.GetHost();
                isok = Utils.IsCrossSitePost(stUrlReferrer, sHost, Configs.SysConfigs.ConfigsControl.Instance.DomainName);//是否跨域

                //if (!Equals(SecurityKey, null))  //在jquery ajax里请求有问题，暂时不开启
                //{

                //    isok = (SecurityKey.SafeKey == ConfigsControl.Instance.WebServiceSafeCode);

                //    string stUrlReferrer = Utils.GetUrlReferrer();
                //    string sHost = Utils.GetHost();
                //    isok = !Utils.IsCrossSitePost(stUrlReferrer, sHost);//是否跨域
                //}

            }

            if (isok)
            {
                if (Context.Request.UrlReferrer.AbsoluteUri.ToLower().IndexOf("login.aspx") == -1)
                {
                    if (IsCheckUserLogin)
                    {
                        isok = BLL.Base.Host.Instance.UserID > 0 ? true : false;
                    }
                }
            }
            return isok;

        }
        protected bool IsAllow(bool IsCheckUserLogin)
        {
            return IsAllow(IsCheckUserLogin, false);
        }

        //[WebMethod]
        ////[SoapHeader("SecurityKey")]
        //public string IISPath()
        //{
        //    return BLL.Base.AppStartInit.IISPath;
        //}
        [WebMethod]
        //[SoapHeader("SecurityKey")]
        public string UserName()
        {
            return BLL.Base.Host.Instance.UserName;
        }
        [WebMethod]
        //[SoapHeader("SecurityKey")]
        public int UserID()
        {
            return BLL.Base.Host.Instance.UserID;
        }

    }
}
