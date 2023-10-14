using CleanArchitectureApp.Application.DTO;
using CleanArchitectureApp.Domain;

namespace CleanArchitectureApp.Application.Services
{
    public interface IUserService { 
        Task<User> Register(UserDto userDto);
        Task<string> Login(UserDto userDto);
        Task<bool> UpdateUser(UserDto userDto);
        Task<bool> DeleteUser(int userId);
        Task<User> GetUser(int userId);

    }
}

