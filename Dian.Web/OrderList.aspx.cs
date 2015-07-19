using Dian.Biz;
using Dian.Common.Entity;
using Dian.Common.Interface;
using Dian.Web.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dian.Web
{
    public partial class OrderList : BasePage
    {
        public int CurPage { get; set; }
        public int TotalCount { get; set; }
        public int PageCount { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControlData();
            }
            else
            {
                OperateOrder();
            }

            BindTableData();
        }

        private void BindControlData()
        {
            if (base.CurEmployeeEntity.IS_ADMIN == true)
            {
                IRestaurant restaurantBiz = new RestaurantBiz();
                this.ddlRestaurant.DataSource = restaurantBiz.GetRestaurantDataTable();
                this.ddlRestaurant.DataValueField = "RESTAURANT_ID";
                this.ddlRestaurant.DataTextField = "RESTAURANT_NAME";
                this.ddlRestaurant.DataBind();
                this.ddlRestaurant.Items.Insert(0, new ListItem() { Text = "全部", Value = "0" });
            }
            else
            {
                this.ddlRestaurant.Visible = false;
            }
        }
        private void BindTableData()
        {
            var type = this.hOrderStatus.Value;
            if (string.IsNullOrEmpty(type)) type = "1";
            this.lType.InnerText = GetTypeName(type);
            if (type == "0") type = null;
            int? restaurantId = base.ParseInt(this.ddlRestaurant.SelectedValue);
            if (restaurantId == 0) restaurantId = null;
            IOrder2 biz = new Order2Biz();
            DataTable dt = (bool)base.CurEmployeeEntity.IS_ADMIN ?
                biz.GetOrderMainDataTable(restaurantId, type) :
                biz.GetOrderMainDataTable(base.CurEmployeeEntity.RESTAURANT_ID, type);
            repeater1.DataSource = GetPagedDataSource(dt.DefaultView);
            repeater1.DataBind();
        }
        private void OperateOrder()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.hOperationId.Value))
                {
                    var op = this.hOperationId.Value.Split('|')[0];
                    var id = base.ParseInt(this.hOperationId.Value.Split('|')[1]);
                    IOrder2 biz = new Order2Biz();
                    var condition = new OrderMainEntity2();
                    condition.ORDER_ID = id;
                    if (op == "finish")
                    {
                        condition.ORDER_FLAG = "2";
                        biz.UpdateOrderMainEntity(condition);
                        this.lMsg.InnerText = "完成订单成功!";
                    }
                    else if (op == "cancel")
                    {
                        condition.ORDER_FLAG = "3";
                        biz.UpdateOrderMainEntity(condition);
                        this.lMsg.InnerText = "取消订单成功!";
                    }
                }
            }
            catch (Exception ex)
            {
                this.lMsg.InnerText = "操作失败，原因：" + ex.ToString();
            }
        }

        public string GetStatusName(string val)
        {
            switch (val)
            {
                case "1": return "未完成";
                case "2": return "已完成";
                case "3": return "已取消";
                default: return "-";
            }
        }

        public string GetTypeName(string val)
        {
            switch (val)
            {
                case "0": return "全部订单";
                case "1": return "未完成的订单";
                case "2": return "已完成的订单";
                case "3": return "已取消的订单";
                default: return "-";
            }
        }

        public string GetButtonStyle(string type)
        {
            if (type == "2" || type == "3")
                return "style=\"display:none;\"";
            return "";
        }

        public string GetCountStyle(string all, string finish, string confirm, string unconfirm)
        {
            var intAll = base.ParseInt(all);
            var intFinish = base.ParseInt(finish);
            var intConfirm = base.ParseInt(confirm);
            var intUnconfirm = base.ParseInt(unconfirm);
            return
                "<span class=\"am-badge am-badge-warning\">+" + intAll.ToString() + "</span>" +
                "<span class=\"am-badge am-badge-warning\">+" + intFinish.ToString() + "</span>" +
                "<span class=\"am-badge am-badge-warning\">+" + intConfirm.ToString() + "</span>" +
                "<span class=\"am-badge am-badge-warning\">+" + intUnconfirm.ToString() + "</span>";
        }

        protected PagedDataSource GetPagedDataSource(DataView dv)
        {
            CurPage = base.ParseInt(this.hCurPageNum.Value);
            var pds = new PagedDataSource();
            pds.DataSource = dv;
            pds.AllowPaging = true;
            pds.PageSize = 8;
            if (CurPage < 1) CurPage = 1;
            if (CurPage > pds.PageCount) CurPage = pds.PageCount;
            pds.CurrentPageIndex = CurPage - 1;
            TotalCount = pds.DataSourceCount;
            PageCount = pds.PageCount;
            return pds;
        }

    }
}