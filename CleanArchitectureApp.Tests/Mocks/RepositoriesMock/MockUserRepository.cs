using CleanArchitectureApp.Domain;
using CleanArchitectureApp.Infrastructure.Repository;

namespace CleanArchitectureApp.Tests.Mocks.RepositoriesMock
{

    public class MockUserRepository : IUserRepository
    {
        public Task<bool> AddUser(User user)
        {
            return Task.FromResult(true);
        }

    }
}
