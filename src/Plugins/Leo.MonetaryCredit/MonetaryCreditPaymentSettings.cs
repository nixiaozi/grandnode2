using Grand.Domain.Configuration;

namespace Leo.MonetaryCredit
{
    public class MonetaryCreditPaymentSettings : ISettings
    {
        /// <summary>
        /// 总充值数量限额（人民币）
        /// </summary>
        public decimal LimitTotalRecharge { get; set; }

        /// <summary>
        /// 获取信用货币的比率 0.00x
        /// </summary>
        public decimal CreditRate { get; set; }

        public int DisplayOrder { get; set; }
    }
}
