using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Dian.Common.Entity;
using Dian.Common.Interface;
using Dian.Dao;
namespace Dian.Biz
{
    public class DianBiz : System.MarshalByRefObject,IMain
    {
        public DataTable GetDianDataTable()
        {
            try
            {
                return null;
            }
            catch (Exception ex)
            {
                
                throw new DianBizException("获取店的数据出错！",ex);
            }
        }
        public void InsertDianEntity(DianEntity condition_entity)
        {
            try
            {
                DianDao.InsertEntity(condition_entity);
            }
            catch (Exception ex)
            {
                
                throw new DianBizException("插入店数据出错！",ex);
            }
            
        }
        public void UpdateDianEntity(DianEntity condition_entity)
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
        public void DeleteDianEntity(DianEntity condition_entity)
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
    }
}
