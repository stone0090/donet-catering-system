using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dian.Common.Entity;
using Dian.Web.Utility;

namespace Dian.Web
{
    public partial class Restaurant : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //加载店家信息 从url中获取店家ID
            }

        }
        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                string restaurant_id = Request.QueryString["restaurant_id"].ToString();
                if (!string.IsNullOrEmpty(restaurant_id))
                {
                    //修改
                    RestaurantEntity condition_entity = new RestaurantEntity();
                    condition_entity.RESTAURANT_ID = Convert.ToInt32(restaurant_id);
                     
                }
                else
                {
                    //新增
                    RestaurantEntity condition_entity = new RestaurantEntity();
                    condition_entity.RESTAURANT_ID = Convert.ToInt32(restaurant_id);

                    //获取客户端上的文件全名称
                    string picture_name = FURestaurantMap.FileName;
                    //获取文件名称
                    string [] name_list=picture_name.Split('/');
                    picture_name = name_list[name_list.Length - 1];
                    //构造服务器上的文件全名称
                    string full_name = "../Images/OriginalImages/" + picture_name;
                    string nail_name = "../Images/NailImages/" + picture_name;
                    FURestaurantMap.SaveAs(full_name);
                    //生成缩略图并保存
                    ImageHelper ic = new ImageHelper(full_name);
                    ic.GetReducedImage(20, 20, nail_name);

                }

            }
            catch (Exception ex)
            {

                throw;
            }
        }
        protected void LoadRestaurant()
        {
            try
            {
                string restaurant_id = Request.QueryString["restaurant_id"].ToString();
                if (!string.IsNullOrEmpty(restaurant_id))
                {
                    RestaurantEntity condition_entity = new RestaurantEntity();
                    condition_entity.RESTAURANT_ID = Convert.ToInt32(restaurant_id);
                    //从数据库获取数据
                }

            }
            catch (Exception ex)
            {
                
                throw;
            }
        }        
    }
}