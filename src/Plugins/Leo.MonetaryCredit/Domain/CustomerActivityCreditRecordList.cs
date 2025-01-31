﻿using Grand.Domain;
using Leo.MonetaryCredit.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leo.MonetaryCredit.Domain
{
    public class CustomerActivityCreditRecordList : BaseEntity
    {
        /// <summary>
        /// 引起积分变化的事件编号
        /// </summary>
        public string ReleateID { get; set; }

        /// <summary>
        /// 引起积分变化的事件名称
        /// </summary>
        public string RelateNameTag { get; set; }

        /// <summary>
        /// 积分有变化的用户
        /// </summary>
        public string CustomerID { get; set; }

        /// <summary>
        /// 积分变化的数量(保留两位小数)
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// 积分变化后的当前积分
        /// </summary>
        public decimal AmountRemain { get;set; }

        /// <summary>
        /// 该用户积分变化的上一条信息
        /// </summary>
        public string LastID { get; set; }

        /// <summary>
        /// 记录的变更类型
        /// </summary>
        public ChangeType TheChangeType { get; set; }

        /// <summary>
        /// 记录的创建时间
        /// </summary>
        public DateTime CreateDate { get; set; }

    }
}
