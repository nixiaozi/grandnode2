using Grand.Domain;
using Grand.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit.Domain
{
    public class CustomerCreditData : BaseEntity
    {
        /// <summary>
        /// 客户编号
        /// </summary>
        public Guid CustomerID { get; set; }

        /// <summary>
        /// 购买积分
        /// </summary>
        public decimal BuyCredit { get; set; }

        /// <summary>
        /// 销售积分
        /// </summary>
        public decimal SellCredit { get; set; }

        /// <summary>
        /// 活动积分
        /// </summary>
        public decimal ActionCredit { get; set; }

        /// <summary>
        /// 总的已兑换积分
        /// </summary>
        public decimal TotalRechangeCredit { get; set; }


    }
}
