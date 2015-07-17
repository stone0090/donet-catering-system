using Dian.Biz;
using Dian.Common.Entity;
using Dian.Common.Interface;
using Dian.Web.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dian.Web
{
    public partial class Index : BasePage
    {
        public int RestaurantId { get; set; }
        public int TableId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            RestaurantId = base.ParseInt(Request.QueryString["rId"]);
            TableId = base.ParseInt(Request.QueryString["tId"]);
            this.hOrderId.Value = "";

            if (RestaurantId == 0 || TableId == 0)
            {
                Server.Transfer("Error404.aspx");
            }

            if (!IsPostBack)
            {
                BindData();

                if (CurEmployeeEntity != null)
                {
                    this.aLogin.HRef = "BackgroudIndex.aspx";
                    this.aLogin.InnerText = CurEmployeeEntity.EMPLOYEE_NAME + "，您好";
                }
            }
        }

        private void BindData()
        {
            IFoodType foodTypeBiz = new FoodTypeBiz();
            repeater1.DataSource = foodTypeBiz.GetFoodTypeDataTable();
            repeater1.DataBind();

            IFood foodBiz = new FoodBiz();
            repeater2.DataSource = foodBiz.GetFoodDataTable();
            repeater2.DataBind();

            IOrder2 orderBiz = new Order2Biz();
            var condition = new OrderMainEntity2();
            condition.RESTAURANT_ID = RestaurantId;
            condition.TABLE_ID = TableId;
            condition.ORDER_FLAG = "1";
            var list = orderBiz.GetOrderMainEntityList(condition);
            if (list != null && list.Count > 0)
            {
                this.hOrderId.Value = list[0].ORDER_ID.ToString();
            }
        }


    }
}