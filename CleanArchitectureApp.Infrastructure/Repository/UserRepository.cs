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


        public async Task<bool> AddUser(User user)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            INSERT INTO User (Name,Email,PasswordHash,PasswordSalt)
            VALUES (@Name, @Email, @PasswordHash, @PasswordSalt)
            """;
            var result= await connection.ExecuteAsync(sql, user);
            return (result > 0);
        }

        public async Task<bool> DeleteUser(string emailUser)
        {
            using var connection = _context.CreateConnection();
            var sql = """
            DELETE FROM User where Email = @emailUser
            """;
            var result = await connection.ExecuteAsync(sql, new { emailUser });
            return (result > 0);
        }

        public async Task<User> GetUserByMail(string emailUser)
        {

            using var connection = _context.CreateConnection();
            var sql = """
            SELECT * FROM User
            WHERE Email = @emailUser
            """;
            var user = await connection.QuerySingleOrDefaultAsync<User>(sql, new { emailUser });
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
