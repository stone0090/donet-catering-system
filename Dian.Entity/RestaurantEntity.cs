using System;
using DoNet.Utility.Database.EntitySql.Attribute;
using DoNet.Utility.Database.EntitySql.Entity;

namespace Dian.Entity
{
    [Serializable]
    [Table("RESTAURANT")]
    public class RestaurantEntity : BaseEntity
    {
        [Field("RESTAURANT_ID")]
        public int? RESTAURANT_ID { get; set; }
        [Field("RESTAURANT_NAME")]
        public string RESTAURANT_NAME { get; set; }
        [Field("ADDRESS")]
        public string ADDRESS { get; set; }
        [Field("DESCREPTION")]
        public string DESCREPTION { get; set; }
        [Field("LEVEL")]
        public string LEVEL { get; set; }
        [Field("AREA")]
        public string AREA { get; set; }
        [Field("PARKING_COUNT")]
        public int? PARKING_COUNT { get; set; }
        [Field("RESTAURANT_MAP")]
        public string RESTAURANT_MAP { get; set; }
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
