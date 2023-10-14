using CleanArchitectureApp.Application.DTO; 

namespace CleanArchitectureApp.Application.Services
{
    public interface IUserService { 
        Task<bool> Register(UserDto userDto);
        Task<string> Login(UserDto userDto);
        Task<bool> UpdateUser(UserDto userDto);
        Task<bool> DeleteUser(string email);
        Task<UserDto> GetUser(string email);

    }
}

