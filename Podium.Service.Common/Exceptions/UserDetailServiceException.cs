using System;

namespace Podium.Service.Common.Exceptions
{
    public class UserDetailServiceException : ServiceException
    {
        public UserDetailServiceException(string message, Exception exception) : base(message, exception)
        {
        }

        public UserDetailServiceException(string message) : base(message)
        {
        }
    }
}