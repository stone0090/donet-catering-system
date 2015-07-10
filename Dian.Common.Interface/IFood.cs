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
    public interface IFood : IAppBizAvailableV2
    {
        DataTable GetFoodDataTable();
        List<FoodEntity> GetFoodEntityList(FoodEntity condition_entity);
        void InsertFoodEntity(FoodEntity condition_entity);
        void UpdateFoodEntity(FoodEntity condition_entity);
        void DeleteFoodEntity(FoodEntity condition_entity);
        FoodEntity GetFoodEntity(int? id);
    }
}
