using AutoMapper;
using CleanArchitectureApp.Application.DTO;
using CleanArchitectureApp.Application.Exceptions;
using CleanArchitectureApp.Domain;
using CleanArchitectureApp.Infrastructure.Repository; 

namespace CleanArchitectureApp.Application.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserServiceRepository _userServiceRepository;
        private readonly IMapper _mapper;
        public UserService(IUserServiceRepository userServiceRepository, IMapper mapper)
        {
            _userServiceRepository = userServiceRepository;
            _mapper = mapper;
        }

        public async Task<bool> Register(UserDto userDto)
        {
            try
            {
                var user = _mapper.Map<User>(userDto);
                var result = await _userServiceRepository.AddUser(user);
                return result;
            }
            catch (Exception ex)
            {
                throw new UserServiceException(ex);
            }
        }
    }
}
