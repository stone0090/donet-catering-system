using Dian.Biz;
using Dian.Common.Entity;
using Dian.Common.Interface;
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

        protected EmployeeEntity CurEmployeeEntity
        {
            get
            {
                if (this.Context.User.Identity.IsAuthenticated)
                {
                    if (Session["CurEmployeeEntity"] == null)
                    {
                        //重建Session，以避免Session丢失
                        IEmployee biz = new EmployeeBiz();
                        var identity = HttpContext.Current.User.Identity as FormsIdentity;
                        if (identity != null)
                            Session["CurEmployeeEntity"] = biz.GetEmployeeEntity(identity.Ticket.UserData);
                    }
                    if (Session["CurEmployeeEntity"] == null)
                        throw new Exception("获取用户信息失败！");
                    return (EmployeeEntity)Session["CurEmployeeEntity"];
                }
                return null;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (CurEmployeeEntity != null && (bool)CurEmployeeEntity.IS_ADMIN == false)
                {
                    this.liRestaurant.Visible = false;
                    this.liEmployee.Visible = false;
                }
            }
            else
            {
                if (this.hLogout.Value == "1")
                {
                    Session["CurEmployeeEntity"] = null;
                    FormsAuthentication.SignOut();
                    Response.Redirect("Index.aspx");
                }
            }

        }
    }
}