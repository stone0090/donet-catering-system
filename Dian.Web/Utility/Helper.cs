using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Dian.Web.Utility
{
    public class Helper
    {
        public static int ParseInt(string str)
        {
            var temp = 0;
            int.TryParse(str, out temp);
            return temp;
        }
        public static decimal ParseDecimal(string str)
        {
            decimal temp = 0;
            decimal.TryParse(str, out temp);
            return temp;
        }
    }
}