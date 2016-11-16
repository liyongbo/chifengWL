using System;
using System.Data;
using System.Text;
using System.Web;
using System.Web.UI;
using Tools.JS;

namespace Tools
{
    public class cJavascripts
    {

        public static string PackJs(string str)
        {

            //stCommon.PacksJs.ECMAScriptPacker pjs = new ECMAScriptPacker();
            ECMAScriptPacker p = new ECMAScriptPacker(ECMAScriptPacker.PackerEncoding.Mid, true, false);

            return p.Pack(str);

        }
        #region ertl 页面跳转
        /// <summary>
        /// 回到历史页面
        /// </summary>
        /// <param name="value">-1/1</param>
        public static void GoHistory(int value)
        {
            HttpContext.Current.Response.Write("<Script language='JavaScript'>history.go(" + value + ")</Script>");
        }
        /// <summary>
        /// href 跳转到指定页【相当于在地址栏中输入地址】
        /// </summary>
        /// <param name="message">弹出信息</param>
        /// <param name="ToURL">URL</param>
        public static void AlertAndHref(String message, String ToURL)
        {
            HttpContext.Current.Response.Write("<script>alert('" + message + "');window.parent.location.href='" + ToURL + "'</script>");
        }
        /// <summary>
        /// href 跳转到指定页【相当于在地址栏中输入地址】
        /// </summary>
        /// <param name="ToURL">跳转地址</param>
        public static void Href(String ToURL)
        {
            HttpContext.Current.Response.Write("<script>window.parent.location.href='" + ToURL + "'</script>");
        }
        /// <summary>
        /// 关闭页面
        /// </summary>
        public static void Close()
        {
            HttpContext.Current.Response.Write("<script language='javascript'>window.parent.close()</script>");
        }
        /// <summary>
        /// Redirect 跳转到指定页
        /// </summary>
        /// <param name="toURL">跳转页</param>
        public static void Redirect(String toURL)
        {
            HttpContext.Current.Response.Write("<script language='javascript'>window.location.replace('" + toURL + "')</script>");
        }
        /// <summary>
        /// 向客户端发送函数KendoPostBack(eventTarget, eventArgument)
        /// 服务器端可接收__EVENTTARGET,__EVENTARGUMENT的值
        /// </summary>
        /// <param name="page">System.Web.UI.Page 一般为this</param>
        public static void JscriptSender(System.Web.UI.Page page)
        {
            page.RegisterHiddenField("__EVENTTARGET", "");
            page.RegisterHiddenField("__EVENTARGUMENT", "");
            String s = @"        
<script language=Javascript>
      function KendoPostBack(eventTarget, eventArgument) 
      {
                var theform = document.forms[0];
                theform.__EVENTTARGET.value = eventTarget;
                theform.__EVENTARGUMENT.value = eventArgument;
                theform.submit();
            }
</script>";
            page.RegisterStartupScript("sds", s);
        }
        public static void RtnRltMsgbox(object message, String strWinCtrl)
        {
            HttpContext.Current.Response.Write("<Script language='JavaScript'>strWinCtrl = true;strWinCtrl = if(!confirm('" + message + "'))return false;</Script>");
        }
        /// <summary>
        /// 关闭当前窗口
        /// </summary>
        public static void CloseWindow()
        {
            HttpContext.Current.Response.Write("<Script language='JavaScript'>window.close();</Script>");
            HttpContext.Current.Response.End();
        }
        /// <summary>
        /// 刷新父窗口
        /// </summary>
        public static void RefreshParent()
        {
            HttpContext.Current.Response.Write("<Script language='JavaScript'>parent.location.reload();/Script>");
        }
        /// <summary>
        /// 格式化为JS可解释的字符串
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static String JSStringFormat(String js)
        {
            return js.Replace("\r", "\\r").Replace("\n", "\\n").Replace("'", "\\'").Replace("\"", "\\\"");
        }
        /// <summary>
        /// 刷新打开窗口
        /// </summary>
        public static void RefreshOpener()
        {
            HttpContext.Current.Response.Write("<Script language='JavaScript'>opener.location.reload();</Script>");
        }
        /// <summary>
        /// 打开窗口
        /// </summary>
        /// <param name="url"></param>
        public static void OpenWebForm(String url)
        {
            HttpContext.Current.Response.Write("<script>window.open('" + url + "','_blank','')</script>");
        }
        public static void OpenWebForm(String url, String name, String future)
        {
            HttpContext.Current.Response.Write("<Script language='JavaScript'>window.open('" + url + @"','" + name + @"','" + future + @"')</Script>");
        }
        public static void OpenWebForm(String url, String formName)
        {
            HttpContext.Current.Response.Write("<Script language='JavaScript'>window.open('" + url + @"','" + formName + @"','height=0,width=0,top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');</Script>");
        }
        /// <summary>        
        /// 函数名:OpenWebForm    
        /// 功能描述:打开WEB窗口    
        /// </summary>
        /// <param name="url">WEB窗口</param>
        /// <param name="isFullScreen">是否全屏幕</param>
        public static void OpenWebForm(String url, bool isFullScreen)
        {
            String js = @"<Script language='JavaScript'>";
            if (isFullScreen)
            {
                js += "var iWidth = 0;";
                js += "var iHeight = 0;";
                js += "iWidth=window.screen.availWidth-10;";
                js += "iHeight=window.screen.availHeight-50;";
                js += "var szFeatures ='width=' + iWidth + ',height=' + iHeight + ',top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no';";
                js += "window.open('" + url + @"','',szFeatures);";
            }
            else
                js += "window.open('" + url + @"','','height=0,width=0,top=0,left=0,location=no,menubar=no,resizable=yes,scrollbars=yes,status=yes,titlebar=no,toolbar=no,directories=no');";

            js += "</Script>";
            HttpContext.Current.Response.Write(js);
        }
        /// <summary>
        /// 指定的框架页面转换
        /// </summary>
        /// <param name="FrameName"></param>
        /// <param name="url"></param>
        public static void JavaScriptFrameHref(String FrameName, String url)
        {
            HttpContext.Current.Response.Write("<Script language='JavaScript'>" + FrameName + ".location.replace('" + url + "');</Script>");
        }
        /// <summary>
        ///重置页面
        /// </summary>
        public static void ResetPage(String strRows)
        {
            HttpContext.Current.Response.Write("<Script language='JavaScript'>window.parent.CenterFrame.rows='" + strRows + "';</Script>");
        }
        /// <summary>
        /// 函数名:JavaScriptSetCookie
        /// 功能描述:客户端方法设置Cookie
        /// </summary>
        /// <param name="strName">Cookie名</param>
        /// <param name="strValue">Cookie值</param>
        public static void JavaScriptSetCookie(String strName, String strValue)
        {
            String js = @"<script language=Javascript>
            var the_cookie = '" + strName + "=" + strValue + @"'
            var dateexpire = 'Tuesday, 01-Dec-2020 12:00:00 GMT';
            //document.cookie = the_cookie;//写入Cookie<BR>} <BR>
            document.cookie = the_cookie + '; expires='+dateexpire;            
            </script>";
            HttpContext.Current.Response.Write(js);
        }
        /// <summary>        
        /// 函数名:GotoParentWindow    
        /// 功能描述:返回父窗口    
        /// </summary>
        /// <param name="parentWindowUrl">父窗口</param>        
        public static void GotoParentWindow(String parentWindowUrl)
        {
            HttpContext.Current.Response.Write("<Script language='JavaScript'>this.parent.location.replace('" + parentWindowUrl + "');</Script>");
        }
        /// <summary>        
        /// 函数名:ReplaceParentWindow    
        /// 功能描述:替换父窗口    
        /// </summary>
        /// <param name="parentWindowUrl">父窗口</param>
        /// <param name="caption">窗口提示</param>
        /// <param name="future">窗口特征参数</param>
        public static void ReplaceParentWindow(String parentWindowUrl, String caption, String future)
        {
            if (future != null && future.Trim().Length != 0)
                HttpContext.Current.Response.Write("<script language=javascript>this.parent.location.replace('" + parentWindowUrl + "','" + caption + "','" + future + "');</script>");
            else
                HttpContext.Current.Response.Write("<script language=javascript>var iWidth = 0 ;var iHeight = 0 ;iWidth=window.screen.availWidth-10;iHeight=window.screen.availHeight-50;var szFeatures = 'dialogWidth:'+iWidth+';dialogHeight:'+iHeight+';dialogLeft:0px;dialogTop:0px;center:yes;help=no;resizable:on;status:on;scroll=yes';this.parent.location.replace('" + parentWindowUrl + "','" + caption + "',szFeatures);</script>");
        }
        /// <summary>        
        /// 函数名:ReplaceOpenerWindow    
        /// 功能描述:替换当前窗体的打开窗口    
        /// </summary>
        /// <param name="openerWindowUrl">当前窗体的打开窗口</param>        
        public static void ReplaceOpenerWindow(String openerWindowUrl)
        {
            HttpContext.Current.Response.Write("<Script language='JavaScript'>window.opener.location.replace('" + openerWindowUrl + "');</Script>");
        }
        /// <summary>        
        /// 函数名:ReplaceOpenerParentWindow    
        /// 功能描述:替换当前窗体的打开窗口的父窗口    
        /// </summary>
        /// <param name="openerWindowUrl">当前窗体的打开窗口的父窗口</param>        
        public static void ReplaceOpenerParentFrame(String frameName, String frameWindowUrl)
        {
            HttpContext.Current.Response.Write("<Script language='JavaScript'>window.opener.parent." + frameName + ".location.replace('" + frameWindowUrl + "');</Script>");
        }
        /// <summary>        
        /// 函数名:ReplaceOpenerParentWindow    
        /// 功能描述:替换当前窗体的打开窗口的父窗口    
        /// </summary>
        /// <param name="openerWindowUrl">当前窗体的打开窗口的父窗口</param>        
        public static void ReplaceOpenerParentWindow(String openerParentWindowUrl)
        {
            HttpContext.Current.Response.Write("<Script language='JavaScript'>window.opener.parent.location.replace('" + openerParentWindowUrl + "');</Script>");
        }
        /// <summary>        
        /// 函数名:CloseParentWindow    
        /// 功能描述:关闭窗口    
        /// </summary>
        public static void CloseParentWindow()
        {
            HttpContext.Current.Response.Write("<Script language='JavaScript'>window.parent.close();</Script>");
        }
        public static void CloseOpenerWindow()
        {
            HttpContext.Current.Response.Write("<Script language='JavaScript'>window.opener.close();</Script>");
        }
        /// <summary>
        /// 函数名:ShowModalDialogJavascript    
        /// 功能描述:返回打开模式窗口的脚本    
        /// </summary>
        /// <param name="webFormUrl"></param>
        /// <returns></returns>
        public static String ShowModalDialogJavascript(String webFormUrl)
        {
            return @"<script language=javascript>
                            var iWidth = 0 ;
                            var iHeight = 0 ;
                            iWidth=window.screen.availWidth-10;
                            iHeight=window.screen.availHeight-50;
                            var szFeatures = 'dialogWidth:'+iWidth+';dialogHeight:'+iHeight+';dialogLeft:0px;dialogTop:0px;center:yes;help=no;resizable:on;status:on;scroll=yes';
                            showModalDialog('" + webFormUrl + "','',szFeatures);</script>";
        }
        public static String ShowModalDialogJavascript(String webFormUrl, String features)
        {
            return @"<script language=javascript>showModalDialog('" + webFormUrl + "','','" + features + "');</script>";
        }
        /// <summary>
        /// 函数名:ShowModalDialogWindow    
        /// 功能描述:打开模式窗口    
        /// </summary>
        /// <param name="webFormUrl"></param>
        /// <returns></returns>
        public static void ShowModalDialogWindow(String webFormUrl)
        {
            HttpContext.Current.Response.Write(ShowModalDialogJavascript(webFormUrl));
        }
        public static void ShowModalDialogWindow(String webFormUrl, String features)
        {
            HttpContext.Current.Response.Write(ShowModalDialogJavascript(webFormUrl, features));
        }
        public static void ShowModalDialogWindow(String webFormUrl, int width, int height, int top, int left)
        {
            String features = "dialogWidth:" + width.ToString() + "px"
                + ";dialogHeight:" + height.ToString() + "px"
                + ";dialogLeft:" + left.ToString() + "px"
                + ";dialogTop:" + top.ToString() + "px"
                + ";center:yes;help=no;resizable:no;status:no;scroll=no";
            ShowModalDialogWindow(webFormUrl, features);
        }
        public static void SetHtmlElementValue(String formName, String elementName, String elementValue)
        {
            HttpContext.Current.Response.Write("<Script language='JavaScript'>if(document." + formName + "." + elementName + "!=null){document." + formName + "." + elementName + ".value =" + elementValue + ";}</Script>");
        }
        #endregion
        #region Javascript 弹出框消息处理
        /// <summary>
        /// 弹出消息框，继续执行下去
        /// </summary>
        /// <param name="Content">消息内容</param>
        public static void MessageShowNext(string Content)
        {
            string script = "<script language=\"javascript\">alert('" + Content + "');</" + "script>";


            System.Web.HttpResponse Response = HttpContext.Current.Response;

            Response.Write(script);

        }
        /// <summary>
        /// 弹出消息框，继续执行下去
        /// </summary>
        /// <param name="Content">消息内容</param>
        public static void MessageShowNext(string Content, Page cPage)
        {
            string script = "<script language=\"javascript\">alert('" + Content + "');</" + "script>";

            ClientScriptManager cs = cPage.ClientScript;
            cs.RegisterStartupScript(cPage.GetType(), "message", script);
        }
        /// <summary>
        /// 弹出消息框，并截至输出到当前位置
        /// </summary>
        /// <param name="Content">消息内容</param>
        public static void MessageShow(string Content)
        {
            string script = "<script language=\"javascript\">alert('" + Content + "');</" + "script>";
            System.Web.HttpResponse Response = HttpContext.Current.Response;

            Response.Write(script);
            Response.End();
        }

        /// <summary>
        /// 弹出消息对话框，并在点击确定后返回指定页
        /// </summary>
        /// <param name="Content">消息内容</param>
        public static void MessageShowMyreturn(string Content, string strUrl)
        {
            string script = "<script language=\"javascript\">alert('" + Content + "');location.href='" + strUrl + "';</" + "script>";
            System.Web.HttpResponse Response = HttpContext.Current.Response;

            Response.Write(script);
            Response.End();
        }


        /// <summary>
        /// 弹出消息框，并支持执行弹出后的Javascript教本，同时截至输出到当前位置
        /// </summary>
        /// <param name="Content">消息内容</param>
        /// <param name="CustomScript">自定义Javascript教本</param>
        public static void MessageShow(string Content, string CustomScript)
        {
            string script = "<script language=\"javascript\">alert('" + Content + "');" + CustomScript + "</" + "script>";
            System.Web.HttpResponse Response = HttpContext.Current.Response;

            Response.Write(script);
            Response.End();
        }


        /// <summary>
        /// 弹出消息对话框，并在点击确定后返回上一页，同时截至输出到当前位置
        /// </summary>
        /// <param name="Content">消息内容</param>
        public static void MessageShowBack(string Content)
        {
            string script = "<script language=\"javascript\">alert('" + Content + "');window.history.back();</" + "script>";
            System.Web.HttpResponse Response = HttpContext.Current.Response;

            Response.Write(script);
            Response.End();
        }

        /// <summary>
        /// 弹出消息对话框，并在点击确定后返回上一页，同时截至输出到当前位置
        /// </summary>
        /// <param name="Content">消息内容</param>
        public static void MessageClose(string Content)
        {
            string script = "<script language=\"javascript\">alert('" + Content + "');window.close();</" + "script>";
            System.Web.HttpResponse Response = HttpContext.Current.Response;

            Response.Write(script);
            Response.End();
        }
        public static void AlertNoRush(string message)
        {
            System.Web.UI.Page page = (System.Web.UI.Page)System.Web.HttpContext.Current.Handler;
            if (!page.ClientScript.IsClientScriptBlockRegistered(page.GetType(), "clientScript"))
                page.ClientScript.RegisterClientScriptBlock(page.GetType(), "clientScript", "<script language=javascript>alert('" + message + "!');</script>");
        }
        public static void RunClientJs(string Content)
        {
            string script = "<script language=\"javascript\">" + Content + "</" + "script>";
            System.Web.HttpResponse Response = HttpContext.Current.Response;

            Response.Write(script);
            //Response.End();
        }

        //public static void RunClientJs(string sJs)
        //{

        //    //Strings.cJavascripts.RunClientJs(sJs);
        //    //ctr.Page.ClientScript.RegisterStartupScript(ctr.GetType(), "okjs", sJs, true);

        //    ScriptManager.RegisterClientScriptBlock(ctr, ctr.GetType(), "okjs", sJs, true);
        //}
        public static void RunClientJs(System.Web.UI.Control ctr, string sJs)
        {
            ctr.Page.ClientScript.RegisterClientScriptBlock(ctr.GetType(), "okjs", string.Format("<script>{0}</script>", sJs));
        }
        /// <summary>
        /// 弹出消息对话框，并在点击确定后重定向到上一页，同时截至输出到当前位置
        /// </summary>
        /// <param name="Content">消息内容</param>
        public static void MessageShowRBack(string Content)
        {
            string script = "<script language=\"javascript\">alert('" + Content + "');window.location.href=window.location.href;</" + "script>";
            System.Web.HttpResponse Response = HttpContext.Current.Response;

            Response.Write(script);
            Response.End();
        }


        /// <summary>
        /// 在输出到客户端内容的末尾追加一个弹出消息对话框
        /// </summary>
        /// <param name="Content">消息内容</param>
        /// <param name="page">当前 Page 对象</param>
        public static void MessageShow(string Content, Page page)
        {
            string script = "<script language=\"javascript\">alert('" + Content + "');</" + "script>";

            page.RegisterStartupScript("message", script);
        }


        /// <summary>
        /// 在输出到客户端内容的末尾追加一个弹出消息对话框
        /// </summary>
        /// <param name="Content">消息内容</param>
        /// <param name="CustomScript">自定义Javascript教本</param>
        /// <param name="page">当前 Page 对象</param>
        public static void MessageShow(string Content, string CustomScript, Page page)
        {
            string script = "<script language=\"javascript\">alert('" + Content + "');" + CustomScript + "</" + "script>";

            page.RegisterStartupScript("message", script);

        }


        /// <summary>
        /// 弹出消息对话框，并在点击确定后返回上一页
        /// </summary>
        /// <param name="Content">消息内容</param>
        /// <param name="page">当前 Page 对象</param>
        public static void MessageShowBack(string Content, Page page)
        {
            string script = "<script language=\"javascript\">alert('" + Content + "');window.history.back();</" + "script>";

            page.ClientScript.RegisterStartupScript(page.GetType(), "message", script);
        }
        #endregion

        #region "提取数据转化成客户端脚本格式"


        /// <summary>
        /// 根据指定条件生成信息列表脚本
        /// </summary>
        /// <param name="dt">提取的数据集合</param>
        /// <param name="formatTableList">需要进行脚本代码处理的字段集合，字段与字段之间用“,”隔开</param>
        /// <returns>string</returns>
        public static string ConvertDataTableToClientScript(DataTable dt, string formatTableList)
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendFormat("var my" + dt.TableName + " = new My" + dt.TableName + "();\n");
            sb.Append("function My" + dt.TableName + "(){");
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sb.Append("this." + dt.Columns[i] + " = new Array();");
            }
            sb.Append("}\n");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    if (formatTableList == "")
                    {
                        sb.AppendFormat("my" + dt.TableName + "." + dt.Columns[j] + "[{0}]=\"{1}\";", i, dt.Rows[i][dt.Columns[j]].ToString());
                    }
                    else
                    {
                        if (Validate.InArray(dt.Columns[j].ToString(), formatTableList, ','))
                        {
                            sb.AppendFormat("my" + dt.TableName + "." + dt.Columns[j] + "[{0}]=\"{1}\";", i, cConvert.convertScript(dt.Rows[i][dt.Columns[j]].ToString()));
                        }
                        else
                        {
                            sb.AppendFormat("my" + dt.TableName + "." + dt.Columns[j] + "[{0}]=\"{1}\";", i, dt.Rows[i][dt.Columns[j]].ToString());
                        }
                    }
                }
            }
            // 释放 DataTable 所占用的资源
            dt.Clear();
            dt.Dispose();

            return sb.ToString();
        }
        #endregion
    }
}
