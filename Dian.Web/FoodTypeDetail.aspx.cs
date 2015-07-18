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
    public partial class FoodTypeDetail : BasePageDetail
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
        }
        private void FillFormData()
        {
            if (CurId == 0)
            {
                AlertAndTransfer("参数id无效！", base.UrlReferrer);
                return;
            }

            IFoodType biz = new FoodTypeBiz();
            var entity = biz.GetFoodTypeEntity(CurId);
            if (entity == null)
            {
                AlertAndTransfer("参数id无效，获取数据失败！", base.UrlReferrer);
                return;
            }

            this.tFoodTypeName.Value = entity.FOOD_TYPE_NAME;

        }
        private void Save()
        {
            try
            {
                IFoodType biz = new FoodTypeBiz();
                var entity = new FoodTypeEntity();
                entity.FOOD_TYPE_NAME = this.tFoodTypeName.Value;

                if (CurOperation == "add")
                    biz.InsertFoodTypeEntity(entity);
                else if (CurOperation == "edit")
                {
                    entity.FOOD_TYPE_ID = CurId;
                    biz.UpdateFoodTypeEntity(entity);
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