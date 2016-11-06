using Dian.Entity;
using System.Collections.Generic;
using System.Data;

namespace Dian.Interface
{
    public interface IRestaurant
    {
        DataTable GetRestaurantDataTable(string employeeId = "");
        List<RestaurantEntity> GetRestaurantEntityList(RestaurantEntity condition_entity);
        void InsertRestaurantEntity(RestaurantEntity condition_entity);
        void UpdateRestaurantEntity(RestaurantEntity condition_entity);
        void DeleteRestaurantEntity(RestaurantEntity condition_entity);
        RestaurantEntity GetRestaurantEntity(int? id);
    }
}
