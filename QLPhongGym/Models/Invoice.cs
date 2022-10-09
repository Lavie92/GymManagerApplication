namespace QLPhongGym.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Invoice")]
    public partial class Invoice
    {
        [StringLength(10)]
        public string InvoiceID { get; set; }

        [StringLength(10)]
        public string StaffID { get; set; }

        [StringLength(10)]
        public string CustomerID { get; set; }

        [StringLength(10)]
        public string SubscriptionID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreateDate { get; set; }

        public double? Total { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual GymSubscription GymSubscription { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
