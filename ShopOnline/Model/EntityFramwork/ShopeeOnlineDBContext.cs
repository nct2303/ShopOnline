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
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Product_> Product_ { get; set; }
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

            modelBuilder.Entity<Order>()
                .Property(e => e.order_id)
                .IsUnicode(false);

            modelBuilder.Entity<Order>()
                .Property(e => e.customer_id)
                .IsUnicode(false);

            modelBuilder.Entity<OrderDetail>()
                .Property(e => e.order_id)
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

            modelBuilder.Entity<Product_>()
                .Property(e => e.product_id)
                .IsUnicode(false);

            modelBuilder.Entity<Product_>()
                .Property(e => e.product_size)
                .IsUnicode(false);

            modelBuilder.Entity<Product_>()
                .Property(e => e.product_color)
                .IsUnicode(false);

            modelBuilder.Entity<UserAdmin>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<UserAdmin>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<UserAdmin>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<UserAdmin>()
                .Property(e => e.fullname)
                .IsUnicode(false);

            modelBuilder.Entity<UserAdmin>()
                .Property(e => e.email)
                .IsUnicode(false);
        }
    }
}
