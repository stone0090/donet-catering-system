using Dian.Biz;
using Dian.Common.Entity;
using Dian.Common.Interface;
using Dian.Web.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dian.Web
{
    public partial class OrderDetail : BasePage
    {
        public int OrderId { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            OrderId = base.ParseInt(Request.QueryString["id"]);
            if (OrderId == 0)
            {
                this.lMsg.InnerText = "获取订单数据失败，订单编号错误！";
                Response.End();
            }

            if (!IsPostBack)
            {
                BindControlData();
            }
            else
            {
                OperateOrder();
            }

            BindTableData();
        }

        private void BindControlData()
        {
            IOrder2 orderBiz = new Order2Biz();
            var entity = orderBiz.GetOrderMainEntity(OrderId);
            this.hOrderStatus.Value = entity.ORDER_FLAG;
            this.lTableId.InnerText = "桌号为：" + entity.TABLE_ID;
        }
        private void BindTableData()
        {
            IOrder2 orderBiz = new Order2Biz();
            var dt = orderBiz.GetOrderData(OrderId);
            if (dt != null && dt.Rows.Count > 0)
            {
                var data1 = dt.Clone();
                var drs = dt.Select(" ( FINISH_TIME = '' or FINISH_TIME is null ) and ( CONFIRM_TIME = '' or CONFIRM_TIME is null ) ");
                foreach (DataRow row in drs)
                {
                    data1.Rows.Add(row.ItemArray);
                }
                this.rUnconfirm.DataSource = data1;
                this.rUnconfirm.DataBind();

                var data2 = dt.Clone();
                drs = dt.Select("( FINISH_TIME = '' or FINISH_TIME is null ) and ( CONFIRM_TIME <> '' and CONFIRM_TIME is not null ) ");
                foreach (DataRow row in drs)
                {
                    data2.Rows.Add(row.ItemArray);
                }
                this.rConfirm.DataSource = data2;
                this.rConfirm.DataBind();

                var data3 = dt.Clone();
                drs = dt.Select(" FINISH_TIME <> '' and FINISH_TIME is not null ");
                foreach (DataRow row in drs)
                {
                    data3.Rows.Add(row.ItemArray);
                }
                this.rFinish.DataSource = data3;
                this.rFinish.DataBind();

                decimal totalPrice = 0;
                foreach (DataRow row in dt.Rows)
                {
                    totalPrice += base.ParseDecimal(row["PRICE"].ToString()) * base.ParseInt(row["COUNT"].ToString());
                }
                this.sTotalPrice.InnerText = totalPrice.ToString();
            }
            else
            {
                this.rUnconfirm.DataSource = null;
                this.rUnconfirm.DataBind();

                this.rConfirm.DataSource = null;
                this.rConfirm.DataBind();

                this.rFinish.DataSource = null;
                this.rFinish.DataBind();
            }

        }
        private void OperateOrder()
        {
            try
            {
                if (!string.IsNullOrEmpty(this.hOperation.Value))
                {
                    IOrder2 orderBiz = new Order2Biz();
                    if (this.hOperation.Value.IndexOf('|') > -1)
                    {
                        var op = this.hOperation.Value.Split('|')[0];
                        var listId = base.ParseInt(this.hOperation.Value.Split('|')[1]);
                        if (listId == 0)
                        {
                            this.lMsg.InnerText = "处理失败，参数 LIST_ID 不正确！";
                            return;
                        }
                        if (op == "cancel")
                        {
                            var condition = new OrderListEntity2();
                            condition.LIST_ID = listId;
                            condition.CANCEL_TIME = DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss");
                            orderBiz.UpdateOrderListEntity(condition);
                        }
                        if (op == "confirm")
                        {
                            var condition = new OrderListEntity2();
                            condition.LIST_ID = listId;
                            condition.CONFIRM_TIME = DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss");
                            orderBiz.UpdateOrderListEntity(condition);
                        }
                        else if (op == "finish")
                        {
                            //假如存在已完成同样的菜单，更新原有的数量
                            var curOrderListEntity = orderBiz.GetOrderListEntity(listId);
                            var condition = new OrderListEntity2();
                            condition.FOOD_ID = curOrderListEntity.FOOD_ID;
                            condition.ORDER_ID = OrderId;
                            int oldListId = 0;
                            var list = orderBiz.GetOrderListEntityList(condition);

                            condition = null;
                            if (list != null && list.Count > 0)
                            {
                                foreach (OrderListEntity2 e in list)
                                {
                                    if (!string.IsNullOrEmpty(e.FINISH_TIME) && string.IsNullOrEmpty(e.CANCEL_TIME))
                                    {
                                        condition = new OrderListEntity2();
                                        condition.LIST_ID = e.LIST_ID;
                                        condition.COUNT = e.COUNT;
                                    }
                                }
                            }

                            if (condition != null)
                            {
                                condition.COUNT += curOrderListEntity.COUNT;
                                orderBiz.UpdateOrderListEntity(condition);
                                orderBiz.DeleteOrderListEntity(new OrderListEntity2() { LIST_ID = curOrderListEntity.LIST_ID });
                            }
                            else
                            {
                                condition = new OrderListEntity2();
                                condition.LIST_ID = listId;
                                condition.FINISH_TIME = DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss");
                                orderBiz.UpdateOrderListEntity(condition);
                            }
                        }
                        else if (op == "cancelfinish")
                        {
                            //假如存在已完成同样的菜单，更新原有的数量
                            var curOrderListEntity = orderBiz.GetOrderListEntity(listId);
                            var condition = new OrderListEntity2();
                            condition.FOOD_ID = curOrderListEntity.FOOD_ID;
                            condition.ORDER_ID = OrderId;
                            int oldListId = 0;
                            var list = orderBiz.GetOrderListEntityList(condition);

                            condition = null;
                            if (list != null && list.Count > 0)
                            {
                                foreach (OrderListEntity2 e in list)
                                {
                                    if (!string.IsNullOrEmpty(e.CONFIRM_TIME) && string.IsNullOrEmpty(e.FINISH_TIME) && string.IsNullOrEmpty(e.CANCEL_TIME))
                                    {
                                        condition = new OrderListEntity2();
                                        condition.LIST_ID = e.LIST_ID;
                                        condition.COUNT = e.COUNT;
                                    }
                                }
                            }

                            if (condition != null)
                            {
                                condition.COUNT += curOrderListEntity.COUNT;
                                orderBiz.UpdateOrderListEntity(condition);
                                orderBiz.DeleteOrderListEntity(new OrderListEntity2() { LIST_ID = curOrderListEntity.LIST_ID });
                            }
                            else
                            {
                                condition = new OrderListEntity2();
                                condition.LIST_ID = listId;
                                condition.FINISH_TIME = string.Empty;
                                orderBiz.UpdateOrderListEntity(condition);
                            }
                        }
                    }
                    else
                    {
                        if (this.hOperation.Value == "confirmall")
                        {

                        }
                        else if (this.hOperation.Value == "finishall")
                        {

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                this.lMsg.InnerText = "处理失败，原因：" + ex.ToString();
            }
        }

    }
}