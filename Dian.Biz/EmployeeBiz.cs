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
    public class EmployeeBiz : System.MarshalByRefObject, IEmployee
    {
        private DbHelper _db;
        private DbHelper Db
        {
            get { return _db ?? (_db = DbFactory.CreateDatabase()); }
        }

        public DataTable GetEmployeeDataTable()
        {
            string sql = @"SELECT A.*,B.RESTAURANT_NAME FROM EMPLOYEE A 
                                LEFT JOIN RESTAURANT B ON A.RESTAURANT_ID = B.RESTAURANT_ID WHERE 1=1 ";
            using (DbCommand dc = Db.GetSqlStringCommand(sql))
            {
                return Db.ExecuteDataTable(dc);
            }
        }
        public List<EmployeeEntity> GetEmployeeEntityList(EmployeeEntity condition_entity)
        {
            GenericWhereEntity<EmployeeEntity> where_entity = new GenericWhereEntity<EmployeeEntity>();
            if (condition_entity.EMPLOYEE_ID != null)
                where_entity.Where(n => (n.EMPLOYEE_ID == condition_entity.EMPLOYEE_ID));
            if (!string.IsNullOrEmpty(condition_entity.PASSWORD))
                where_entity.Where(n => (n.PASSWORD == condition_entity.PASSWORD));
            return EntityExecution.SelectAll(where_entity);
        }
        public void InsertEmployeeEntity(EmployeeEntity condition_entity)
        {
            condition_entity.Insert();
        }
        public void UpdateEmployeeEntity(EmployeeEntity condition_entity)
        {
            condition_entity.Update();
        }
        public void DeleteEmployeeEntity(EmployeeEntity condition_entity)
        {
            condition_entity.Delete();
        }
        public EmployeeEntity GetEmployeeEntity(string id)
        {
            var entity = EntityExecution.SelectOne<EmployeeEntity>(n => n.EMPLOYEE_ID == id);
            var restaurantEntity = new RestaurantBiz().GetRestaurantEntity(entity.RESTAURANT_ID);
            if (restaurantEntity != null)
                entity.RESTAURANT_NAME = restaurantEntity.RESTAURANT_NAME;
            return entity;
        }
        
    }
}
