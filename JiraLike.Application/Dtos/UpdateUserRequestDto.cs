namespace JiraLike.Application.Dtos
{
    public sealed record class UpdateUserRequestDto
    {
        public  string? Name { get; init; }
        public  string? Email { get; init; }
        public  string? Role { get; init; }
    }
}
