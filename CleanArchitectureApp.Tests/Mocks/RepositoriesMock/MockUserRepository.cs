using CleanArchitectureApp.Domain;
using CleanArchitectureApp.Infrastructure.Repository;

namespace CleanArchitectureApp.Tests.Mocks.RepositoriesMock
{

    public class MockUserRepository : IUserRepository
    {
        public Task<int> AddUser(User user)
        {
            return Task.FromResult(0);
        }

        public Task<bool> DeleteUser(int userId)
        {
            return Task.FromResult(true);
        }

        public Task<User> GetUserByEmail(string email)
        {
            return Task.FromResult(new User());
        }

        public Task<User> GetUserById(int userId)
        {
            return Task.FromResult(new User());
        }

        public Task<bool> UpdateUser(User user)
        {
            return Task.FromResult(true);
        }
    }
}
