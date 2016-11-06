using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Dian.Entity;
using Dian.Interface;
using System.Transactions;
using DoNet.Utility.Database;
using DoNet.Utility.Database.EntitySql;
using DoNet.Utility.Database.EntitySql.Entity;

namespace Dian.Biz
{
    public class OrderBiz : System.MarshalByRefObject, IOrder
    {
        private DbHelper _db;
        private DbHelper Db
        {
            get { return _db ?? (_db = DbFactory.CreateDatabase()); }
        }

        #region 扩展方法

        public DataTable GetOrderData(int orderId)
        {
            string sql = @"SELECT A.*,B.FOOD_NAME FROM ORDERLIST A 
                            LEFT JOIN FOOD B ON A.FOOD_ID = B.FOOD_ID 
                            WHERE  (CANCEL_TIME = '' OR CANCEL_TIME IS NULL)  
                            AND A.ORDER_ID = @ORDER_ID ";
            using (DbCommand dc = Db.GetSqlStringCommand(sql))
            {
                Db.AddInParameter(dc, "@ORDER_ID", DbType.Int32, orderId);
                return Db.ExecuteDataTable(dc);
            }
        }

        public int CreateOrder(int restaurantId, int tableId, decimal price, List<OrderListEntity> listOrderList)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                var orderMainEntity = new OrderMainEntity();
                orderMainEntity.RESTAURANT_ID = restaurantId;
                orderMainEntity.TABLE_ID = tableId;
                orderMainEntity.PRICE = price;
                orderMainEntity.ORDER_FLAG = "1";
                var orderId = InsertOrderMainEntity(orderMainEntity);

                foreach (var orderList in listOrderList)
                {
                    orderList.ORDER_ID = orderId;
                    orderList.ORDER_FLAG = "1";
                    orderList.ORDER_TIME = DateTime.Now.ToString("yyyy-MM-dd HH:mm:sss");
                    InsertOrderListEntity(orderList);
                }

                ts.Complete();

                return orderId;
            }
        }

        public void UpdateOrder(int orderId, decimal price, string foodOp, OrderListEntity entity)
        {
            using (TransactionScope ts = new TransactionScope())
            {
                //更新主表价格
                var orderMainEntity = new OrderMainEntity();
                orderMainEntity.ORDER_ID = orderId;
                orderMainEntity.PRICE = price;
                UpdateOrderMainEntity(orderMainEntity);

                //更新子表明细
                var dt = GetUnConfirmOrderData(orderId, entity.FOOD_ID);
                if (foodOp == "add")
                {
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        var condition = new OrderListEntity();
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
                            var condition = new OrderListEntity();
                            condition.LIST_ID = int.Parse(dt.Rows[0]["LIST_ID"].ToString());
                            DeleteOrderListEntity(condition);
                        }
                        else
                        {
                            var condition = new OrderListEntity();
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
                        var condition = new OrderListEntity();
                        condition.LIST_ID = int.Parse(dt.Rows[0]["LIST_ID"].ToString());
                        condition.TASTE = entity.TASTE;
                        condition.REMARK = entity.REMARK;
                        UpdateOrderListEntity(condition);
                    }
                }

                ts.Complete();
            }

        }

        public void ClearCart(int orderId)
        {
            var dt = GetUnConfirmOrderData(orderId);
            if (dt != null && dt.Rows.Count > 0)
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        var condition = new OrderListEntity();
                        condition.LIST_ID = int.Parse(dr["LIST_ID"].ToString());
                        DeleteOrderListEntity(condition);
                    }
                    ts.Complete();
                }
            }
        }

        public void BatchProcessOrder(int orderId, string opreation)
        {
            string sql = "UPDATE ORDERLIST SET {0} = CONVERT(varchar(100), GETDATE(), 120) WHERE ORDER_ID = @ORDER_ID AND ({0} IS NULL OR {0} = '')";
            if (opreation == "confirmall")
                sql = string.Format(sql, "CONFIRM_TIME");
            if (opreation == "finishall")
            {
                sql = string.Format(sql, "FINISH_TIME");
                sql += " AND (CONFIRM_TIME IS NOT NULL AND CONFIRM_TIME <> '') ";
            }
            using (DbCommand dc = Db.GetSqlStringCommand(sql))
            {
                Db.AddInParameter(dc, "@ORDER_ID", DbType.Int32, orderId);
                Db.ExecuteNonQuery(dc);
            }
        }

        private DataTable GetUnConfirmOrderData(int orderId, int? foodId = null)
        {
            string sql = @"SELECT A.*,B.FOOD_NAME FROM ORDERLIST A 
                            LEFT JOIN FOOD B ON A.FOOD_ID = B.FOOD_ID 
                            WHERE (CANCEL_TIME = '' OR CANCEL_TIME IS NULL) 
                            AND (CONFIRM_TIME = '' OR CONFIRM_TIME IS NULL) 
                            AND (FINISH_TIME = '' OR FINISH_TIME IS NULL) 
                            AND A.ORDER_ID = @ORDER_ID ";
            if (foodId != null)
                sql += " AND A.FOOD_ID = @FOOD_ID ";
            using (DbCommand dc = Db.GetSqlStringCommand(sql))
            {
                Db.AddInParameter(dc, "@ORDER_ID", DbType.Int32, orderId);
                if (foodId != null)
                    Db.AddInParameter(dc, "@FOOD_ID", DbType.Int32, foodId);
                return Db.ExecuteDataTable(dc);
            }
        }

        #endregion

        #region  基础方法
        public DataTable GetOrderMainDataTable(int? restaurantId = null, string type = null)
        {
            string sql = @"SELECT A.*,B.RESTAURANT_NAME,
                                ISNULL(C.ALLORDER,0) ALLORDER,
                                ISNULL(D.FINISH,0) FINISH,
                                ISNULL(E.CONFIRM,0) CONFIRM,
                                ISNULL(F.UNCONFIRM,0) UNCONFIRM 
                                FROM ORDERMAIN A
                                LEFT JOIN RESTAURANT B ON A.RESTAURANT_ID = B.RESTAURANT_ID
                                LEFT JOIN (SELECT ORDER_ID,SUM([COUNT]) ALLORDER FROM ORDERLIST
			                                WHERE (CANCEL_TIME = '' OR CANCEL_TIME IS NULL) 
			                                GROUP BY ORDER_ID) C ON A.ORDER_ID = C.ORDER_ID
                                LEFT JOIN (SELECT ORDER_ID,SUM([COUNT]) FINISH FROM ORDERLIST
			                                WHERE (CANCEL_TIME = '' OR CANCEL_TIME IS NULL) 
			                                AND (FINISH_TIME <> '' AND FINISH_TIME IS NOT NULL) 
			                                GROUP BY ORDER_ID) D ON A.ORDER_ID = D.ORDER_ID
                                LEFT JOIN (SELECT ORDER_ID,SUM([COUNT]) CONFIRM FROM ORDERLIST
			                                WHERE (CANCEL_TIME = '' OR CANCEL_TIME IS NULL) 
			                                AND (CONFIRM_TIME <> '' AND CONFIRM_TIME IS NOT NULL) 
			                                AND (FINISH_TIME = '' OR FINISH_TIME IS NULL) 
			                                GROUP BY ORDER_ID) E ON A.ORDER_ID = E.ORDER_ID
                                LEFT JOIN (SELECT ORDER_ID,SUM([COUNT]) UNCONFIRM FROM ORDERLIST
			                                WHERE (CANCEL_TIME = '' OR CANCEL_TIME IS NULL) 
			                                AND (CONFIRM_TIME = '' OR CONFIRM_TIME IS NULL) 
			                                AND (FINISH_TIME = '' OR FINISH_TIME IS NULL) 
			                                GROUP BY ORDER_ID) F ON A.ORDER_ID = F.ORDER_ID
                                WHERE 1=1 ";
            if (restaurantId != null)
                sql += " AND B.RESTAURANT_ID = @RESTAURANT_ID ";
            if (!string.IsNullOrEmpty(type))
                sql += " AND A.ORDER_FLAG = @ORDER_FLAG ";
            using (DbCommand dc = Db.GetSqlStringCommand(sql))
            {
                if (restaurantId != null)
                    Db.AddInParameter(dc, "@RESTAURANT_ID", DbType.Int32, restaurantId);
                if (!string.IsNullOrEmpty(type))
                    Db.AddInParameter(dc, "@ORDER_FLAG", DbType.AnsiString, type);
                return Db.ExecuteDataTable(dc);
            }
        }

        public List<OrderMainEntity> GetOrderMainEntityList(OrderMainEntity condition_entity)
        {
            GenericWhereEntity<OrderMainEntity> where_entity = new GenericWhereEntity<OrderMainEntity>();
            if (condition_entity.ORDER_ID != null)
                where_entity.Where(n => (n.ORDER_ID == condition_entity.ORDER_ID));
            if (condition_entity.RESTAURANT_ID != null)
                where_entity.Where(n => (n.RESTAURANT_ID == condition_entity.RESTAURANT_ID));
            if (condition_entity.TABLE_ID != null)
                where_entity.Where(n => (n.TABLE_ID == condition_entity.TABLE_ID));
            if (condition_entity.ORDER_FLAG != null)
                where_entity.Where(n => (n.ORDER_FLAG == condition_entity.ORDER_FLAG));
            return EntityExecution.SelectAll(where_entity);
        }

        public int InsertOrderMainEntity(OrderMainEntity condition_entity)
        {
            var result = condition_entity.InsertWithIdentity();
            return int.Parse(result.ToString());
        }

        public void UpdateOrderMainEntity(OrderMainEntity condition_entity)
        {
            condition_entity.Update();
        }

        public void DeleteOrderMainEntity(OrderMainEntity condition_entity)
        {
            condition_entity.Delete();
        }

        public OrderMainEntity GetOrderMainEntity(int? id)
        {
            return EntityExecution.SelectOne<OrderMainEntity>(n => n.ORDER_ID == id);
        }
        public DataTable GetOrderListDataTable(int? restaurantId = null)
        {
            string sql = @"SELECT A.*,C.RESTAURANT_NAME,D.FOOD_NAME FROM ORDERLIST A
                                LEFT JOIN ORDERMAIN B ON A.ORDER_ID = B.ORDER_ID
                                LEFT JOIN RESTAURANT C ON B.RESTAURANT_ID = C.RESTAURANT_ID
                                LEFT JOIN FOOD D ON A.FOOD_ID = D.FOOD_ID
                                WHERE 1=1 ";
            if (restaurantId != null)
                sql += " AND C.RESTAURANT_ID = @RESTAURANT_ID ";
            using (DbCommand dc = Db.GetSqlStringCommand(sql))
            {
                if (restaurantId != null)
                    Db.AddInParameter(dc, "@RESTAURANT_ID", DbType.Int32, restaurantId);
                return Db.ExecuteDataTable(dc);
            }
        }

        public List<OrderListEntity> GetOrderListEntityList(OrderListEntity condition_entity)
        {
            GenericWhereEntity<OrderListEntity> where_entity = new GenericWhereEntity<OrderListEntity>();
            if (condition_entity.LIST_ID != null)
                where_entity.Where(n => (n.LIST_ID == condition_entity.LIST_ID));
            if (condition_entity.ORDER_ID != null)
                where_entity.Where(n => (n.ORDER_ID == condition_entity.ORDER_ID));
            if (condition_entity.FOOD_ID != null)
                where_entity.Where(n => (n.FOOD_ID == condition_entity.FOOD_ID));
            return EntityExecution.SelectAll(where_entity);
        }

        public void InsertOrderListEntity(OrderListEntity condition_entity)
        {
            condition_entity.Insert();
        }

        public void UpdateOrderListEntity(OrderListEntity condition_entity)
        {
            condition_entity.Update();
        }

        public void DeleteOrderListEntity(OrderListEntity condition_entity)
        {
            condition_entity.Delete();
        }


        public OrderListEntity GetOrderListEntity(int? id)
        {
            return EntityExecution.SelectOne<OrderListEntity>(n => n.LIST_ID == id);
        }

        #endregion
        
        //        public DataTable GetTableDataTable(int? restaurantId = null)
        //        {
        //            try
        //            {
        //                string sql = @"SELECT A.*,B.RESTAURANT_NAME FROM [TABLE] A
        //                                LEFT JOIN RESTAURANT B ON A.RESTAURANT_ID = B.RESTAURANT_ID
        //                                WHERE 1=1 ";
        //                if (restaurantId != null)
        //                    sql += " AND B.RESTAURANT_ID = @RESTAURANT_ID ";
        //                using (DbCommand dc = Db.GetSqlStringCommand(sql))
        //                {
        //                    if (restaurantId != null)
        //                        Db.AddInParameter(dc, "@RESTAURANT_ID", DbType.AnsiString, restaurantId);
        //                    return Db.ExecuteDataTable(dc);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                throw new DianDaoException("获取菜品类型的数据出错！", ex);
        //            }
        //        }

    }
}
