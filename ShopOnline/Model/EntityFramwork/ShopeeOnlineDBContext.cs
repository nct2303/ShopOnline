using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace Model.EntityFramwork
{
    public partial class ShopeeOnlineDBContext : DbContext
    {
        public ShopeeOnlineDBContext()
            : base("name=ShopeeOnlineDBContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerAccount> CustomerAccounts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Statistic> Statistics { get; set; }
        public virtual DbSet<UserAdmin> UserAdmins { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .Property(e => e.cate_id)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.customer_id)
                .IsUnicode(false);

            modelBuilder.Entity<Customer>()
                .Property(e => e.customer_phone)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.product_id)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.orderdetail_quanlity)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.orderdetail_price)
                .IsUnicode(false);

            modelBuilder.Entity<Statistic>()
                .Property(e => e.Id)
                .IsFixedLength();

            modelBuilder.Entity<UserAdmin>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<UserAdmin>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<UserAdmin>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<UserAdmin>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<UserAdmin>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
