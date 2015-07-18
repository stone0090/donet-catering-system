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
    public partial class FoodList : BasePageList
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                DeleteData();

            BindData();

            
        }
        private void BindData()
        {
            IFood biz = new FoodBiz();           
            DataTable dt = (bool)base.CurEmployeeEntity.IS_ADMIN ?
                biz.GetFoodDataTable() :
                biz.GetFoodDataTable(base.CurEmployeeEntity.RESTAURANT_ID);
            repeater1.DataSource = GetPagedDataSource(dt.DefaultView);
            repeater1.DataBind();
        }
        private void DeleteData()
        {
            try
            {
                var id = base.ParseInt(this.hDeleteId.Value);
                if (id != 0)
                {
                    IFood biz = new FoodBiz();
                    biz.DeleteFoodEntity(new FoodEntity() { FOOD_ID = id });
                    this.lMsg.InnerText = "删除成功!";
                }
            }
            catch (Exception ex)
            {
                this.lMsg.InnerText = "删除失败，原因：" + ex.ToString();
            }
        }

        public string GetTasteName(string val)
        {
            switch (val)
            {
                case "1": return "无";
                case "2": return "酸";
                case "3": return "甜";
                case "4": return "苦";
                case "5": return "辣";
                case "6": return "咸";
                default: return "-";
            }
        }
    }
}