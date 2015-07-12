using System;
using System.Data;
using System.Data.Common;
using CSN.DotNetLibrary.Common;

namespace Dian.Common.Entity
{
    partial class EmployeeEntity
    {
        [Field("EMPLOYEE_ID", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = true)]
        public string EMPLOYEE_ID { get; set; }

        [Field("EMPLOYEE_NAME", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string EMPLOYEE_NAME { get; set; }

        [Field("RESTAURANT_ID", FieldDBType = DbType.Int32, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public int RESTAURANT_ID { get; set; }

        [Field("PASSWORD", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string PASSWORD { get; set; }

        [Field("SEX", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string SEX { get; set; }

        [Field("OFFICE_PHONE", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string OFFICE_PHONE { get; set; }

        [Field("MOBILE_PHONE", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string MOBILE_PHONE { get; set; }

        [Field("IS_ADMIN", FieldDBType = DbType.Boolean, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public bool? IS_ADMIN { get; set; }

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
