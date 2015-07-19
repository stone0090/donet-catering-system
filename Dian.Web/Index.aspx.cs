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
            else
            {
                IRestaurant restaurantBiz = new RestaurantBiz();
                if (restaurantBiz.GetRestaurantEntity(RestaurantId) == null)
                    Server.Transfer("Error404.aspx");
            }

            if (!IsPostBack)
            {
                BindData();

                if (CurEmployeeEntity != null)
                {
                    this.aLogin.HRef = "OrderList.aspx";
                    this.aLogin.InnerText = "后台管理";
                }
            }
        }

        private void BindData()
        {
            //绑定菜单列表
            IFood foodBiz = new FoodBiz();
            var dt = foodBiz.GetFoodDataTable(RestaurantId);
            repeater2.DataSource = dt;
            repeater2.DataBind();

            //绑定菜单类型列表            
            var strFoodId = string.Empty;
            var listFoodType = new List<FoodTypeEntity>();
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    if (!strFoodId.Contains(dr["FOOD_TYPE_ID"].ToString() + "|"))
                    {
                        strFoodId += dr["FOOD_TYPE_ID"].ToString() + "|";
                        listFoodType.Add(new FoodTypeEntity()
                        {
                            FOOD_TYPE_ID = base.ParseInt(dr["FOOD_TYPE_ID"].ToString()),
                            FOOD_TYPE_NAME = dr["FOOD_TYPE_NAME"].ToString()
                        });
                    }
                }
            }
            repeater1.DataSource = listFoodType;
            repeater1.DataBind();

            //获取是否已经点过菜
            IOrder2 orderBiz = new Order2Biz();
            var condition = new OrderMainEntity2();
            condition.RESTAURANT_ID = RestaurantId;
            condition.TABLE_ID = TableId;
            condition.ORDER_FLAG = "1";
            var list = orderBiz.GetOrderMainEntityList(condition);
            if (list != null && list.Count > 0)
                this.hOrderId.Value = list[0].ORDER_ID.ToString();

        }


    }
}