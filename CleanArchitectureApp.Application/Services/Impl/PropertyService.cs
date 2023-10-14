using CleanArchitectureApp.Domain;
using Microsoft.Extensions.Options;

namespace CleanArchitectureApp.Application.Services.Impl
{
    public class PropertyService : IPropertyService
    {
        public async Task<List<Property>> GetAllProperties()
        {
           return new List<Property> { };
        }
    }
}
