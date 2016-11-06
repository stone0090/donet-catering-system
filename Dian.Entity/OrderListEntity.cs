using System;
using DoNet.Utility.Database.EntitySql.Attribute;
using DoNet.Utility.Database.EntitySql.Entity;

namespace Dian.Entity
{
    [Serializable]
    [Table("ORDERLIST")]
    public class OrderListEntity : BaseEntity
    {
        [Field("LIST_ID")]
        public int? LIST_ID { get; set; }
        [Field("ORDER_ID")]
        public int? ORDER_ID { get; set; }
        [Field("FOOD_ID")]
        public int? FOOD_ID { get; set; }
        [Field("COUNT")]
        public int? COUNT { get; set; }
        [Field("PRICE")]
        public decimal? PRICE { get; set; }
        [Field("ORDER_FLAG")]
        public string ORDER_FLAG { get; set; }
        [Field("ORDER_TIME")]
        public string ORDER_TIME { get; set; }
        [Field("CONFIRM_TIME")]
        public string CONFIRM_TIME { get; set; }
        [Field("CANCEL_TIME")]
        public string CANCEL_TIME { get; set; }
        [Field("FINISH_TIME")]
        public string FINISH_TIME { get; set; }
        [Field("TASTE")]
        public string TASTE { get; set; }
        [Field("REMARK")]
        public string REMARK { get; set; }
    }
}
