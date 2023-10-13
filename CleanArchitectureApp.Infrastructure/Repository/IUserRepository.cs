using CleanArchitectureApp.Domain; 

namespace CleanArchitectureApp.Infrastructure.Repository
{
    public interface IUserRepository
    {
        public Task<bool> AddUser(User user);
        public Task<User> GetUserById(int userId);
        public Task<bool> DeleteUser(int userId);
        public Task<bool> UpdateUser(User user);

    }

}
