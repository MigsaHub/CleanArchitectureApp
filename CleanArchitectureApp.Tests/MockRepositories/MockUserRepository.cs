using CleanArchitectureApp.Domain;
using CleanArchitectureApp.Infrastructure.Repository; 

namespace CleanArchitectureApp.Tests.MockRepositories
{

    public class MockUserRepository : IUserServiceRepository
    {
        public Task<bool> AddUser(User user)
        {
            return Task.FromResult(true);
        }

    }
}
