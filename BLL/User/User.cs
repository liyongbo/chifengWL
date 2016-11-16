using BLL.Base;
using Entity;

using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using System.Xml.Linq;
using System;
namespace BLL
{

    public class User
    {
        private const string cacheclass = "User";
        static User()
        {
        }
        /// <summary>
        /// 增加一条数据
        /// </summary>
        static public long Add(Entity.User model)
        {

            long cid = Host.Instance.DALCMS.User_Add(model);
            if (cid > 0)
            {
                return cid;
            }
            else
            {
                return -1;
            }

        }


        /// <summary>
        /// 更新一条数据
        /// </summary>
        static public void Update(Entity.User model)
        {
            Host.Instance.DALCMS.User_Update(model);
            //Host.CacheApp.InvalidateCache(cacheclass);
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        static public void Delete(long id)
        {
            Host.Instance.DALCMS.User_Delete(id);
        }
        static public void Delete(string ids)
        {
            Host.Instance.DALCMS.User_Deletes(ids);
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        static public Entity.User GetModel(long id)
        {
            return Host.Instance.DALCMS.User_GetModel(id); ;
        }


        static public List<Entity.User> User_GetListArray(string strWhere, int top, string orderby, bool ascORdesc)
        {
            return Host.Instance.DALCMS.User_GetListArray(strWhere, top, orderby, ascORdesc); ;
        }
        static public List<Entity.User> User_GetListPages(int PageIndex, int PageSize, string strWhere, string oderby, bool ascending, out long rc)
        {
            return Host.Instance.DALCMS.User_GetListPages(PageIndex, PageSize, strWhere, oderby, ascending, out  rc);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="login_username">用户帐号，或用户email或手机号码，视login_type 而定，0为帐号登录，1为email登录，2为手机号登录</param>
        /// <param name="login_pwd">密码</param>
        /// <param name="login_yzm">验证码</param>
        /// <param name="iscookie">是否记住</param>
        /// <param name="login_type">0为帐号登录，1为email登录，2为手机号登录</param>
        /// <param name="ls">登录状态</param>
        /// <param name="sReturnUrl">登录成功后返回地址</param>
        /// <param name="IsMD5Pass">密码是否经过加密的</param>
        /// <param name="sFromUrl">请求来源地址，用户返回</param>
        /// <returns></returns>
        static public Entity.User Login(string login_username, string login_pwd, string login_yzm, bool iscookie, int login_type, out LoginStatus ls, out string sReturnUrl, bool IsMD5Pass, string sFromUrl)
        {

            sReturnUrl = string.Empty;
            if (BLL.UserIdentity.IsOverErrLoginNum())
            {
                ls = LoginStatus.错误登录次数超出规定;
                return null;
            }

            Entity.User ucf = null;
            //验证是否禁止登录IP

            bool isAllowIP = Tools.IP.IsAllowIP(Tools.Utils.GetClientIP(), Configs.UserSetConfigs.ConfigsControl.Instance.StarIP,
 Configs.UserSetConfigs.ConfigsControl.Instance.EndIP, Configs.UserSetConfigs.ConfigsControl.Instance.IPSetDateTime);

            if (!isAllowIP)
            {
                ls = LoginStatus.IP禁止登录;
                return null;
            }

            string sPass = (IsMD5Pass) ? login_pwd : UserIdentity.PassWordEncode(login_pwd);

            bool HaveUser = false;

                List<Entity.User> user = Host.Instance.DALCMS.User_GetListArray(string.Format("[username]='{0}' and [userpassword]='{1}'", Tools.GetString.NoHTML(login_username.Trim()), sPass), 1, "[id]", true);
                if (user != null && user.Count > 0)
                {
                    ucf = user.FirstOrDefault();
                    if (ucf.state == Entity.UserState.账号锁定.GetHashCode())
                    {
                        ls = LoginStatus.帐号出现异常已锁定;
                        return null;
                    }
                    HaveUser = true;
                }
            


            if (HaveUser)
            {
                ucf.endtime = DateTime.Now;
                Update(ucf);

                int CookieExpiresTime = 1440; //1440分钟后过期 一天时间24小时
                if (iscookie)
                    CookieExpiresTime = Configs.SysConfigs.ConfigsControl.Instance.LoginExpires;
                BLL.Base.Host.Instance.WriteUserIdentity(ucf.id.ToString(), ucf.username, ucf.name, ucf.userpassword, 180, "", "");
            }
            else
            {
                try
                {
                    BLL.UserIdentity.AddErrLoginNum();
                }
                catch (Exception ex) { }
                ls = LoginStatus.不存在此帐号或密码错误;
                return null;
            }


            ls = LoginStatus.登录成功;
            sReturnUrl = sFromUrl;
            return ucf;

        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="reg_username">用户名</param>
        /// <param name="reg_pwd">密码</param>
        /// <param name="reg_mobile">手机号</param>
        /// <param name="ip">用户IP</param>
        /// <param name="ms">返回信息</param>
        /// <returns></returns>
        static public int RegUser(string reg_username, string reg_pwd, string reg_weixin, string reg_mobile, string reg_address, string ip, out RegStatus ms)
        {
            List<Entity.User> user = BLL.User.User_GetListArray(" username='" + reg_username.Trim() + "'", 0, "id", true);
            if (user != null && user.Count > 0)
            {
                ms = RegStatus.已经存在此帐号;
                return 0;
            }

            //同时注册UserCustomField表，以记录用户的一些共同可扩展属性
            Entity.User userE = new Entity.User();
            userE.username = reg_username;
            userE.userpassword = BLL.UserIdentity.PassWordEncode(reg_pwd);
            userE.tel = reg_mobile;
            userE.address = reg_address;
            userE.weixin = reg_weixin;
            userE.ip = ip;
            userE.name = reg_username;
            userE.timedate = DateTime.Now;
            userE.endtime = DateTime.Now;
            long iNewUserID = BLL.User.Add(userE);

            if (iNewUserID > 0)
            {
                #region 发送激活信
                //if (Configs.UserSetConfigs.ConfigsControl.Instance.AllowUserType == 2)
                //{

                //    string sWebName = "";//Base.Host.Instance.MainSite.SiteName;
                //    string sWebUrl = Configs.SysConfigs.ConfigsControl.Instance.DomainName;
                //    string iisPath = Configs.SysConfigs.ConfigsControl.Instance.IISPath;
                //    string ActivateCorde = GetActivateEncode(iNewUserID.ToString(), UCF.CreateDate.ToString(), YQUserID, RoleID);

                //    string sContent = string.Format("感谢您加入[{0}],请在24小时内点击此连接来激活您的帐号 <a href='{1}{2}activate.aspx?act={3}'>{1}{2}activate.aspx?act={3}</a>！",
                //        sWebName, sWebUrl, iisPath, ActivateCorde
                //        );
                //    EmailBLL.SendEmail(email.Trim(), "请激活您的帐号", sContent);
                //}
                #endregion
                ms = RegStatus.注册成功;
            }
            else
            {
                ms = RegStatus.注册失败;
            }
            return (int)iNewUserID;
        }

        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="reg_username">用户名</param>
        /// <param name="reg_pwd">密码</param>
        /// <param name="reg_mobile">手机号</param>
        /// <param name="ip">用户IP</param>
        /// <param name="ms">返回信息</param>
        /// <returns></returns>
        static public int RegBus(string reg_storename,string reg_storeaddress,string reg_tel,string Ip,out RegStatus ms)
        {
            List<Entity.Store> user = BLL.Store.Store_GetListArray(" title='" + reg_storename.Trim() + "'", 0, "id", true);
            if (user != null && user.Count > 0)
            {
                ms = RegStatus.已经存在此帐号;
                return 0;
            }

            //同时注册UserCustomField表，以记录用户的一些共同可扩展属性
            Entity.Store userE = new Entity.Store();
            userE.Title = reg_storename;
            userE.Address = reg_storeaddress;
            userE.CreateDate = DateTime.Now.ToString();
            userE.LastupDateTime = DateTime.Now.ToString();
            long iNewUserID = BLL.Store.Add(userE);

            if (iNewUserID > 0)
            {
                #region 发送激活信
                //if (Configs.UserSetConfigs.ConfigsControl.Instance.AllowUserType == 2)
                //{

                //    string sWebName = "";//Base.Host.Instance.MainSite.SiteName;
                //    string sWebUrl = Configs.SysConfigs.ConfigsControl.Instance.DomainName;
                //    string iisPath = Configs.SysConfigs.ConfigsControl.Instance.IISPath;
                //    string ActivateCorde = GetActivateEncode(iNewUserID.ToString(), UCF.CreateDate.ToString(), YQUserID, RoleID);

                //    string sContent = string.Format("感谢您加入[{0}],请在24小时内点击此连接来激活您的帐号 <a href='{1}{2}activate.aspx?act={3}'>{1}{2}activate.aspx?act={3}</a>！",
                //        sWebName, sWebUrl, iisPath, ActivateCorde
                //        );
                //    EmailBLL.SendEmail(email.Trim(), "请激活您的帐号", sContent);
                //}
                #endregion
                ms = RegStatus.注册成功;
            }
            else
            {
                ms = RegStatus.注册失败;
            }
            return (int)iNewUserID;
        }
    }
}




