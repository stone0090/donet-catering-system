using Dian.Biz;
using Dian.Entity;
using Dian.Interface;
using Dian.Web.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dian.Web.Operation
{
    /// <summary>
    /// GetOrderData 的摘要说明
    /// </summary>
    public class GetOrderData : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            var orderId = Helper.ParseInt(context.Request.Form["oid"]);

            IOrder orderBiz = new OrderBiz();
            var dt = orderBiz.GetOrderData(orderId);
            if (dt != null && dt.Rows.Count > 0)
            {
                var result = JsonHelper.DataTableToJson(dt);
                context.Response.Write(result);
            }
            else
            {
                context.Response.Write("{}");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}