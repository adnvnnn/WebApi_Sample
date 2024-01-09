using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Context
{
    public class DefaultDbContext :DbContext
    {
        public DefaultDbContext(DbContextOptions<DefaultDbContext> opt) :base(opt)
        {
            
        }

        public DbSet<BallTbl>? BallTbls { get; set; }

        public DbSet<ModelTbl>? ModelTbls { get; set; }

        public DbSet<ColorTbl>? ColorTbls { get; set; }

        public DbSet<UserTbl>? UserTbls { get; set; }

        

    }
}
