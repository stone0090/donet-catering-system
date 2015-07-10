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
    public class RestaurantBiz : System.MarshalByRefObject, IRestaurant
    {
        private DianManual _manual_dao = null;
        public DianManual manual_dao
        {
            get
            {
                return _manual_dao == null ? _manual_dao = new DianManual() : _manual_dao;
            }
        }

        public DataTable GetRestaurantDataTable()
        {
            try
            {
                return manual_dao.GetRestaurantDataTable();
            }
            catch (Exception ex)
            {

                throw new DianBizException("获取店的数据出错！", ex);
            }
        }
        public List<RestaurantEntity> GetRestaurantEntityList(RestaurantEntity condition_entity)
        {
            try
            {
                GenericWhereEntity<RestaurantEntity> where_entity = new GenericWhereEntity<RestaurantEntity>();
                if (condition_entity.RESTAURANT_ID != null)
                    where_entity.Where(n => (n.RESTAURANT_ID == condition_entity.RESTAURANT_ID));
                if (condition_entity.RESTAURANT_NAME != null)
                    where_entity.Where(n => (n.RESTAURANT_NAME == condition_entity.RESTAURANT_NAME));
                return DianDao.ReadEntityList(where_entity);
            }
            catch (Exception ex)
            {
                throw new DianBizException("获取店数据出错！", ex);
            }
        }
        public void InsertRestaurantEntity(RestaurantEntity condition_entity)
        {
            try
            {
                DianDao.InsertEntity(condition_entity);
            }
            catch (Exception ex)
            {

                throw new DianBizException("插入店数据出错！", ex);
            }

        }
        public void UpdateRestaurantEntity(RestaurantEntity condition_entity)
        {
            try
            {
                DianDao.UpdateEntity(condition_entity);
            }
            catch (Exception ex)
            {

                throw new DianBizException("更新店数据出错！", ex);
            }

        }
        public void DeleteRestaurantEntity(RestaurantEntity condition_entity)
        {
            try
            {
                DianDao.DeleteEntity(condition_entity);
            }
            catch (Exception ex)
            {

                throw new DianBizException("删除店数据出错！", ex);
            }

        }
        public RestaurantEntity GetRestaurantEntity(int? id)
        {
            return DianDao.ReadEntity2<RestaurantEntity>(n => n.RESTAURANT_ID == id);
        }

        public int TestCallAble()
        {
            throw new NotImplementedException();
        }
    }
}
