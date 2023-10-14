using CleanArchitectureApp.Application.DTO;
using CleanArchitectureApp.Domain;
using System.Runtime.CompilerServices;

namespace CleanArchitectureApp.Application.Services
{
    public interface IPropertyService
    {
        public Task<List<Property>> GetAllProperties();
    }
}
