using Microsoft.EntityFrameworkCore;
using RobotDreams.API.Context.Domain;

namespace RobotDreams.API.Context
{
    public class RobotDreamsDbContext : DbContext
    {
        public RobotDreamsDbContext(DbContextOptions<RobotDreamsDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserRoles> UserRoles { get; set; }

    }
}
