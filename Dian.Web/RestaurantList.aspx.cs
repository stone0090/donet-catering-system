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
    public partial class RestaurantList : BasePage
    {
        public int CurPage { get; set; }
        public int TotalCount { get; set; }
        public int PageCount { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            CurPage = base.ParseInt(Request.QueryString["page"]);

            if (IsPostBack)
                DeleteData();

            BindData();
        }
        private void BindData()
        {
            IRestaurant biz = new RestaurantBiz();
            var pds = new PagedDataSource();
            pds.DataSource = biz.GetRestaurantDataTable().DefaultView;
            pds.AllowPaging = true;
            pds.PageSize = 8;
            if (CurPage < 1) CurPage = 1;
            if (CurPage > pds.PageCount) CurPage = pds.PageCount;
            pds.CurrentPageIndex = CurPage - 1;
            repeater1.DataSource = pds;
            repeater1.DataBind();
            TotalCount = pds.DataSourceCount;
            PageCount = pds.PageCount;
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
                default: return "未定义的等级";
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
                default: return "未定义的区域";
            }
        }


    }
}