using Grand.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit.Models.User
{
    public class MonetaryCreditUserInfoModel:BaseModel
    {
        /// <summary>
        /// 客户编号
        /// </summary>
        public string CustomerID { get; set; }

        /// <summary>
        /// 客户名称
        /// </summary>
        public string CustomerName { get; set; }


        /// <summary>
        /// 当前账户余额
        /// </summary>
        public decimal CurrentBalanceRemain { get; set; }


        /// <summary>
        /// 总计充值金额(仅第三方)
        /// </summary>
        public decimal TotalRechangeByThird { get; set; }

        /// <summary>
        /// 通过货币信用兑换的金额
        /// </summary>
        public decimal TotalRechangeByCredit { get; set; }


        /// <summary>
        /// 现有购买积分 
        /// </summary>
        public decimal BuyCreditRemain { get; set; }

        /// <summary>
        /// 已使用的购买积分
        /// </summary>
        public decimal TotalUsedBuyCredit { get; set; }


        /// <summary>
        /// 现有销售积分
        /// </summary>
        public decimal SellCreditRemain { get; set; }

        /// <summary>
        /// 已使用的销售积分
        /// </summary>
        public decimal TotalUsedSellCredit { get; set; }

        /// <summary>
        /// 现有活动积分
        /// </summary>
        public decimal ActionCreditRemain { get; set; }

        /// <summary>
        /// 总的已使用活动积分
        /// </summary>
        public decimal TotalUsedActionCredit { get; set; }

        /// <summary>
        /// 用户的信用分数(不同的信用分数有不同的事情可以做)
        /// </summary>
        public int UserCreditScore { get; set; }




    }
}
