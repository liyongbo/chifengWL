using BLL;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.Services;


namespace wy.api
{
    /// <summary>
    /// ws 的摘要说明
    /// </summary>
    [System.Web.Script.Services.ScriptService]
    public class ws : BLL.MainWebServiceBase
    {

        /// <summary>
        /// 密码修改
        /// </summary>
        /// <param name="oPwd"></param>
        /// <param name="userPwd"></param>
        /// <returns></returns>
        [WebMethod(EnableSession = true)]
        public bool updatePwd(string oPwd, string userPwd)
        {
            if (!string.IsNullOrEmpty(oPwd) && !string.IsNullOrEmpty(userPwd) && !string.IsNullOrEmpty(BLL.Base.Host.Instance.UserName))
            {
                List<Entity.Users> userList = BLL.Users.Users_GetListArray(string.Format("[username]='{0}' and [userpassword]='{1}'", Tools.GetString.NoHTML(BLL.Base.Host.Instance.UserName.Trim()), UserIdentity.PassWordEncode(oPwd)), 1, "[id]", true);
                if (userList != null && userList.Count > 0)
                {
                    Entity.Users user = userList.FirstOrDefault();
                    user.userpassword = BLL.UserIdentity.PassWordEncode(userPwd);
                    BLL.Users.Update(user);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 目的地修改
        /// </summary>
        /// <param name="box_dest"></param>
        /// <param name="box_carname"></param>
        /// <param name="box_tel"></param>
        /// <param name="box_username"></param>
        /// <param name="box_password"></param>
        /// <param name="box_age"></param>
        /// <param name="box_address"></param>
        /// <param name="box_emergency"></param>
        /// <param name="box_bank"></param>
        /// <param name="box_bankcard"></param>
        /// <param name="box_comment"></param>
        /// <param name="destid"></param>
        /// <returns></returns>
        public bool updateDest(string box_dest, string box_carname, string box_tel, string box_username, string box_password, string box_age, string box_address
                                , string box_emergency, string box_bank, string box_bankcard, string box_comment, string destid)
        {
            if (!string.IsNullOrEmpty(destid))
            {
                Entity.Destinations dest = BLL.Destinations.GetModel(destid);

            }

            return false;
        }


    }

}

