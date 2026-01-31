namespace JiraLike.Application.Dtos.Auth
{
    public sealed record AuthResponseDto
    {
        public Guid? UserId { get; init; }
        public string AccessToken { get; init; } = null!;

        public string RefreshToken { get; init; } = null!;
    }
}
