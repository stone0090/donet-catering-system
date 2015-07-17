using System;
using System.Data;
using System.Data.Common;
using CSN.DotNetLibrary.Common;

namespace Dian.Common.Entity
{
    partial class OrderListEntity2
    {

        [Field("LIST_ID", FieldDBType = DbType.Int32, FieldDesc = "", IsIdentityField = true, IsPrimaryKey = true)]
        public int? LIST_ID { get; set; }

        [Field("ORDER_ID", FieldDBType = DbType.Int32, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public int? ORDER_ID { get; set; }

        [Field("FOOD_ID", FieldDBType = DbType.Int32, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public int? FOOD_ID { get; set; }

        [Field("COUNT", FieldDBType = DbType.Int32, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public int? COUNT { get; set; }

        [Field("PRICE", FieldDBType = DbType.Decimal, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public decimal? PRICE { get; set; }

        [Field("ORDER_FLAG", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string ORDER_FLAG { get; set; }

        [Field("ORDER_TIME", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string ORDER_TIME { get; set; }

        [Field("CONFIRM_TIME", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string CONFIRM_TIME { get; set; }

        [Field("CANCEL_TIME", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string CANCEL_TIME { get; set; }

        [Field("FINISH_TIME", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string FINISH_TIME { get; set; }

        [Field("TASTE", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string TASTE { get; set; }

        [Field("REMARK", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string REMARK { get; set; }

    }
}
