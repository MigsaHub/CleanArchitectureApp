using CleanArchitectureApp.Application.DTO;
using CleanArchitectureApp.Application.Services;
using Moq;

namespace CleanArchitectureApp.Tests.Mocks.ServicesMocks
{
    public static class UserServiceMock
    { 
        internal static Mock<IUserService> GetIUserServiceMock()
        {
            var serviceMock = new Mock<IUserService>();
            serviceMock.Setup(s => s.Register(It.IsAny<UserDto>())).ReturnsAsync(true);

            return serviceMock;
        }

    }
}
