namespace QLPhongGym.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Card")]
    public partial class Card
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Card()
        {
            Tickets = new HashSet<Ticket>();
        }

        [StringLength(10)]
        public string CardID { get; set; }

        [StringLength(10)]
        public string CustomerID { get; set; }

        [StringLength(10)]
        public string StaffID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ReceiveDay { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExpirationDay { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Staff Staff { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}
