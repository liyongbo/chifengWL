using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BLL.Base.Page
{
    public class AdminPage : BasePage
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public AdminPage()
        {
            this.Load += new EventHandler(this.AdminPage_Load);
        }
        /// <summary>
        /// LOAD事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void AdminPage_Load(object sender, EventArgs e)
        {
            //验证当前用户是否已经登录(帐号+密码),如果还未登录，跳转到登录页面
            CheckCurrentUserIsLogin();
        }

        /// <summary>
        /// 生成前端上传js
        /// </summary>
        /// <param name="UpBtnID">触发上传按钮</param>
        /// <param name="Ext">允许上传的文件类型，以逗号分开，如jpg,gif,png,zip</param>
        /// <param name="AllowSize">允许上传的大小最大值，单位为kb,如1024，代表上传的文件大小不能超过1兆</param>
        /// <param name="SaveFolder">文件的保存目录，是一个文件夹的名字，如 img,可以为空</param>
        /// <param name="IsSmallimg">是否开启缩略图，前提条件是:上传的文件类型必要是图片</param>
        /// <param name="SmallImgSizes">如果IsSmallimg为true时，你还可以通过此参数设置缩略图的数量与规格，格式为ew []{"50*50","80*80","90*90","120*200"},上传后将生成4组不同规格的缩略图</param>
        /// <returns></returns>
        protected string CreatUpload(string UpBtnID, string Ext, int AllowSize, string SaveFolder, bool IsSmallimg, string[] SmallImgSizes)
        {
            return BLL.Utity.CreatUpload(UpBtnID, Ext, AllowSize, SaveFolder, IsSmallimg, SmallImgSizes, true, false);
        }

        protected string CreatUpload(string UpBtnID, string Ext, int AllowSize, string SaveFolder, bool IsSmallimg, string[] SmallImgSizes, bool isinit)
        {
            return BLL.Utity.CreatUpload(UpBtnID, Ext, AllowSize, SaveFolder, IsSmallimg, SmallImgSizes, isinit, false);
        }

        protected string CreatUpload(string UpBtnID, string Ext, int AllowSize, string SaveFolder, bool IsSmallimg, string[] SmallImgSizes, bool isinit, bool isjs)
        {
            return BLL.Utity.CreatUpload(UpBtnID, Ext, AllowSize, SaveFolder, IsSmallimg, SmallImgSizes, isinit, isjs);
        }


        protected string CreatUpload(string UpBtnID, string Ext, int AllowSize, string SaveFolder)
        {
            return BLL.Utity.CreatUpload(UpBtnID, Ext, AllowSize, SaveFolder);
        }
    }
}
