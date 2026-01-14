namespace JiraLike.Application.Dtos
{
    public sealed record AddUserRequestDto
    {
        public required string Name { get; init; }
        public required string Email { get; init; }
        public required string Password { get; init; }
        public required string Role { get; init; }
    }

}
