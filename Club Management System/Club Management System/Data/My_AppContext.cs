using Club_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Club_Management_System.Data
{
    public class My_AppContext : DbContext
    {
        public My_AppContext(DbContextOptions<My_AppContext> options) : base(options)
        {
        }
        public DbSet<Member> Members { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Membership>()
               .HasOne(x => x.Member)
               .WithOne(x => x.Membership)
               .HasForeignKey<Membership>(x => x.MemberId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Member>()
                .HasMany(x =>x.Bookings)
                .WithOne(x => x.Member)
                .HasForeignKey(x => x.MemberId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Facility>()
                .HasMany(x => x.Bookings)
                .WithOne(x => x.Facility)
                .HasForeignKey(x => x.FacilityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Membership>()
                .HasMany(x => x.Payments)
                .WithOne(x => x.Membership)
                .HasForeignKey(x => x.MembershipId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Facility>().HasIndex(x => x.Name).IsUnique();

            modelBuilder.Entity<Member>().HasData(new Member { Id = 1, BirthDate = new DateTime(2000 - 05 - 15), Email = "b@gmail.com", FullName = "basil mohamed", Phone = "01158589053" });

            modelBuilder.Entity<Membership>().HasData(new Membership { Id = 1, StartDate = new DateTime(2026 - 01 - 01), EndDate = new DateTime(2027 - 01 - 01), MemberId = 1, Status = "Active", Price = 5000, Type = "Gold" });

            modelBuilder.Entity<Facility>().HasData(new Facility { Id = 1, Capacity = 100, HourlyPrice = 200, Name = "Swimming Pool" });

            modelBuilder.Entity<Booking>().HasData(new Booking { Id = 1, BookingDate = new DateTime(2026 - 01 - 01), StartTime = new TimeSpan(10, 0, 0), EndTime = new TimeSpan(12, 0, 0), MemberId = 1, Status = "Confirmed", FacilityId = 1, GroupSize = 20 });

            modelBuilder.Entity<Payment>().HasData(new Payment { Id = 1, MembershipId = 1, PaymentDate = new DateTime(2026 - 01 - 01), PaymentMethod = "Card" });








            base.OnModelCreating(modelBuilder);
        }

    }
}
