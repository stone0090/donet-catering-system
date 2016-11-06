using Dian.Biz;
using Dian.Entity;
using Dian.Interface;
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
    /// UpdateOrder 的摘要说明
    /// </summary>
    public class UpdateOrder : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                var orderId = Helper.ParseInt(context.Request.Form["oid"]);
                var orderData = context.Request.Form["orderData"];
                var foodOp = context.Request.Form["fop"];
                var price = Helper.ParseDecimal(context.Request.Form["price"]);
                var entity = JsonToObject(orderData);

                IOrder orderBiz = new OrderBiz();
                orderBiz.UpdateOrder(orderId, price, foodOp, entity);
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

        private OrderListEntity JsonToObject(string strJson)
        {
            if (string.IsNullOrEmpty(strJson))
                return null;

            DataTable dt = null;

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

            if (dt != null && dt.Rows.Count > 0)
                return DataTableHepler.DataRowToEntity<OrderListEntity>(dt.Rows[0]);

            return null;
        }
    }
}