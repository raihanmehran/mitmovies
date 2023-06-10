using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.AccountService.Command
{
    public class EditUserRolesCommandHandler : IRequestHandler<EditUserRolesCommand, ResponseMessage>
    {
        private readonly IAccountRepository _accountRepository;
        public EditUserRolesCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<ResponseMessage> Handle(EditUserRolesCommand request, CancellationToken cancellationToken)
        {
            return await _accountRepository.EditUserRolesAsync(
                user: request.User, roles: request.Roles);
        }
    }
}