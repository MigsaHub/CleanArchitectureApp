using CleanArchitectureApp.Domain;
using CleanArchitectureApp.Infrastructure.Repository; 

namespace CleanArchitectureApp.Tests.MockRepositories
{
    public class MockUserRepositoryFail : IUserRepository
    {
        public Task<bool> AddUser(User user)
        {
            throw new Exception();
        }

    }
}
