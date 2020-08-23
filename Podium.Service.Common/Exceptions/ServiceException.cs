using System;
using System.Collections.Generic;

namespace Podium.Service.Common.Exceptions
{
    public abstract class ServiceException : Exception
    {
        public ServiceException()
        {
            Errors = new Dictionary<string, string[]>();
        }

        public Dictionary<string, string[]> Errors { get; set; }

        protected ServiceException(string message, Exception exception) : base(message, exception)
        {
        }

        protected ServiceException(string message) : base(message)
        {
        }
    }
}