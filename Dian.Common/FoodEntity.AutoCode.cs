using System;
using System.Data;
using System.Data.Common;
using CSN.DotNetLibrary.Common;

namespace Dian.Common.Entity
{
    partial class FoodEntity
    {
        [Field("FOOD_ID", FieldDBType = DbType.Int32, FieldDesc = "", IsIdentityField = true, IsPrimaryKey = true)]
        public int? FOOD_ID { get; set; }

        [Field("FOOD_NAME", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string FOOD_NAME { get; set; }

        [Field("RESTAURANT_ID", FieldDBType = DbType.Int32, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public int? RESTAURANT_ID { get; set; }

        [Field("FOOD_TYPE_ID", FieldDBType = DbType.Int32, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public int? FOOD_TYPE_ID { get; set; }

        [Field("FOOD_TASTE", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string FOOD_TASTE { get; set; }

        [Field("DESCRIPTION", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string DESCRIPTION { get; set; }

        [Field("FOOD_IMAGE_NAIL1", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string FOOD_IMAGE_NAIL1 { get; set; }

        [Field("FOOD_IMAGE_NAIL2", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string FOOD_IMAGE_NAIL2 { get; set; }

        [Field("FOOD_IMAGE_NAIL3", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string FOOD_IMAGE_NAIL3 { get; set; }

        [Field("FOOD_IMAGE_NAIL4", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string FOOD_IMAGE_NAIL4 { get; set; }

        [Field("FOOD_IMAGE1", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string FOOD_IMAGE1 { get; set; }

        [Field("FOOD_IMAGE2", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string FOOD_IMAGE2 { get; set; }

        [Field("FOOD_IMAGE3", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string FOOD_IMAGE3 { get; set; }

        [Field("FOOD_IMAGE4", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string FOOD_IMAGE4 { get; set; }
    }
}
