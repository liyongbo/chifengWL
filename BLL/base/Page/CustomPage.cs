using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
namespace BLL.Base.Page
{
    public class CustomPage : BasePage
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        public CustomPage() {
            this.Load += new EventHandler(CustomPage_Load);
            this.LoadComplete += new EventHandler(CustomPage_LoadComplete);
        }
      

        /// <summary>
        /// LOAD事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomPage_Load(object sender, EventArgs e)
        {
           
        }

        /// <summary>
        /// LOAD事件处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomPage_LoadComplete(object sender, EventArgs e)
        {

        }

    }
}
