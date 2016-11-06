using Dian.Biz;
using Dian.Entity;
using Dian.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dian.Web.Utility
{
    public class BasePageDetail : BasePage
    {
        #region 属性

        public int CurId { get; set; }
        public string CurOperation { get; set; }

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

            CurId = base.ParseInt(Request.QueryString["id"]);
            CurOperation = Request.QueryString["op"];

            if (CurOperation != "add" && CurOperation != "edit")
            {
                AlertAndTransfer("无效的操作类型！", base.UrlReferrer);
                return;
            }

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


        #endregion

    }
}
