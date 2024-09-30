using DigitalConstructal.Entities;
using Microsoft.EntityFrameworkCore;

namespace DigitalConstructal.Data
{
    public class DigitalContext : DbContext
    {
        public DigitalContext(DbContextOptions<DigitalContext> options) : base(options)
        {
        }

        public DbSet<AccessLog> AccessLogs { get; set; }
        public DbSet<Content> Contents { get; set; }
        public DbSet<ContentType> ContentTypes { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<SEOIndex> SEOIndexes { get; set; }
        public DbSet<UserLogin> UserLogins { get; set; }
        public DbSet<Seller> Sellers { get; set; }
        public DbSet<OrderStatus> OrdersStatus { get; set; }
        public DbSet<Order> Orders { get; set; } 
        public DbSet<OrderProduct> OrderProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessLog>()
                .HasOne(al => al.UserLogin)
                .WithMany(ul => ul.AccessLogs)
                .HasForeignKey(al => al.UserLoginId);

            modelBuilder.Entity<Content>()
                .HasOne(c => c.Project)
                .WithMany(p => p.Contents)
                .HasForeignKey(c => c.ProjectId);

            modelBuilder.Entity<Project>()
                .HasOne(p => p.ContentType)
                .WithMany(ct => ct.Projects)
                .HasForeignKey(p => p.ContentTypeId);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

            modelBuilder.Entity<AccessLog>()
                .Property(al => al.AccessTime)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<UserLogin>()
                .Property(ul => ul.CreatedAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.UserLoginId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.Seller)
                .WithMany(s => s.Orders)
                .HasForeignKey(o => o.SellerId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Order>()
                .HasOne(o => o.OrderStatus)
                .WithMany()
                .HasForeignKey(o => o.OrderStatusId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId);

            modelBuilder.Entity<OrderProduct>()
                .HasOne(op => op.Product)
                .WithMany(p => p.OrderProducts) 
                .HasForeignKey(op => op.ProductId);


            // Seed dos dados fixos para OrderStatus
            modelBuilder.Entity<OrderStatus>().HasData(
                new OrderStatus { Id = 1, Name = "Pending" },
                new OrderStatus { Id = 2, Name = "Processing" },
                new OrderStatus { Id = 3, Name = "Shipped" },
                new OrderStatus { Id = 4, Name = "Delivered" },
                new OrderStatus { Id = 5, Name = "Cancelled" },
                new OrderStatus { Id = 6, Name = "Returned" }
            );

            // Seed dos dados fixos para ContentType
            modelBuilder.Entity<ContentType>().HasData(
                new ContentType { Id = 1, Name = "Blog Post" },
                new ContentType { Id = 2, Name = "Ebook" },
                new ContentType { Id = 3, Name = "Newsletter" },
                new ContentType { Id = 4, Name = "Page" },
                new ContentType { Id = 5, Name = "Social Post" },
                new ContentType { Id = 6, Name = "Task" },
                new ContentType { Id = 7, Name = "Webinar" }
            );

            // Seed dos dados fixos para SEOIndex
            modelBuilder.Entity<SEOIndex>().HasData(
                new SEOIndex { Id = 1, Name = "CF", Description = "CF" },
                new SEOIndex { Id = 2, Name = "CA", Description = "CA" },
                new SEOIndex { Id = 3, Name = "DR", Description = "DR" },
                new SEOIndex { Id = 4, Name = "PA", Description = "PA" },
                new SEOIndex { Id = 5, Name = "SC", Description = "SC" },
                new SEOIndex { Id = 6, Name = "TF", Description = "TF" },
                new SEOIndex { Id = 7, Name = "UR", Description = "UR" }
            );
        }
    }
}
