using Microsoft.EntityFrameworkCore;

namespace WEB.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<HelpRequestModel> HelpRequests { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<Extra> Extras { get; set; }
        public DbSet<BookingExtra> BookingExtras { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<BookingExtra>()
                .HasKey(be => new { be.BookingId, be.ExtraId });

            modelBuilder.Entity<BookingExtra>()
                .HasOne(be => be.Booking)
                .WithMany(b => b.BookingExtras)
                .HasForeignKey(be => be.BookingId);

            modelBuilder.Entity<BookingExtra>()
                .HasOne(be => be.Extra)
                .WithMany(e => e.BookingExtras)
                .HasForeignKey(be => be.ExtraId);
        }

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
