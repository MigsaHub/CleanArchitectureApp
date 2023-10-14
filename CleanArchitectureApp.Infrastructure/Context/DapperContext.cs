using Dapper;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using System.Data; 

namespace CleanArchitectureApp.Infrastructure.Context
{
    public class DapperContext
    {
        protected readonly IConfiguration Configuration;

        public DapperContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IDbConnection CreateConnection()
        {
               return new SqliteConnection(Configuration.GetConnectionString("DefaultConnection"));
        }
        
    }
}
