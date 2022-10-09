namespace QLPhongGym.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Permission")]
    public partial class Permission
    {
        [StringLength(10)]
        public string PermissionID { get; set; }

        [StringLength(50)]
        public string PermissionName { get; set; }
    }
}
