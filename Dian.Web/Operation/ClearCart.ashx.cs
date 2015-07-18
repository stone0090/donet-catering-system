using Dian.Biz;
using Dian.Common.Entity;
using Dian.Common.Interface;
using Dian.Web.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Dian.Web.Operation
{
    /// <summary>
    /// ClearCart 的摘要说明
    /// </summary>
    public class ClearCart : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                var orderId = Helper.ParseInt(context.Request.Form["oid"]);

                IOrder2 orderBiz = new Order2Biz();
                orderBiz.ClearCart(orderId);
                context.Response.Write("{\"success\":1}");
            }
            catch (Exception ex)
            {
                context.Response.Write("{\"success\":0,\"msg\":\" " + ex.ToString() + " \"}");
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