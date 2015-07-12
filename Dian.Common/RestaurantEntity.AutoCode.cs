using System;
using System.Data;
using System.Data.Common;
using CSN.DotNetLibrary.Common;

namespace Dian.Common.Entity
{
    partial class RestaurantEntity
    {
        [Field("RESTAURANT_ID", FieldDBType = DbType.Int32, FieldDesc = "", IsIdentityField = true, IsPrimaryKey = true)]
        public int? RESTAURANT_ID { get; set; }

        [Field("RESTAURANT_NAME", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string RESTAURANT_NAME { get; set; }

        [Field("ADDRESS", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string ADDRESS { get; set; }

        [Field("DESCREPTION", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string DESCREPTION { get; set; }

        [Field("LEVEL", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string LEVEL { get; set; }

        [Field("AREA", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string AREA { get; set; }

        [Field("PARKING_COUNT", FieldDBType = DbType.Int32, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public int? PARKING_COUNT { get; set; }

        [Field("RESTAURANT_MAP", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string RESTAURANT_MAP { get; set; }

        [Field("CREATE_TIME", FieldDBType = DbType.DateTime, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public DateTime? CREATE_TIME { get; set; }

        [Field("CREATE_PERSON", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string CREATE_PERSON { get; set; }

        [Field("UPDATE_TIME", FieldDBType = DbType.DateTime, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public DateTime? UPDATE_TIME { get; set; }

        [Field("UPDATE_PERSON", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string UPDATE_PERSON { get; set; }
    }
}
