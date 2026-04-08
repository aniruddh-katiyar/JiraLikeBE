namespace JiraLike.Application.Dtos.User
{
    using System;

    public class UserResponseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public bool IsActive { get; set; }
        public string? ShortCode { get; set; }

        public string? UserSequence { get; set; }
    }

}
