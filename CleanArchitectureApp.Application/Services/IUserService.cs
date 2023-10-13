using CleanArchitectureApp.Application.DTO; 

namespace CleanArchitectureApp.Application.Services
{
    public interface IUserService
    {
        Task<bool> Register(UserDto userDto);
    }
}
