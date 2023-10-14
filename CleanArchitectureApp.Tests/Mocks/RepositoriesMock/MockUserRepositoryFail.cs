using CleanArchitectureApp.Domain;
using CleanArchitectureApp.Infrastructure.Repository;

namespace CleanArchitectureApp.Tests.Mocks.RepositoriesMock
{
    public class MockUserRepositoryFail : IUserRepository
    {
        public Task<bool> AddUser(User user)
        {
            throw new Exception();
        }

        public Task<bool> DeleteUser(string emailUser)
        {
            throw new Exception();
        } 
        public Task<User> GetUserByMail(string emailUser)
        {
          throw new Exception(); 
        }

        public Task<bool> UpdateUser(User user)
        {
        throw new Exception();
       }
    }
}
