using JiraLike.Application.Dtos;
using MediatR;

namespace JiraLike.Application.Abstraction.Query
{
    public class GetAllUserQuery : IRequest<List<GetUserResponseDto>>
    {


    }
}
