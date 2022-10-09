namespace QLPhongGym.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("GymEquipment")]
    public partial class GymEquipment
    {
        [StringLength(10)]
        public string GymEquipmentID { get; set; }

        [StringLength(50)]
        public string GymEquipmentName { get; set; }

        [StringLength(10)]
        public string StaffID { get; set; }

        public double? Price { get; set; }

        [StringLength(10)]
        public string Muscle { get; set; }

        public int? Quantity { get; set; }

        public virtual Staff Staff { get; set; }
    }
}
