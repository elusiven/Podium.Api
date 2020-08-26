using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.Logging;
using Podium.Data.Abstractions;
using Podium.Data.Primitives.Entities;
using Podium.Service.Abstractions;
using Podium.Service.Common.Exceptions;
using Podium.Service.Primitives.Models.UserDetail;

namespace Podium.Service
{
    public class UserDetailService : IUserDetailService
    {
        private readonly ILogger<UserDetailService> _logger;
        private readonly IUserDetailsRepository _userDetailsRepository;
        private readonly IMapper _mapper;

        public UserDetailService(
            ILogger<UserDetailService> logger,
            IUserDetailsRepository userDetailsRepository,
            IMapper mapper)
        {
            _logger = logger;
            _userDetailsRepository = userDetailsRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Get user detail by ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<UserDetailResourceModel> GetById(string id)
        {
            _logger.LogInformation("UserDetailService::GetById");

            var userDetailEntity = await _userDetailsRepository.GetAsync(id);
            if (userDetailEntity == null) throw new UserDetailServiceException($"Could not find user detail with this id {id}");
            return _mapper.Map<UserDetailResourceModel>(userDetailEntity);
        }

        /// <summary>
        /// Get all user details
        /// </summary>
        /// <returns></returns>
        public async Task<HashSet<UserDetailResourceModel>> GetAll()
        {
            _logger.LogInformation("UserDetailService::GetAll");

            HashSet<UserDetailResourceModel> userDetails = new HashSet<UserDetailResourceModel>();
            userDetails = _mapper.Map<HashSet<UserDetailResourceModel>>(await _userDetailsRepository.GetAllAsync());
            return userDetails;
        }

        /// <summary>
        /// Creates a user detail
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task<UserDetailResourceModel> Create(CreateUserDetailModel model)
        {
            _logger.LogInformation("UserDetailService::Create");

            var userDetailEntity = _mapper.Map<UserDetails>(model);
            var createdUserDetailEntity = await _userDetailsRepository.CreateAsync(userDetailEntity);
            return _mapper.Map<UserDetailResourceModel>(createdUserDetailEntity);
        }
    }
}