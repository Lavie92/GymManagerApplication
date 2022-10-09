namespace QLPhongGym.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Ticket")]
    public partial class Ticket
    {
        [StringLength(10)]
        public string TicketID { get; set; }

        [StringLength(10)]
        public string StaffID { get; set; }

        [StringLength(10)]
        public string CardID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ExtensionDay { get; set; }

        public virtual Card Card { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
