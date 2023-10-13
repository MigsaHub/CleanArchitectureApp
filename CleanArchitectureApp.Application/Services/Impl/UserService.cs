using AutoMapper;
using CleanArchitectureApp.Application.DTO;
using CleanArchitectureApp.Application.Exceptions;
using CleanArchitectureApp.Domain;
using CleanArchitectureApp.Infrastructure.Repository; 

namespace CleanArchitectureApp.Application.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
        public async Task<UserDto> GetUser(int userId)
        {
            try
            {
                var result = await _userRepository.GetUserById(userId);
                var userDto = _mapper.Map<UserDto>(result);
                return userDto;
            }
            catch (Exception ex)
            {
                throw new UserServiceException(ex.Message, ex.InnerException);
            }
        }
        public async Task<bool> DeleteUser(int userId)
        {
            try
            {
                var result = await _userRepository.DeleteUser(userId);
                return result; 
            }
            catch (Exception ex)
            {
                throw new UserServiceException(ex.Message, ex.InnerException);
            }
        }

        public async Task<string> Login(UserDto userDto)
        {
            try
            {
                var result = await _userRepository.GetUserById(userDto.Id);

                if (result == null)
                {
                    throw new UserServiceException("User doesnt exist, verify your credentials");
                }
                else
                    return string.Empty; // return token or validation
            }
            catch (Exception ex)
            {
                throw new UserServiceException(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> Register(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                var result = await _userRepository.AddUser(user);
                return result;
            }
            catch (Exception ex)
            {
                throw new UserServiceException(ex.Message,ex.InnerException);
            }
        }

        public async Task<bool> UpdateUser(UserDto userDto)
        {
            try
            {
                //pending verify if user exist
                var user = _mapper.Map<User>(userDto);
                var result = await _userRepository.UpdateUser(user);
                return result;
            }
            catch (Exception ex)
            {
                throw new UserServiceException(ex.Message, ex.InnerException);
            }
        }

    }
}
