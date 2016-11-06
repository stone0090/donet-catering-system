using System.Collections.Generic;
using System.Data;
using Dian.Entity;

namespace Dian.Interface
{
    public interface IFood 
    {
        DataTable GetFoodDataTable(int? restaurantId = null);
        List<FoodEntity> GetFoodEntityList(FoodEntity condition_entity);
        void InsertFoodEntity(FoodEntity condition_entity);
        void UpdateFoodEntity(FoodEntity condition_entity);
        void DeleteFoodEntity(FoodEntity condition_entity);
        FoodEntity GetFoodEntity(int? id);
    }
}
