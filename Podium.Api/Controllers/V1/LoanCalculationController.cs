using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Podium.Service.Abstractions;
using System.Threading.Tasks;
using Podium.Service.Primitives.Models.LoanCalculation;

namespace Podium.Api.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoanCalculationController : ControllerBase
    {
        private readonly ILogger<LoanCalculationController> _logger;
        private readonly ILoanCalculationService _loanCalculationService;

        public LoanCalculationController(
            ILogger<LoanCalculationController> logger,
            ILoanCalculationService loanCalculationService)
        {
            _logger = logger;
            _loanCalculationService = loanCalculationService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateLoanCalculationModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(await _loanCalculationService.CalculateLoansAsync(model));
        }
    }
}