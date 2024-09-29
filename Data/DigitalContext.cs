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
