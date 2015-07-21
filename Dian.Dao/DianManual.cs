using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Dian.Common.Entity;
namespace Dian.Dao
{
    public class DianManual
    {
        #region 属性
        protected CSN.DotNetLibrary.Data.Database _db = null;
        protected virtual CSN.DotNetLibrary.Data.Database db
        {
            get
            {
                if (_db == null)
                {
                    _db = CSN.DotNetLibrary.Data.DatabaseFactory.CreateDatabase();
                }
                return _db;
            }
        }
        #endregion

        public DataTable GetRestaurantDataTable(string employeeId = "")
        {
            try
            {
                string sql = @"
                    SELECT DISTINCT A.* FROM RESTAURANT A
                    LEFT JOIN EMPLOYEE B ON A.RESTAURANT_ID = B.RESTAURANT_ID
                    WHERE 1=1 ";
                if (!string.IsNullOrEmpty(employeeId))
                    sql += " AND b.EMPLOYEE_ID = @EMPLOYEE_ID ";
                using (DbCommand dc = db.GetSqlStringCommand(sql))
                {
                    if (!string.IsNullOrEmpty(employeeId))
                        db.AddInParameter(dc, "@EMPLOYEE_ID", DbType.AnsiString, employeeId);
                    return db.ExecuteDataTable(dc);
                }
            }
            catch (Exception ex)
            {
                throw new DianDaoException("获取店家的数据出错！", ex);
            }
        }

        public DataTable GetFoodDataTable(int? restaurantId = null)
        {
            try
            {
                string sql = @"SELECT A.*,B.FOOD_TYPE_NAME,C.RESTAURANT_NAME FROM FOOD A
                                LEFT JOIN FOOD_TYPE B ON A.FOOD_TYPE_ID = B.FOOD_TYPE_ID
                                LEFT JOIN RESTAURANT C ON A.RESTAURANT_ID = C.RESTAURANT_ID
                                WHERE 1=1 ";
                if (restaurantId != null)
                    sql += " AND c.RESTAURANT_ID = @RESTAURANT_ID ";
                using (DbCommand dc = db.GetSqlStringCommand(sql))
                {
                    if (restaurantId != null)
                        db.AddInParameter(dc, "@RESTAURANT_ID", DbType.Int32, restaurantId);
                    return db.ExecuteDataTable(dc);
                }
            }
            catch (Exception ex)
            {
                throw new DianDaoException("获取菜品的数据出错！", ex);
            }
        }

        public DataTable GetFoodTypeDataTable(int? restaurantId = null)
        {
            try
            {
                string sql = @"SELECT A.*,B.RESTAURANT_NAME FROM FOOD_TYPE A
                                LEFT JOIN RESTAURANT B ON A.RESTAURANT_ID = B.RESTAURANT_ID
                                WHERE 1=1 ";
                if (restaurantId != null)
                    sql += " AND B.RESTAURANT_ID = @RESTAURANT_ID ";
                using (DbCommand dc = db.GetSqlStringCommand(sql))
                {
                    if (restaurantId != null)
                        db.AddInParameter(dc, "@RESTAURANT_ID", DbType.Int32, restaurantId);
                    return db.ExecuteDataTable(dc);
                }
            }
            catch (Exception ex)
            {
                throw new DianDaoException("获取菜品类型的数据出错！", ex);
            }
        }

        public DataTable GetEmployeeDataTable()
        {
            try
            {
                string sql = @"SELECT A.*,B.RESTAURANT_NAME FROM EMPLOYEE A 
                                LEFT JOIN RESTAURANT B ON A.RESTAURANT_ID = B.RESTAURANT_ID WHERE 1=1 ";
                using (DbCommand dc = db.GetSqlStringCommand(sql))
                {
                    return db.ExecuteDataTable(dc);
                }
            }
            catch (Exception ex)
            {
                throw new DianDaoException("获取用户的数据出错！", ex);
            }
        }

        public DataTable GetOrderMainDataTable(int? restaurantId = null, string type = null)
        {
            try
            {
                string sql = @"SELECT A.*,B.RESTAURANT_NAME,
                                ISNULL(C.ALLORDER,0) ALLORDER,
                                ISNULL(D.FINISH,0) FINISH,
                                ISNULL(E.CONFIRM,0) CONFIRM,
                                ISNULL(F.UNCONFIRM,0) UNCONFIRM 
                                FROM ORDERMAIN2 A
                                LEFT JOIN RESTAURANT B ON A.RESTAURANT_ID = B.RESTAURANT_ID
                                LEFT JOIN (SELECT ORDER_ID,SUM([COUNT]) ALLORDER FROM ORDERLIST2
			                                WHERE (CANCEL_TIME = '' OR CANCEL_TIME IS NULL) 
			                                GROUP BY ORDER_ID) C ON A.ORDER_ID = C.ORDER_ID
                                LEFT JOIN (SELECT ORDER_ID,SUM([COUNT]) FINISH FROM ORDERLIST2
			                                WHERE (CANCEL_TIME = '' OR CANCEL_TIME IS NULL) 
			                                AND (FINISH_TIME <> '' AND FINISH_TIME IS NOT NULL) 
			                                GROUP BY ORDER_ID) D ON A.ORDER_ID = D.ORDER_ID
                                LEFT JOIN (SELECT ORDER_ID,SUM([COUNT]) CONFIRM FROM ORDERLIST2
			                                WHERE (CANCEL_TIME = '' OR CANCEL_TIME IS NULL) 
			                                AND (CONFIRM_TIME <> '' AND CONFIRM_TIME IS NOT NULL) 
			                                AND (FINISH_TIME = '' OR FINISH_TIME IS NULL) 
			                                GROUP BY ORDER_ID) E ON A.ORDER_ID = E.ORDER_ID
                                LEFT JOIN (SELECT ORDER_ID,SUM([COUNT]) UNCONFIRM FROM ORDERLIST2
			                                WHERE (CANCEL_TIME = '' OR CANCEL_TIME IS NULL) 
			                                AND (CONFIRM_TIME = '' OR CONFIRM_TIME IS NULL) 
			                                AND (FINISH_TIME = '' OR FINISH_TIME IS NULL) 
			                                GROUP BY ORDER_ID) F ON A.ORDER_ID = F.ORDER_ID
                                WHERE 1=1 ";
                if (restaurantId != null)
                    sql += " AND B.RESTAURANT_ID = @RESTAURANT_ID ";
                if (!string.IsNullOrEmpty(type))
                    sql += " AND A.ORDER_FLAG = @ORDER_FLAG ";
                using (DbCommand dc = db.GetSqlStringCommand(sql))
                {
                    if (restaurantId != null)
                        db.AddInParameter(dc, "@RESTAURANT_ID", DbType.Int32, restaurantId);
                    if (!string.IsNullOrEmpty(type))
                        db.AddInParameter(dc, "@ORDER_FLAG", DbType.AnsiString, type);
                    return db.ExecuteDataTable(dc);
                }
            }
            catch (Exception ex)
            {
                throw new DianDaoException("获取订单的数据出错！", ex);
            }
        }

        public DataTable GetOrderListDataTable(int? restaurantId = null)
        {
            try
            {
                string sql = @"SELECT A.*,C.RESTAURANT_NAME,D.FOOD_NAME FROM ORDERLIST2 A
                                LEFT JOIN ORDERMAIN2 B ON A.ORDER_ID = B.ORDER_ID
                                LEFT JOIN RESTAURANT C ON B.RESTAURANT_ID = C.RESTAURANT_ID
                                LEFT JOIN FOOD D ON A.FOOD_ID = D.FOOD_ID
                                WHERE 1=1 ";
                if (restaurantId != null)
                    sql += " AND C.RESTAURANT_ID = @RESTAURANT_ID ";
                using (DbCommand dc = db.GetSqlStringCommand(sql))
                {
                    if (restaurantId != null)
                        db.AddInParameter(dc, "@RESTAURANT_ID", DbType.Int32, restaurantId);
                    return db.ExecuteDataTable(dc);
                }
            }
            catch (Exception ex)
            {
                throw new DianDaoException("获取订单列表的数据出错！", ex);
            }
        }

        public DataTable GetOrderData(int orderId)
        {
            string sql = @"SELECT A.*,B.FOOD_NAME FROM ORDERLIST2 A 
                            LEFT JOIN FOOD B ON A.FOOD_ID = B.FOOD_ID 
                            WHERE  (CANCEL_TIME = '' OR CANCEL_TIME IS NULL)  
                            AND A.ORDER_ID = @ORDER_ID ";
            using (DbCommand dc = db.GetSqlStringCommand(sql))
            {
                db.AddInParameter(dc, "@ORDER_ID", DbType.Int32, orderId);
                return db.ExecuteDataTable(dc);
            }
        }

        public DataTable GetUnConfirmOrderData(int orderId, int? foodId = null)
        {
            string sql = @"SELECT A.*,B.FOOD_NAME FROM ORDERLIST2 A 
                            LEFT JOIN FOOD B ON A.FOOD_ID = B.FOOD_ID 
                            WHERE (CANCEL_TIME = '' OR CANCEL_TIME IS NULL) 
                            AND (CONFIRM_TIME = '' OR CONFIRM_TIME IS NULL) 
                            AND (FINISH_TIME = '' OR FINISH_TIME IS NULL) 
                            AND A.ORDER_ID = @ORDER_ID ";
            if (foodId != null)
                sql += " AND A.FOOD_ID = @FOOD_ID ";
            using (DbCommand dc = db.GetSqlStringCommand(sql))
            {
                db.AddInParameter(dc, "@ORDER_ID", DbType.Int32, orderId);
                if (foodId != null)
                    db.AddInParameter(dc, "@FOOD_ID", DbType.Int32, foodId);
                return db.ExecuteDataTable(dc);
            }
        }

        public void BatchProcessOrder(int orderId, string opreation)
        {
            string sql = "UPDATE ORDERLIST2 SET {0} = CONVERT(varchar(100), GETDATE(), 120) WHERE ORDER_ID = @ORDER_ID AND ({0} IS NULL OR {0} = '')";
            if (opreation == "confirmall")
                sql = string.Format(sql, "CONFIRM_TIME");
            if (opreation == "finishall")
            {
                sql = string.Format(sql, "FINISH_TIME");
                sql += " AND (CONFIRM_TIME IS NOT NULL AND CONFIRM_TIME <> '') ";
            }
            using (DbCommand dc = db.GetSqlStringCommand(sql))
            {
                db.AddInParameter(dc, "@ORDER_ID", DbType.Int32, orderId);
                db.ExecuteNonQuery(dc);
            }
        }


        //        public DataTable GetTableDataTable(int? restaurantId = null)
        //        {
        //            try
        //            {
        //                string sql = @"SELECT A.*,B.RESTAURANT_NAME FROM [TABLE] A
        //                                LEFT JOIN RESTAURANT B ON A.RESTAURANT_ID = B.RESTAURANT_ID
        //                                WHERE 1=1 ";
        //                if (restaurantId != null)
        //                    sql += " AND B.RESTAURANT_ID = @RESTAURANT_ID ";
        //                using (DbCommand dc = db.GetSqlStringCommand(sql))
        //                {
        //                    if (restaurantId != null)
        //                        db.AddInParameter(dc, "@RESTAURANT_ID", DbType.AnsiString, restaurantId);
        //                    return db.ExecuteDataTable(dc);
        //                }
        //            }
        //            catch (Exception ex)
        //            {
        //                throw new DianDaoException("获取菜品类型的数据出错！", ex);
        //            }
        //        }

    }
}
