
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace BLL.Base
{

    [Serializable]
    public abstract class Base<TYPE, KEY> : IDisposable
    {


        protected Data.DataProviderCms DALCMS;

        public Base()
        {

            MasterCacheKeyArray = typeof(TYPE).Name;
            DALCMS = Host.Instance.DALCMS;
        }
        public void Tips(string Title, string Info)
        {
            Tips(Title, Info, "");
        }
        public void Tips(string sTitle, string Msg, string reUrl)
        {
            System.Web.HttpContext.Current.Response.Write("<!DOCTYPE html PUBLIC \"-//W3C//DTD XHTML 1.0 Transitional//EN\" \"http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd\">");
            System.Web.HttpContext.Current.Response.Write("<html xmlns=\"http://www.w3.org/1999/xhtml\" >");
            System.Web.HttpContext.Current.Response.Write("<head ><title>" + sTitle + "</title>");
            System.Web.HttpContext.Current.Response.Write("<LINK media=all href=/css/css.css\" type=\"text/css\" rel=\"Stylesheet\" >");

            if (!string.IsNullOrEmpty(reUrl))
                System.Web.HttpContext.Current.Response.Write("<meta http-equiv=\"refresh\" content=\"3; url=" + reUrl + "\"> ");



            System.Web.HttpContext.Current.Response.Write("</head><body style=\"text-align:center;text-align: -moz-center !important;padding-top:20px;\">");
            System.Web.HttpContext.Current.Response.Write("<center><div style='width:50%;' >");
            System.Web.HttpContext.Current.Response.Write("<div class=\"box-p\">");
            System.Web.HttpContext.Current.Response.Write("<div  class=\"box-s\">");
            System.Web.HttpContext.Current.Response.Write("<div class=\"box-title\" >" + sTitle + "</div>");
            System.Web.HttpContext.Current.Response.Write("<div class=\"box-content\" style=\"padding-left:20px;\" >");
            System.Web.HttpContext.Current.Response.Write("<br />");
            //内容
            System.Web.HttpContext.Current.Response.Write("<li><span style=\"word-wrap:bread-word;word-break:break-all;font-size:11.5px;\">" + Msg + "</span></li>");

            if (!string.IsNullOrEmpty(reUrl))
            {
                System.Web.HttpContext.Current.Response.Write("<li>系统3秒钟后自动返回...</li><li><a href='javascript:history.back();'><font color=\"red\">返回上一级</font></a>&nbsp;&nbsp;&nbsp;&nbsp;</li>");
            }
            else
            {
                System.Web.HttpContext.Current.Response.Write(string.Concat("<br/><li><a href='http://www.jiaqiaor.com/css'><font color=\"red\">返回网站首页</font></a>&nbsp;&nbsp;&nbsp;&nbsp;</li>"));
            }

            //if (string.IsNullOrEmpty(reUrl))
            //{
            //    System.Web.HttpContext.Current.Response.Write("<li><a href='javascript:history.back();'><font color=\"red\">返回上一级</font></a>&nbsp;&nbsp;&nbsp;&nbsp;</li>");

            //}
            //else
            //{
            //    System.Web.HttpContext.Current.Response.Write("<li>系统3秒钟后自动返回...</li><li><a href='javascript:history.back();'><font color=\"red\">返回上一级</font></a>&nbsp;&nbsp;&nbsp;&nbsp;</li>");

            //}
            System.Web.HttpContext.Current.Response.Write("</div>");
            System.Web.HttpContext.Current.Response.Write("</div>");
            System.Web.HttpContext.Current.Response.Write("</div>");
            System.Web.HttpContext.Current.Response.Write("</div></center>");
            System.Web.HttpContext.Current.Response.Write("</body>");
            System.Web.HttpContext.Current.Response.Write("</html>");


            System.Web.HttpContext.Current.Response.End();
        }
        private KEY _Id;
        /// <summary>
        /// 获取或设置某个对象的唯一ID
        /// </summary>
        public KEY Id
        {
            get { return _Id; }
            set { _Id = value; }
        }
        public abstract TYPE GetEntity(KEY id);

        /// <summary>
        /// Updates the object in its data store.
        /// 更新一条数据
        /// </summary>
        public abstract void Update(TYPE model);

        /// <summary>
        /// Inserts a new object to the data store.
        /// 添加一条新的数据
        /// </summary>
        public abstract KEY Add(TYPE model);

        /// <summary>
        /// Deletes the object from the data store.
        /// 删除一条数据
        /// </summary>
        public abstract void Delete(KEY id);

        public abstract List<TYPE> GetListArray(int Top, string strWhere, string filedOrder);

        public abstract List<TYPE> GetListPages(int PageIndex, int PageSize, string strWhere, string Fileds,
                                                 string oderby, out int RecordCount);
        /// <summary>
        /// 删除自己本身
        /// </summary>
        public void Delete()
        {
            Delete(Id);
        }

    

   

        #region IDisposable

        private bool _IsDisposed;
        /// <summary>
        /// Gets or sets if the object has been disposed.
        /// 如果这个对象已经被处理过了,就可以通过get或者set来获取相应的值.
        /// <remarks>
        /// If the objects is disposed, it must not be disposed a second
        /// time. The IsDisposed property is set the first time the object
        /// is disposed. If the IsDisposed property is true, then the Dispose()
        /// method will not dispose again. This help not to prolong the object's
        /// life if the Garbage Collector.
        /// 如果对象被处理,但一定不能被处理两次.如果处理属性是第一次处理对象可以通过set，如果处理属性是ture
        /// Dispose（）方法将再次处理它.如果在垃圾收集工里处理,将会减少对象的寿命!
        /// </remarks>
        /// </summary>
        protected bool IsDisposed
        {
            get { return _IsDisposed; }
        }

        /// <summary>
        /// Disposes the object and frees ressources for the Garbage Collector.
        /// 处理对象和摆脱垃圾收集工的来源
        /// </summary>
        /// <param name="disposing">如果对象被处理了,则返回ture! If true, the object gets disposed.</param>
        protected virtual void Dispose(bool disposing)
        {
            if (this.IsDisposed)
                return;

            if (disposing)
            {
                _IsDisposed = true;
            }
        }

        /// <summary>
        /// Disposes the object and frees ressources for the Garbage Collector.
        /// 处理对象和摆脱垃圾收集工的来源
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region IDataErrorInfo Members

        /// <summary>
        /// Gets an error message indicating what is wrong with this object.
        /// 获取错误的信息，这个对象有什么样的错误标志 。
        /// </summary>
        /// <returns>An error message indicating what is wrong with this object. 
        /// The default is an empty string ("").</returns>
        /// 默认是一个空的 string("")
        public string Error
        {
            get { return "发生错误了!"; }
        }

        /// <summary>
        /// Gets the <see cref="System.String"/> with the specified column name.指定和获取 columnName
        /// IDataErrorInfo 接口的实现
        /// </summary>
        public string this[string columnName]
        {
            get
            {

                return string.Empty;
            }
        }

        #endregion
        /// <summary>
        /// Occurs when this instance is marked dirty.  
        /// It means the instance has been changed but not saved.
        /// 实例属性被改变而不是存储
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        /// <summary>
        /// Raises the PropertyChanged event safely.
        /// 增加属性改变事件的安全性
        /// </summary>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        #region 缓存处理
        protected string MasterCacheKeyArray = "cudata";
        virtual protected string GetCacheKey(string cacheKey)
        {
            return string.Concat(MasterCacheKeyArray, "-", cacheKey);

        }
      
        #endregion


    }
}
