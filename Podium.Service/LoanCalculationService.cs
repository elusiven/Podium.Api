using System;
using Microsoft.Extensions.Logging;
using Podium.Data.Abstractions;
using Podium.Service.Abstractions;
using Podium.Service.Primitives.Models.LoanCalculation;
using System.Threading.Tasks;
using Podium.Service.Common.Exceptions;

namespace Podium.Service
{
    public class LoanCalculationService : ILoanCalculationService
    {
        private readonly ILogger<LoanCalculationService> _logger;
        private readonly ILoanCalculationRepository _loanCalculationRepository;
        private readonly IUserDetailService _userDetailService;

        public LoanCalculationService(
            ILogger<LoanCalculationService> logger,
            ILoanCalculationRepository loanCalculationRepository,
            IUserDetailService userDetailService)
        {
            _logger = logger;
            _loanCalculationRepository = loanCalculationRepository;
            _userDetailService = userDetailService;
        }

        public async Task<LoanCalculationResourceModel> CalculateLoansAsync(CreateLoanCalculationModel model)
        {
            LoanCalculationResourceModel resourceModel = new LoanCalculationResourceModel();

            var user = await _userDetailService.GetById(model.UserId);
            if (user == null) throw new LoanCalculationServiceException($"User with ID {model.UserId} is not found");

            return resourceModel;
        }
    }
}