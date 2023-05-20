using Application.v1.DTOs;
using Application.v1.Utils;
using MediatR;

namespace Application.v1.Services.UserService.Query
{
    public class GetMembersQuery : IRequest<PagedList<MemberDto>>
    {
        public UserParams UserParams { get; set; }
    }
}