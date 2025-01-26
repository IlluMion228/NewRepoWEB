using Microsoft.EntityFrameworkCore;

namespace WEB.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Здесь добавляются DbSet для ваших моделей данных
        public DbSet<Booking> Booking { get; set; }
    }
}
