using System;

namespace Podium.Service.Common.Exceptions
{
    public class ProductServiceException : ServiceException
    {
        public ProductServiceException(string message, Exception exception) : base(message, exception)
        {
        }

        public ProductServiceException(string message) : base(message)
        {
        }
    }
}