using System;
using System.Collections.Generic;

namespace Infrastructure.Models
{
    public partial class PromotionTier
    {
        public PromotionTier()
        {
            Voucher = new HashSet<Voucher>();
        }

        public Guid PromotionTierId { get; set; }
        public Guid? PromotionId { get; set; }
        public string TierName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool DelFlg { get; set; }
        public DateTime InsDate { get; set; }
        public DateTime UpdDate { get; set; }
        public Guid? ConditionRuleId { get; set; }
        public Guid ActionId { get; set; }
        public Guid? GiftId { get; set; }
        public string Summary { get; set; }
        public int TierIndex { get; set; }
        public Guid? VoucherGroupId { get; set; }
        public int? Priority { get; set; }
        public int? VoucherQuantity { get; set; }

        public virtual Action Action { get; set; }
        public virtual ConditionRule ConditionRule { get; set; }
        public virtual Gift Gift { get; set; }
        public virtual Promotion Promotion { get; set; }
        public virtual VoucherGroup VoucherGroup { get; set; }
        public virtual ICollection<Voucher> Voucher { get; set; }
    }
}
