using WebApi.Entities;
using WebApi.Repositories.Generic;

namespace WebApi.Repositories.User
{
    public interface IUserRepository : IGenericRepository<UserTbl>
    {
        bool IsAuthenticated(UserTbl userTbl);

        UserTbl GetByUsername(string username);
    }
}
