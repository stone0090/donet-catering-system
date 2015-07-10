using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dian.Web
{
    public partial class Food : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                 * 注意图片上传保存时，自动生成相应的缩略图
                 */
            }
            catch (Exception ex)
            {
                
                throw;
            }

        }

        
    }
}