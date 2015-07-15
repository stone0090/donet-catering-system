using System;
using System.Data;
using System.Data.Common;
using CSN.DotNetLibrary.Common;

namespace Dian.Common.Entity
{
    partial class OrderMainEntity2
    {

        [Field("ORDER_ID", FieldDBType = DbType.Int32, FieldDesc = "", IsIdentityField = true, IsPrimaryKey = true)]
        public int? ORDER_ID { get; set; }

        [Field("RESTAURANT_ID", FieldDBType = DbType.Int32, FieldDesc = "", IsIdentityField = true, IsPrimaryKey = true)]
        public int? RESTAURANT_ID { get; set; }

        [Field("TABLE_ID", FieldDBType = DbType.Int32, FieldDesc = "", IsIdentityField = true, IsPrimaryKey = true)]
        public int? TABLE_ID { get; set; }

        [Field("PRICE", FieldDBType = DbType.Decimal, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public decimal? PRICE { get; set; }

        [Field("ORDER_FLAG", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = true, IsPrimaryKey = true)]
        public string ORDER_FLAG { get; set; }

    }
}
