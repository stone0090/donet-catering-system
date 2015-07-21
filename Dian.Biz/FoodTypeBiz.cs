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
    public class FoodTypeBiz : System.MarshalByRefObject, IFoodType
    {
        private DianManual _manual_dao = null;
        public DianManual manual_dao
        {
            get
            {
                return _manual_dao == null ? _manual_dao = new DianManual() : _manual_dao;
            }
        }

        public DataTable GetFoodTypeDataTable(int? restaurantId = null)
        {
            return manual_dao.GetFoodTypeDataTable(restaurantId);
        }
        public List<FoodTypeEntity> GetFoodTypeEntityList(FoodTypeEntity condition_entity)
        {
            GenericWhereEntity<FoodTypeEntity> where_entity = new GenericWhereEntity<FoodTypeEntity>();
            if (condition_entity.FOOD_TYPE_ID != null)
                where_entity.Where(n => (n.FOOD_TYPE_ID == condition_entity.FOOD_TYPE_ID));
            if (condition_entity.FOOD_TYPE_NAME != null)
                where_entity.Where(n => (n.FOOD_TYPE_NAME == condition_entity.FOOD_TYPE_NAME));
            return DianDao.ReadEntityList(where_entity);
        }
        public void InsertFoodTypeEntity(FoodTypeEntity condition_entity)
        {
            DianDao.InsertEntity(condition_entity);
        }
        public void UpdateFoodTypeEntity(FoodTypeEntity condition_entity)
        {
            DianDao.UpdateEntity(condition_entity);
        }
        public void DeleteFoodTypeEntity(FoodTypeEntity condition_entity)
        {
            DianDao.DeleteEntity(condition_entity);
        }
        public FoodTypeEntity GetFoodTypeEntity(int? id)
        {
            return DianDao.ReadEntity2<FoodTypeEntity>(n => n.FOOD_TYPE_ID == id);
        }

        public int TestCallAble()
        {
            throw new NotImplementedException();
        }
    }
}
