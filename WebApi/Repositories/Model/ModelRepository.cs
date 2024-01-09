using WebApi.Context;
using WebApi.Entities;
using WebApi.Repositories.Generic;

namespace WebApi.Repositories.Model
{
    public class ModelRepository : GenericRepository<ModelTbl> , IModelRepository
    {
        public ModelRepository(DefaultDbContext context) : base(context)
        {
        }
    }
}
