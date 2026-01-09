namespace JiraLike.Api.Tests
{
    using JiraLike.Domain.Dtos;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class SeedData
    {
        public static UserResponseDto GetUserResponse()
        {
            return new UserResponseDto
            {
                UserId = Guid.NewGuid(),
                Username = "Amit",
                Email ="Amit@gmail.com",
                Success = true
            };
        }
        public static UserRequestDto GetUserRequest()
        {
            return new UserRequestDto
            {
                Name = "Amit",
                Email = "Amit@gmail.com",
                Password = "Amit@123",
                Role = "Admin"
            };
        }
    }
}
