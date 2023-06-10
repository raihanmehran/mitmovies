using Application.v1.DTOs;
using Application.v1.Interfaces;
using AutoMapper;
using Domain.v1.Entities;
using Infrastructure.v1.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.v1.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        public AuthRepository(UserManager<AppUser> userManager, ITokenService tokenService, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _tokenService = tokenService;
        }
        public async Task<ResponseMessage> AuthenticateUser(AuthDto authDto)
        {
            var response = new ResponseMessage();
            var user = await _userManager.Users
                .SingleOrDefaultAsync(u => u.UserName == authDto.Username);

            if (user == null)
            {
                response.StatusCode = 401;
                response.Message = "Invalid Username";
                return response;
            }

            var result = await _userManager
                .CheckPasswordAsync(user: user, password: authDto.Password);

            if (!result)
            {
                response.StatusCode = 401;
                response.Message = "Invalid Password";
                return response;
            }

            var userDto = new UserDto
            {
                UserId = user.Id,
                FirstName = user.FirstName,
                Username = user.UserName,
                Token = await _tokenService.CreateToken(user: user)
            };

            response.StatusCode = 200;
            response.Data = userDto;
            return response;
        }
    }
}