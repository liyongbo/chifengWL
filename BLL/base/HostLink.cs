using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;

namespace BLL.Base
{
    /// <summary>
    /// 为插件提供系统常用的信息
    /// </summary>
    public partial class Host
    {
        /// <summary>
        /// 主站域名
        /// </summary>
        public string GetMainServer
        {
            get { return Configs.SysConfigs.ConfigsControl.Instance.MainServer; }
        }
        /// <summary>
        /// 获取物业域名
        /// </summary>
        public string GetWyUrl
        {
            get { return Configs.SysConfigs.ConfigsControl.Instance.WyUrl; }
        }
        /// <summary>
        /// 获取会员域名
        /// </summary>
        public string GetHyUrl
        {
            get { return Configs.SysConfigs.ConfigsControl.Instance.HyUrl; }
        }
        /// <summary>
        /// 获取社区域名
        /// </summary>
        public string GetLtUrl
        {
            get { return Configs.SysConfigs.ConfigsControl.Instance.LtUrl; }
        }
        /// <summary>
        /// 获取后台管理域名
        /// </summary>
        public string GetAdminUrl
        {
            get { return Configs.SysConfigs.ConfigsControl.Instance.AdminBackUrl; }
        }
        /// <summary>
        /// 获取Css域名
        /// </summary>
        public string GetCssUrl
        {
            get { return Configs.SysConfigs.ConfigsControl.Instance.CssUrl; }
        }
        /// <summary>
        /// 获取文件服务器域名
        /// </summary>
        public string GetFileServerUrl
        {
            get { return Configs.SysConfigs.ConfigsControl.Instance.FileServer; }
        }
        /// <summary>
        /// 获取搜索前端域名
        /// </summary>
        public string GetSearchUrl
        {
            get { return Configs.SysConfigs.ConfigsControl.Instance.SearchUrl; }
        }

        public string GetClassHref( int from, object cid, int pageindex, int factoryid, int carmodelid, int yearid, int rootid, int xiaoliang, int jiage, int brandid, string tvs)
        {
            return string.Format("/{12}-{11}-{0}-{1}-{2}-{3}-{4}-{5}-{6}-{7}-{8}-{9}-{10}.html", from, cid, pageindex, factoryid, carmodelid, yearid, rootid, xiaoliang, jiage, brandid, tvs, 0,0);

        }

        

        //public string GetOldClassHref(int from, object cid, int pageindex, int factoryid, int carmodelid, int yearid, int rootid, int xiaoliang, int jiage, int brandid, string tvs)
        //{
        //    Entity.eb_NewsClass model = eb_NewsClass.NewUrl(carmodelid);
        //    if (!Equals(model, null)&&!string.IsNullOrEmpty( model.HtmlName))
        //    {
        //        return model.HtmlName;
        //    }
        //    else
        //    {
        //        return string.Format("{11}-{0}-{1}-{2}-{3}-{4}-{5}-{6}-{7}-{8}-{9}-{10}.html", from, cid, pageindex, factoryid, carmodelid, yearid, rootid, xiaoliang, jiage, brandid, tvs, 0);

        //    }

        //}

        public string GetClassHref( int cb, int from, object cid, int pageindex, int factoryid, int carmodelid, int yearid, int rootid, int xiaoliang, int jiage, int brandid, string tvs)
        {
            return string.Format("/{12}-{11}-{0}-{1}-{2}-{3}-{4}-{5}-{6}-{7}-{8}-{9}-{10}.html", from, cid, pageindex, factoryid, carmodelid, yearid, rootid, xiaoliang, jiage, brandid, tvs, cb, 0);

        }
        /// <summary>
        ///   获取列表页地址 汽车品牌入口， from 来源 0主机厂，1一级分类，2品牌| c 分类id | p 页码 | F 主机厂 |M 车系| y 年款 |r 配件一级分类|x 排序字段 1销量，2价格|j 排序规则 1，降，2升|brandid 品牌ID|zv  格格属性
        /// </summary> 
        public string GetClassHref(int close,int cb,int from, object cid, int pageindex, int factoryid, int carmodelid, int yearid, int rootid, int xiaoliang, int jiage, int brandid, string tvs)
        {
            return string.Format("/{12}-{11}-{0}-{1}-{2}-{3}-{4}-{5}-{6}-{7}-{8}-{9}-{10}.html", from, cid, pageindex, factoryid, carmodelid, yearid, rootid, xiaoliang, jiage, brandid, tvs,cb,close);

        }
        /// <summary>
        /// 获取商品详细页地址
        /// </summary>
        /// <param name="iID">13位商品ID</param>
        /// <returns></returns>
        public string GetContentLink(object iID)
        {
            return string.Format("{1}/{0}.html", iID, GetMainServer);
        }
        /// <summary>
        /// 获取专题页面地址
        /// </summary>
        /// <param name="id">专题ID</param> 
        /// <returns></returns>
        public string GetSpecialHref(int id)
        {
            return string.Empty;
        }
        
       
        /// <summary>
        /// 获取搜索页面地址
        /// </summary>
        public string SearchUrl
        {
            get
            {
                return string.Concat(GetSearchUrl,"/so.jsp");
            }

        }

        public string GetErrPageRw(string id)
        {
            return string.Empty;
        }

        public string LoginApiBindUrl(string appname)
        {
            return "";
        }
        /// <summary>
        /// 获取帮助中心页面连接地址
        /// </summary>
        /// <returns></returns>
        public string NewsUrl(object id)
        {
            return string.Concat(GetMainServer,"/n",id,".html");
        }
        public string NewsListUrl(object cid, int PageIndex)
        {
            return string.Concat(GetMainServer, "/nl", cid, "-",PageIndex,".html");
        }
        public string SpecialUrl(object id)
        {
            return string.Concat(GetMainServer,"s", id, ".html");
        }

        public string PinPaiDaQuanUrl
        {
            get { return "/pinpaidaquan.shtml"; }
        }
        public string PeiJianDaQuanUrl
        {
            get { return "/peijiandaquan.shtml"; }
        }
        public string PartsCategoryBrandUrl
        {
            get { return "/partscategorybrand.html"; }
        }
        
        public string InstallShop
        {
            get { return "/installshop.html"; }
        }
        /// <summary>
        /// 获取第三方登录页面地址,比如你要在首页连接全个QQ登录，调用这个方法
        /// </summary>
        /// <param name="AppName">第三方登录插件标记，如QQ,TAOBAO</param>
        /// <returns>返回一个地址，连接倒第三方验证平台</returns>
        public string GetLoginApiUrl(string AppName)
        {
            return string.Concat(IISPath, "loginapi.ashx?t=", AppName);
        }
        ///// <summary>
        ///// 问答路径
        ///// </summary>
        ///// <param name="id"></param>
        ///// <returns></returns>
        //public string WenDaUrl(int id)
        //{          
        //    return string.Concat(GetAskUrl,"/ask/", id);
        //}

        /// <summary>
        /// 获取网站安装的虚拟目录
        /// </summary>
        public string IISPath
        {
            get
            {
                return Base.AppStartInit.IISPath;
            }
        }
        /// <summary>
        /// 获取当前网站域名
        /// </summary>
        public string Domain
        {
            get
            {
                return AppStartInit.DomainName;
            }
        }
        /// <summary>
        /// 获取网站安装的绝对目录
        /// </summary>
        public string sMapPath
        {
            get
            {
                return Configs.SysConfigs.ConfigsControl.Instance.sMapPath;
            }
        }
    }
}
