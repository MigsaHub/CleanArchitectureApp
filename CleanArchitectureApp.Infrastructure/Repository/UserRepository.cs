using CleanArchitectureApp.Domain;
using CleanArchitectureApp.Infrastructure.Context;
using Dapper; 

namespace CleanArchitectureApp.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        private DapperContext _context;
        
        public UserRepository(DapperContext context)
        {
            _context = context;
        }


        public async Task<int> AddUser(User user)
        {
            using var connection = _context.CreateConnection();
            var sql = @"
            INSERT INTO User (Name,Email,PasswordHash,PasswordSalt)
            VALUES (@Name, @Email, @PasswordHash, @PasswordSalt);
            SELECT LAST_INSERT_ROWID();
            ";

            int result = await connection.QuerySingleAsync<int>(sql, user);
            return (result);
        }

        public async Task<bool> DeleteUser(int userId)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            DELETE FROM User where Id = @userId
            """;
            var result = await connection.ExecuteAsync(sql, new { userId });
            return (result > 0);
        }

        public async Task<User> GetUserByEmail(string email)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            SELECT * FROM User
            WHERE Email = @email
            """;
            var user = await connection.QuerySingleOrDefaultAsync<User>(sql, new { email });
            return user!;
        }

        public async Task<User> GetUserById(int userId)
        {

            using var connection = _context.CreateConnection();
            var sql = """
            SELECT * FROM User
            WHERE Id = @userId
            """;
            var user = await connection.QuerySingleOrDefaultAsync<User>(sql, new { userId });
            return user!;
         
        }
         

        public async Task<bool> UpdateUser(User user)
        {
            using var connection = _context.CreateConnection();
            var sql = """  
             UPDATE User 
                SET Name = @Name,
                    Email = @Email,
                    PasswordHash = @PasswordHash, 
                    PasswordSalt = @PasswordSalt 
                WHERE Id = @Id
            """;
            var result = await connection.ExecuteAsync(sql, user);
            return (result > 0);
        }
    }
}
