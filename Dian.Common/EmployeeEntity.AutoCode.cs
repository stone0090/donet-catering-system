using System;
using System.Data;
using System.Data.Common;
using CSN.DotNetLibrary.Common;

namespace Dian.Common.Entity
{
    partial class EmployeeEntity
    {
        private string _EMPLOYEE_ID;
        [Field("EMPLOYEE_ID", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = true)]
        public string EMPLOYEE_ID
        {
            get
            {
                return _EMPLOYEE_ID;
            }
            set
            {
                _EMPLOYEE_ID = value;
            }
        }
        private string _EMPLOYEE_NAME;
        [Field("EMPLOYEE_NAME", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string EMPLOYEE_NAME
        {
            get
            {
                return _EMPLOYEE_NAME;
            }
            set
            {
                _EMPLOYEE_NAME = value;
            }
        }
        private int _RESTAURANT_ID;
        [Field("RESTAURANT_ID", FieldDBType = DbType.Int32, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public int RESTAURANT_ID
        {
            get
            {
                return _RESTAURANT_ID;
            }
            set
            {
                _RESTAURANT_ID = value;
            }
        }
        private string _PASSWORD;
        [Field("PASSWORD", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string PASSWORD
        {
            get
            {
                return _PASSWORD;
            }
            set
            {
                _PASSWORD = value;
            }
        }
        private string _SEX;
        [Field("SEX", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string SEX
        {
            get
            {
                return _SEX;
            }
            set
            {
                _SEX = value;
            }
        }
        private string _OFFICE_PHONE;
        [Field("OFFICE_PHONE", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string OFFICE_PHONE
        {
            get
            {
                return _OFFICE_PHONE;
            }
            set
            {
                _OFFICE_PHONE = value;
            }
        }
        private string _MOBILE_PHONE;
        [Field("MOBILE_PHONE", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string MOBILE_PHONE
        {
            get
            {
                return _MOBILE_PHONE;
            }
            set
            {
                _MOBILE_PHONE = value;
            }
        }
    }
}
