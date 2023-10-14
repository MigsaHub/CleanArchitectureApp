﻿using AutoMapper;
using CleanArchitectureApp.Application.DTO;
using CleanArchitectureApp.Application.Exceptions;
using CleanArchitectureApp.Domain;
using CleanArchitectureApp.Infrastructure.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace CleanArchitectureApp.Application.Services.Impl
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        public UserService(IUserRepository userRepository, IMapper mapper, IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _configuration = configuration;
        }
        public async Task<UserDto> GetUser(string email)
        {
            try
            {
                var result = await _userRepository.GetUserByMail(email);
                var userDto = _mapper.Map<UserDto>(result); 
                return userDto;
            }
            catch (Exception ex)
            {
                throw new UserServiceException(ex.Message, ex.InnerException);
            }
        }
        public async Task<bool> DeleteUser(string email)
        {
            try
            {
                var result = await _userRepository.DeleteUser(email);
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
                var result = await _userRepository.GetUserByMail(userDto.Email);
                if (result == null)
                {
                    throw new UserServiceException("User doesn't exist, verify your credentials");
                }
                else
                {
                    if (!Decrypt(userDto.Password, result.PasswordHash, result.PasswordSalt))
                    {
                        throw new UserServiceException("Password Incorrect");
                    }
                    var user = _mapper.Map<User>(userDto);

                    string token = CreateToken(user);
                    return token;
                }
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
                Encrypt(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                var user = _mapper.Map<User>(userDto);
                user.PasswordHash = passwordHash;
                user.PasswordSalt = passwordSalt;

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
            {  //CHECK
                var userById = await _userRepository.GetUserByMail(userDto.Email);
                if (userById == null)
                {
                    throw new UserServiceException("User doesn't exist, verify your credentials");
                }
                else 
                {
                    Encrypt(userDto.Password, out byte[] passwordHash, out byte[] passwordSalt);
                    var user = _mapper.Map<User>(userDto);
                    user.Id = userById.Id;
                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;

                    var result = await _userRepository.UpdateUser(user);
                    return result;
                } 
            }
            catch (Exception ex)
            {
                throw new UserServiceException(ex.Message, ex.InnerException);
            }
        }

        #region SecurityRegion

        //cryptography
        private void Encrypt(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool Decrypt(string password, byte[] passwordHash, byte[] passwordSalt)
        {

            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }

        private string CreateToken(User user)
        {
            List<Claim> claims = new List<Claim>() { new Claim(ClaimTypes.Name, user.Name) };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("JwtBearer:Token").Value!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public Task<bool> DeleteUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
