namespace JiraLike.Application.Dtos
{
    public record GetUserResponseDto
    {
        public Guid UserId { get; set; }          
        public string? Username { get; set; }  
        public string? Email { get; set; }     
        public string? Role { get; set; }      
        public DateTime CreatedAt { get; set; }
        public bool Success { get; set; }   
        public string? Message { get; set; }  

    }
}
