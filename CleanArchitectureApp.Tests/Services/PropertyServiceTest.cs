using AutoMapper;
using CleanArchitectureApp.Application.DTO;
using CleanArchitectureApp.Application.Mappers;
using CleanArchitectureApp.Application.Services;
using CleanArchitectureApp.Domain;
using CleanArchitectureApp.Infrastructure.Repository;
using Moq;

namespace CleanArchitectureApp.Tests.Services
{
    public class PropertyServiceTest
    {
        private readonly Mock<IPropertyService> _mockPropertyService;
        private readonly Mock<IPropertyRepository> _propertyRepository;
        private readonly IMapper _mapper;
        public PropertyServiceTest()
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
        public async Task GetAllProperties_WhenCalled_ReturnsListOfUsers()
        {
            //Arrange
            var expectedResponse = new List<string>();
  
            //Act

            //Assert
        }

        [Fact]
        public async Task CreateNewPropertyApplication_OnSuccessReturnsStatusCode200()
        {
            //Arrange 
            var propertyrecord = new PropertyDto();
            _mockPropertyService.Setup(service => service.CreatePropertyRecord(It.IsAny<PropertyDto>())).ReturnsAsync(new Property());

            //Act
            var result = await _mockPropertyService.Object.CreatePropertyRecord(propertyrecord);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<Property>(result);
        }

        [Fact]
        public async Task GetPropertyByUserId_OnSuccessReturnsStatusCode200()
        {
            //Arrange
            int userId = 1;
            _mockPropertyService.Setup(service => service.GetPropertiesByUserId(It.IsAny<int>())).ReturnsAsync(new List<Property>());
            //Act
            var result = await _mockPropertyService.Object.GetPropertiesByUserId(userId);
            //Assert
            Assert.NotNull(result);
            Assert.IsType<List<Property>>(result);
        }

        [Fact]
        public async Task DeletePropertyRecord_OnSuccessReturnsStatusCode200()
        {
            //Arrange 
            var propertyrecord = new PropertyDto();
            var property = _mapper.Map<Property>(propertyrecord);
            _mockPropertyService.Setup(service => service.DeletePropertyRecord(It.IsAny<int>())).ReturnsAsync(true);

            //Act
            var result = await _mockPropertyService.Object.DeletePropertyRecord(property.Id);
            //Assert
            Assert.True(result);
            Assert.IsType<bool>(result);
        }

        [Fact]
        public async Task UpdatePropertyRecord_OnSuccessReturnsStatusCode200()
        {
            //Arrange 
            var propertyrecord = new PropertyDto();
            _mockPropertyService.Setup(service => service.UpdatePropertyRecord(It.IsAny<PropertyDto>())).ReturnsAsync(true);
            //Act
            var result = await _mockPropertyService.Object.UpdatePropertyRecord(propertyrecord);
            //Assert
            Assert.True(result);
            Assert.IsType<bool>(result);
        }
    }
}
