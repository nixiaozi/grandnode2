using Grand.Domain.Configuration;

namespace Leo.MonetaryCredit
{
    public class MonetaryCreditPaymentSettings : ISettings
    {
        /// <summary>
        /// �ܳ�ֵ�����޶����ң�
        /// </summary>
        public decimal LimitTotalRecharge { get; set; }

        /// <summary>
        /// ��ȡ���û��ҵı��� 0.00x
        /// </summary>
        public decimal CreditRate { get; set; }

        public int DisplayOrder { get; set; }
    }
}
