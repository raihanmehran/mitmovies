using Application.v1.DTOs;
using Application.v1.Interfaces;
using Application.v1.Utils;
using MediatR;

namespace Application.v1.Services.UserService.Query
{
    public class GetMembersQueryHandler : IRequestHandler<GetMembersQuery, PagedList<MemberDto>>
    {
        private readonly IUserRepository _userRepository;
        public GetMembersQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<PagedList<MemberDto>> Handle(GetMembersQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetMembersAsync(userParams: request.UserParams);
        }
    }
}