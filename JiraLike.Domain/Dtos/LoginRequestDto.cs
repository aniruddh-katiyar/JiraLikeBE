namespace JiraLike.Domain.Dtos
{
    public sealed record LoginRequestDto
    {
        public required string Email { get; init; }

        public required string Password { get; init; }
    }
}
