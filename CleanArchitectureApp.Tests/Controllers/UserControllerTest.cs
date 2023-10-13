using AutoMapper;
using CleanArchitectureApp.Application.DTO;
using CleanArchitectureApp.Application.Exceptions;
using CleanArchitectureApp.Application.Mappers;
using CleanArchitectureApp.Application.Services;
using CleanArchitectureApp.Application.Services.Impl;
using CleanArchitectureApp.Infrastructure.Repository; 
using CleanArchitectureApp.Tests.Mocks.RepositoriesMock;
using CleanArchitectureApp.Tests.Mocks.ServicesMocks;
using Moq;

namespace CleanArchitectureApp.Tests.Controllers
{
    public class UserControllerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserService> _userServiceMock;
        public UserControllerTest() 
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserProfile());
            });

            _mapper = new Mapper(mapperConfig);
            _userServiceMock = UserServiceMock.GetIUserServiceMock();
        }

        [Fact]
        public async void RegisterUser_WhenRequestIsOk_Successfull()
        {   //Arrange
            IUserRepository userRepository = new MockUserRepository();

            var userDto = new UserDto(); 
            //Act
            var result = await _userServiceMock.Object.Register(userDto);
            //Assert 
            Assert.True(result);
        }

        [Fact]
        public async Task RegisterUser_ThrowsException()
        {
            //Arrange
            IUserRepository userRepository = new MockUserRepositoryFail();

            var userDto = new UserDto();
            var service = new UserService(userRepository, _mapper);

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
     
}
