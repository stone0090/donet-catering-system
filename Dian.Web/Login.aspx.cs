using Dian.Biz;
using Dian.Common.Entity;
using Dian.Common.Interface;
using Dian.Web.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dian.Web
{
    public partial class Login : BasePage
    {
        private string ReturnUrl
        {
            get { return Request.QueryString["ReturnUrl"] ?? FormsAuthentication.DefaultUrl; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (!string.IsNullOrEmpty(this.tName.Value) && !string.IsNullOrEmpty(this.tPassword.Value))
                {
                    try
                    {
                        IEmployee biz = new EmployeeBiz();
                        EmployeeEntity condition_entity = new EmployeeEntity();
                        condition_entity.EMPLOYEE_ID = this.tName.Value;
                        condition_entity.PASSWORD = this.tPassword.Value;
                        var list = biz.GetEmployeeEntityList(condition_entity);
                        if (list != null && list.Count > 0)
                        {
                            //登陆成功，把用户编号保存到票据中    
                            FormsAuthentication.SetAuthCookie(this.tName.Value, false);
                            var ticket = new FormsAuthenticationTicket(1, list[0].EMPLOYEE_NAME, DateTime.Now, DateTime.Now.AddMonths(2), false, this.tName.Value, FormsAuthentication.FormsCookiePath);
                            var encTicket = FormsAuthentication.Encrypt(ticket);
                            var newCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                            HttpContext.Current.Response.Cookies.Add(newCookie);
                            Response.Redirect(ReturnUrl);
                        }
                        else
                        {
                            this.lMsg.InnerText = "登陆失败，账户或密码错误！";
                        }
                    }
                    catch (Exception ex)
                    {
                        this.lMsg.InnerText = "登陆失败，原因是：" + ex.ToString();
                    }
                }
            }
        }
    }
}