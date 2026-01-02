namespace JiraLike.Application.Abstraction.Command
{
    using JiraLike.Domain.Dtos;
    using MediatR;

    public sealed class LoginUserCommand : IRequest<AuthResponseDto>
    {
        public LoginRequestDto LoginRequestDto { get; }
        public LoginUserCommand(LoginRequestDto loginRequestDto)
        {
            LoginRequestDto = loginRequestDto;
        }
    }
}
