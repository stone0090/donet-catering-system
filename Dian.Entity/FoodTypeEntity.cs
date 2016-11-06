using System;
using DoNet.Utility.Database.EntitySql.Attribute;
using DoNet.Utility.Database.EntitySql.Entity;

namespace Dian.Entity
{
    [Serializable]
    [Table("FOOD_TYPE")]
    public class FoodTypeEntity : BaseEntity
    {
        [Field("FOOD_TYPE_ID")]
        public int? FOOD_TYPE_ID { get; set; }
        [Field("FOOD_TYPE_NAME")]
        public string FOOD_TYPE_NAME { get; set; }
        [Field("RESTAURANT_ID")]
        public int? RESTAURANT_ID { get; set; }
    }
}
