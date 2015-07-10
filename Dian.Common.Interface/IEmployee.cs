using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using CSN.DotNetLibrary.EntityExpressions.Entitys;
using Dian.Common.Entity;
namespace Dian.Common.Interface
{
    public interface IEmployee : IAppBizAvailableV2
    {
        DataTable GetEmployeesDataTable();
        List<EmployeeEntity> GetEmployeeEntityList(EmployeeEntity condition_entity);
        void InsertEmployeeEntity(EmployeeEntity condition_entity);
        void UpdateEmployeeEntity(EmployeeEntity condition_entity);
        void DeleteEmployeeEntity(EmployeeEntity condition_entity);
        EmployeeEntity GetEmployeeEntity(string id);
    }
}
