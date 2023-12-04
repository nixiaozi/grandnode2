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
    /// 余额变动记录列表
    /// </summary>
    public class CustomerBalanceRecordList : BaseEntity
    {
        /// <summary>
        /// 用户编号(主键字段)
        /// </summary>
        public string CustomerID { get; set; }

        /// <summary>
        /// 余额变化单号
        /// </summary>
        public string ChangeOrderID { get; set; }

        /// <summary>
        /// 变化金额
        /// </summary>
        public decimal ChangeMoney { get; set; }

        /// <summary>
        /// 变化后的账户金额
        /// </summary>
        public decimal ResultMoney { get; set; }

        /// <summary>
        /// 关联的上一个Id
        /// </summary>
        public string ReleateId { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateDateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

    }
}
