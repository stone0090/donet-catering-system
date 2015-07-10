using Dian.Biz;
using Dian.Common.Entity;
using Dian.Common.Interface;
using Dian.Web.Utility;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dian.Web
{
    public partial class RestaurantDetail : BasePage
    {
        public int CurId { get; set; }
        public string CurOperation { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            CurId = base.ParseInt(Request.QueryString["id"]);
            CurOperation = Request.QueryString["op"];

            if (CurOperation != "add" && CurOperation != "edit")
            {
                AlertAndTransfer("无效的操作类型！", base.UrlReferrer);
                return;
            }

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
        }
        private void FillFormData()
        {
            if (CurId == 0)
            {
                AlertAndTransfer("参数id无效！", base.UrlReferrer);
                return;
            }

            IRestaurant biz = new RestaurantBiz();
            var entity = biz.GetRestaurantEntity(CurId);
            if (entity == null)
            {
                AlertAndTransfer("参数id无效，获取数据失败！", base.UrlReferrer);
                return;
            }

            this.tRestaurantName.Value = entity.RESTAURANT_NAME;
            this.tAddress.Value = entity.ADDRESS;
            this.tDescription.Value = entity.DESCREPTION;
            this.hLevel.Value = entity.LEVEL;
            this.hArea.Value = entity.AREA;
            this.hPackingCount.Value = entity.PARKING_COUNT.ToString();
            if (!string.IsNullOrEmpty(entity.RESTAURANT_MAP))
                this.imgMap.Src = entity.RESTAURANT_MAP;

        }
        private void Save()
        {
            try
            {
                IRestaurant biz = new RestaurantBiz();               

                var entity = new RestaurantEntity();
                entity.RESTAURANT_NAME = this.tRestaurantName.Value;
                entity.ADDRESS = this.tAddress.Value;
                entity.DESCREPTION = this.tDescription.Value;
                entity.LEVEL = this.hLevel.Value;
                entity.AREA = this.hArea.Value;
                entity.PARKING_COUNT = base.ParseInt(this.hPackingCount.Value);

                if (!string.IsNullOrEmpty(fileMap.PostedFile.FileName))
                {
                    if (!fileMap.PostedFile.ContentType.Contains("image"))
                    {
                        this.lMsg.InnerText = "保存失败，原因：地图必须是图片格式！";
                        return;
                    }
                    if (fileMap.PostedFile.ContentLength > (1024 * 1024 * 2))
                    {
                        this.lMsg.InnerText = "保存失败，原因：地图大小不能超过2M！";
                        return;
                    }
                    if (!Directory.Exists(Server.MapPath(ConfigHelper.GetConfigString("RESTAURANT_MAP_PATH"))))
                        Directory.CreateDirectory(Server.MapPath(ConfigHelper.GetConfigString("RESTAURANT_MAP_PATH")));
                    var ext = Path.GetExtension(fileMap.PostedFile.FileName);
                    var fileName = Guid.NewGuid().ToString();
                    var filePath = Path.Combine(ConfigHelper.GetConfigString("RESTAURANT_MAP_PATH"), fileName) + ext;
                    fileMap.SaveAs(Server.MapPath(filePath));
                    entity.RESTAURANT_MAP = filePath.Replace(@"\", @"/");
                }

                if (CurOperation == "add")
                    biz.InsertRestaurantEntity(entity);
                else if (CurOperation == "edit")
                {
                    entity.RESTAURANT_ID = CurId;
                    biz.UpdateRestaurantEntity(entity);
                }

                AlertAndTransfer("保存成功！", base.UrlReferrer);
            }
            catch (Exception ex)
            {
                this.lMsg.InnerText = "保存失败，原因：" + ex.ToString();
            }
        }

    }
}