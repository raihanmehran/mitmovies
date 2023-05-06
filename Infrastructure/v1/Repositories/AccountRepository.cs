using Application.v1.DTOs;
using Application.v1.Interfaces;
using AutoMapper;
using Domain.v1.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.v1.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        public AccountRepository(UserManager<AppUser> userManager, IMapper mapper)
        {
            _mapper = mapper;
            _userManager = userManager;
        }
        public async Task<ResponseMessage> RegisterUser(RegisterUserDto registerUserDto)
        {
            var response = new ResponseMessage();

            if (await UserExists(username: registerUserDto.Username))
            {
                response.StatusCode = 400;
                response.Message = "Username is taken";
                return response;
            }

            var user = _mapper.Map<AppUser>(source: registerUserDto);
            user.UserName = registerUserDto.Username;

            var result = await _userManager
                .CreateAsync(user: user, password: registerUserDto.Password);

            if (!result.Succeeded)
            {
                response.StatusCode = 400;
                response.Message = "Something went wrong while registering a new user";
                return response;
            }

            var roleResult = await _userManager.AddToRoleAsync(user: user, role: "Member");

            if (!roleResult.Succeeded)
            {
                response.StatusCode = 400;
                response.Message = roleResult.Errors.ToString();
                return response;
            }

            response.StatusCode = 200;
            response.Message = "User Registered";
            response.Data = _mapper.Map<MemberDto>(source: user);

            return response;
        }

        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(u =>
                u.UserName == username);
        }
    }
}