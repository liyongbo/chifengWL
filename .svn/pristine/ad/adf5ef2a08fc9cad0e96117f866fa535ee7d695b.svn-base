using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace web
{
    public partial class code : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Tools.ValidateCode validateCode = new Tools.ValidateCode();
                //生成验证码指定的长度
                string code = validateCode.GetRandomString(4);
                Tools.Cookie.CookieEncryption("ccheckCode", "key", code, 0);
                //创建验证码的图片
                byte[] bytes = validateCode.CreateImage(code);
                //清除缓冲区流中的所有输出
                Response.ClearContent();
                //输出流的HTTP MIME类型设置为"image/Jpeg"
                Response.ContentType = "image/Jpeg";
                //输出图片的二进制流
                Response.BinaryWrite(bytes);
            }
        }
    }
}