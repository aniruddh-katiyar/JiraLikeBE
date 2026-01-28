namespace JiraLike.Application.Dto.Auth
{
    public sealed record AuthResponseDto
    {
        public string AccessToken { get; init; } = null!;

        public string RefreshToken { get; init; } = null!;
    }
}
