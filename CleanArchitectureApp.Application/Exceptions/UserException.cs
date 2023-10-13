using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitectureApp.Application.Exceptions
{
    public class UserServiceException : Exception
    { 
        protected UserServiceException(SerializationInfo info, StreamingContext context)
                 : base(info, context)
        {
        }
        public UserServiceException(string message, Exception innerException)
        : base(message, innerException) { }

        public UserServiceException(string message)
        : base(message) { }
    }
}
