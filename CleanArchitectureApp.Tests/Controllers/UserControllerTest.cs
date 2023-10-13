using AutoMapper;
using CleanArchitectureApp.Application.DTO;
using CleanArchitectureApp.Application.Exceptions;
using CleanArchitectureApp.Application.Mappers;
using CleanArchitectureApp.Application.Services.Impl;
using CleanArchitectureApp.Infrastructure.Repository;
using CleanArchitectureApp.Tests.MockRepositories;

namespace CleanArchitectureApp.Tests.Controllers
{
    public class UserControllerTest
    {
        [Fact]
        public async Task RegisterUser_ThrowsException()
        {
            //Arrange
            IUserRepository userRepository = new MockUserRepositoryFail();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserProfile());
            });

            IMapper mapper = new Mapper(mapperConfig);
            var userDto = new UserDto();
            var service = new UserService(userRepository, mapper);

            //Assert 
            await Assert.ThrowsAnyAsync<UserServiceException>(async () => await service.Register(userDto));
        }
        [Fact]
        public async void RegisterUser_WhenRequestIsOk_Successfull()
        {   //Arrange
            IUserRepository userRepository = new MockUserRepository();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UserProfile());
            });

            IMapper mapper = new Mapper(mapperConfig);
            var userDto = new UserDto();
            var service = new UserService(userRepository, mapper);
            //Act
            var result = await service.Register(userDto);
            //Assert 
             Assert.True(result);
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
