using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Podium.Service.Abstractions;
using Podium.Service.Primitives.Models.UserDetail;
using System;
using System.Threading.Tasks;

namespace Podium.Api.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [Route("api/[controller]")]
    [ApiController]
    public class UserDetailController : ControllerBase
    {
        private readonly ILogger<UserDetailController> _logger;
        private readonly IUserDetailService _userDetailService;

        public UserDetailController(
            ILogger<UserDetailController> logger,
            IUserDetailService userDetailService)
        {
            _logger = logger;
            _userDetailService = userDetailService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            _logger.LogInformation("UserDetailController::Get");
            return Ok(await _userDetailService.GetById(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            _logger.LogInformation("UserDetailController::GetAll");
            return Ok(await _userDetailService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDetailModel model)
        {
            _logger.LogInformation("UserDetailController::Create");
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userDetail = await _userDetailService.Create(model);
            return Created(new Uri(Url.Action("Get", new { id = userDetail.Id }), UriKind.Relative), userDetail);
        }
    }
}