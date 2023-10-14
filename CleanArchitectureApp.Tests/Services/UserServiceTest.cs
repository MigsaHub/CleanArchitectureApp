using AutoMapper;
using CleanArchitectureApp.Application.DTO;
using CleanArchitectureApp.Application.Exceptions;
using CleanArchitectureApp.Application.Services.Impl;
using CleanArchitectureApp.Application.Services;
using CleanArchitectureApp.Domain;
using CleanArchitectureApp.Infrastructure.Repository;
using CleanArchitectureApp.Tests.Mocks.RepositoriesMock; 
using Microsoft.Extensions.Configuration;
using Moq;
using CleanArchitectureApp.Application.Mappers;

namespace CleanArchitectureApp.Tests.Services
{
    public class UserServiceTest
    {
        private readonly IMapper _mapper;
        private readonly Mock<IUserService> _userServiceMock;
        private readonly Mock<IUserRepository> _userRepositoryMock;
        private readonly IConfigurationRoot _configuration;
        public UserServiceTest()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserProfile());
            });

            _mapper = new Mapper(mapperConfig);
            _userServiceMock = new Mock<IUserService>();
            _userRepositoryMock = new Mock<IUserRepository>();
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }

        [Fact]
        public async void RegisterUser_WhenRequestOk_ReturnsOk()
        {   //Arrange 

            var userDto = new Mock<UserDto>();
            _userServiceMock.Setup(service => service.Register(It.IsAny<UserDto>())).ReturnsAsync(new User());
            
            //Act
            var result = await _userServiceMock.Object.Register(userDto.Object);
            //Assert 
            Assert.IsType<User>(result);
        }

        [Fact]
        public async Task RegisterUser_BadRequestThrowsException()
        {
            //Arrange 

            var userDto = new Mock<UserDto>();
            _userServiceMock.Setup(service => service.Register(It.IsAny<UserDto>())).Throws(new UserServiceException("test exception", new Exception()));


            //Assert 
            await Assert.ThrowsAnyAsync<UserServiceException>(async () => await _userServiceMock.Object.Register(userDto.Object));
        }

        [Fact]
        public async Task LoginUser_WhenRequestOk_ReturnsOk()
        {   //Arrange 

            var userDto = new Mock<UserDto>();
            _userServiceMock.Setup(service => service.Login(It.IsAny<UserDto>())).ReturnsAsync(string.Empty);

            //Act

            var result = await _userServiceMock.Object.Login(userDto.Object);
            //Assert
            Assert.IsType<string>(result);
        }

        [Fact]
        public async Task GetUser_WhenRequestOk_ReturnsOk()
        {   //Arrange 

            var userDto = new Mock<UserDto>();
            var user = _mapper.Map<User>(userDto.Object);
            _userServiceMock.Setup(service => service.GetUser(It.IsAny<int>())).ReturnsAsync(new User());

            //Act

            var result = await _userServiceMock.Object.GetUser(user.Id);
            //Assert
            Assert.IsType<User>(result);
        }

        [Fact]
        public async Task UpdateUser_WhenRequestOk_ReturnsOk()
        {
            //Arrange 

            var userDto = new Mock<UserDto>();
            _userServiceMock.Setup(service => service.UpdateUser(It.IsAny<UserDto>())).ReturnsAsync(true);

            //Act

            var result = await _userServiceMock.Object.UpdateUser(userDto.Object);
            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task DeleteUser_WhenRequestOk_ReturnsOk()
        {
            //Arrange 

            var userDto = new Mock<UserDto>();
            var user = _mapper.Map<User>(userDto.Object);
            _userServiceMock.Setup(service => service.DeleteUser(It.IsAny<int>())).ReturnsAsync(true);

            //Act

            var result = await _userServiceMock.Object.DeleteUser(user.Id);
            //Assert
            Assert.True(result);
        }
    }
}
