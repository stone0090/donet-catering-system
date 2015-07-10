using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dian.Common.Entity
{
    [Serializable]

    public class DianWebException : Exception
    {
        //记录到文本中
        //删除6个月之前的错误信息
        //在网页层，保存出错信息到文本文件
        public DianWebException(Exception ex)
        {
        }
        public DianWebException(string message, Exception ex)
        {
            //写数据到文本
        }
    }
}
