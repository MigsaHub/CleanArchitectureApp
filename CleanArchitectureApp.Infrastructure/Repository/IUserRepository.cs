using CleanArchitectureApp.Domain; 

namespace CleanArchitectureApp.Infrastructure.Repository
{
    public interface IUserRepository
    {
        public Task<bool> AddUser(User user);
    }

}
