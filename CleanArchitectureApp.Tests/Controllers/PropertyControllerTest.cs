using CleanArchitectureApp.Application.Services;
using CleanArchitectureApp.Controllers;
using CleanArchitectureApp.Domain;
using CleanArchitectureApp.Tests.Mocks.Helpers;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System.Reflection;
using Xunit;

namespace CleanArchitectureApp.Tests.Controllers
{
    public class PropertyControllerTest
    {
        [Fact]
        public async Task Get_OnSuccessReturnsStatusCode200()
        {
            //Arrange
            var mockPropertyService = new Mock<IPropertyService>();

            mockPropertyService
                .Setup(service => service.GetAllProperties())
                .ReturnsAsync(PropertyFixture.GetTestProperties());


            var sut = new PropertyController(mockPropertyService.Object);

            //Act
            var result = (OkObjectResult)await sut.Get();

            //Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Get_OnSuccess_InvokesPropertyServiceExactlyOnce()
        {
            //Arrange
            var mockPropertyService = new Mock<IPropertyService>();

            mockPropertyService
                .Setup(service => service.GetAllProperties())
                .ReturnsAsync(new List<Property>());

            var sut = new PropertyController(mockPropertyService.Object);

            //Act
            var result =  await sut.Get();

            //Assert
            mockPropertyService.Verify(
                service  => service.GetAllProperties(),
                Times.Once());
        }

        [Fact]
        public async Task Get_OnSuccess_ReturnListOfProperties()
        {
            //Arrange
            var mockPropertyService = new Mock<IPropertyService>();

            mockPropertyService
                .Setup(service => service.GetAllProperties())
                .ReturnsAsync(PropertyFixture.GetTestProperties());

            var sut = new PropertyController(mockPropertyService.Object);

            //Act
            var result = await sut.Get();

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;

            objectResult.Value.Should().BeOfType<List<Property>>();
        }

        [Fact]
        public async Task Get_OnNoPropertiesFound_Returns404()
        {
            //Arrange
            var mockPropertyService = new Mock<IPropertyService>();

            mockPropertyService
                .Setup(service => service.GetAllProperties())
                .ReturnsAsync(new List<Property>());

            var sut = new PropertyController(mockPropertyService.Object);

            //Act
            var result = await sut.Get();

            //Assert
            result.Should().BeOfType<NotFoundResult>();
            var objectResult = (NotFoundResult)result;

            objectResult.StatusCode.Should().Be(404);
        }



    }
}
