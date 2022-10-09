using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLPhongGym.Models
{
    public partial class GaYeuMeoContext : DbContext
    {
        public GaYeuMeoContext()
            : base("name=GaYeuMeoContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Card> Cards { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<GymEquipment> GymEquipments { get; set; }
        public virtual DbSet<GymSubscription> GymSubscriptions { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<Permission> Permissions { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<Staff> Staffs { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .Property(e => e.Password)
                .IsFixedLength();

            modelBuilder.Entity<Customer>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Staff>()
                .Property(e => e.Phone)
                .IsFixedLength()
                .IsUnicode(false);
        }
    }
}
