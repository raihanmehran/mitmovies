using Application.v1.DTOs;
using MediatR;

namespace Application.v1.Services.PersonService.Query
{
    public class GetPopularPeopleQuery : IRequest<ResponseMessage>
    {
    }
}