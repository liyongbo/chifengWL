using System;
using System.Collections.Generic;

namespace web.Control
{
    public partial class DestControl : BLL.Base.Page.UserPage
    {
        protected List<Entity.Destinations> destList;
        protected long rCount = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                pageindex = Tools.DataConvert.ToInt32(Request.QueryString["p"], 1);
                destList = BLL.Destinations.Destinations_GetListPages(pageindex, pagesize, "", "id", true, out rCount);
            }
        }
    }

}