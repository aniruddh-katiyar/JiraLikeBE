namespace JiraLike.Domain.Dtos
{
    public record UserResponseDto
    {
        public Guid UserId { get; set; }           // Unique identifier for the user
        public string? Username { get; set; }   // Chosen username
        public string? Email { get; set; }      // User email
        public string? Role { get; set; }       // Assigned role (e.g., Admin, User)
        public DateTime CreatedAt { get; set; } // Timestamp when user was created
        public bool Success { get; set; }      // Indicates if add operation succeeded
        public string? Message { get; set; }    // Optional message (e.g., "User created successfully")

    }
}
