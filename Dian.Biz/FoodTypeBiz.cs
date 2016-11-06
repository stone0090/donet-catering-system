using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Common;
using Dian.Entity;
using Dian.Interface;

using DoNet.Utility.Database;
using DoNet.Utility.Database.EntitySql;
using DoNet.Utility.Database.EntitySql.Entity;

namespace Dian.Biz
{
    public class FoodTypeBiz : System.MarshalByRefObject, IFoodType
    {
        private DbHelper _db;
        private DbHelper Db
        {
            get { return _db ?? (_db = DbFactory.CreateDatabase()); }
        }
        
        public DataTable GetFoodTypeDataTable(int? restaurantId = null)
        {
            string sql = @"SELECT A.*,B.RESTAURANT_NAME FROM FOOD_TYPE A
                                LEFT JOIN RESTAURANT B ON A.RESTAURANT_ID = B.RESTAURANT_ID
                                WHERE 1=1 ";
            if (restaurantId != null)
                sql += " AND B.RESTAURANT_ID = @RESTAURANT_ID ";
            using (DbCommand dc = Db.GetSqlStringCommand(sql))
            {
                if (restaurantId != null)
                    Db.AddInParameter(dc, "@RESTAURANT_ID", DbType.Int32, restaurantId);
                return Db.ExecuteDataTable(dc);
            }
        }
        public List<FoodTypeEntity> GetFoodTypeEntityList(FoodTypeEntity condition_entity)
        {
            GenericWhereEntity<FoodTypeEntity> where_entity = new GenericWhereEntity<FoodTypeEntity>();
            if (condition_entity.FOOD_TYPE_ID != null)
                where_entity.Where(n => (n.FOOD_TYPE_ID == condition_entity.FOOD_TYPE_ID));
            if (condition_entity.FOOD_TYPE_NAME != null)
                where_entity.Where(n => (n.FOOD_TYPE_NAME == condition_entity.FOOD_TYPE_NAME));
            return EntityExecution.SelectAll(where_entity);
        }
        public void InsertFoodTypeEntity(FoodTypeEntity condition_entity)
        {
            condition_entity.Insert();
        }
        public void UpdateFoodTypeEntity(FoodTypeEntity condition_entity)
        {
            condition_entity.Update();
        }
        public void DeleteFoodTypeEntity(FoodTypeEntity condition_entity)
        {
            condition_entity.Delete();
        }
        public FoodTypeEntity GetFoodTypeEntity(int? id)
        {
            return EntityExecution.SelectOne<FoodTypeEntity>(n => n.FOOD_TYPE_ID == id);
        }
    }
}
