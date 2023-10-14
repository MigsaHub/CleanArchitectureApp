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

    }
}
