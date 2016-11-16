using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Security;
using Amib.Threading;
using Entity;
using Tools;


namespace BLL.Base
{
    /// <summary>
    /// 为插件提供系统常用的信息
    /// </summary>
    public partial class Host 
    {
       
        /// <summary>
        /// 将一个文件按回车分割成数组
        /// </summary>
        /// <param name="str">源字符</param>
        /// <returns></returns>
        public string[] HuiCheSplit(string str)
        {
            return GetString.SplitString(str, "\r\n");//\r\n
        }
        
        /// <summary>
        /// 获取来路
        /// </summary>
        public  string GetReurl
        {
            get
            {
                return HttpContext.Current.Request["ru"];
            }
        }
     
  
        /// <summary>
        /// 对字符进行md5加密
        /// </summary>
        /// <param name="str">在加密的字符串</param>
        /// <returns></returns>
        public string EncodeByMD5(string str)
        {
            return Utils.MD5(str);
        }
        /// <summary>
        /// 使用ebsite设置的密钥加密
        /// </summary>
        /// <param name="str">要加密的字符</param>
        /// <returns></returns>
        public string EncodeByKey(string str)
        {
            return DES.Encode(str, Configs.SysConfigs.ConfigsControl.Instance.EncryptionKey);
        }
        /// <summary>
        /// 使用ebsite设置的密钥解密
        /// </summary>
        /// <param name="str">要解密的字符</param>
        /// <returns></returns>
        public string DecodeByKey(string str)
        {
            return DES.Decode(str, Configs.SysConfigs.ConfigsControl.Instance.EncryptionKey);
        }

        /// <summary>
        /// 获取CMS数据库提供程序名称
        /// </summary>
        public string GetCMSDbType
        {
            get
            {
                return Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerType;
            }
        }
        /// <summary>
        /// 获取用户数据库提供程序名称
        /// </summary>
        public string GetUserDbType
        {
            get
            {
                return Configs.BaseCinfigs.ConfigsControl.Instance.DataLayerTypeUser;
            }
        }
        /// <summary>
        /// 定向到一个提示页面
        /// </summary>
        /// <param name="Title">提示标题</param>
        /// <param name="Info">提示内容</param>
        public void Tips(string Title, string Info)
        {
            Tips(Title, Info, "");
        }
   

        public void Tips(string Title, string Info, string sUrl)
        {
            AppStartInit.TipsPageRender(Title, Info, sUrl);
        }
        /// <summary>
        /// 发送一条站内信息
        /// </summary>
        /// <param name="Title">信息标题</param>
        /// <param name="Msg">信息内容</param>
        /// <param name="RecUserID">接收人ID</param>
       /// <param name="IsHtml">是否html,如果是对外开放，一定要设置为fase,让系统自动过滤html,否则会有脚本注入情况</param>
        public void SendSysMsg(string Title,string Msg,int RecUserID,bool IsHtml)
        {
            //BeiMai.BLL.Msg md = new BeiMai.BLL.Msg();
            //md.SendDate = DateTime.Now;
            //md.IsNewMsg = true;
            //md.Sender = string.IsNullOrEmpty(UserName) ? "游客" : UserName;
            //md.SenderNiName = UserNiName;
            //md.SenderUserID = UserID;
            //md.RecipientUserID = RecUserID;
            //md.FolderType = 1;
            //if (IsHtml)
            //{
              
            //    md.MsgContent = Msg;
            //}
            //else
            //{
            //    md.MsgContent = Utils.EncodeHtml(Msg);
                
            //}
            //if (!string.IsNullOrEmpty(Title))
            //{
            //    md.Title = GetString.NoHtml(Title);
            //}
            //else
            //{
            //    md.Title = GetString.CutLen(GetString.NoHtml(md.MsgContent), 50);
            //}
            
           
            //md.Save();

        }
        /// <summary>
        /// 发送一条站内信息
        /// </summary>
        /// <param name="Msg">短消息内容</param>
        /// <param name="RecUserID">接收用户ID</param>
        /// <param name="IsHtml">是否HTML格式</param>
        public void SendSysMsg( string Msg, int RecUserID, bool IsHtml)
        {
            SendSysMsg("", Msg, RecUserID, IsHtml);
        }



        /// <summary>
        /// 在线程池中发送email
        /// </summary>
        /// <param name="email">要接收EMAIL的地址</param>
        /// <param name="title">email标题</param>
        /// <param name="body">email内容</param>
        public void SendEmailPool(string email, string title, string body)
        {
            //EmailBLL.SendEmail(email, title, body);
        }


        /// <summary>
        /// 发送一条手机短信
        /// </summary>
        /// <param name="Msg">短信内容</param>
        /// <param name="MobiNumber">手机号码</param>
        /// <param name="UserName">发送人帐号</param>
        public void SendMobileMsg(string Msg, string MobiNumber, string UserName)
        {
           
        }
        /// <summary>
        /// 加密一个密码
        /// </summary>
        /// <param name="sPass"></param>
        /// <returns></returns>
        public string PassWordEncode(string sPass)
        {
            return BLL.UserIdentity.PassWordEncode(sPass);
        }

    }
}
