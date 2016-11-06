using System.Collections.Generic;
using System.Data;
using Dian.Entity;

namespace Dian.Interface
{
    public interface IEmployee
    {
        DataTable GetEmployeeDataTable();
        List<EmployeeEntity> GetEmployeeEntityList(EmployeeEntity condition_entity);
        void InsertEmployeeEntity(EmployeeEntity condition_entity);
        void UpdateEmployeeEntity(EmployeeEntity condition_entity);
        void DeleteEmployeeEntity(EmployeeEntity condition_entity);
        EmployeeEntity GetEmployeeEntity(string id);
    }
}
