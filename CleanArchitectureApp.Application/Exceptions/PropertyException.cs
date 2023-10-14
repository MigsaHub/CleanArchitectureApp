using System.Runtime.Serialization;

namespace CleanArchitectureApp.Application.Exceptions
{
    public class PropertyException : Exception
    {
        protected PropertyException(SerializationInfo info, StreamingContext context)
               : base(info, context)
        {
        }
        public PropertyException(string message, Exception innerException)
        : base(message, innerException) { }

        public PropertyException(string message)
        : base(message) { }
    }
}
