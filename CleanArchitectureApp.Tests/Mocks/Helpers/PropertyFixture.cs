using CleanArchitectureApp.Domain;

namespace CleanArchitectureApp.Tests.Mocks.Helpers
{
    public static class PropertyFixture
    {
        public static List<Property> GetTestProperties() => new() {
            new Property {
                Id = 1,
                Area = "Palermo",
                Price = 250,
                Status = "New",
                Observation = "",
                Temporary = false,
                URL = "",
                User = new User()
                {
                    Id = 1,
                    Email = "random@test.com",
                    Name = "Test",
                    Password = "Test"
                    }
                },
            new Property {
                Id = 2,
                Area = "Chacarita",
                Price = 500,
                Status = "Closed",
                Observation = "",
                Temporary = true,
                URL = "",
                User = new User()
                {
                    Id = 2,
                    Email = "random@test.com",
                    Name = "Test",
                    Password = "Test"
                    }
                },
            new Property {
                Id = 3,
                Area = "Villa Urquiza",
                Price = 12000,
                Status = "New",
                Observation = "",
                Temporary = false,
                URL = "",
                User = new User()
                {
                    Id = 3,
                    Email = "random@test.com",
                    Name = "Test",
                    Password = "Test"
                    }
                }
        };
    }
}