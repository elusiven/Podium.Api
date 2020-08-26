using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Podium.Data.Abstractions;
using Podium.Service.Abstractions;
using Podium.Service.Common.Exceptions;
using Podium.Service.Primitives.Models.LoanCalculation;
using System.Threading.Tasks;
using AutoMapper;
using Podium.Data.Primitives.Entities;
using Podium.Service.Primitives.Models.Product;

namespace Podium.Service
{
    public class LoanCalculationService : ILoanCalculationService
    {
        private readonly ILogger<LoanCalculationService> _logger;
        private readonly ILoanCalculationRepository _loanCalculationRepository;
        private readonly IUserDetailService _userDetailService;
        private readonly IProductService _productService;
        private readonly IFinanceCalculationsService _financeCalculationsService;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;

        public LoanCalculationService(
            ILogger<LoanCalculationService> logger,
            ILoanCalculationRepository loanCalculationRepository,
            IUserDetailService userDetailService,
            IProductService productService,
            IFinanceCalculationsService financeCalculationsService,
            IValidationService validationService,
            IMapper mapper)
        {
            _logger = logger;
            _loanCalculationRepository = loanCalculationRepository;
            _userDetailService = userDetailService;
            _productService = productService;
            _financeCalculationsService = financeCalculationsService;
            _validationService = validationService;
            _mapper = mapper;
        }

        /// <summary>
        /// Calculates available loans for a user
        /// </summary>
        /// <param name="model"></param>
        /// <returns>A collection of available loans for a user</returns>
        public async Task<LoanCalculationResourceModel> CalculateLoansAsync(CreateLoanCalculationModel model)
        {
            _logger.LogInformation("LoanCalculationService::CalculateLoansAsync");

            LoanCalculationResourceModel resourceModel = new LoanCalculationResourceModel();

            var user = await _userDetailService.GetById(model.UserId);
            if (user == null) throw new LoanCalculationServiceException($"User with ID {model.UserId} is not found");

            if (!_validationService.ValidateAdultAge(user.DateOfBirth)) return resourceModel;

            var ltv = _financeCalculationsService.CalculateLTVPercentage(model.PropertyDetail.PropertyValue,
                model.PropertyDetail.DepositAmount);

            if (ltv < 90)
                resourceModel.Products = new List<ProductResourceModel>(await _productService.GetAll());

            resourceModel.UserDetailsId = model.UserId;
            resourceModel.PropertyDetails = model.PropertyDetail;

            await _loanCalculationRepository.CreateAsync(_mapper.Map<LoanCalculation>(resourceModel));

            return resourceModel;
        }
    }
}