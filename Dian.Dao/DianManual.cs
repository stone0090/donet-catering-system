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

        public DataTable GetRestaurantDataTable()
        {
            try
            {
                string sql = @"SELECT * FROM RESTAURANT WHERE 1=1 ";
                DbCommand dc = db.GetSqlStringCommand(sql);

                return db.ExecuteDataTable(dc);
            }
            catch (Exception ex)
            {

                throw new DianDaoException("获取店家的数据出错！", ex);
            }
        }
        public DataTable GetFoodDataTable()
        {
            try
            {
                string sql = @"SELECT A.*,B.FOOD_TYPE_NAME,C.RESTAURANT_NAME FROM FOOD A
                                LEFT JOIN FOOD_TYPE B ON A.FOOD_TYPE_ID = B.FOOD_TYPE_ID
                                LEFT JOIN RESTAURANT C ON A.RESTAURANT_ID = C.RESTAURANT_ID
                                WHERE 1=1 ";
                DbCommand dc = db.GetSqlStringCommand(sql);

                return db.ExecuteDataTable(dc);
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

                throw new DianDaoException("获取菜品的数据出错！", ex);
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

                throw new DianDaoException("获取员工的数据出错！", ex);
            }
        }
    }
}
