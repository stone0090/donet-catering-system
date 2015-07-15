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
    public class OrderBiz : System.MarshalByRefObject, IOrder2
    {
        private DianManual _manual_dao = null;
        public DianManual manual_dao
        {
            get
            {
                return _manual_dao == null ? _manual_dao = new DianManual() : _manual_dao;
            }
        }

        #region 扩展方法

        public void CreateOrder()
        {

        }

        #endregion

        #region  基础方法

        public DataTable GetOrderMainDataTable()
        {
            try
            {
                return manual_dao.GetOrderMainDataTable();
            }
            catch (Exception ex)
            {
                throw new DianBizException("获取订单的数据出错！", ex);
            }
        }

        public List<OrderMainEntity2> GetOrderMainEntityList(OrderMainEntity2 condition_entity)
        {
            try
            {
                GenericWhereEntity<OrderMainEntity2> where_entity = new GenericWhereEntity<OrderMainEntity2>();
                if (condition_entity.ORDER_ID != null)
                    where_entity.Where(n => (n.ORDER_ID == condition_entity.ORDER_ID));
                return DianDao.ReadEntityList(where_entity);
            }
            catch (Exception ex)
            {
                throw new DianBizException("获取订单的数据出错！", ex);
            }
        }

        public void InsertOrderMainEntity(OrderMainEntity2 condition_entity)
        {
            try
            {
                DianDao.InsertEntity(condition_entity);
            }
            catch (Exception ex)
            {
                throw new DianBizException("插入订单数据出错！", ex);
            }
        }

        public void UpdateOrderMainEntity(OrderMainEntity2 condition_entity)
        {
            try
            {
                DianDao.UpdateEntity(condition_entity);
            }
            catch (Exception ex)
            {
                throw new DianBizException("更新订单数据出错！", ex);
            }
        }

        public void DeleteOrderMainEntity(OrderMainEntity2 condition_entity)
        {
            try
            {
                DianDao.DeleteEntity(condition_entity);
            }
            catch (Exception ex)
            {
                throw new DianBizException("删除订单数据出错！", ex);
            }
        }

        public OrderMainEntity2 GetOrderMainEntity(int? id)
        {
            return DianDao.ReadEntity2<OrderMainEntity2>(n => n.ORDER_ID == id);
        }



        public DataTable GetOrderListDataTable()
        {
            try
            {
                return manual_dao.GetOrderListDataTable();
            }
            catch (Exception ex)
            {
                throw new DianBizException("获取订单列表的数据出错！", ex);
            }
        }

        public List<OrderListEntity2> GetOrderListEntityList(OrderListEntity2 condition_entity)
        {
            try
            {
                GenericWhereEntity<OrderListEntity2> where_entity = new GenericWhereEntity<OrderListEntity2>();
                if (condition_entity.ORDER_ID != null)
                    where_entity.Where(n => (n.ORDER_ID == condition_entity.ORDER_ID));
                return DianDao.ReadEntityList(where_entity);
            }
            catch (Exception ex)
            {
                throw new DianBizException("获取订单列表的数据出错！", ex);
            }
        }

        public void InsertOrderListEntity(OrderListEntity2 condition_entity)
        {
            try
            {
                DianDao.InsertEntity(condition_entity);
            }
            catch (Exception ex)
            {
                throw new DianBizException("插入订单列表数据出错！", ex);
            }
        }

        public void UpdateOrderListEntity(OrderListEntity2 condition_entity)
        {
            try
            {
                DianDao.UpdateEntity(condition_entity);
            }
            catch (Exception ex)
            {
                throw new DianBizException("更新订单列表数据出错！", ex);
            }
        }

        public void DeleteOrderListEntity(OrderListEntity2 condition_entity)
        {
            try
            {
                DianDao.DeleteEntity(condition_entity);
            }
            catch (Exception ex)
            {
                throw new DianBizException("删除订单列表数据出错！", ex);
            }
        }

        public OrderListEntity2 GetOrderListEntity(int? id)
        {
            return DianDao.ReadEntity2<OrderListEntity2>(n => n.ORDER_ID == id);
        }

        #endregion

        public int TestCallAble()
        {
            throw new NotImplementedException();
        }
    }
}
