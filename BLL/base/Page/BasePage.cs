using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;

namespace BLL.Base.Page
{
    public class BasePage : System.Web.UI.Page
    {
        protected global::System.Web.UI.HtmlControls.HtmlGenericControl datacount;
        protected global::System.Web.UI.WebControls.Literal llFootInfo;
        public Host HostApi
        {
            get
            {
                return Host.Instance;
            }
        }

        #region ����
        protected string[] MasterCacheKeyArray = new string[1];
        /// <summary>
        /// վ������
        /// </summary>
        protected string SiteName
        {
            get
            {
                return "����";
            }
        }
        /// <summary>
        /// վ������
        /// </summary>
        protected string DomainName
        {
            get
            {
                return AppStartInit.DomainName;
            }
        }

        protected int UserID = AppStartInit.UserID;
        protected string UserName = AppStartInit.UserName;

        /// <summary>
        /// ��վ��װĿ¼
        /// </summary>
        protected static string IISPath
        {
            get
            {
                return AppStartInit.IISPath;
            }
        }
        /// <summary>
        /// ϵͳ��̨���Ŀ¼����
        /// </summary>
        protected string AdminPath
        {
            get
            {
                return AppStartInit.AdminPath;
            }
        }

        #endregion


        public BasePage()
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (!Page.IsCallback)
            {
                AddHeaderPram();
            }

        }
        protected string KeepUserState(string sPram)
        {
            return string.Format("<script> scountpram='{0}';</script>", sPram);
        }
        virtual protected string KeepUserState()
        {
            return KeepUserState("");
        }

        protected override void OnUnload(EventArgs e)
        {

        }

        protected string SeoTitle;
        protected string SeoKeyWord;
        protected string SeoDes;

        protected virtual void AddHeaderPram()
        {
            if (!string.IsNullOrEmpty(SeoTitle))
            {
                Page.Title = SeoTitle;// string.Concat(SeoTitle, " - Powered by EbSite");
            }
            if (!string.IsNullOrEmpty(SeoKeyWord))
            {
                SetMeta("keywords", SeoKeyWord);
            }
            if (!string.IsNullOrEmpty(SeoDes))
            {
                SetMeta("Description", SeoDes);
            }

           // AddJavaScriptInclude(string.Concat(AppStartInit.IISPath, "js/upload/Upload.js"), "");

        }
        /// <summary>
        /// Adds a JavaScript reference to the HTML head tag.
        /// </summary>
        public virtual void AddJavaScriptInclude(string url, string ID)
        {
            HtmlGenericControl script = new HtmlGenericControl("script");
            script.Attributes["type"] = "text/javascript";
            script.Attributes["src"] = url;

            if (!string.IsNullOrEmpty(ID))
                script.Attributes["id"] = ID;

            Page.Header.Controls.Add(script);
        }

        /// <summary>
        /// Adds a JavaScript reference to the HTML head tag.
        /// </summary>
        public virtual void AddJavaScripts(string scripttext, string ID)
        {
            HtmlGenericControl script = new HtmlGenericControl("script");
            script.Attributes["type"] = "text/javascript";
            script.InnerHtml = scripttext;

            if (!string.IsNullOrEmpty(ID))
                script.Attributes["id"] = ID;

            Page.Header.Controls.Add(script);
        }
        public void SetMeta(string Name, string Content)
        {
            HtmlMeta hm = new HtmlMeta();
            hm.Name = Name;
            hm.Content = Content;
            Page.Header.Controls.Add(hm);

        }

        /// <summary>
        /// ��ʼ��һЩ�Զ���js,����ֵΪjs��ŵ����·�� �� /js/comm.js ϵͳ������뵽header֮������λ��
        /// </summary>
        protected virtual string[] InitOrtherJavaScript
        {
            get
            {
                return new string[0];
            }
        }


        /// <summary>
        /// ��֤��ǰ�û��Ƿ��Ѿ���¼,�����δ��¼����ת����¼ҳ�� �ؼ�,ҳ����඼���ڴ˴��룬����Ķ�Ҫͬ���Ķ�
        /// </summary>
        virtual protected void CheckCurrentUserIsLogin()
        {
            if (!CurrentAdminIsLogin)
            {
                AppStartInit.AdminerLoginReurl();
            }
        }

        virtual protected void CheckFrontUserIsLogin()
        {
            if (!CurrentUserIsLogin)
            {
                AppStartInit.PassPortLoginReurl();
            }
        }
        protected bool CurrentAdminIsLogin
        {
            get
            {
                string UserName = AppStartInit.AdminName;
                bool islogin = false;
                if (!string.IsNullOrEmpty(UserName))
                {
                    //����cookie��������Ѿ����ܣ���������false
                    islogin = true;

                }
                return islogin;
            }
        }
        protected bool CurrentUserIsLogin
        {
            get
            {
                string UserName = AppStartInit.UserName;
                bool islogin = false;
                if (!string.IsNullOrEmpty(UserName))
                {
                    //����cookie��������Ѿ����ܣ���������false
                    islogin = true;

                }
                return islogin;
            }
        }

        /// <summary>
        /// Adds a Stylesheet reference to the HTML head tag.
        /// </summary>
        /// <param name="url">The relative URL.</param>
        public virtual void AddStylesheetInclude(string url)
        {
            HtmlLink link = new HtmlLink();
            link.Attributes["type"] = "text/css";
            link.Attributes["href"] = url;
            link.Attributes["rel"] = "stylesheet";
            Page.Header.Controls.Add(link);
        }

        protected void Tips(string Title, string Info, string Url)
        {
            AppStartInit.TipsPageRender(Title, Info, Url);
        }
        //ͨ��
        protected string GetSeoWord(string Rule, string sTitle)
        {
            string sSeo = Rule.Replace("{ר������}", sTitle).Replace("{վ������}", SiteName).Replace("{��ǩ����}", sTitle).Replace("{��ǩ����}", sTitle);
            return sSeo;
        }

        protected string GetCurrentCss(string dataid, string sCurrentClassName, string RequestTagid)
        {
            string tagid = HttpContext.Current.Request[RequestTagid];
            string sCss = "";

            if (string.IsNullOrEmpty(tagid))
            {
                tagid = "0";

            }
            if (Equals(dataid, tagid))
            {
                sCss = string.Concat("class='", sCurrentClassName, "'");
            }

            return sCss;
        }
        /// <summary>
        /// ��ȡ��ǰ����ѡ�е���ʽ
        /// </summary>
        /// <param name="ob">��ǰ����ID</param>
        /// <param name="sCurrentClassName">��ǰ��ʽ����</param>
        /// <returns></returns>
        protected string GetCurrentContent(object ob, string sCurrentClassName)
        {
            int cid = Tools.Utils.StrToInt(HttpContext.Current.Request["id"], 0);
            string sCss = "";

            if (!Equals(ob, null))
            {
                int ID = int.Parse(ob.ToString());

                if (ID == cid) //���жϵ�ǰ����ID
                {
                    sCss = sCurrentClassName;
                }
            }

            return sCss;
        }


    }

}