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
    public interface IFoodType : IAppBizAvailableV2
    {
        DataTable GetFoodTypeDataTable(int? restaurantId = null);
        List<FoodTypeEntity> GetFoodTypeEntityList(FoodTypeEntity condition_entity);
        void InsertFoodTypeEntity(FoodTypeEntity condition_entity);
        void UpdateFoodTypeEntity(FoodTypeEntity condition_entity);
        void DeleteFoodTypeEntity(FoodTypeEntity condition_entity);
        FoodTypeEntity GetFoodTypeEntity(int? id);
    }
}
