using Dian.Biz;
using Dian.Common.Entity;
using Dian.Common.Interface;
using Dian.Web.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dian.Web
{
    public partial class Index2 : BasePage
    {
        public int RestaurantId { get; set; }
        public int TableId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            RestaurantId = base.ParseInt(Request.QueryString["rId"]);
            TableId = base.ParseInt(Request.QueryString["tId"]);

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
        }
    }
}