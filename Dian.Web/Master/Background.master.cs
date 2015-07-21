using Dian.Web.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dian.Web.Master
{
    public partial class Background : BaseMasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                this.hLogout.Value = "0";
                if (CurEmployeeEntity != null && (bool)CurEmployeeEntity.IS_ADMIN == false)
                {
                    this.liRestaurant.Visible = false;
                    this.liEmployee.Visible = false;
                    this.liFoodType.Visible = false;
                }
            }
            else
            {
                if (this.hLogout.Value == "1")
                {
                    FormsAuthentication.SignOut();
                    Session.Clear();
                    Response.Redirect("Login.aspx");
                    Response.End();
                }
            }
        }
    }
}