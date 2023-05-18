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
            if (await UserExists(username: registerUserDto.Username)) return Response(
                    statusCode: 400, message: "Username is taken");

            var user = _mapper.Map<AppUser>(source: registerUserDto);
            user.UserName = registerUserDto.Username;

            var result = await _userManager
                .CreateAsync(user: user, password: registerUserDto.Password);

            if (!result.Succeeded) return Response(
                statusCode: 400, message: "Something went wrong while registering a new user");

            var roleResult = await _userManager.AddToRoleAsync(user: user, role: "Member");

            if (!roleResult.Succeeded) return Response(
                statusCode: 400, message: roleResult.Errors.ToString());

            return Response(statusCode: 200, message: "User Registered",
                data: _mapper.Map<MemberDto>(source: user));
        }

        private async Task<bool> UserExists(string username)
        {
            return await _userManager.Users.AnyAsync(u =>
                u.UserName == username);
        }
        public async Task<ResponseMessage> GetUsersWithRoleAsync()
        {
            var users = await _userManager.Users
                .OrderBy(u => u.UserName)
                .Select(u => new
                {
                    u.Id,
                    Username = u.UserName,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Roles = u.UserRoles.Select(r => r.Role.Name).ToList()
                }).ToListAsync();

            return (users.Count > 0)
                ? Response(statusCode: 200,
                    message: "Data Fetched Successfully", data: users)
                : Response(statusCode: 404, message: "Users Not Found");
        }

        public async Task<ResponseMessage> EditUserRolesAsync(AppUser user, string roles)
        {
            if (user == null) return Response(
                statusCode: 404, message: "User Not Found");

            if (string.IsNullOrEmpty(roles)) return Response(
                statusCode: 400, message: "You must select at least one role");

            var selectedRoles = roles.Split(",".ToArray());
            var userRoles = await _userManager.GetRolesAsync(user: user);

            var result = await _userManager.AddToRolesAsync(user: user,
                roles: selectedRoles.Except(userRoles));

            if (!result.Succeeded) return Response(statusCode: 400,
                message: "Failed To Add To Roles");

            result = await _userManager.RemoveFromRolesAsync(user: user,
                roles: userRoles.Except(selectedRoles));

            if (!result.Succeeded) return Response(statusCode: 400,
                message: "Failed To Remove From Roles");

            return Response(statusCode: 200, message: "User Roles Edited",
                data: await _userManager.GetRolesAsync(user: user));
        }

        private ResponseMessage Response(int statusCode, string message, object data = null)
        {
            var response = new ResponseMessage();
            response.StatusCode = statusCode;
            response.Message = message;
            response.Data = data;

            return response;
        }
    }
}