namespace JiraLike.Application.Dto
{
    public sealed record AuthResponseDto
    {
        public string AccessToken { get; init; } = null!;

        public string RefreshToken { get; init; } = null!;
    }
}
