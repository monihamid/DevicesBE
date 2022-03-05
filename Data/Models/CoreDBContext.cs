using Data.Models;
using Microsoft.EntityFrameworkCore;


namespace Data.Models
{
    public class CoreDbContext: DbContext
    {
        public CoreDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
        }
        public DbSet<Users> Users{ get; set; }
        public DbSet<UserDevices> UserDevices { get; set; }
        
    }
}