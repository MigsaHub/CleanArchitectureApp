using AutoMapper;
using CleanArchitectureApp.Application.DTO;
using CleanArchitectureApp.Application.Exceptions;
using CleanArchitectureApp.Domain;
using CleanArchitectureApp.Infrastructure.Repository;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace CleanArchitectureApp.Application.Services.Impl
{
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;
        private readonly ILogger _logger;

        public PropertyService(IPropertyRepository propertyRepository, IMapper mapper, ILoggerFactory loggerFactory)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
            _logger = loggerFactory.CreateLogger<PropertyService>();
        }

        public async Task<Property> CreatePropertyRecord(PropertyDto propertyrecord)
        {
            try
            {
                _logger.LogInformation("CreatePropertyRecord initiates");

                var property = _mapper.Map<Property>(propertyrecord);

                var record = await _propertyRepository.CreateProperty(property);
                var result = await _propertyRepository.GetPropertyById(record);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in CreatePropertyRecordMethod {message}{exception}", ex.Message, ex.InnerException);
                throw new PropertyException(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<Property>> GetAllProperties()
        {
            try
            {
                _logger.LogInformation("GetAllProperties initiates"); 

                var result = await _propertyRepository.GetAllProperties(); 
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in GetAllProperties {message}{exception}", ex.Message, ex.InnerException);
                throw new PropertyException(ex.Message, ex.InnerException);
            }
        }

        public async Task<List<Property>> GetPropertiesByUserId(int userId)
        {
            try
            {
                _logger.LogInformation("GetPropertiesByUserId initiates");

                var result = await _propertyRepository.GetPropertiesByUserId(userId);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in GetPropertiesByUserId {message}{exception}", ex.Message, ex.InnerException);
                throw new PropertyException(ex.Message, ex.InnerException);
            }
        }

        public async Task<bool> UpdatePropertyRecord(PropertyDto propertyrecord)
        {
            try
            {
                _logger.LogInformation("UpdatePropertyRecord initiates");
                var propertyById = await _propertyRepository.GetPropertyByUrl(propertyrecord.URL);
                if (propertyById == null)
                {
                    throw new UserServiceException("Property doesn't exist, verify your data");
                }
                else
                {
                    var property = _mapper.Map<Property>(propertyrecord);
                    property.Id= propertyById.Id;
                    var result = await _propertyRepository.UpdateProperty(property);
                    return result;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in UpdatePropertyRecord {message}{exception}", ex.Message, ex.InnerException);
                throw new PropertyException(ex.Message, ex.InnerException);
            }
        }
      
        public async Task<bool> DeletePropertyRecord(int propertyId)
        {
            try
            {
                _logger.LogInformation("DeletePropertyRecord initiates"); 

                var result = await _propertyRepository.DeleteProperty(propertyId);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError("Exception in DeletePropertyRecord {message}{exception}", ex.Message, ex.InnerException);
                throw new PropertyException(ex.Message, ex.InnerException);
            }
        }

    }
}
