using AutoMapper;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NubimetricsChallenge.Application.DTOs;
using NubimetricsChallenge.Application.Interfaces.Services;
using NubimetricsChallenge.WebAPI.Controllers;
using NubimetricsChallenge.WebAPI.UnitTests.Fixtures;
using Xunit;

namespace NubimetricsChallenge.WebAPI.UnitTests.Systems.Controllers
{
    public class TestUsersController
    {
        [Fact]
        public async Task GetAllUsers_OnSuccess_ReturnsStatusCode200()
        {
            //Arrange
            var mockUserServices = new Mock<IUsersServices>();
            var mockMapper = new Mock<IMapper>();

            mockUserServices
                .Setup(service => service.GetAllUsersAsync())
                .ReturnsAsync(UsersFixture.GetAllTestUsers);

            var sut = new UsersController(mockUserServices.Object, mockMapper.Object);

            //Act
            var result = await sut.Get();

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            var objectResult = (OkObjectResult)result;
            objectResult.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetAllUsers_OnSuccess_InvokesUserServicesExactlyOnce()
        {
            //Arrange
            var mockUserServices = new Mock<IUsersServices>();
            var mockMapper = new Mock<IMapper>();

            mockUserServices
                .Setup(service => service.GetAllUsersAsync())
                .ReturnsAsync(new List<UserDTO>());

            var sut = new UsersController(mockUserServices.Object, mockMapper.Object);

            //Act
            var result = await sut.Get();

            //Assert
            mockUserServices.Verify(service => service.GetAllUsersAsync(), Times.Once());
        }

        [Fact]
        public async Task GetAllUsers_OnSuccess_ReturnsListOfUsers()
        {
            //Arrange
            var mockUserServices = new Mock<IUsersServices>();
            var mockMapper = new Mock<IMapper>();

            mockUserServices
                .Setup(service => service.GetAllUsersAsync())
                .ReturnsAsync(UsersFixture.GetAllTestUsers);

            var sut = new UsersController(mockUserServices.Object, mockMapper.Object);

            //Act
            var result = await sut.Get();

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            var objectResult = (OkObjectResult)result;
            objectResult.StatusCode.Should().Be(200);
            objectResult.Value.Should().BeOfType<List<UserDTO>>();
        }

        [Fact]
        public async Task GetAllUsers_OnNoUsersFound_ReturnsStatusCode204()
        {
            //Arrange
            var mockUserServices = new Mock<IUsersServices>();
            var mockMapper = new Mock<IMapper>();

            mockUserServices
                .Setup(service => service.GetAllUsersAsync())
                .ReturnsAsync(UsersFixture.GetNoTestUsers);

            var sut = new UsersController(mockUserServices.Object, mockMapper.Object);

            //Act
            var result = await sut.Get();

            //Assert
            result.GetType().Should().Be(typeof(NoContentResult));
            var objectResult = (NoContentResult)result;
            objectResult.StatusCode.Should().Be(204);
        }

        
        [Fact]
        public async Task GetUserById_OnSucces_ReturnsStatusCode200()
        {
            //Arrange
            var mockUserServices = new Mock<IUsersServices>();
            var mockMapper = new Mock<IMapper>();
            int id = 9;

            mockUserServices
                .Setup(service => service.GetUserByIdAsync(id))
                .ReturnsAsync(UsersFixture.GetTestUserById(id));

            var sut = new UsersController(mockUserServices.Object, mockMapper.Object);

            //Act
            var result = await sut.Get(id);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            var objectResult = (OkObjectResult)result;
            objectResult.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetUserById_OnSuccess_InvokesUserServicesExactlyOnce()
        {
            //Arrange
            var mockUserServices = new Mock<IUsersServices>();
            var mockMapper = new Mock<IMapper>();
            int id = 9;

            mockUserServices
                .Setup(service => service.GetUserByIdAsync(id))
                .ReturnsAsync(new UserDTO());

            var sut = new UsersController(mockUserServices.Object, mockMapper.Object);

            //Act
            var result = await sut.Get(id);

            //Assert
            mockUserServices.Verify(service => service.GetUserByIdAsync(id), Times.Once());
        }

        [Fact]
        public async Task GetUserById_OnSuccess_ReturnsUser()
        {
            //Arrange
            var mockUserServices = new Mock<IUsersServices>();
            var mockMapper = new Mock<IMapper>();

            int id = 9;

            mockUserServices
                .Setup(service => service.GetUserByIdAsync(id))
                .ReturnsAsync(UsersFixture.GetTestUserById(id));

            var sut = new UsersController(mockUserServices.Object, mockMapper.Object);

            //Act
            var result = await sut.Get(id);

            //Assert
            result.GetType().Should().Be(typeof(OkObjectResult));
            var objectResult = (OkObjectResult)result;
            objectResult.StatusCode.Should().Be(200);
            objectResult.Value.Should().BeOfType<UserDTO>();
        }

        [Fact]
        public async Task GetUserById_OnNoUserFound_ReturnsStatusCode404()
        {
            //Arrange
            var mockUserServices = new Mock<IUsersServices>();
            var mockMapper = new Mock<IMapper>();
            int id = 5;

            mockUserServices
                .Setup(service => service.GetUserByIdAsync(id))
                .ReturnsAsync(UsersFixture.GetNoTestUserById(id));

            var sut = new UsersController(mockUserServices.Object, mockMapper.Object);

            //Act
            var result = await sut.Get(id);

            //Assert
            result.Should().NotBeNull();
            result.GetType().Should().Be(typeof(NotFoundResult));
            var objectResult = (NotFoundResult)result;
            objectResult.StatusCode.Should().Be(404);
        }
    }
}