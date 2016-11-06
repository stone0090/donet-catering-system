using System;
using DoNet.Utility.Database.EntitySql.Attribute;
using DoNet.Utility.Database.EntitySql.Entity;

namespace Dian.Entity
{
    [Serializable]
    [Table("FOOD")]
    public class FoodEntity : BaseEntity
    {
        [Field("FOOD_ID")]
        public int? FOOD_ID { get; set; }
        [Field("FOOD_NAME")]
        public string FOOD_NAME { get; set; }
        [Field("RESTAURANT_ID")]
        public int? RESTAURANT_ID { get; set; }
        [Field("FOOD_TYPE_ID")]
        public int? FOOD_TYPE_ID { get; set; }
        [Field("FOOD_TASTE")]
        public string FOOD_TASTE { get; set; }
        [Field("DESCRIPTION")]
        public string DESCRIPTION { get; set; }
        [Field("PRICE")]
        public decimal? PRICE { get; set; }
        [Field("FOOD_IMAGE_NAIL1")]
        public string FOOD_IMAGE_NAIL1 { get; set; }
        [Field("FOOD_IMAGE_NAIL2")]
        public string FOOD_IMAGE_NAIL2 { get; set; }
        [Field("FOOD_IMAGE_NAIL3")]
        public string FOOD_IMAGE_NAIL3 { get; set; }
        [Field("FOOD_IMAGE_NAIL4")]
        public string FOOD_IMAGE_NAIL4 { get; set; }
        [Field("FOOD_IMAGE1")]
        public string FOOD_IMAGE1 { get; set; }
        [Field("FOOD_IMAGE2")]
        public string FOOD_IMAGE2 { get; set; }
        [Field("FOOD_IMAGE3")]
        public string FOOD_IMAGE3 { get; set; }
        [Field("FOOD_IMAGE4")]
        public string FOOD_IMAGE4 { get; set; }
        [Field("CREATE_TIME")]
        public DateTime? CREATE_TIME { get; set; }
        [Field("CREATE_PERSON")]
        public string CREATE_PERSON { get; set; }
        [Field("UPDATE_TIME")]
        public DateTime? UPDATE_TIME { get; set; }
        [Field("UPDATE_PERSON")]
        public string UPDATE_PERSON { get; set; }
    }
}
