using WebApi.Context;
using WebApi.Entities;
using WebApi.Repositories.Generic;

namespace WebApi.Repositories.User
{
    public class UserRepository : GenericRepository<UserTbl> , IUserRepository
    {
        private readonly DefaultDbContext _context; 
        public UserRepository(DefaultDbContext context) : base(context)
        {
            _context = context;
        }

        public bool IsAuthenticated(UserTbl userTbl)
        {
            try
            {
                var user = _context.UserTbls.FirstOrDefault(x => x.Id == userTbl.Id);

                //TODO: hash pass
                if (userTbl.Username == user.Username && userTbl.Password == user.Password)
                {
                    return true;
                }

                return false;
            }
            catch 
            {
                return false;
            }
        }

        public UserTbl GetByUsername(string username)
        {
            return _context.UserTbls.FirstOrDefault(x => x.Username == username);
        }
    }
}
