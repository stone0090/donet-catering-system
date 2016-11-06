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
    public partial class EmployeeDetail : BasePage
    {
        public string CurId { get; set; }
        public string CurOperation { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            CurId = Request.QueryString["id"];
            CurOperation = Request.QueryString["op"];

            if (CurOperation != "add" && CurOperation != "edit")
            {
                AlertAndTransfer("无效的操作类型！", base.UrlReferrer);
                return;
            }

            if (!IsPostBack)
            {
                BindControlData();
                if (CurOperation == "edit")
                {
                    FillFormData();
                    this.lTypeName.InnerText = "编辑";
                }
            }
            else
            {
                Save();
            }
        }

        private void BindControlData()
        {
            IRestaurant biz = new RestaurantBiz();
            this.ddlRestaurant.DataSource = biz.GetRestaurantDataTable();
            this.ddlRestaurant.DataValueField = "RESTAURANT_ID";
            this.ddlRestaurant.DataTextField = "RESTAURANT_NAME";
            this.ddlRestaurant.DataBind();
        }
        private void FillFormData()
        {
            if (string.IsNullOrEmpty(CurId))
            {
                AlertAndTransfer("参数id无效！", base.UrlReferrer);
                return;
            }

            IEmployee biz = new EmployeeBiz();
            var entity = biz.GetEmployeeEntity(CurId);
            if (entity == null)
            {
                AlertAndTransfer("参数id无效，获取数据失败！", base.UrlReferrer);
                return;
            }
            this.tEmployeeId.Value = entity.EMPLOYEE_ID;
            this.tEmployeeName.Value = entity.EMPLOYEE_NAME;
            this.ddlRestaurant.SelectedValue = entity.RESTAURANT_ID.ToString();
            this.tPassword.Value = entity.PASSWORD;
            this.tOfficePhone.Value = entity.OFFICE_PHONE;
            this.tMobilePhone.Value = entity.MOBILE_PHONE;
            this.hSex.Value = entity.SEX;
            this.cIsAdmin.Checked = (bool)entity.IS_ADMIN;

            this.tEmployeeId.Disabled = true;
        }
        private void Save()
        {
            try
            {
                IEmployee biz = new EmployeeBiz();

                if (CurOperation == "add")
                {
                    var condition_entity = new EmployeeEntity();
                    condition_entity.EMPLOYEE_ID = this.tEmployeeId.Value;
                    var list = biz.GetEmployeeEntityList(condition_entity);
                    if (list != null && list.Count > 0)
                    {
                        this.lMsg.InnerText = "保存失败，原因：已存在重复的账号！";
                    }
                }

                var entity = new EmployeeEntity();
                entity.EMPLOYEE_ID = this.tEmployeeId.Value;
                entity.EMPLOYEE_NAME = this.tEmployeeName.Value;
                entity.RESTAURANT_ID = base.ParseInt(this.ddlRestaurant.SelectedValue);
                entity.PASSWORD = this.tPassword.Value;
                entity.OFFICE_PHONE = this.tOfficePhone.Value;
                entity.MOBILE_PHONE = this.tMobilePhone.Value;
                entity.SEX = this.hSex.Value;
                entity.IS_ADMIN = this.cIsAdmin.Checked;

                if (CurOperation == "add")
                {
                    entity.CREATE_TIME = DateTime.Now;
                    entity.CREATE_PERSON = base.CurEmployeeEntity.EMPLOYEE_ID;
                    biz.InsertEmployeeEntity(entity);
                }
                else if (CurOperation == "edit")
                {
                    entity.EMPLOYEE_ID = CurId;
                    entity.UPDATE_TIME = DateTime.Now;
                    entity.UPDATE_PERSON = base.CurEmployeeEntity.EMPLOYEE_ID;
                    biz.UpdateEmployeeEntity(entity);
                }

                AlertAndTransfer("保存成功！", base.UrlReferrer);
            }
            catch (Exception ex)
            {
                this.lMsg.InnerText = "保存失败，原因：" + ex.ToString();
            }
        }

    }
}