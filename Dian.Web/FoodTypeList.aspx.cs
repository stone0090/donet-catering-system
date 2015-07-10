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
    public partial class FoodTypeList : BasePage
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
            IFoodType biz = new FoodTypeBiz();
            var pds = new PagedDataSource();
            pds.DataSource = biz.GetFoodTypeDataTable().DefaultView;
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