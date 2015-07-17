using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Dian.Common.Entity;
using Dian.Common.Interface;
using Dian.Dao;
using CSN.DotNetLibrary.EntityExpressions.Entitys;
using System.Transactions;

namespace Dian.Biz
{
    public class Order2Biz : System.MarshalByRefObject, IOrder2
    {
        private DianManual _manual_dao = null;
        public DianManual manual_dao
        {
            get
            {
                return _manual_dao == null ? _manual_dao = new DianManual() : _manual_dao;
            }
        }


        #region 扩展方法

        public DataTable GetOrderData(int orderId)
        {
            try
            {
                return manual_dao.GetOrderData(orderId);
            }
            catch (Exception ex)
            {
                throw new DianBizException("获取订单列表的数据出错！", ex);
            }
        }

        public int CreateOrder(int orderId, int restaurantId, int tableId, decimal price, List<OrderListEntity2> listOrderList)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                if (orderId == 0)
                {
                    var orderMainEntity = new OrderMainEntity2();
                    orderMainEntity.RESTAURANT_ID = restaurantId;
                    orderMainEntity.TABLE_ID = tableId;
                    orderMainEntity.PRICE = price;
                    orderMainEntity.ORDER_FLAG = "1";
                    orderId = InsertOrderMainEntity(orderMainEntity);
                }
                else
                {
                    manual_dao.DeleteOrderListByConfirmTimeIsNull(orderId);
                }

                foreach (var orderList in listOrderList)
                {
                    orderList.ORDER_ID = orderId;
                    orderList.ORDER_FLAG = "1";
                    orderList.ORDER_TIME = DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss");
                    InsertOrderListEntity(orderList);
                }

                ts.Complete();
            }

            return orderId;
        }

        public void UpdateOrder(int orderId, string foodOp, OrderListEntity2 entity)
        {
            var dt = GetUnConfirmOrderDataByFood(orderId, (int)entity.FOOD_ID);

            if (foodOp == "add")
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    var condition = new OrderListEntity2();
                    condition.LIST_ID = int.Parse(dt.Rows[0]["LIST_ID"].ToString());
                    condition.COUNT = int.Parse(dt.Rows[0]["COUNT"].ToString()) + 1;
                    UpdateOrderListEntity(condition);
                }
                else
                {
                    entity.ORDER_ID = orderId;
                    entity.COUNT = 1;
                    entity.ORDER_FLAG = "1";
                    entity.ORDER_TIME = DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss");
                    InsertOrderListEntity(entity);
                }
            }
            else if (foodOp == "cut")
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    var count = int.Parse(dt.Rows[0]["COUNT"].ToString());
                    if (count <= 1)
                    {
                        var condition = new OrderListEntity2();
                        condition.LIST_ID = int.Parse(dt.Rows[0]["LIST_ID"].ToString());
                        DeleteOrderListEntity(condition);
                    }
                    else
                    {
                        var condition = new OrderListEntity2();
                        condition.LIST_ID = int.Parse(dt.Rows[0]["LIST_ID"].ToString());
                        condition.COUNT = count - 1;
                        UpdateOrderListEntity(condition);
                    }
                }
            }
            else if (foodOp == "remark")
            {
                if (dt != null && dt.Rows.Count > 0)
                {
                    var condition = new OrderListEntity2();
                    condition.LIST_ID = int.Parse(dt.Rows[0]["LIST_ID"].ToString());
                    condition.TASTE = entity.TASTE;
                    condition.REMARK = entity.REMARK;
                    UpdateOrderListEntity(condition);
                }
            }

        }

        private DataTable GetUnConfirmOrderDataByFood(int orderId, int foodId)
        {
            return manual_dao.GetUnConfirmOrderDataByFood(orderId, foodId);
        }

        #endregion

        #region  基础方法

        public DataTable GetOrderMainDataTable()
        {
            try
            {
                return manual_dao.GetOrderMainDataTable();
            }
            catch (Exception ex)
            {
                throw new DianBizException("获取订单的数据出错！", ex);
            }
        }

        public List<OrderMainEntity2> GetOrderMainEntityList(OrderMainEntity2 condition_entity)
        {
            try
            {
                GenericWhereEntity<OrderMainEntity2> where_entity = new GenericWhereEntity<OrderMainEntity2>();
                if (condition_entity.ORDER_ID != null)
                    where_entity.Where(n => (n.ORDER_ID == condition_entity.ORDER_ID));
                if (condition_entity.RESTAURANT_ID != null)
                    where_entity.Where(n => (n.RESTAURANT_ID == condition_entity.RESTAURANT_ID));
                if (condition_entity.TABLE_ID != null)
                    where_entity.Where(n => (n.TABLE_ID == condition_entity.TABLE_ID));
                if (condition_entity.ORDER_FLAG != null)
                    where_entity.Where(n => (n.ORDER_FLAG == condition_entity.ORDER_FLAG));
                return DianDao.ReadEntityList(where_entity);
            }
            catch (Exception ex)
            {
                throw new DianBizException("获取订单的数据出错！", ex);
            }
        }

        public int InsertOrderMainEntity(OrderMainEntity2 condition_entity)
        {
            try
            {
                var result = DianDao.InsertEntityWithIdentity(condition_entity);
                return int.Parse(result.ToString());
            }
            catch (Exception ex)
            {
                throw new DianBizException("插入订单数据出错！", ex);
            }
        }

        public void UpdateOrderMainEntity(OrderMainEntity2 condition_entity)
        {
            try
            {
                DianDao.UpdateEntity(condition_entity);
            }
            catch (Exception ex)
            {
                throw new DianBizException("更新订单数据出错！", ex);
            }
        }

        public void DeleteOrderMainEntity(OrderMainEntity2 condition_entity)
        {
            try
            {
                DianDao.DeleteEntity(condition_entity);
            }
            catch (Exception ex)
            {
                throw new DianBizException("删除订单数据出错！", ex);
            }
        }

        public OrderMainEntity2 GetOrderMainEntity(int? id)
        {
            return DianDao.ReadEntity2<OrderMainEntity2>(n => n.ORDER_ID == id);
        }



        public DataTable GetOrderListDataTable()
        {
            try
            {
                return manual_dao.GetOrderListDataTable();
            }
            catch (Exception ex)
            {
                throw new DianBizException("获取订单列表的数据出错！", ex);
            }
        }

        public List<OrderListEntity2> GetOrderListEntityList(OrderListEntity2 condition_entity)
        {
            try
            {
                GenericWhereEntity<OrderListEntity2> where_entity = new GenericWhereEntity<OrderListEntity2>();
                if (condition_entity.ORDER_ID != null)
                    where_entity.Where(n => (n.ORDER_ID == condition_entity.ORDER_ID));
                if (condition_entity.FOOD_ID != null)
                    where_entity.Where(n => (n.FOOD_ID == condition_entity.FOOD_ID));
                return DianDao.ReadEntityList(where_entity);
            }
            catch (Exception ex)
            {
                throw new DianBizException("获取订单列表的数据出错！", ex);
            }
        }

        public void InsertOrderListEntity(OrderListEntity2 condition_entity)
        {
            try
            {
                DianDao.InsertEntity(condition_entity);
            }
            catch (Exception ex)
            {
                throw new DianBizException("插入订单列表数据出错！", ex);
            }
        }

        public void UpdateOrderListEntity(OrderListEntity2 condition_entity)
        {
            try
            {
                DianDao.UpdateEntity(condition_entity);
            }
            catch (Exception ex)
            {
                throw new DianBizException("更新订单列表数据出错！", ex);
            }
        }

        public void DeleteOrderListEntity(OrderListEntity2 condition_entity)
        {
            try
            {
                DianDao.DeleteEntity(condition_entity);
            }
            catch (Exception ex)
            {
                throw new DianBizException("删除订单列表数据出错！", ex);
            }
        }


        public OrderListEntity2 GetOrderListEntity(int? id)
        {
            return DianDao.ReadEntity2<OrderListEntity2>(n => n.ORDER_ID == id);
        }

        #endregion

        public int TestCallAble()
        {
            throw new NotImplementedException();
        }

    }
}
