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
    public class TableBiz : System.MarshalByRefObject, ITable
    {
        private DianManual _manual_dao = null;
        public DianManual manual_dao
        {
            get
            {
                return _manual_dao == null ? _manual_dao = new DianManual() : _manual_dao;
            }
        }

        public DataTable GetTableDataTable(int? restaurantId = null)
        {
            try
            {
                return manual_dao.GetTableDataTable(restaurantId);
            }
            catch (Exception ex)
            {
                throw new DianBizException("获取店的数据出错！", ex);
            }
        }
        public List<TableEntity> GetTableEntityList(TableEntity condition_entity)
        {
            try
            {
                GenericWhereEntity<TableEntity> where_entity = new GenericWhereEntity<TableEntity>();
                if (condition_entity.TABLE_ID != null)
                    where_entity.Where(n => (n.TABLE_ID == condition_entity.TABLE_ID));
                if (condition_entity.RESTAURANT_ID != null)
                    where_entity.Where(n => (n.RESTAURANT_ID == condition_entity.RESTAURANT_ID));
                return DianDao.ReadEntityList(where_entity);
            }
            catch (Exception ex)
            {
                throw new DianBizException("获取店的数据出错！", ex);
            }
        }
        public void InsertTableEntity(TableEntity condition_entity)
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
        public void UpdateTableEntity(TableEntity condition_entity)
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
        public void DeleteTableEntity(TableEntity condition_entity)
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
        public TableEntity GetTableEntity(int? id)
        {
            return DianDao.ReadEntity2<TableEntity>(n => n.TABLE_ID == id);
        }

        public int TestCallAble()
        {
            throw new NotImplementedException();
        }
    }
}
