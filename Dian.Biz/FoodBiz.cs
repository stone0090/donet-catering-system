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
    public class FoodBiz : System.MarshalByRefObject, IFood
    {
        private DbHelper _db;
        private DbHelper Db
        {
            get { return _db ?? (_db = DbFactory.CreateDatabase()); }
        }

        public DataTable GetFoodDataTable(int? restaurantId = null)
        {
            string sql = @"SELECT A.*,B.FOOD_TYPE_NAME,C.RESTAURANT_NAME FROM FOOD A
                                LEFT JOIN FOOD_TYPE B ON A.FOOD_TYPE_ID = B.FOOD_TYPE_ID
                                LEFT JOIN RESTAURANT C ON A.RESTAURANT_ID = C.RESTAURANT_ID
                                WHERE 1=1 ";
            if (restaurantId != null)
                sql += " AND c.RESTAURANT_ID = @RESTAURANT_ID ";
            using (DbCommand dc = Db.GetSqlStringCommand(sql))
            {
                if (restaurantId != null)
                    Db.AddInParameter(dc, "@RESTAURANT_ID", DbType.Int32, restaurantId);
                return Db.ExecuteDataTable(dc);
            }
        }
        public List<FoodEntity> GetFoodEntityList(FoodEntity condition_entity)
        {
            GenericWhereEntity<FoodEntity> where_entity = new GenericWhereEntity<FoodEntity>();
            if (condition_entity.FOOD_ID != null)
                where_entity.Where(n => (n.FOOD_ID == condition_entity.FOOD_ID));
            if (condition_entity.RESTAURANT_ID != null)
                where_entity.Where(n => (n.RESTAURANT_ID == condition_entity.RESTAURANT_ID));
            return EntityExecution.SelectAll(where_entity);
        }
        public void InsertFoodEntity(FoodEntity condition_entity)
        {
            condition_entity.Insert();
        }
        public void UpdateFoodEntity(FoodEntity condition_entity)
        {
            condition_entity.Update();
        }
        public void DeleteFoodEntity(FoodEntity condition_entity)
        {
            condition_entity.Delete();
        }
        public FoodEntity GetFoodEntity(int? id)
        {
            return EntityExecution.SelectOne<FoodEntity>(n => n.FOOD_ID == id);
        }
    }
}
