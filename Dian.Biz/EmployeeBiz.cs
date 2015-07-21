using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dian.Common.Entity;
using Dian.Common.Interface;
using Dian.Dao;
using CSN.DotNetLibrary.EntityExpressions.Entitys;
namespace Dian.Biz
{
    public class EmployeeBiz : System.MarshalByRefObject, IEmployee
    {
        private DianManual _manual_dao = null;
        public DianManual manual_dao
        {
            get
            {
                return _manual_dao == null ? _manual_dao = new DianManual() : _manual_dao;
            }
        }

        public DataTable GetEmployeesDataTable()
        {
                return manual_dao.GetEmployeeDataTable();
        }
        public List<EmployeeEntity> GetEmployeeEntityList(EmployeeEntity condition_entity)
        {
                GenericWhereEntity<EmployeeEntity> where_entity = new GenericWhereEntity<EmployeeEntity>();
                if (condition_entity.EMPLOYEE_ID != null)
                    where_entity.Where(n => (n.EMPLOYEE_ID == condition_entity.EMPLOYEE_ID));
                if (!string.IsNullOrEmpty(condition_entity.PASSWORD))
                    where_entity.Where(n => (n.PASSWORD == condition_entity.PASSWORD));
                return DianDao.ReadEntityList(where_entity);
        }
        public void InsertEmployeeEntity(EmployeeEntity condition_entity)
        {
                DianDao.InsertEntity(condition_entity);
        }
        public void UpdateEmployeeEntity(EmployeeEntity condition_entity)
        {
                DianDao.UpdateEntity(condition_entity);
        }
        public void DeleteEmployeeEntity(EmployeeEntity condition_entity)
        {
                DianDao.DeleteEntity(condition_entity);
        }
        public EmployeeEntity GetEmployeeEntity(string id)
        {
            var entity = DianDao.ReadEntity2<EmployeeEntity>(n => n.EMPLOYEE_ID == id);
            var restaurantEntity = new RestaurantBiz().GetRestaurantEntity(entity.RESTAURANT_ID);
            if(restaurantEntity!=null)
                entity.RESTAURANT_NAME = restaurantEntity.RESTAURANT_NAME;
            return entity;
        }

        public int TestCallAble()
        {
            throw new NotImplementedException();
        }
    }
}
