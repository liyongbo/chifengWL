﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.Services.Protocols;
using BLL.Base;
using Entity;


namespace BLL
{


    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    public class MainWebServiceBase : WebServiceBase
    {

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="login_username">用户帐号，或用户email或手机号码，视login_type 而定，0为帐号登录，1为email登录，2为手机号登录</param>
        /// <param name="login_pwd">密码,未加密</param>
        /// <param name="login_yzm">验证码</param>
        /// <param name="iscookie">是否记住</param>
        /// <param name="login_type">0为帐号登录，1为email登录，2为手机号登录</param>
        /// <param name="login_formurl">请求来源地址，用户返回</param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        ////[SoapHeader("SecurityKey")]
        public JsonResponse LoginUser(string login_username, string login_pwd)
        {
            JsonResponse jr = new JsonResponse();
            if (IsAllow(false))
            {
                LoginStatus ls;
                string sReturnUrl;

                Entity.Users md = BLL.Users.Login(login_username, login_pwd, out ls, out sReturnUrl);

                if (LoginStatus.登录成功 == ls)
                {
                    jr.UserName = md.username;
                    jr.Message = Server.UrlDecode(sReturnUrl);
                    jr.Success = true;
                    jr.UserID = md.id.ToString();
                }
                else
                {
                    if (LoginStatus.IP禁止登录 == ls)
                    {
                        jr.Message = "IP禁止登录";
                        jr.Success = false;
                    }
                    else if (LoginStatus.不存在此Email或密码错误 == ls)
                    {
                        jr.Message = "不存在此Email或密码错误";
                        jr.Success = false;
                    }
                    else if (LoginStatus.不存在此手机号码或密码错误 == ls)
                    {
                        jr.Message = "不存在此手机号码或密码错误";
                        jr.Success = false;
                    }
                    else if (LoginStatus.不存在此帐号或密码错误 == ls)
                    {
                        jr.Message = "不存在此帐号或密码错误";
                        jr.Success = false;
                    }
                    else if (LoginStatus.错误登录次数超出规定 == ls)
                    {
                        jr.Message = "对不起，你错误登录了" + Configs.SysConfigs.ConfigsControl.Instance.ErrLoginNum + "次，系统登录锁定！";
                        jr.Success = false;
                    }

                    else if (LoginStatus.验证码不正确 == ls)
                    {
                        jr.Message = "验证码不正确或已经过期";
                        jr.Success = false;
                    }
                    else if (LoginStatus.帐号出现异常已锁定 == ls)
                    {
                        jr.Message = "帐号出现异常已锁定";
                        jr.Success = false;
                    }
                    else
                    {
                        jr.Message = "登录失败";
                        jr.Success = false;
                    }
                }

            }
            else
            {
                jr.Message = base.NoAllowTips;
                jr.Success = false;
            }

            return jr;
        }

        ///// <summary>
        ///// 用户注册
        ///// </summary>
        ///// <param name="reg_username">用户名</param>
        ///// <param name="reg_pwd">密码</param>
        ///// <param name="reg_mobile">手机号</param>
        ///// <param name="reg_yzm">验证码</param>
        ///// <returns></returns>
        //[WebMethod(EnableSession = true)]
        //////[SoapHeader("SecurityKey")]
        //public JsonResponse RegUser(string reg_username, string reg_pwd, string reg_yzm, string reg_weixin, string reg_mobile, string reg_address)
        //{
        //    JsonResponse jr = new JsonResponse();
        //    if (IsAllow(false))
        //    {
        //        //手机号验证码 验证 todo
        //        if (BLL.UserIdentity.ValidateMobileCode(reg_yzm, "reg"+reg_username))
        //        {
        //            RegStatus ms;
        //            string sReturnUrl = string.Empty;
        //            string Ip = Tools.Utils.GetClientIP();
        //            int userID = BLL.User.RegUser(reg_username, reg_pwd, reg_weixin, reg_mobile, reg_address, Ip, out ms);
        //            if (RegStatus.注册成功 == ms)
        //            {
        //                LoginStatus ls;
        //                Entity.User md = BLL.User.Login(reg_username, reg_pwd, "", true, 0, out ls, out sReturnUrl, false, "");

        //                sReturnUrl = "login.aspx";
        //                jr.UserID = userID.ToString();
        //                jr.UserName = reg_username;
        //                jr.Message = sReturnUrl;
        //                jr.Success = true;
        //            }
        //            else
        //            {
        //                if (RegStatus.已经存在此帐号 == ms)
        //                {
        //                    jr.Message = "已经存在此用户名,请换一个用户名再注册!";
        //                    jr.Success = false;
        //                }
        //                else
        //                {
        //                    jr.Message = "注册失败，原因不明!";
        //                    jr.Success = false;
        //                }
        //            }
        //        }
        //        else
        //        {
        //            jr.Message = "注册失败，验证码不正确!";
        //            jr.Success = false;
        //        }

        //    }
        //    else
        //    {
        //        jr.Message = base.NoAllowTips;
        //        jr.Success = false;
        //    }
        //    return jr;
        //}

    }
}
