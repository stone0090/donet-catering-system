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
                        db.AddInParameter(dc, "@RESTAURANT_ID", DbType.AnsiString, restaurantId);
                    return db.ExecuteDataTable(dc);
                }
            }
            catch (Exception ex)
            {
                throw new DianDaoException("获取菜品的数据出错！", ex);
            }
        }

        public DataTable GetFoodTypeDataTable()
        {
            try
            {
                string sql = @"SELECT * FROM FOOD_TYPE WHERE 1=1 ";
                DbCommand dc = db.GetSqlStringCommand(sql);

                return db.ExecuteDataTable(dc);
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
                DbCommand dc = db.GetSqlStringCommand(sql);

                return db.ExecuteDataTable(dc);
            }
            catch (Exception ex)
            {
                throw new DianDaoException("获取用户的数据出错！", ex);
            }
        }

        public DataTable GetOrderMainDataTable()
        {
            try
            {
                string sql = @"SELECT * FROM ORDERMAIN2 WHERE 1=1 ";
                DbCommand dc = db.GetSqlStringCommand(sql);
                return db.ExecuteDataTable(dc);
            }
            catch (Exception ex)
            {
                throw new DianDaoException("获取订单的数据出错！", ex);
            }
        }

        public DataTable GetOrderListDataTable()
        {
            try
            {
                string sql = @"SELECT * FROM ORDERLIST2 WHERE 1=1 ";
                DbCommand dc = db.GetSqlStringCommand(sql);
                return db.ExecuteDataTable(dc);
            }
            catch (Exception ex)
            {
                throw new DianDaoException("获取订单列表的数据出错！", ex);
            }
        }

    }
}
