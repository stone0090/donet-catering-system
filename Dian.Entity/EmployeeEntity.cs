using System;
using DoNet.Utility.Database.EntitySql.Attribute;
using DoNet.Utility.Database.EntitySql.Entity;

namespace Dian.Entity
{
    [Serializable]
    [Table("EMPLOYEE")]
    public class EmployeeEntity : BaseEntity
    {
        [Field("EMPLOYEE_ID")]
        public string EMPLOYEE_ID { get; set; }
        [Field("EMPLOYEE_NAME")]
        public string EMPLOYEE_NAME { get; set; }
        [Field("RESTAURANT_ID")]
        public int? RESTAURANT_ID { get; set; }
        [Field("PASSWORD")]
        public string PASSWORD { get; set; }
        [Field("SEX")]
        public string SEX { get; set; }
        [Field("OFFICE_PHONE")]
        public string OFFICE_PHONE { get; set; }
        [Field("MOBILE_PHONE")]
        public string MOBILE_PHONE { get; set; }
        [Field("IS_ADMIN")]
        public bool? IS_ADMIN { get; set; }
        [Field("CREATE_TIME")]
        public DateTime? CREATE_TIME { get; set; }
        [Field("CREATE_PERSON")]
        public string CREATE_PERSON { get; set; }
        [Field("UPDATE_TIME")]
        public DateTime? UPDATE_TIME { get; set; }
        [Field("UPDATE_PERSON")]
        public string UPDATE_PERSON { get; set; }

        public string RESTAURANT_NAME { get; set; }
    }
}
