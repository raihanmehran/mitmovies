using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.UserService.Query
{
    public class GetMemberByUserIdQueryHandler : IRequestHandler<GetMemberByUserIdQuery, ResponseMessage>
    {
        private readonly IUserRepository _userRepository;
        public GetMemberByUserIdQueryHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<ResponseMessage> Handle(GetMemberByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.GetMemberByUserIdAsync(userId: request.UserId);
        }
    }
}