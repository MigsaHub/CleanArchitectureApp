using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Exceptions
{
    public class UserServiceException : Exception
    {
        public UserServiceException(Exception e) { }
    }
}
