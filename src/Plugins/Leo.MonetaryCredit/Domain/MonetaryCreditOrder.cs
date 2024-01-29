using Grand.Domain;
using Leo.MonetaryCredit.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit.Domain
{
    /// <summary>
    /// 信用货币兑换的充值订单
    /// </summary>
    public class MonetaryCreditOrder : BaseEntity
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
        /// 使用的活动积分
        /// </summary>
        public decimal UsedActivityCredit { get; set; }

        /// <summary>
        /// 使用的购买积分
        /// </summary>
        public decimal UsedBuyCredit {  get; set; }

        /// <summary>
        /// 使用的销售积分
        /// </summary>
        public decimal UsedSellCredit { get; set; }

        /// <summary>
        /// 当时的配置快照
        /// </summary>
        public string MonetarySettingShot { get; set; }

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
