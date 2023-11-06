using Grand.Infrastructure.ModelBinding;
using Grand.Infrastructure.Models;

namespace Leo.MonetaryCredit.Models
{
    public class ConfigurationModel : BaseModel
    {
        /// <summary>
        /// 总充值数量限额（人民币）
        /// </summary>

        [GrandResourceDisplayName("Plugins.Leo.MonetaryCredit.Fields.LimitTotalRecharge")]
        public decimal LimitTotalRecharge { get; set; }

        /// <summary>
        /// 获取信用货币的比率 0.00x
        /// </summary>

        [GrandResourceDisplayName("Plugins.Leo.MonetaryCredit.Fields.CreditRate")]
        public decimal CreditRate { get; set; }


        [GrandResourceDisplayName("Plugins.Leo.MonetaryCredit.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }
    }
}