using CleanArchitectureApp.Domain; 

namespace CleanArchitectureApp.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        public Task<bool> AddUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
