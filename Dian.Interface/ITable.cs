using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//using System.Threading.Tasks;
using System.Data;
using CSN.DotNetLibrary.EntityExpressions.Entitys;
using Dian.Common.Entity;
namespace Dian.Common.Interface
{
    public interface ITable : IAppBizAvailableV2
    {
        DataTable GetTableDataTable(int? restaurantId = null);
        List<TableEntity> GetTableEntityList(TableEntity condition_entity);
        void InsertTableEntity(TableEntity condition_entity);
        void UpdateTableEntity(TableEntity condition_entity);
        void DeleteTableEntity(TableEntity condition_entity);
        TableEntity GetTableEntity(int? id);
    }
}
