using Dian.Biz;
using Dian.Common.Entity;
using Dian.Common.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dian.Web.Utility
{
    public class BaseMasterPage : System.Web.UI.MasterPage
    {

        #region 属性

        public string UrlReferrer
        {
            get
            {
                return ViewState["UrlReferrer"] == null ? "~/Index.aspx" : ViewState["UrlReferrer"].ToString(); ;
            }
        }

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

        #endregion

        #region 页面事件

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (!IsPostBack)
            {
                try
                {
                    if (ViewState["UrlReferrer"] == null && Request.UrlReferrer != null)
                        ViewState["UrlReferrer"] = Request.UrlReferrer.PathAndQuery;
                }
                catch (Exception)
                {
                    ViewState["UrlReferrer"] = "~/Index.aspx";
                }
            }

        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

        }

        #endregion

    }
}
