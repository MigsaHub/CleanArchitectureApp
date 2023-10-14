using CleanArchitectureApp.Domain; 

namespace CleanArchitectureApp.Infrastructure.Repository
{
    public interface IUserRepository
    {
        public Task<bool> AddUser(User user);
        public Task<User> GetUserByMail(string emailUser);
        public Task<bool> DeleteUser(string emailUser);
        public Task<bool> UpdateUser(User user);

    }

}
