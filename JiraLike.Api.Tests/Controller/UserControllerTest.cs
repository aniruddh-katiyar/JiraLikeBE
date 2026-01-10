//Unit Test for user Controller
namespace JiraLike.Api.Tests.Controller
{
    using JiraLike.Api.Controllers;
    using JiraLike.Application.Abstraction.Command;
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using Moq;
    using Xunit;

    public class UsersControllerTest
    {
        private readonly Mock<IMediator> _mockMediator;
        private readonly Mock<ILogger<UsersController>> _mockLogger;
        private readonly UsersController _controller;

        public UsersControllerTest()
        {
            _mockMediator = new Mock<IMediator>();
            _mockLogger = new Mock<ILogger<UsersController>>();
            _controller = new UsersController(_mockMediator.Object, _mockLogger.Object);
        }

        [Fact]
        public async Task CreateUserAsync_ShouldReturnOkResult_WhenUserIsCreated()
        {
            // Arrange
            var requestDto = SeedData.GetUserRequest();
            var responseDto = SeedData.GetUserResponse();

            _mockMediator
                .Setup(x => x.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()))
                .ReturnsAsync(responseDto);

            // Act
            var result = await _controller.CreateUserAsync(requestDto, CancellationToken.None);

            // Assert
            var okResult = Assert.IsType<CreatedResult>(result);
            Assert.Equal(responseDto, okResult.Value);

            // Verify
            _mockMediator.Verify(
                x => x.Send(It.IsAny<CreateUserCommand>(), It.IsAny<CancellationToken>()),
                Times.Once);
        }
    }
}
