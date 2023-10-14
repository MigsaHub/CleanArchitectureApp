using AutoMapper;
using CleanArchitectureApp.Application.DTO;
using CleanArchitectureApp.Application.Mappers;
using CleanArchitectureApp.Application.Services;
using CleanArchitectureApp.Application.Services.Impl;
using CleanArchitectureApp.Controllers;
using CleanArchitectureApp.Domain;
using CleanArchitectureApp.Infrastructure.Repository;
using CleanArchitectureApp.Tests.Mocks.RepositoriesMock;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace CleanArchitectureApp.Tests.Controllers
{
    public class PropertyControllerTest
    {
        private readonly Mock<IPropertyService> _mockPropertyService;
        private readonly Mock<IPropertyRepository> _propertyRepository;
        private readonly IMapper _mapper;
        public PropertyControllerTest()
        {
            _mockPropertyService = new Mock<IPropertyService>();
            _propertyRepository = new Mock<IPropertyRepository>();
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new PropertyProfile());
            });

            _mapper = new Mapper(mapperConfig);
        }

        [Fact]
        public async Task Get_OnSuccessReturnsStatusCode200()
        {
            //Arrange 
            _mockPropertyService
                .Setup(service => service.GetAllProperties())
                .ReturnsAsync(MockPropertyRepository.GetTestProperties());


            var sut = new PropertyController(_mockPropertyService.Object);

            //Act
            var result = (OkObjectResult)await sut.Get();

            //Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task Get_OnNoPropertiesFoundReturns404()
        {
            //Arrange 
            _mockPropertyService
                .Setup(service => service.GetAllProperties())
                .ReturnsAsync(new List<Property>());

            var sut = new PropertyController(_mockPropertyService.Object);

            //Act
            var result = await sut.Get();

            //Assert
            result.Should().BeOfType<NotFoundResult>();
            var objectResult = (NotFoundResult)result;

            objectResult.StatusCode.Should().Be(404);
        }

        [Fact]
        public async Task CreateProperty_OnSuccessReturnsStatusCode200()
        {
            //Arrange 
            var propertymodel = new Mock<PropertyDto>();
            _mockPropertyService
                .Setup(service => service.CreatePropertyRecord(It.IsAny<PropertyDto>())).ReturnsAsync(new Property());

            var sut = new PropertyController(_mockPropertyService.Object);

            //Act
            var result = (OkObjectResult)await sut.CreateProperty(propertymodel.Object);
            //Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task GetPropertiesByUserId_OnSuccessReturnsStatusCode200()
        {
            //Arrange 
            var propertyMock= new Mock<Property>();
            _mockPropertyService
                .Setup(service => service.GetPropertiesByUserId(It.IsAny<int>()))
                .ReturnsAsync(MockPropertyRepository.GetTestProperties());


            var sut = new PropertyController(_mockPropertyService.Object);

            //Act
            var result = (OkObjectResult)await sut.GetPropertyByUserId(propertyMock.Object.Id);

            //Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task UpdateProperty_OnSuccessReturnsStatusCode200()
        {
            //Arrange 
            var propertymodel = new Mock<PropertyDto>();
            _mockPropertyService
                .Setup(service => service.UpdatePropertyRecord(It.IsAny<PropertyDto>())).ReturnsAsync(true);

            var sut = new PropertyController(_mockPropertyService.Object);

            //Act
            var result = (OkObjectResult)await sut.UpdateProperty(propertymodel.Object);
            //Assert
            result.StatusCode.Should().Be(200);
        }

        [Fact]
        public async Task DeleteProperty_OnSuccessReturnsStatusCode200()
        {
            //Arrange 
            var propertymodelId = 1;
            _mockPropertyService
                .Setup(service => service.DeletePropertyRecord(It.IsAny<int>())).ReturnsAsync(true);

            var sut = new PropertyController(_mockPropertyService.Object);

            //Act
            var result = (OkObjectResult)await sut.DeletePropertyById(propertymodelId);
            //Assert
            result.StatusCode.Should().Be(200);
        }

    }



   

   
}
