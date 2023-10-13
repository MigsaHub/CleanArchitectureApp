namespace CleanArchitectureApp.Tests.Controllers
{
    public class UserControllerTest
    {
        [Fact]
        public async Task RegisterUser_ThrowsException()
        {
            //Arrange
            IUserServiceRepository userServiceRepository = new MockUserRepository();

            var userDto = new UserDto();
            var service = new UserService(userServiceRepository);
            //Act
            //Assert 
            await Assert.ThrowsAnyAsync<UserServiceException>(async () => await service.Register(userDto));
        }


        [Fact]
        public void LoginUser_WhenRequestIsOk_Successfull()
        {

        }

        [Fact]
        public void UpdateUser_WhenRequestIsOk_Successfull()
        {

        }

        [Fact]
        public void DeleteUser_WhenRequestIsOk_Successfull()
        {

        }
 
    }
    public class MockUserRepository : IUserServiceRepository
    {
        public Task<bool> AddUser(UserDto userDto)
        {
            throw new NotImplementedException();
        }
    }

    public interface IUserServiceRepository
    {
        public Task<bool> AddUser(UserDto userDto);
    }

    public class UserServiceException : Exception
    {
    }

    public class UserService
    {  
        private readonly IUserServiceRepository _userServiceRepository;
        public UserService(IUserServiceRepository? userServiceRepository)
        {
            _userServiceRepository = userServiceRepository;
        }

        public async Task<bool> Register(UserDto userDto)
        {
           var result= await _userServiceRepository.AddUser(userDto);
           return result;
        }
    }

    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public UserDto() { }
    }
}
