using System;
using DoNet.Utility.Database.EntitySql.Attribute;
using DoNet.Utility.Database.EntitySql.Entity;

namespace Dian.Entity
{
    [Serializable]
    [Table("TABLE")]
    public class TableEntity : BaseEntity
    {
        [Field("TABLE_ID")]
        public int? TABLE_ID { get; set; }
        [Field("TABLE_NAME")]
        public string TABLE_NAME { get; set; }
        [Field("RESTAURANT_ID")]
        public int? RESTAURANT_ID { get; set; }
    }
}
