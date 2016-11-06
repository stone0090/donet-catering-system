using Dian.Biz;
using Dian.Entity;
using Dian.Interface;
using Dian.Web.Utility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using ThoughtWorks.QRCode.Codec;

namespace Dian.Web
{
    public partial class CreateQRCode : BasePage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindControlData();
            }
            else
            {
                var hStyleMasterOperation = Master.Master.FindControl("hStyleMasterOperation") as HtmlInputHidden;
                if (hStyleMasterOperation.Value == "logout")
                    return;
                GenerateQRCode();
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
        }
        private void FillFormData()
        {

        }
        private void GenerateQRCode()
        {
            try
            {
                var url = "http://" + Request.Url.Authority + "/Index.aspx?rid=" + this.ddlRestaurant.SelectedValue + "&tid=" + this.hTableId.Value;

                var encoder = new QRCodeEncoder();
                encoder.QRCodeEncodeMode = QRCodeEncoder.ENCODE_MODE.BYTE;
                encoder.QRCodeScale = 8;
                encoder.QRCodeVersion = 7;
                encoder.QRCodeErrorCorrect = QRCodeEncoder.ERROR_CORRECTION.M;

                using (var ms = new MemoryStream())
                {
                    using (Bitmap bmp = encoder.Encode(url))
                    {
                        bmp.Save(ms, ImageFormat.Jpeg);
                        Response.ClearContent();
                        Response.ContentEncoding = Encoding.UTF8;
                        Response.ContentType = "image/jpeg";
                        Response.AppendHeader("Content-Disposition", "attachment; filename=QRcode.jpg");
                        Response.BinaryWrite(ms.ToArray());
                        Response.Flush();
                        Response.End();
                    }
                }

            }
            catch (Exception ex)
            {
                this.lMsg.InnerText = "生成二维码失败，原因：" + ex.ToString();
            }

        }
    }
}