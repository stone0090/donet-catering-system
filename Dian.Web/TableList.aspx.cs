using Dian.Biz;
using Dian.Common.Entity;
using Dian.Common.Interface;
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
using System.Web.UI.WebControls;
using ThoughtWorks.QRCode.Codec;

namespace Dian.Web
{
    public partial class TableList : BasePageList
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                if (this.hOperation.Value == "delete")
                    DeleteData();
                else if (this.hOperation.Value == "qrcode")
                    GenerateQRCode();
            }

            BindData();
        }
        private void BindData()
        {
            ITable biz = new TableBiz();
            DataTable dt = (bool)base.CurEmployeeEntity.IS_ADMIN ?
                biz.GetTableDataTable() :
                biz.GetTableDataTable(base.CurEmployeeEntity.RESTAURANT_ID);
            repeater1.DataSource = GetPagedDataSource(dt.DefaultView);
            repeater1.DataBind();
        }
        private void DeleteData()
        {
            try
            {
                var id = base.ParseInt(this.hDeleteId.Value);
                if (id != 0)
                {
                    ITable biz = new TableBiz();
                    biz.DeleteTableEntity(new TableEntity() { TABLE_ID = id });
                    this.lMsg.InnerText = "删除成功!";
                }
            }
            catch (Exception ex)
            {
                this.lMsg.InnerText = "删除失败，原因：" + ex.ToString();
            }
        }

        private void GenerateQRCode()
        {
            try
            {
                var id = base.ParseInt(this.hDeleteId.Value);
                if (id != 0)
                {
                    ITable biz = new TableBiz();
                    var entity = biz.GetTableEntity(id);
                    var url = "http://" + Request.Url.Authority + "/Index.aspx?rid=" + entity.RESTAURANT_ID.ToString() + "&tid=" + id.ToString();

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
            }
            catch (Exception ex)
            {
                this.lMsg.InnerText = "生成二维码失败，原因：" + ex.ToString();
            }
        }
    }
}