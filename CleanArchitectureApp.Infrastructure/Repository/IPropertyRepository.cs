using CleanArchitectureApp.Domain; 

namespace CleanArchitectureApp.Infrastructure.Repository
{
    public interface IPropertyRepository
    {
        public Task<int> CreateProperty(Property propertyDto);
        public Task<List<Property>> GetAllProperties();
        public Task<Property> GetPropertyById(int propertyId);
        public Task<Property> GetPropertyByUrl(string url);
        public Task<List<Property>> GetPropertiesByUserId(int userId);
        public Task<bool> UpdateProperty(Property property);
        public Task<bool> DeleteProperty(int propertyId);
    }
}
