using CleanArchitectureApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Infrastructure.Repository
{
    public interface IUserServiceRepository
    {
        public Task<bool> AddUser(User user);
    }

}
