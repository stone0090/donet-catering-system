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
    public class BasePage : System.Web.UI.Page
    {

        #region 属性

        public string UrlReferrer
        {
            get
            {
                return ViewState["UrlReferrer"] == null ? "/index.aspx" : ViewState["UrlReferrer"].ToString();
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

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected override void OnPreLoad(EventArgs e)
        {
            base.OnPreLoad(e);

            if (!IsPostBack)
            {
                try
                {
                    if (ViewState["UrlReferrer"] == null && Request.UrlReferrer != null)
                        ViewState["UrlReferrer"] = Request.UrlReferrer.PathAndQuery;
                }
                catch (Exception)
                {
                    Server.Transfer("Index.aspx");
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

        #region 提供子类使用的方法

        public void Alert(string msg)
        {
            string script = string.Format("<script type='text/javascript'>alert({0});</script>", msg);
            ClientScript.RegisterClientScriptBlock(this.GetType(), null, script);
        }

        public void AlertAndTransfer(string msg, string url)
        {
            string script = string.Format("<script type='text/javascript'>alert('{0}');self.location.href='{1}'</script>", msg, url);
            ClientScript.RegisterClientScriptBlock(this.GetType(), null, script);
        }

        public int RequestQueryInt(string str)
        {
            var temp = 0;
            int.TryParse(Request.QueryString[str], out temp);
            return temp;
        }

        public int ParseInt(string str)
        {
            return Helper.ParseInt(str);
        }

        public decimal ParseDecimal(string str)
        {
            return Helper.ParseDecimal(str);
        }

        #endregion

    }
}
