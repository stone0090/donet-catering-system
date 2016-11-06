using System.Collections.Generic;
using System.Data;
using Dian.Entity;

namespace Dian.Interface
{
    public interface IOrder
    {
        int CreateOrder(int restaurantId, int tableId, decimal price, List<OrderListEntity> orderList);
        DataTable GetOrderData(int orderId);
        void UpdateOrder(int orderId, decimal price, string foodOp, OrderListEntity entity);
        void ClearCart(int orderId);
        void BatchProcessOrder(int orderId, string opreation);

        DataTable GetOrderMainDataTable(int? restaurantId = null, string type = null);
        List<OrderMainEntity> GetOrderMainEntityList(OrderMainEntity condition_entity);
        int InsertOrderMainEntity(OrderMainEntity condition_entity);
        void UpdateOrderMainEntity(OrderMainEntity condition_entity);
        void DeleteOrderMainEntity(OrderMainEntity condition_entity);
        OrderMainEntity GetOrderMainEntity(int? id);

        DataTable GetOrderListDataTable(int? restaurantId = null);
        List<OrderListEntity> GetOrderListEntityList(OrderListEntity condition_entity);
        void InsertOrderListEntity(OrderListEntity condition_entity);
        void UpdateOrderListEntity(OrderListEntity condition_entity);
        void DeleteOrderListEntity(OrderListEntity condition_entity);
        OrderListEntity GetOrderListEntity(int? id);
    }
}
