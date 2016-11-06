using System.Collections.Generic;
using System.Data;
using Dian.Entity;

namespace Dian.Interface
{
    public interface IFoodType 
    {
        DataTable GetFoodTypeDataTable(int? restaurantId = null);
        List<FoodTypeEntity> GetFoodTypeEntityList(FoodTypeEntity condition_entity);
        void InsertFoodTypeEntity(FoodTypeEntity condition_entity);
        void UpdateFoodTypeEntity(FoodTypeEntity condition_entity);
        void DeleteFoodTypeEntity(FoodTypeEntity condition_entity);
        FoodTypeEntity GetFoodTypeEntity(int? id);
    }
}
