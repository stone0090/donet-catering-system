using System;
using System.Data;
using System.Data.Common;
using CSN.DotNetLibrary.Common;

namespace Dian.Common.Entity
{
    partial class RestaurantEntity
    {
        private int? _RESTAURANT_ID;
        [Field("RESTAURANT_ID", FieldDBType = DbType.Int32, FieldDesc = "", IsIdentityField = true, IsPrimaryKey = true)]
        public int? RESTAURANT_ID
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
        private string _RESTAURANT_NAME;
        [Field("RESTAURANT_NAME", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string RESTAURANT_NAME
        {
            get
            {
                return _RESTAURANT_NAME;
            }
            set
            {
                _RESTAURANT_NAME = value;
            }
        }
        private string _ADDRESS;
        [Field("ADDRESS", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string ADDRESS
        {
            get
            {
                return _ADDRESS;
            }
            set
            {
                _ADDRESS = value;
            }
        }
        private string _DESCREPTION;
        [Field("DESCREPTION", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string DESCREPTION
        {
            get
            {
                return _DESCREPTION;
            }
            set
            {
                _DESCREPTION = value;
            }
        }
        private string _LEVEL;
        [Field("LEVEL", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string LEVEL
        {
            get
            {
                return _LEVEL;
            }
            set
            {
                _LEVEL = value;
            }
        }
        private string _AREA;
        [Field("AREA", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string AREA
        {
            get
            {
                return _AREA;
            }
            set
            {
                _AREA = value;
            }
        }
        private int? _PARKING_COUNT;
        [Field("PARKING_COUNT", FieldDBType = DbType.Int32, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public int? PARKING_COUNT
        {
            get
            {
                return _PARKING_COUNT;
            }
            set
            {
                _PARKING_COUNT = value;
            }
        }
        private string _RESTAURANT_MAP;
        [Field("RESTAURANT_MAP", FieldDBType = DbType.AnsiString, FieldDesc = "", IsIdentityField = false, IsPrimaryKey = false)]
        public string RESTAURANT_MAP
        {
            get
            {
                return _RESTAURANT_MAP;
            }
            set
            {
                _RESTAURANT_MAP = value;
            }
        }
    }
}
