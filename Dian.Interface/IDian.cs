using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using CSN.DotNetLibrary.EntityExpressions.Entitys;
using Dian.Common.Entity;
namespace Dian.Common.Interface
{
    public interface IDian:IAppBizAvailableV2
    {
        DataTable GetDianDataTable();
        void InsertDianEntity(DianEntity condition_entity);
        void UpdateDianEntity(DianEntity condition_entity);
        void DeleteDianEntity(DianEntity condition_entity);
    }
}
