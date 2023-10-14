using CleanArchitectureApp.Domain;

namespace CleanArchitectureApp.Tests.Mocks.RepositoriesMock
{
    public static class MockPropertyRepository
    {
        public static List<Property> GetTestProperties() => new() {
            new Property {
                Id = 1,
                Area = "Palermo",
                Price = 250,
                Status = "New",
                Observation = "",
                Temporary = 0,
                URL = "",
                User = 3 },
            new Property {
                Id = 2,
                Area = "Chacarita",
                Price = 500,
                Status = "Closed",
                Observation = "",
                Temporary = 1,
                URL = "",
                User = 1 },
            new Property {
                Id = 3,
                Area = "Villa Urquiza",
                Price = 12000,
                Status = "New",
                Observation = "",
                Temporary = 0,
                URL = "",
                User = 2 
            }
        };
    }
}