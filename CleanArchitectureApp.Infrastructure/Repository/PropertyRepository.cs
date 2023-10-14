using CleanArchitectureApp.Domain;
using CleanArchitectureApp.Infrastructure.Context;
using Dapper;

namespace CleanArchitectureApp.Infrastructure.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private DapperContext _context;

        public PropertyRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<int> CreateProperty(Property propertyDto)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
            INSERT INTO Property (Status,Area,Price,Temporary,URL,Observation,User)
            VALUES (@Status, @Area, @Price, @Temporary, @URL, @Observation, @User);
            SELECT LAST_INSERT_ROWID();
            ";

            var result = await connection.QuerySingleAsync<int>(sql, propertyDto);
            return (result);
        }
        public Task<List<Property>> GetAllProperties()
        {
            using var connection = _context.CreateConnection();
            var sql = """
            SELECT * FROM Property 
            """;
            var result = connection.Query<Property>(sql);
            return Task.FromResult(result.ToList());
        }

        public Task<List<Property>> GetPropertiesByUserId(int userId)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            SELECT * FROM Property 
            WHERE User =@userId
            """;
            var result = connection.Query<Property>(sql,new {userId});
            return Task.FromResult(result.ToList());
        }

        public async Task<Property> GetPropertyById(int propertyId)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            SELECT * FROM Property 
            WHERE Id =@propertyId
            """;
            var result = await connection.QuerySingleOrDefaultAsync<Property>(sql, new { propertyId });
            return result!;
        }

        public async Task<bool> UpdateProperty(Property property)
        {
            using var connection = _context.CreateConnection();
            var sql = """  
             UPDATE Property 
                SET 
                Status=@Status,
                Area=@Area,
                Price=@Price,
                Temporary=@Temporary,
                URL=@URL,
                Observation=@Observation,
                User=@User
                )
                WHERE Id = @Id
            """;
            var result = await connection.ExecuteAsync(sql, property);
            return (result > 0);
        }

        public async Task<bool> DeleteProperty(int propertyId)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            DELETE FROM Property where Id = @propertyId
            """;
            var result = await connection.ExecuteAsync(sql, new { propertyId });
            return (result > 0);
        }

        public async Task<Property> GetPropertyByUrl(string url)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            SELECT * FROM Property
            WHERE URL = @url
            """;
            var result = await connection.QuerySingleOrDefaultAsync<Property>(sql, new { url });
            return result!;
        }
    }
}
