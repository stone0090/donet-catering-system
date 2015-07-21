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
    /// CreateOrder 的摘要说明
    /// </summary>
    public class CreateOrder : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                var tableId = Helper.ParseInt(context.Request.QueryString["tid"]);
                var restaurantId = Helper.ParseInt(context.Request.QueryString["rid"]);
                var orderData = context.Request.Form["orderData"];
                var price = Helper.ParseDecimal(context.Request.Form["price"]);

                IOrder2 orderBiz = new Order2Biz();
                var condition = new OrderMainEntity2();
                condition.RESTAURANT_ID = restaurantId;
                condition.TABLE_ID = tableId;
                condition.ORDER_FLAG = "1";
                var list = orderBiz.GetOrderMainEntityList(condition);
                if (list != null && list.Count > 0)
                {
                    context.Response.Write("{\"success\":0,\"msg\":\"上个订单还未结束，不能创建新的订单，请重新重新刷新页面！\"}");
                    return;
                }

                var list2 = JsonToObjects(orderData);
                if (list2 != null && list2.Count > 0)
                {
                    var orderId = orderBiz.CreateOrder(restaurantId, tableId, price, list2);
                    context.Response.Write("{\"success\":1,\"id\":" + orderId.ToString() + "}");
                }
            }
            catch (Exception ex)
            {
                context.Response.Write("{\"success\":0,\"msg\":\"订单数据有误，原因是" + ex.ToString() + "！\"}");
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private List<OrderListEntity2> JsonToObjects(string strJson)
        {
            if (string.IsNullOrEmpty(strJson))
                return new List<OrderListEntity2>();

            DataTable dt = null;

            //去除表名  
            strJson = strJson.Substring(strJson.IndexOf("[") + 1);
            strJson = strJson.Substring(0, strJson.LastIndexOf("]"));

            //获取数据  
            Regex rg = new Regex(@"(?<={)[^}]+(?=})");
            MatchCollection mc = rg.Matches(strJson);
            for (int i = 0; i < mc.Count; i++)
            {
                string strRow = mc[i].Value;
                string[] strRows = strRow.Split(',');

                //创建表  
                if (dt == null)
                {
                    dt = new DataTable();
                    foreach (string str in strRows)
                    {
                        DataColumn dc = new DataColumn();
                        string[] strCell = str.Split(':');
                        dc.ColumnName = strCell[0].Replace("\"", "");
                        dt.Columns.Add(dc);
                    }
                    dt.AcceptChanges();
                }

                //增加内容  
                DataRow dr = dt.NewRow();
                for (int r = 0; r < strRows.Length; r++)
                {
                    dr[r] = strRows[r].Split(':')[1].Trim().Replace("，", ",").Replace("：", ":").Replace("/", "").Replace("\"", "");
                }
                dt.Rows.Add(dr);
                dt.AcceptChanges();
            }

            if (dt != null)
                return DataTableHepler.DataTableToList<OrderListEntity2>(dt);

            return new List<OrderListEntity2>();
        }


    }
}