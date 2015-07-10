using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dian.Web
{
    public partial class Order : System.Web.UI.Page
    {
        private string[] arrUrl;
        int intTable;
              int intStore;
        protected void Page_Load(object sender, EventArgs e)
        {
           

            SetStoreAndTableID();

            GetOrderList(intStore, intTable);
            
        }

        //获取已点菜单，如果没有点过，则点新的
        private void GetOrderList(int intStore, int intTable)
        {
            //获取已点菜单

            //同时展现别的菜单待点
        }

        private void SetStoreAndTableID()
        {
            //解密URL
            arrUrl = DecryptUrl();
            //获取用户桌号和饭店号
            intTable = GetTableID(arrUrl);
            intStore = GetStoreID(arrUrl);
            //string strStore = strUrl[]
         
        
            Session["Store"] = intStore;
            Session["Table"] = intTable;
            }

        private int GetTableID(string[] strUrl)
        {
            return int.Parse(strUrl[1]); 
        }

        private int GetStoreID(string[] strUrl)
        {
            return int.Parse(strUrl[0]); 
        }


        private string[] DecryptUrl()
        {
            string strUrl = Request.QueryString["T"] ;
            //strUrl = System.Text.Encoding.Default.GetString(Convert.FromBase64String(strUrl.Replace("+", "% 2B")));
            strUrl = "123|1";
            return strUrl.Split('|');

        }
    }
}