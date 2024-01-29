using Grand.Domain;
using Grand.Infrastructure.Models;
using Leo.MonetaryCredit.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit.Domain
{
    /// <summary>
    /// 第三方的充值订单
    /// </summary>
    public class ThirdBalanceRechangeOrder : BaseEntity
    {
        /// <summary>
        /// 用户编号(主键字段)
        /// </summary>
        public string CustomerID { get; set; }

        /// <summary>
        /// 余额充值单号
        /// </summary>
        public string RechangeChangeID { get; set; }

        /// <summary>
        /// 充值方式
        /// </summary>
        public string RechangeChangeType { get; set; } 

        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal RechangeMoney { get; set; }


        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDateTime { get; set; }

        /// <summary>
        /// 充值状态
        /// </summary>
        public RechangeStatus TheRechangeStatus { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

    }
}
