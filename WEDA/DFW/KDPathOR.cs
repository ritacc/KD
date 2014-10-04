using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DK.KDServer.WEBDA.DFW
{
  public  class KDPathOR
    {
      /// <summary>
      /// 序号
      /// </summary>
      public int Index { get; set; }

      /// <summary>
      /// 快递 时间
      /// </summary>
      public DateTime PathData { get; set; }

      /// <summary>
      /// 快递城市
      /// </summary>
      public string City { get; set; }

      /// <summary>
      /// 详细状态
      /// </summary>
      public string KDStatus { get; set; }
    }
}
