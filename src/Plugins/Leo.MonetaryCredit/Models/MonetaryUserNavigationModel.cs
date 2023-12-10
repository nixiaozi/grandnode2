using Grand.Infrastructure.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit.Models
{
    public class MonetaryUserNavigationModel:BaseModel
    {
        /// <summary>
        /// 隐藏信用货币主体信息
        /// </summary>
        public bool HideInfo { get; set; }

        /// <summary>
        /// 隐藏账户变动信息
        /// </summary>
        public bool HideBalanceRecord { get; set; }

        /// <summary>
        /// 隐藏账户充值记录
        /// </summary>
        public bool HideBanlanceRechangeOrder { get; set; }

        /// <summary>
        ///  是否隐藏信用货币兑换订单
        /// </summary>
        public bool HideMonetaryOrder { get; set; }

        /// <summary>
        /// 隐藏活动积分变化记录
        /// </summary>
        public bool HideActivityCreditRecord { get; set; }  

        /// <summary>
        /// 隐藏消费积分变化记录
        /// </summary>
        public bool HideBuyCreditRecord { get; set; }

        /// <summary>
        /// 隐藏购买积分变化记录
        /// </summary>
        public bool HideSellCreditRecord { get; set; }

        /// <summary>
        /// 选中的标识
        /// </summary>
        public MonetaryUserNavigationEnum SelectedTab { get; set; }

    }

    public enum MonetaryUserNavigationEnum
    {
        Info=0,
        BalanceRecord=10,
        BanlanceRechangeOrder=20,
        MonetaryOrder = 30,
        ActivityCreditRecord=40,
        BuyCreditRecord=50,
        SellCreditRecord=60
    }

}
