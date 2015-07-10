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
    public interface IRestaurant : IAppBizAvailableV2
    {
        DataTable GetRestaurantDataTable();
        List<RestaurantEntity> GetRestaurantEntityList(RestaurantEntity condition_entity);
        void InsertRestaurantEntity(RestaurantEntity condition_entity);
        void UpdateRestaurantEntity(RestaurantEntity condition_entity);
        void DeleteRestaurantEntity(RestaurantEntity condition_entity);
        RestaurantEntity GetRestaurantEntity(int? id);
    }
}
