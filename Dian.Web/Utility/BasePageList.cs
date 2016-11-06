using Dian.Biz;
using Dian.Entity;
using Dian.Interface;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dian.Web.Utility
{
    public class BasePageList : BasePage
    {
        #region 属性

        public int CurPage { get; set; }
        public int TotalCount { get; set; }
        public int PageCount { get; set; }

        #endregion

        #region 页面事件

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected override void OnPreLoad(EventArgs e)
        {
            base.OnPreLoad(e);
            CurPage = base.ParseInt(Request.QueryString["page"]);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);

        }

        #endregion

        #region 提供子类使用的方法

        protected PagedDataSource GetPagedDataSource(DataView dv)
        {
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

        #endregion

    }
}
