using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dian.Common.Entity
{
    [Serializable]
   public  class DianEntity
    {
        private string _DianID;
        public string DianID
        {
            get { return _DianID; }
            set { _DianID = value; }
        }

        private string _DianName;
        public string DianName
        {
            get { return _DianName; }
            set { _DianName = value; }
        }

        private string _Address;
        public string Address
        {
            get { return _Address; }
            set { _Address = value; }
        }
    }
}
