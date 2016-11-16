using BLL.Base.Page;
using System;
using System.Web.UI.HtmlControls;

namespace BLL
{
    public class OLPage : UserPage
    {
        public OLPage()
        {
        }

        private const String strEnter = "\r\n", strJH = "-";

        //protected DataTable dt = Tools.GetString.GetConfig.getConfig("banner");
        public void SetMeta(Int32 type, String title, String keywords, String description, bool ISCache, int beginTime, int endTime)
        {
            //Meta(helper.GetConfig.getConfig("flConfig"), type, title, keywords, description, ISCache, beginTime, endTime);

            AddJS("/js/commn.js");
            AddJS("/js/jquery-1.8.2.min.js");
            AddCss("/css/index.css");
            AddCss("/css/header_footer.css");
        }

        /// 
        /// 添加JS脚本链接 
        /// 
        /// 页面 
        /// 路径 
        public void AddJS(string url)
        {
            HtmlGenericControl jsControl = new HtmlGenericControl("script");
            jsControl.Attributes.Add("type", "text/javascript");
            jsControl.Attributes.Add("src", url);
            this.Page.Header.Controls.AddAt(0, jsControl);
        }


        /// 
        /// 添加JS脚本内容 
        /// 
        /// 页面 
        /// 脚本内容 
        public void AddScript(string content)
        {
            HtmlGenericControl scriptControl = new HtmlGenericControl("script");
            scriptControl.Attributes.Add("type", "text/javascript");
            scriptControl.InnerHtml = content;
            this.Page.Header.Controls.Add(scriptControl);
        }


        /// 
        /// 添加CSS样式链接 
        /// 
        /// 页面 
        /// 路径 
        public void AddCss(string url)
        {
            HtmlLink link = new HtmlLink();
            link.Href = url;
            link.Attributes.Add("rel", "stylesheet");
            link.Attributes.Add("type", "text/css");
            this.Page.Header.Controls.Add(link);
        }


        /// 
        /// 添加CSS样式内容 
        /// 
        /// 页面 
        /// 样式内容 
        public void AddStyle(System.Web.UI.Page page, string content)
        {
            HtmlGenericControl styleControl = new HtmlGenericControl("style");
            styleControl.Attributes.Add("type", "text/css");
            styleControl.InnerHtml = content;
            page.Header.Controls.Add(styleControl);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="type"></param>
        /// <param name="title"></param>
        /// <param name="keywords"></param>
        /// <param name="description"></param>
        /// <param name="ISCache">是否缓存</param>
        /// <param name="beginTime">开始时间 如11(表示11:00:00点整)</param>
        /// <param name="endTime">结束时间 如23(表示23:59:59)</param>
        private void Meta(System.Data.DataTable dt, Int32 type, String title, String keywords, String description, bool ISCache, int beginTime, int endTime)
        {

            if (ISCache && DateTime.Now.Hour >= beginTime)
            {
                Response.Cache.SetExpires(new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, endTime, 59, 59));
                Response.Cache.SetCacheability(System.Web.HttpCacheability.Public);
                Response.Cache.SetValidUntilExpires(true);
            }


            if (title.Length == 0)
                this.Page.Title = dt.Rows[type][1].ToString();
            else
                this.Page.Title = dt.Rows[type][1] + strJH + title;

            if (keywords.Length == 0)
                keywords = dt.Rows[type][2].ToString();
            else
                keywords = keywords + strJH + dt.Rows[type][2];

            if (description.Length == 0)
                description = dt.Rows[type][4].ToString();
            else
                description = description + strJH + dt.Rows[type][4];

            System.Web.UI.HtmlControls.HtmlMeta meta_keywords = new System.Web.UI.HtmlControls.HtmlMeta();
            meta_keywords.Name = "keywords";
            meta_keywords.Content = keywords;
            this.Page.Header.Controls.Add(meta_keywords);
            this.Page.Header.Controls.Add(new System.Web.UI.LiteralControl(strEnter));

            System.Web.UI.HtmlControls.HtmlMeta meta_content = new System.Web.UI.HtmlControls.HtmlMeta();
            meta_content.Name = "description";
            meta_content.Content = description;
            this.Page.Header.Controls.Add(meta_content);
            this.Page.Header.Controls.Add(new System.Web.UI.LiteralControl(strEnter));
        }

    }
}
