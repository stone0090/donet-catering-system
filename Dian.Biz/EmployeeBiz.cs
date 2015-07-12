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
            try
            {
                return manual_dao.GetEmployeeDataTable();
            }
            catch (Exception ex)
            {

                throw new DianBizException("获取用户的数据出错！", ex);
            }
        }
        public List<EmployeeEntity> GetEmployeeEntityList(EmployeeEntity condition_entity)
        {
            try
            {
                GenericWhereEntity<EmployeeEntity> where_entity = new GenericWhereEntity<EmployeeEntity>();
                if (condition_entity.EMPLOYEE_ID != null)
                    where_entity.Where(n => (n.EMPLOYEE_ID == condition_entity.EMPLOYEE_ID));
                if (!string.IsNullOrEmpty(condition_entity.PASSWORD))
                    where_entity.Where(n => (n.PASSWORD == condition_entity.PASSWORD));
                return DianDao.ReadEntityList(where_entity);
            }
            catch (Exception ex)
            {
                throw new DianBizException("获取用户的数据出错！", ex);
            }
        }
        public void InsertEmployeeEntity(EmployeeEntity condition_entity)
        {
            try
            {
                DianDao.InsertEntity(condition_entity);
            }
            catch (Exception ex)
            {
                throw new DianBizException("插入用户的数据出错！", ex);
            }

        }
        public void UpdateEmployeeEntity(EmployeeEntity condition_entity)
        {
            try
            {
                DianDao.UpdateEntity(condition_entity);
            }
            catch (Exception ex)
            {

                throw new DianBizException("更新用户的数据出错！", ex);
            }

        }
        public void DeleteEmployeeEntity(EmployeeEntity condition_entity)
        {
            try
            {
                DianDao.DeleteEntity(condition_entity);
            }
            catch (Exception ex)
            {

                throw new DianBizException("删除用户的数据出错！", ex);
            }

        }
        public EmployeeEntity GetEmployeeEntity(string id)
        {
            return DianDao.ReadEntity2<EmployeeEntity>(n => n.EMPLOYEE_ID == id);
        }

        public int TestCallAble()
        {
            throw new NotImplementedException();
        }
    }
}
