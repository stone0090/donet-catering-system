using Dian.Biz;
using Dian.Entity;
using Dian.Interface;
using Dian.Web.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dian.Web
{
    public partial class EmployeeList : BasePageList
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                DeleteData();

            BindData();
        }
        private void BindData()
        {
            IEmployee biz = new EmployeeBiz();
            repeater1.DataSource = GetPagedDataSource(biz.GetEmployeeDataTable().DefaultView);
            repeater1.DataBind();
        }
        private void DeleteData()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.hDeleteId.Value))
                {
                    IEmployee biz = new EmployeeBiz();
                    biz.DeleteEmployeeEntity(new EmployeeEntity() { EMPLOYEE_ID = this.hDeleteId.Value });
                    this.lMsg.InnerText = "删除成功!";
                }
            }
            catch (Exception ex)
            {
                this.lMsg.InnerText = "删除失败，原因：" + ex.ToString();
            }
        }

        public string GetSexName(string val)
        {
            switch (val)
            {
                case "1": return "男";
                case "2": return "女";
                case "3": return "保密";
                default: return "-";
            }
        }

        public string GetIsAdminName(string val)
        {
            switch (val)
            {
                case "False": return "否";
                case "True": return "是";
                default: return "-";
            }
        }

    }
}