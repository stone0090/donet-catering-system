using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Dian.Entity;
using Dian.Interface;

using DoNet.Utility.Database;
using DoNet.Utility.Database.EntitySql;
using DoNet.Utility.Database.EntitySql.Entity;

namespace Dian.Biz
{
    public class RestaurantBiz : System.MarshalByRefObject, IRestaurant
    {
        private DbHelper _db;
        private DbHelper Db
        {
            get { return _db ?? (_db = DbFactory.CreateDatabase()); }
        }

        public DataTable GetRestaurantDataTable(string employeeId = "")
        {
            string sql = @"
                    SELECT DISTINCT A.* FROM RESTAURANT A
                    LEFT JOIN EMPLOYEE B ON A.RESTAURANT_ID = B.RESTAURANT_ID
                    WHERE 1=1 ";
            if (!string.IsNullOrEmpty(employeeId))
                sql += " AND b.EMPLOYEE_ID = @EMPLOYEE_ID ";
            using (DbCommand dc = Db.GetSqlStringCommand(sql))
            {
                if (!string.IsNullOrEmpty(employeeId))
                    Db.AddInParameter(dc, "@EMPLOYEE_ID", DbType.AnsiString, employeeId);
                return Db.ExecuteDataTable(dc);
            }
        }
        public List<RestaurantEntity> GetRestaurantEntityList(RestaurantEntity condition_entity)
        {
            GenericWhereEntity<RestaurantEntity> where_entity = new GenericWhereEntity<RestaurantEntity>();
            if (condition_entity.RESTAURANT_ID != null)
                where_entity.Where(n => (n.RESTAURANT_ID == condition_entity.RESTAURANT_ID));
            if (condition_entity.RESTAURANT_NAME != null)
                where_entity.Where(n => (n.RESTAURANT_NAME == condition_entity.RESTAURANT_NAME));
            return EntityExecution.SelectAll(where_entity);
        }
        public void InsertRestaurantEntity(RestaurantEntity condition_entity)
        {
            condition_entity.Insert();
        }
        public void UpdateRestaurantEntity(RestaurantEntity condition_entity)
        {
            condition_entity.Update();
        }
        public void DeleteRestaurantEntity(RestaurantEntity condition_entity)
        {
            condition_entity.Delete();
        }
        public RestaurantEntity GetRestaurantEntity(int? id)
        {
            return EntityExecution.SelectOne<RestaurantEntity>(n => n.RESTAURANT_ID == id);
        }
    }
}
