using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace DK.KDServer.WEBDA.DFW
{
    /// <summary>
    /// 快递在哪儿 接口
    /// </summary>
    public abstract class KDPathBase
    {
        #region 属性
        /// <summary>
        /// 快递单号
        /// </summary>
        public string KDNo { get; set; }

        public string URL { get; set; }
        /// <summary>
        /// 验证码图片
        /// </summary>
        public  Bitmap BMVerificationCode { get; set; }

        /// <summary>
        /// 验证码
        /// </summary>
        public string VerificationCode { get; set; }

        /// <summary>
        /// 验证码长度
        /// </summary>
        public   int VeriCodeLength { get; set; }

        /// <summary>
        /// http:操作实例
        /// </summary>
        public HttpHelper HttpHelp{get;set;}

        /// <summary>
        /// 快递运送 到达 列表
        /// </summary>
        public List<KDPathOR> listKDPath { get; set; }
        #endregion

        #region 接口函数
        /// <summary>
        /// 获取 当前快递位置
        /// </summary>
        /// <returns></returns>
        public abstract string GetKDPath();

        /// <summary>
        /// 对网站初使化,并获取验证码。
        /// </summary>
        public abstract bool Init();
        #endregion



    }
}
