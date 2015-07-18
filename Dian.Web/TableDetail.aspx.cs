using Dian.Biz;
using Dian.Common.Entity;
using Dian.Common.Interface;
using Dian.Web.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dian.Web
{
    public partial class TableDetail : BasePageDetail
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            IRestaurant restaurantBiz = new RestaurantBiz();
            this.ddlRestaurant.DataSource = (bool)base.CurEmployeeEntity.IS_ADMIN ?
                restaurantBiz.GetRestaurantDataTable() :
                restaurantBiz.GetRestaurantDataTable(base.CurEmployeeEntity.EMPLOYEE_ID);
            this.ddlRestaurant.DataValueField = "RESTAURANT_ID";
            this.ddlRestaurant.DataTextField = "RESTAURANT_NAME";
            this.ddlRestaurant.DataBind();
        }
        private void FillFormData()
        {
            if (CurId == 0)
            {
                AlertAndTransfer("参数id无效！", base.UrlReferrer);
                return;
            }

            ITable biz = new TableBiz();
            var entity = biz.GetTableEntity(CurId);
            if (entity == null)
            {
                AlertAndTransfer("参数id无效，获取数据失败！", base.UrlReferrer);
                return;
            }

            this.tTableName.Value = entity.TABLE_NAME;
            this.ddlRestaurant.SelectedValue = entity.RESTAURANT_ID.ToString();

        }
        private void Save()
        {
            try
            {
                ITable biz = new TableBiz();
                var entity = new TableEntity();
                entity.TABLE_NAME = this.tTableName.Value;
                entity.RESTAURANT_ID = base.ParseInt(this.ddlRestaurant.SelectedValue);

                if (CurOperation == "add")
                    biz.InsertTableEntity(entity);
                else if (CurOperation == "edit")
                {
                    entity.TABLE_ID = CurId;
                    biz.UpdateTableEntity(entity);
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