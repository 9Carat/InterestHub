using InterestHub2.Models;
using Microsoft.EntityFrameworkCore;

namespace InterestHub2.Data
{
    public class InterestHubDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Interest> Interests { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<UserInterest> UserInterests { get; set; }
        public DbSet<InterestLink> InterestLinks { get; set; }
        public DbSet<UserInterestLink> UserInterestLinks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder
            .UseSqlServer("Server=DESKTOP-4SNMTAT;Database=InterestHub2;Integrated Security=true;TrustServerCertificate=true;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserInterest>()
                .HasOne(ui => ui.Users)
                .WithMany(u => u.UserInterests)
                .HasForeignKey(ui => ui.FK_UserId);

            modelBuilder.Entity<UserInterest>()
                .HasOne(ui => ui.Interests)
                .WithMany(i => i.UserInterests)
                .HasForeignKey(ui => ui.FK_InterestId);

            modelBuilder.Entity<InterestLink>()
                .HasOne(il => il.Links)
                .WithMany(l => l.InterestLinks)
                .HasForeignKey(il => il.FK_LinkId);

            modelBuilder.Entity<InterestLink>()
                .HasOne(il => il.Interests)
                .WithMany(i => i.InterestLinks)
                .HasForeignKey(il => il.FK_InterestId);

            modelBuilder.Entity<UserInterestLink>()
                .HasOne(uil => uil.Users)
                .WithMany(u => u.UserInterestLinks)
                .HasForeignKey(uil => uil.FK_UserId);

            modelBuilder.Entity<UserInterestLink>()
                .HasOne(uil => uil.Interests)
                .WithMany(i => i.UserInterestLinks)
                .HasForeignKey(uil => uil.FK_InterestId);

            modelBuilder.Entity<UserInterestLink>()
                .HasOne(uil => uil.Links)
                .WithMany(l => l.UserInterestLinks)
                .HasForeignKey(uil => uil.FK_LinkId);
        }
    }
}
