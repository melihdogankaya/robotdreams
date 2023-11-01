using Microsoft.EntityFrameworkCore;

namespace RobotDreams.API.Context
{
    public class RobotDreamsDbContext : DbContext
    {
        public RobotDreamsDbContext(DbContextOptions<RobotDreamsDbContext> options) : base(options) 
        { 
        }
        public DbSet<User> Users { get; set; }
    }

}
