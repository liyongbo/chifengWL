using Configs.ConfigsBase;
using Entity;
using System.Collections.Generic;

namespace Configs.SysConfigs
{
    public class ConfigsInfo : IConfigInfo
    {
        private string _sMapPath;//安装目录
        private string _DomainName;//虚拟路径
        private string _Copyright;//底部版权
        private string _UserPath = "user/";           // 用户系统的存放路径
        private string _AdminPath = "adminht/";      //后台系统的存放路径
        private string _IISPath = "/"; //目录
        private string _CookieDomain = "";
        private string _CookieDomainAdmin = "";
        private int _IsCookieOrSession = 0;
        private int _UploadSize = 0;//前台上传图片大小限制
        private bool _YZM = false;
        private string _INDEXIMG = "";
        private bool _AuditingContent = false;
        private bool _AuditingComment = false;
        private bool _IsOpenSafeCoder = false;
        private bool _IsOpenAdminLoginLog = true;
        private bool _IsOpenAppLog = true;
        private int _ErrLoginNum = 3;
        private int _HitsUpdateTimeLength = 30;
        private int _LoginExpires = 15;
        private PassWordType _PassType = PassWordType.MD5;
        private string _ContentFileds_Widget = "";      //默认部件查询内容字段
        private string _Culture = "";
        private string _WebServiceSafeCode = "ebsite";
        private int _WebServiceRequestModel = 0;
        private string _EncryptionKey = "ebsite";
        private string _ReturnUrl = "";


        public string INDEXIMG
        {
            get { return _INDEXIMG; }
            set { _INDEXIMG = value; }
        }


        public bool YZM
        {
            get { return _YZM; }
            set { _YZM = value; }
        }
        public int UploadSize
        {
            get { return _UploadSize; }
            set { _UploadSize = value; }
        }

        /// <summary>
        /// 是否开启图片防盗
        /// </summary>
        public bool IsOpenPickproofLinkOfPic { get; set; }
        /// <summary>
        /// 图片防盗的后缀文件,逗号分开
        /// </summary>
        public string PickproofLinkPreOfPic { get; set; }

        /// <summary>
        /// 是否开启文件防盗
        /// </summary>
        public bool IsOpenPickproofLinkOfFile { get; set; }
        /// <summary>
        /// 文件防盗的后缀,逗号分开
        /// </summary>
        public string PickproofLinkPreOfFile { get; set; }


        /// <summary>
        /// web服务的访问模式,0不限制，1允许同个域名下访问,2允许同个IP下访问,3允许访问的IP列表
        /// </summary>
        public int WebServiceRequestModel
        {
            get
            {
                return _WebServiceRequestModel;
            }
            set
            {
                _WebServiceRequestModel = value;
            }
        }

        /// <summary>
        /// Web服务安全码，在客户端调用时要设置此码方可调用
        /// </summary>
        public string WebServiceSafeCode
        {
            get
            {
                return _WebServiceSafeCode;
            }
            set
            {
                _WebServiceSafeCode = value;
            }
        }



        /// <summary>
        /// 当WebServiceRequestModel为3时起作用
        /// </summary>
        public string WebServiceIPS { get; set; }
        public List<string> WebServiceIPList { get; set; }
        public List<string> UserlevaNoCheck { get; set; }
        public List<string> UserlevaUpload { get; set; }

        public int PostTimeOut { get; set; }



        /// <summary>
        /// 本化设置
        /// </summary>
        public string Culture
        {
            get
            {
                return _Culture;
            }
            set
            {
                _Culture = value;
            }
        }

        private bool _IsOpenSql;
        /// <summary>
        /// 是否开户sql跟踪
        /// </summary>
        public bool IsOpenSql
        {
            get
            {
                return _IsOpenSql;
            }
            set
            {
                _IsOpenSql = value;
            }
        }

        
        /// <summary>
        /// 本站加密密钥，用在需要加密的地方，如cookie等
        /// </summary>
        public string EncryptionKey
        {
            get
            {
                return _EncryptionKey;
            }
            set
            {
                _EncryptionKey = value;
            }
        }



        private bool _DisableAutoUpdatePlugin;
        /// <summary>
        /// 是关闭插件自动升级插件
        /// </summary>
        public bool DisableAutoUpdatePlugin
        {
            get
            {
                return _DisableAutoUpdatePlugin;
            }
            set
            {
                _DisableAutoUpdatePlugin = value;
            }
        }


        /// <summary>
        /// 密码的加密模式
        /// </summary>
        public PassWordType PassType
        {
            get
            {
                return _PassType;
            }
            set
            {
                _PassType = value;
            }
        }

        /// <summary>
        /// 用户默认登录状态保存时长
        /// </summary>
        public int LoginExpires
        {
            get
            {
                return _LoginExpires;
            }
            set
            {
                _LoginExpires = value;
            }
        }
        /// <summary>
        /// 是否开启个人空间
        /// </summary>
        public bool IsOpenUserHome { get; set; }

        /// <summary>
        /// 是否开启系统异常友好提示
        /// </summary>
        public bool IsErrFriend { get; set; }
        /// <summary>
        /// 是否开启系统异常日志记录
        /// </summary>
        public bool IsOpenAppLog
        {
            get
            {
                return _IsOpenAppLog;
            }
            set
            {
                _IsOpenAppLog = value;
            }
        }

        /// <summary>
        /// 是否开启管理员登录日志
        /// </summary>
        public bool IsOpenAdminLoginLog
        {
            get
            {
                return _IsOpenAdminLoginLog;
            }
            set
            {
                _IsOpenAdminLoginLog = value;
            }
        }

        /// <summary>
        /// 限制错误登录次数上限,适用于管理员登录与用户登录
        /// </summary>
        public int ErrLoginNum
        {
            get
            {
                return _ErrLoginNum;
            }
            set
            {
                _ErrLoginNum = value;
            }
        }

        /// <summary>
        /// 是否开始验证码
        /// </summary>
        public bool IsOpenSafeCoder
        {
            get
            {
                return _IsOpenSafeCoder;
            }
            set
            {
                _IsOpenSafeCoder = value;
            }
        }

        private bool _IsOpenSafeCoder_PL;
        /// <summary>
        /// 是否开启评论验证码
        /// </summary>
        public bool IsOpenSafeCoder_PL
        {
            get
            {
                return _IsOpenSafeCoder_PL;
            }
            set
            {
                _IsOpenSafeCoder_PL = value;
            }
        }

        /// <summary>
        /// 是否审核评论
        /// </summary>
        public bool AuditingComment
        {
            get
            {
                return _AuditingComment;
            }
            set
            {
                _AuditingComment = value;
            }
        }

        /// <summary>
        /// 是否审核内容
        /// </summary>
        public bool AuditingContent
        {
            get
            {
                return _AuditingContent;
            }
            set
            {
                _AuditingContent = value;
            }
        }

        ///// <summary>
        ///// 是否审核友情连接
        ///// </summary>
        //public bool AuditingLinks
        //{
        //    get
        //    {
        //        return _AuditingLinks;
        //    }
        //    set
        //    {
        //        _AuditingLinks = value;
        //    }
        //}
        /// <summary>
        /// 访问统计(点击率)防作弊策略,0为cookie,1为session
        /// </summary>
        public int IsUpdateHisCookieOrSession
        {
            get
            {
                return _IsCookieOrSession;
            }
            set
            {
                _IsCookieOrSession = value;
            }
        }
        /// <summary>
        /// 访问统计(点击率)批量更新时长
        /// </summary>
        public int HitsUpdateTimeLength
        {
            get
            {
                return _HitsUpdateTimeLength;
            }
            set
            {
                _HitsUpdateTimeLength = value;
            }
        }
        ///// <summary>
        ///// 用户密码Key
        ///// </summary>
        //public string Passwordkey
        //{
        //    get
        //    {
        //        return _Passwordkey;
        //    }
        //    set
        //    {
        //        _Passwordkey = value;
        //    }
        //}
        /// <summary>
        /// Cookie的域
        /// </summary>
        public string CookieDomain
        {
            get
            {
                return _CookieDomain;
            }
            set
            {
                _CookieDomain = value;
            }
        }

        /// <summary>
        /// Cookie的域
        /// </summary>
        public string CookieDomainAdmin
        {
            get
            {
                return _CookieDomainAdmin;
            }
            set
            {
                _CookieDomainAdmin = value;
            }
        }


        /// <summary>
        /// 用户系统的存放路径
        /// </summary>
        public string UserPath
        {
            get
            {
                return _UserPath;
            }
            set
            {
                _UserPath = value;
            }
        }

        private int _MaxThreadForPool = 5;
        /// <summary>
        /// 线程池中的最大线程数
        /// </summary>
        public int MaxThreadForPool
        {
            get
            {
                return _MaxThreadForPool;
            }
            set
            {
                _MaxThreadForPool = value;
            }
        }

        /// <summary>
        /// 后台系统的存放路径
        /// </summary>
        public string AdminPath
        {
            get
            {
                return _AdminPath;
            }
            set
            {
                _AdminPath = value;
            }
        }
        /// <summary>
        /// cms系统的安装目录,如果网站为"/",如果说是虚拟目录为请填写虚拟目录路径
        /// </summary>
        public string IISPath
        {
            get
            {
                return _IISPath;
            }
            set
            {
                _IISPath = value;
            }
        }

        public string AllowUpType { get; set; }

        /// <summary>
        /// 是否订单写入消息队列
        /// </summary>
        private bool _IsMEssageWriting;
        public bool IsMEssageWriting
        {
            get
            {
                return _IsMEssageWriting;
            }
            set
            {
                _IsMEssageWriting = value;
            }
        }
        /// <summary>
        /// 是否加密数据库连接串
        /// </summary>
        /// 

        public bool IsEndDataBaseStr { get; set; }
        private bool _IsOpen404Log = true;
        public bool IsOpen404Log
        {
            get
            {
                return _IsOpen404Log;
            }
            set
            {
                _IsOpen404Log = value;
            }
        }
        /// <summary>
        /// 底部版权
        /// </summary>
        public string Copyright
        {
            get
            {
                return _Copyright;
            }
            set
            {
                _Copyright = value;
            }
        }

        /// <summary>
        /// 是否允许申请友情连接
        /// </summary>
        public bool IsAllowApplyFrdLink { get; set; }
        /// <summary>
        /// 友情连接简介
        /// </summary>
        public string FrdLinkDemo { get; set; }

        /// <summary>
        /// 安装目录
        /// </summary>
        public string sMapPath
        {
            get
            {
                return _sMapPath;
            }
            set
            {
                _sMapPath = value;
            }
        }
        /// <summary>
        /// 域名
        /// </summary>
        public string DomainName
        {
            get
            {
                return _DomainName;
            }
            set
            {
                _DomainName = value;
            }
        }


        private string _UploadPath;
        /// <summary>
        /// 文件的上传目录
        /// </summary>
        public string UploadPath
        {
            get
            {
                return _UploadPath;
            }
            set
            {
                _UploadPath = value;
            }

        }
        public string MainServer { get; set; }
        public string SearchUrl { get; set; }
        public string LtUrl { get; set; }
        public string CssUrl { get; set; }
        public string WyUrl { get; set; }
        public string HyUrl { get; set; }
        public string AdminBackUrl { get; set; }
        public string FileServer { get; set; }
        public string EmailSendPlugin { get; set; }

        public string MobileMsgSendPlugin { get; set; }

        /// <summary>
        /// 缓存模式
        /// </summary>
        public string CacheBll { get; set; }

        private bool _IsAddSearchKeyword = true;
        /// <summary>
        /// 是否开户搜索关键词统计
        /// </summary>
        public bool IsAddSearchKeyword
        {
            get
            {
                return _IsAddSearchKeyword;
            }
            set
            {
                _IsAddSearchKeyword = value;
            }
        }

        /// <summary>
        /// 删除模块时是否同时删除项目文件
        /// </summary>
        public bool DelModuleAndFile { get; set; }
        ///// <summary>
        ///// 网站需要加密的地方所用的密钥
        ///// </summary>
        //public string PassKey { get; set; }

        private bool _IsCacheJsCss = true;
        /// <summary>
        /// 是否缓存JS与CSS
        /// </summary>
        public bool IsCacheJsCss
        {
            get
            {
                return _IsCacheJsCss;
            }
            set
            {
                _IsCacheJsCss = value;
            }
        }
        /// <summary>
        /// ip转换区域名的程序插件
        /// </summary>
        public string IpToAreaPluginName { get; set; }
        /// <summary>
        /// 快递查询插件名称
        /// </summary>
        public string KuaiDiPluginName { get; set; }

        private bool _EnableHttpCompression = false;
        /// <summary>
        /// 是否开启http压缩
        /// </summary>
        public bool EnableHttpCompression
        {
            get
            {
                return _EnableHttpCompression;
            }
            set
            {
                _EnableHttpCompression = value;
            }
        }

        private int _EnableCssCompression = 0;
        /// <summary>
        /// 是否开启JsCss合并与压缩
        /// </summary>
        public int EnableCssCompression
        {
            get
            {
                return _EnableCssCompression;
            }
            set
            {
                _EnableCssCompression = value;
            }
        }
        private int _EnableJsCompression = 0;
        /// <summary>
        /// 是否开启JsCss合并与压缩
        /// </summary>
        public int EnableJsCompression
        {
            get
            {
                return _EnableJsCompression;
            }
            set
            {
                _EnableJsCompression = value;
            }
        }


        private int _MEnableJsCompression = 1;
        /// <summary>
        /// 是否开启JsCss合并与压缩
        /// </summary>
        public int MEnableJsCompression
        {
            get
            {
                return _MEnableJsCompression;
            }
            set
            {
                _MEnableJsCompression = value;
            }
        }
        /// <summary>
        /// solr java api url
        /// </summary>
        public string ProductSolrApiUrl { get; set; }

        public string ReturnUrl
        {
            get
            {
                return _ReturnUrl;
            }

            set
            {
                _ReturnUrl = value;
            }
        }
    }


}
