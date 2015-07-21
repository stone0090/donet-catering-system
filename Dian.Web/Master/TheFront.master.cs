using Dian.Web.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dian.Web.Master
{
    public partial class TheFront : BaseMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Url.AbsoluteUri.Contains("Index.aspx"))
                this.sTitle.InnerText = "菜单";
            if (Request.Url.AbsoluteUri.Contains("Login.aspx"))
                this.sTitle.InnerText = "登陆";

            if (CurEmployeeEntity != null)
            {
                this.liBackgroundManage.Visible = true;
                this.liLogin.Visible = false;
            }
            else
            {
                this.liBackgroundManage.Visible = false;
                this.liLogin.Visible = true;
            }

        }
    }
}
