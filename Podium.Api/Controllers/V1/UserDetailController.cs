using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Podium.Service.Abstractions;
using Podium.Service.Primitives.Models.UserDetail;

namespace Podium.Api.Controllers.V1
{
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
            return Ok(await _userDetailService.GetById(id));
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _userDetailService.GetAll());
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserDetailModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            var userDetail = await _userDetailService.Create(model);
            return Created(new Uri(Url.Action("Get", new { id = userDetail.Id }), UriKind.Relative), userDetail);
        }
    }
}