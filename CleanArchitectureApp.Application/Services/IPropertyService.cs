using CleanArchitectureApp.Application.DTO;
using CleanArchitectureApp.Domain; 

namespace CleanArchitectureApp.Application.Services
{
    public interface IPropertyService
    {
        public Task<Property> CreatePropertyRecord(PropertyDto propertyrecord);
        public Task<List<Property>> GetAllProperties();
        public Task<List<Property>> GetPropertiesByUserId(int userId);
        public Task<bool> DeletePropertyRecord(int propertyId);
        public Task<bool> UpdatePropertyRecord(PropertyDto propertyrecord);

 
    }
}
