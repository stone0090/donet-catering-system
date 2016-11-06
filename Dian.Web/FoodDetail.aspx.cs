using Dian.Biz;
using Dian.Entity;
using Dian.Interface;
using Dian.Web.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Dian.Web
{
    public partial class FoodDetail : BasePageDetail
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControlData();
                if (CurOperation == "edit")
                {
                    FillFormData();
                    this.lTypeName.InnerText = "编辑";
                }
            }
            else
            {
                Save();
            }
        }

        private void BindControlData()
        {
            IRestaurant restaurantBiz = new RestaurantBiz();
            this.ddlRestaurant.DataSource = (bool)base.CurEmployeeEntity.IS_ADMIN ?
                restaurantBiz.GetRestaurantDataTable() :
                restaurantBiz.GetRestaurantDataTable(base.CurEmployeeEntity.EMPLOYEE_ID);
            this.ddlRestaurant.DataValueField = "RESTAURANT_ID";
            this.ddlRestaurant.DataTextField = "RESTAURANT_NAME";
            this.ddlRestaurant.DataBind();

            IFoodType foodTypeBiz = new FoodTypeBiz();
            this.ddlFoodType.DataSource = foodTypeBiz.GetFoodTypeDataTable();
            this.ddlFoodType.DataValueField = "FOOD_TYPE_ID";
            this.ddlFoodType.DataTextField = "FOOD_TYPE_NAME";
            this.ddlFoodType.DataBind();
        }
        private void FillFormData()
        {
            if (CurId == 0)
            {
                AlertAndTransfer("参数id无效！", base.UrlReferrer);
                return;
            }

            IFood biz = new FoodBiz();
            var entity = biz.GetFoodEntity(CurId);
            if (entity == null)
            {
                AlertAndTransfer("参数id无效，获取数据失败！", base.UrlReferrer);
                return;
            }

            this.tFoodName.Value = entity.FOOD_NAME;
            this.ddlRestaurant.SelectedValue = entity.RESTAURANT_ID.ToString();
            this.ddlFoodType.SelectedValue = entity.FOOD_TYPE_ID.ToString();
            this.ddlTaste.SelectedValue = entity.FOOD_TASTE;
            this.tDescription.InnerText = entity.DESCRIPTION;
            this.hPrice.Value = entity.PRICE.ToString();
            if (!string.IsNullOrEmpty(entity.FOOD_IMAGE1))
                this.img1.Src = entity.FOOD_IMAGE1;
            if (!string.IsNullOrEmpty(entity.FOOD_IMAGE2))
                this.img2.Src = entity.FOOD_IMAGE2;
            if (!string.IsNullOrEmpty(entity.FOOD_IMAGE3))
                this.img3.Src = entity.FOOD_IMAGE3;
            if (!string.IsNullOrEmpty(entity.FOOD_IMAGE4))
                this.img4.Src = entity.FOOD_IMAGE4;

        }
        private void Save()
        {
            try
            {
                IFood biz = new FoodBiz();
                var entity = new FoodEntity();
                entity.FOOD_NAME = this.tFoodName.Value;
                entity.RESTAURANT_ID = base.ParseInt(this.ddlRestaurant.SelectedValue);
                entity.FOOD_TYPE_ID = base.ParseInt(this.ddlFoodType.SelectedValue);
                entity.FOOD_TASTE = this.ddlTaste.SelectedValue;
                entity.DESCRIPTION = this.tDescription.InnerText;
                decimal temp = 0;
                if (!decimal.TryParse(this.hPrice.Value, out temp))
                {
                    this.lMsg.InnerText = "保存失败，原因：单价必须为数字！";
                    return;
                }
                entity.PRICE = temp;

                string imgUrl, imgUrl_Nail;
                var foodImagePath = ConfigHelper.GetConfigString("FOOD_IMAGE_PATH");

                // 图片1
                imgUrl = null;
                imgUrl_Nail = null;
                if (!SetRestaurantMap(this.fileMap1, this.img1, this.hDeleteImg.Value, foodImagePath, ref imgUrl, ref imgUrl_Nail))
                    return;
                entity.FOOD_IMAGE1 = imgUrl;
                entity.FOOD_IMAGE_NAIL1 = imgUrl_Nail;

                // 图片2
                imgUrl = null;
                imgUrl_Nail = null;
                if (!SetRestaurantMap(this.fileMap2, this.img2, this.hDeleteImg.Value, foodImagePath, ref imgUrl, ref imgUrl_Nail))
                    return;
                entity.FOOD_IMAGE2 = imgUrl;
                entity.FOOD_IMAGE_NAIL2 = imgUrl_Nail;

                // 图片3
                imgUrl = null;
                imgUrl_Nail = null;
                if (!SetRestaurantMap(this.fileMap3, this.img3, this.hDeleteImg.Value, foodImagePath, ref imgUrl, ref imgUrl_Nail))
                    return;
                entity.FOOD_IMAGE3 = imgUrl;
                entity.FOOD_IMAGE_NAIL3 = imgUrl_Nail;

                // 图片4
                imgUrl = null;
                imgUrl_Nail = null;
                if (!SetRestaurantMap(this.fileMap4, this.img4, this.hDeleteImg.Value, foodImagePath, ref imgUrl, ref imgUrl_Nail))
                    return;
                entity.FOOD_IMAGE4 = imgUrl;
                entity.FOOD_IMAGE_NAIL4 = imgUrl_Nail;

                if (CurOperation == "add")
                {
                    entity.CREATE_TIME = DateTime.Now;
                    entity.CREATE_PERSON = base.CurEmployeeEntity.EMPLOYEE_ID;
                    biz.InsertFoodEntity(entity);
                }
                else if (CurOperation == "edit")
                {
                    entity.FOOD_ID = CurId;
                    entity.UPDATE_TIME = DateTime.Now;
                    entity.UPDATE_PERSON = base.CurEmployeeEntity.EMPLOYEE_ID;
                    biz.UpdateFoodEntity(entity);
                }

                AlertAndTransfer("保存成功！", base.UrlReferrer);
            }
            catch (Exception ex)
            {
                this.lMsg.InnerText = "保存失败，原因：" + ex.ToString();
            }
        }

        private bool SetRestaurantMap(FileUpload fileUpload, HtmlImage img, string deleteImg, string configPath, ref string imgUrl, ref string imgUrl_Nail)
        {
            if (!string.IsNullOrEmpty(fileUpload.PostedFile.FileName))
            {
                if (!fileUpload.PostedFile.ContentType.Contains("image"))
                {
                    this.lMsg.InnerText = string.Format("保存失败，原因：文件{0}必须是图片格式！", fileUpload.PostedFile.FileName);
                    return false;
                }
                if (fileUpload.PostedFile.ContentLength > (1024 * 1024 * 2))
                {
                    this.lMsg.InnerText = string.Format("保存失败，原因：文件{0}大小不能超过2M！", fileUpload.PostedFile.FileName);
                    return false;
                }
                if (!Directory.Exists(Server.MapPath(configPath)))
                    Directory.CreateDirectory(Server.MapPath(configPath));
                var ext = Path.GetExtension(fileUpload.PostedFile.FileName);
                var fileName = Guid.NewGuid().ToString();
                var filePath = Path.Combine(configPath, fileName) + ext;
                var filePath_Nail = Path.Combine(configPath, fileName) + "_nail" + ext;

                try
                {
                    fileUpload.SaveAs(Server.MapPath(filePath));
                    ImageHelper imageHelper = new ImageHelper(Server.MapPath(filePath));
                    imageHelper.GetReducedImage(ConfigHelper.GetConfigInt("FOOD_IMAGE_MAX_SIZE"), Server.MapPath(filePath_Nail));
                }
                catch (Exception ex)
                {
                    this.lMsg.InnerText = string.Format("保存失败，原因：{0}！", ex.ToString());
                    return false;
                }

                imgUrl = filePath.Replace(@"\", @"/");
                imgUrl_Nail = filePath_Nail.Replace(@"\", @"/");
                return true;
            }
            else
            {
                if (deleteImg.Contains(img.ClientID))
                {
                    imgUrl = string.Empty;
                    imgUrl_Nail = string.Empty;
                    if (img.Src != "Images/OriginalImages/pic-none.png")
                    {
                        try
                        {
                            var filePath = Server.MapPath(img.Src);
                            File.Delete(filePath);
                            var ext = Path.GetExtension(filePath);
                            var filePath_Nail = Path.GetFileNameWithoutExtension(filePath) + "_nail" + ext;
                            File.Delete(filePath_Nail);
                        }
                        catch { }
                    }
                }
                return true;
            }
        }

    }
}