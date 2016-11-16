using System;

namespace web
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BLL.Base.Host.Instance.SignOutUser();
            Response.Redirect("~/Login.aspx");
        }
    }
}