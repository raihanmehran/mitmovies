using Application.v1.DTOs;
using MediatR;

namespace Application.v1.Services.PersonService.Query
{
    public class GetPersonByIdQuery : IRequest<ResponseMessage>
    {
        public int PersonId { get; set; }
    }
}