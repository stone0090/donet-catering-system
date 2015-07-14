using Dian.Biz;
using Dian.Common.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dian.Web
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                BindData();
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