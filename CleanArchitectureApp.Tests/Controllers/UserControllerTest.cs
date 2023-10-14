using CleanArchitectureApp.Application.DTO;
using CleanArchitectureApp.Application.Services;
using CleanArchitectureApp.Controllers; 
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CleanArchitectureApp.Tests.Controllers
{
    public class UserControllerTest
    {
        private readonly Mock<IUserService> _userServiceMock;

        public UserControllerTest()
        {
            _userServiceMock = new Mock<IUserService>();
        }

        [Fact]
        public async Task Register_OnSuccessReturnsStatusCode200()
        {
            //Arrange 
            var userDtoModel = new Mock<UserDto>();
            _userServiceMock
                .Setup(service => service.Register(It.IsAny<UserDto>())).ReturnsAsync(new Domain.User());

            var sut = new UserController(_userServiceMock.Object);

            //Act
            var result = (OkObjectResult)await sut.Register(userDtoModel.Object);

            //Assert
            result.StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task GetUser_OnSuccessReturnsStatusCode200()
        {
            //Arrange 
            var userDtoModel = new Mock<UserDto>();
            _userServiceMock
                .Setup(service => service.GetUser(It.IsAny<int>())).ReturnsAsync(new Domain.User() { Id=1});

            var sut = new UserController(_userServiceMock.Object);

            //Act
            var result = (OkObjectResult)await sut.GetUser(1);

            //Assert
            result.StatusCode.Should().Be(200);
        }
        [Fact]
        public async Task Login_OnSuccessReturnsStatusCode200()
        {
            //Arrange 
            var userDtoModel = new Mock<UserDto>();
            _userServiceMock
                .Setup(service => service.Login(It.IsAny<UserDto>())).ReturnsAsync(string.Empty);

            var sut = new UserController(_userServiceMock.Object);

            //Act
            var result = (OkObjectResult)await sut.Login(userDtoModel.Object);

            //Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task UpdateUser_OnSuccessReturnsStatusCode200()
        {
            //Arrange 
            var userDtoModel = new Mock<UserDto>();
            _userServiceMock
                .Setup(service => service.UpdateUser(It.IsAny<UserDto>())).ReturnsAsync(true);

            var sut = new UserController(_userServiceMock.Object);

            //Act
            var result = (OkObjectResult)await sut.UpdateUser(userDtoModel.Object);

            //Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task DeleteUser_OnSuccessReturnsStatusCode200()
        {
            //Arrange 
            var userDtoModel = new Mock<UserDto>();
            _userServiceMock
                .Setup(service => service.DeleteUser(It.IsAny<int>())).ReturnsAsync(true);
            _userServiceMock
                .Setup(service => service.GetUser(It.IsAny<int>())).ReturnsAsync(new Domain.User() { Id=1});
                

            var sut = new UserController(_userServiceMock.Object);

            //Act
            var result = (OkObjectResult)await sut.DeleteUserById(1);

            //Assert
            result.StatusCode.Should().Be(200);
        }


    }
}
