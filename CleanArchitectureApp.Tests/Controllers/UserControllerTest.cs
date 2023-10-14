using AutoMapper;
using CleanArchitectureApp.Application.DTO;
using CleanArchitectureApp.Application.Exceptions;
using CleanArchitectureApp.Application.Mappers;
using CleanArchitectureApp.Application.Services;
using CleanArchitectureApp.Application.Services.Impl;
using CleanArchitectureApp.Domain;
using CleanArchitectureApp.Infrastructure.Repository; 
using CleanArchitectureApp.Tests.Mocks.RepositoriesMock;
using CleanArchitectureApp.Tests.Mocks.ServicesMocks;
using Microsoft.Extensions.Configuration;
using Moq;

namespace CleanArchitectureApp.Tests.Controllers
{
    public class UserControllerTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserService> _userServiceMock;
        private readonly IConfigurationRoot _configuration;
        public UserControllerTest() 
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserProfile());
            });

            _mapper = new Mapper(mapperConfig);
            _userServiceMock = UserServiceMock.GetIUserServiceMock();
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }

        [Fact]
        public async void RegisterUser_OnSuccessReturnsStatusCode200()
        {   //Arrange
            IUserRepository userRepository = new MockUserRepository();

            var userDto = new Mock<UserDto>();
            var service = new UserService(userRepository, _mapper, _configuration);
            //Act
            var result = await service.Register(userDto.Object);
            //Assert 
            Assert.IsType<User>(result);
        }

        [Fact]
        public async Task RegisterUser_BadRequestThrowsException()
        {
            //Arrange
            IUserRepository userRepository = new MockUserRepositoryFail();

            var userDto = new Mock<UserDto>();
            var service = new UserService(userRepository, _mapper, _configuration);

            //Assert 
            await Assert.ThrowsAnyAsync<UserServiceException>(async () => await service.Register(userDto.Object));
        }

       //Pending Ajusts Mocking
        public async Task LoginUser_OnSuccessReturnsStatusCode200()
        {   //Arrange
            IUserRepository userRepository = new MockUserRepository();

            var userDto = new Mock<UserDto>();
            var service = new UserService(userRepository, _mapper,_configuration);
            //Act

            var result = await service.Login(userDto.Object);
            //Assert
            Assert.IsType<string>(result);
        }

        [Fact]
        public async Task GetUser_OnSuccessReturnsStatusCode200()
        {   //Arrange
            IUserRepository userRepository = new MockUserRepository();

            var userDto = new Mock<UserDto>();
            var user = _mapper.Map<User>(userDto.Object);
            var service = new UserService(userRepository, _mapper, _configuration);
            //Act

            var result = await service.GetUser(user.Id);
            //Assert
            Assert.IsType<User>(result);
        }

        [Fact]
        public async Task UpdateUser_OnSuccessReturnsStatusCode200()
        {
            //Arrange
            IUserRepository userRepository = new MockUserRepository();

            var userDto = new Mock<UserDto>();
            var service = new UserService(userRepository, _mapper, _configuration);
            //Act

            var result = await service.UpdateUser(userDto.Object);
            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteUser_OnSuccessReturnsStatusCode200()
        {
            //Arrange
            IUserRepository userRepository = new MockUserRepository();

            var userDto = new Mock<UserDto>();
            var user =_mapper.Map<User>(userDto.Object);
            var service = new UserService(userRepository, _mapper, _configuration);
            //Act

            var result = await service.DeleteUser(user.Id);
            //Assert
            Assert.True(result);
        }
    }
}
