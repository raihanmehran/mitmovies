using Application.v1.DTOs;
using Application.v1.Interfaces;
using MediatR;

namespace Application.v1.Services.AccountService.Command
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, ResponseMessage>
    {
        private readonly IAccountRepository _accountRepository;
        public RegisterUserCommandHandler(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<ResponseMessage> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return await _accountRepository.RegisterUser(registerUserDto: request.RegisterUserDto);
        }
    }
}