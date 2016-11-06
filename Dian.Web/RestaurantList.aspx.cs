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
    public partial class RestaurantList : BasePageList
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
                DeleteData();

            BindData();
        }
        private void BindData()
        {
            IRestaurant biz = new RestaurantBiz();
            repeater1.DataSource = GetPagedDataSource(biz.GetRestaurantDataTable().DefaultView);
            repeater1.DataBind();
        }
        private void DeleteData()
        {
            try
            {
                var id = base.ParseInt(this.hDeleteId.Value);
                if (id != 0)
                {
                    IRestaurant biz = new RestaurantBiz();
                    biz.DeleteRestaurantEntity(new RestaurantEntity() { RESTAURANT_ID = id });
                    this.lMsg.InnerText = "删除成功!";
                }
            }
            catch (Exception ex)
            {
                this.lMsg.InnerText = "删除失败，原因：" + ex.ToString();
            }
        }

        public string GetLevelName(string val)
        {
            switch (val)
            {
                case "1": return "一级";
                case "2": return "二级";
                case "3": return "三级";
                case "4": return "四级";
                case "5": return "五级";
                default: return "-";
            }
        }
        public string GetAreaName(string val)
        {
            switch (val)
            {
                case "1": return "华中";
                case "2": return "华东";
                case "3": return "华南";
                case "4": return "华西";
                case "5": return "华北";
                default: return "-";
            }
        }


    }
}