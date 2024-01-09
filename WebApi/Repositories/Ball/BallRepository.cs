using WebApi.Context;
using WebApi.Entities;
using WebApi.Repositories.Generic;

namespace WebApi.Repositories.Ball
{
    public class BallRepository : GenericRepository<BallTbl> , IBallRepository
    {
        public BallRepository(DefaultDbContext context) : base(context)
        {
        }
    }
}
