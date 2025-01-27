using Microsoft.EntityFrameworkCore;

namespace WEB.Models
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<UserModel> Users { get; set; }
        public DbSet<Help> HelpRequests { get; set; }


        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }
    }
}
