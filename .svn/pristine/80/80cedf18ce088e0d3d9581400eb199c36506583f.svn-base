using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using DropDownList = System.Web.UI.WebControls.DropDownList;
using RadioButtonList = System.Web.UI.WebControls.RadioButtonList;
using TextBox = System.Web.UI.WebControls.TextBox;

namespace BLL
{
    public class Utity
    {
        public static string CreatUpload(string UpBtnID, string Ext, int AllowSize, string SaveFolder)
        {
            return CreatUpload(UpBtnID, Ext, AllowSize, SaveFolder, false, null, true, false);
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
        static public string CreatUpload(string UpBtnID, string Ext, int AllowSize, string SaveFolder, bool IsSmallimg, string[] SmallImgSizes, bool isinit, bool isjs)
        {
            StringBuilder sbBuilder = new StringBuilder("<script>");

            sbBuilder.Append("document.domain = 'jiaqiaor.com';");
            string sUploadID = "objAspNetUpload";
            sbBuilder.AppendFormat("var {0};", sUploadID);
           // sbBuilder.Append(" function () {"); //sbBuilder.Append("In.ready('upload', function () {");
            sbBuilder.AppendFormat("{0} = new AspNetUpload();", sUploadID);
            sbBuilder.AppendFormat("{0}.UpBtnID = '{1}';", sUploadID, UpBtnID);
            sbBuilder.AppendFormat("{0}.Ext = '{1}';", sUploadID, Ext);
            sbBuilder.AppendFormat("{0}.AllowSize = '{1}';", sUploadID, AllowSize);
            sbBuilder.AppendFormat("{0}.SaveFolder = '{1}';", sUploadID, HttpContext.Current.Server.UrlEncode(Base.Host.Instance.EncodeByKey(SaveFolder)));
            sbBuilder.AppendFormat("{0}.ValStr = '{1}';", sUploadID, Base.Host.Instance.EncodeByMD5(string.Concat(SaveFolder, AllowSize, Base.Host.Instance.EncodeByKey(Ext), Base.Host.Instance.UserName, Base.Host.Instance.UserID)));
            if (IsSmallimg)
            {
                sbBuilder.AppendFormat("{0}.IsSmallimg = {1};", sUploadID, IsSmallimg ? "true" : "false");
                if (!Equals(SmallImgSizes, null))
                    sbBuilder.AppendFormat("{0}.SmallImgSizes = '{1}';", sUploadID, string.Join("_", SmallImgSizes));
            }

            if (isinit)
                sbBuilder.AppendFormat("{0}.Init();", sUploadID);
            //if (isjs)
            //    sbBuilder.Append("};<\\/script>");
            //else
            //    sbBuilder.Append("};</script>");

            return sbBuilder.ToString();
        }
    }
}
