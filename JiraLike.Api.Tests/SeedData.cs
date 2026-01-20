namespace JiraLike.Api.Tests
{
    using JiraLike.Application.Dto;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public static class SeedData
    {
        public static GetUserResponseDto GetUserResponse()
        {
            return new GetUserResponseDto
            {
                UserId = Guid.NewGuid(),
                Username = "Amit",
                Email ="Amit@gmail.com",
                Success = true
            };
        }
        public static UpdateUserRequestDto GetUserRequest()
        {
            return new UpdateUserRequestDto
            {
                Name = "Amit",
           
            };
        }
    }
}
