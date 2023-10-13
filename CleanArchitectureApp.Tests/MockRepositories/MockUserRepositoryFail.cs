using CleanArchitectureApp.Domain;
using CleanArchitectureApp.Infrastructure.Repository; 

namespace CleanArchitectureApp.Tests.MockRepositories
{
    public class MockUserRepositoryFail : IUserServiceRepository
    {
        public Task<bool> AddUser(User user)
        {
            throw new Exception();
        }

    }
}
