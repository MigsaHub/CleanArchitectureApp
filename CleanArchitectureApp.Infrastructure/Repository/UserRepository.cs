using CleanArchitectureApp.Domain; 

namespace CleanArchitectureApp.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        public Task<bool> AddUser(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetUserById(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
