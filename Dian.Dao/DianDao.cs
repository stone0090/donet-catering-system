using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using System.Data;
using CSN.DotNetLibrary.Data;
using CSN.DotNetLibrary.EntityExpressions.Data;
using CSN.DotNetLibrary.EntityExpressions.Entitys;
using System.Linq.Expressions;
using Dian.Common.Entity;
namespace Dian.Dao
{
    public static class DianDao
    {
        #region 初始化数据库
        public static Database DB
        {
            get
            {
                return DatabaseFactory.CreateDatabase();
            }
        }
        #endregion

        #region 插入实体操作
        public static void InsertEntity<E>(E entity)
        {
            EntityOperations.InsertEntity(entity, DB);
        }
        /// <summary>
        /// 插入实体，并返回标识列的值
        /// </summary>
        /// <typeparam name="E">实体类类型</typeparam>
        /// <param name="entity">实体类实例</param>
        /// <returns>标识列的值</returns>
        public static object InsertEntityWithIdentity<E>(E entity)
        {
            return EntityOperations.InsertEntityWithIdentity(entity, DB);
        }
        #endregion

        #region 删除实体操作
        public static void DeleteEntity<E>(E entity)
        {
            EntityOperations.DeleteEntity(entity, DB);
        }

        public static void DeleteEntity2<E>(Expression<Func<E, bool>> conditionExpression)
        {
            EntityOperations.DeleteEntity2(conditionExpression, DB);
        }

        #endregion

        #region 更新实体操作
        public static void UpdateEntity<E>(E entity)
        {
            EntityOperations.UpdateEntity(entity, DB);
        }
        public static void UpdateEntity<E>(GenericWhereEntity<E> whereEntity, E theEntity)
        {
            EntityOperations.UpdateEntity(whereEntity, theEntity, DB);
        }

        public static void UpdateEntity2<E>(Expression<Func<E, bool>> conditionExpression, E theEntity)
        {
            EntityOperations.UpdateEntity2(conditionExpression, theEntity, DB);
        }
        #endregion

        #region 查询实体操作
        public static DataTable SelectMembers<E, TResult>(GenericWhereEntity<E> whereEntity, Expression<VisitMember<E, TResult>> memberExpression, params int[] maxRowCounts)
        {
            return EntityOperations.SelectMembers(whereEntity, memberExpression, DB, maxRowCounts);
        }
        public static DataTable SelectMembers2<E, TResult>(Expression<Func<E, bool>> conditionExpression, Expression<VisitMember<E, TResult>> memberExpression, params int[] maxRowCounts)
        {
            return EntityOperations.SelectMembers2(conditionExpression, memberExpression, DB, maxRowCounts);
        }
        public static E ReadEntity<E>(GenericWhereEntity<E> whereEntity) where E : class,new()
        {
            return EntityOperations.ReadEntity(whereEntity, DB);
        }
        public static E ReadEntity2<E>(Expression<Func<E, bool>> conditionExpression) where E : class,new()
        {
            return EntityOperations.ReadEntity2(conditionExpression, DB);
        }
        public static List<E> ReadEntityList<E>(GenericWhereEntity<E> whereEntity, params int[] maxRowCounts) where E : class,new()
        {
            return EntityOperations.ReadEntityList(whereEntity, DB, maxRowCounts);
        }

        public static List<E> ReadEntityList2<E>(Expression<Func<E, bool>> conditionExpression, params int[] maxRowCounts) where E : class,new()
        {
            return EntityOperations.ReadEntityList2(conditionExpression, DB, maxRowCounts);
        }
        public static MainTable ReadMainEntity<MainTable, SubTable>(
         GenericJoinEntity<MainTable, SubTable> joinEntity) where MainTable : class,new()
        {
            return EntityOperations.ReadMainEntity(joinEntity, DB);
        }
        public static List<E> LoadEntityListFromReader<E>(IDataReader reader) where E : class,new()
        {
            return EntityOperations.LoadEntityListFromReader<E>(reader);
        }
        public static bool ExistsRecord<E>(GenericWhereEntity<E> whereEntity)
        {
            return EntityOperations.ExistsRecord(whereEntity, DB);
        }
        public static int GetEntityCount<E>(GenericWhereEntity<E> whereEntity)
        {
            return EntityOperations.GetEntityCount(whereEntity, DB);
        }
        #endregion

    }
}
