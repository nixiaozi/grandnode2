using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit.Query
{
    /// <summary>
    /// 订单的修改方式
    /// </summary>
    public enum ChangeType
    {
        Create=10,  // 创建
        Recall=20   // 取消
    }
}
