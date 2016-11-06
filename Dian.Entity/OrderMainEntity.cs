using System;
using DoNet.Utility.Database.EntitySql.Attribute;
using DoNet.Utility.Database.EntitySql.Entity;

namespace Dian.Entity
{
    [Serializable]
    [Table("ORDERMAIN")]
    public class OrderMainEntity : BaseEntity
    {
        [Field("ORDER_ID")]
        public int? ORDER_ID { get; set; }
        [Field("RESTAURANT_ID")]
        public int? RESTAURANT_ID { get; set; }
        [Field("TABLE_ID")]
        public int? TABLE_ID { get; set; }
        [Field("PRICE")]
        public decimal? PRICE { get; set; }
        [Field("ORDER_FLAG")]
        public string ORDER_FLAG { get; set; }
    }
}
