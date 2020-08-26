using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Podium.Service.Common.Exceptions
{
    public class LoanCalculationServiceException : ServiceException
    {
        public LoanCalculationServiceException(string message, Exception exception) : base(message, exception)
        {
        }

        public LoanCalculationServiceException(string message) : base(message)
        {
        }
    }
}