namespace JiraLike.Domain.Dtos
{
    public sealed record AuthResponseDto
    {
        public required string AccessToken { get; init; } 

        public required string RefreshToken { get; init; }
    }
}
