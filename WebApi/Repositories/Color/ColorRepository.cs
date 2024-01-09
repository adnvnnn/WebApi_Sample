using WebApi.Context;
using WebApi.Entities;
using WebApi.Repositories.Generic;

namespace WebApi.Repositories.Color
{
    public class ColorRepository :GenericRepository<ColorTbl> , IColorRepository
    {
        public ColorRepository(DefaultDbContext context) : base(context)
        {
        }
    }
}
