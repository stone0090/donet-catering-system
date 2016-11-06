using Dian.Biz;
using Dian.Entity;
using Dian.Interface;
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
    public partial class FoodTypeList : BasePageList
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                DeleteData();

            BindData();
        }
        private void BindData()
        {
            IFoodType biz = new FoodTypeBiz();
            repeater1.DataSource = GetPagedDataSource(biz.GetFoodTypeDataTable().DefaultView);
            repeater1.DataBind();
        }
        private void DeleteData()
        {
            try
            {
                var id = base.ParseInt(this.hDeleteId.Value);
                if (id != 0)
                {
                    IFoodType biz = new FoodTypeBiz();
                    biz.DeleteFoodTypeEntity(new FoodTypeEntity() { FOOD_TYPE_ID = id });
                    this.lMsg.InnerText = "删除成功!";
                }
            }
            catch (Exception ex)
            {
                this.lMsg.InnerText = "删除失败，原因：" + ex.ToString();
            }
        }
    }
}