using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dian.Web
{
    public partial class BackgroundManagement : System.Web.UI.MasterPage
    {
        public string EmployeeName
        {
            get
            {
                if (this.Context.User.Identity.IsAuthenticated)
                {
                    var identity = HttpContext.Current.User.Identity as FormsIdentity;
                    return identity.Name;
                }
                else
                {
                    return string.Empty;
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                FormsAuthentication.SignOut();
                Response.Redirect("Index.aspx");
            }
        }
    }
}