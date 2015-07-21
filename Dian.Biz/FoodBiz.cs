using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Dian.Common.Entity;
using Dian.Common.Interface;
using Dian.Dao;
using CSN.DotNetLibrary.EntityExpressions.Entitys;

namespace Dian.Biz
{
    public class FoodBiz : System.MarshalByRefObject, IFood
    {
        private DianManual _manual_dao = null;
        public DianManual manual_dao
        {
            get
            {
                return _manual_dao == null ? _manual_dao = new DianManual() : _manual_dao;
            }
        }

        public DataTable GetFoodDataTable(int? restaurantId = null)
        {
            return manual_dao.GetFoodDataTable(restaurantId);
        }
        public List<FoodEntity> GetFoodEntityList(FoodEntity condition_entity)
        {
            GenericWhereEntity<FoodEntity> where_entity = new GenericWhereEntity<FoodEntity>();
            if (condition_entity.FOOD_ID != null)
                where_entity.Where(n => (n.FOOD_ID == condition_entity.FOOD_ID));
            if (condition_entity.RESTAURANT_ID != null)
                where_entity.Where(n => (n.RESTAURANT_ID == condition_entity.RESTAURANT_ID));
            return DianDao.ReadEntityList(where_entity);
        }
        public void InsertFoodEntity(FoodEntity condition_entity)
        {
            DianDao.InsertEntity(condition_entity);
        }
        public void UpdateFoodEntity(FoodEntity condition_entity)
        {
            DianDao.UpdateEntity(condition_entity);
        }
        public void DeleteFoodEntity(FoodEntity condition_entity)
        {
            DianDao.DeleteEntity(condition_entity);
        }
        public FoodEntity GetFoodEntity(int? id)
        {
            return DianDao.ReadEntity2<FoodEntity>(n => n.FOOD_ID == id);
        }

        public int TestCallAble()
        {
            throw new NotImplementedException();
        }
    }
}
