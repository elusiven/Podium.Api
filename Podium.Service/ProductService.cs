using AutoMapper;
using Microsoft.Extensions.Logging;
using Podium.Data.Abstractions;
using Podium.Service.Abstractions;
using Podium.Service.Common.Exceptions;
using Podium.Service.Primitives.Models.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Podium.Service
{
    public class ProductService : IProductService
    {
        private readonly ILogger<ProductService> _logger;
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(
            ILogger<ProductService> logger,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _logger = logger;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets product resource model
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProductResourceModel> Get(string id)
        {
            _logger.LogInformation("ProductService::GetById");

            var productEntity = await _productRepository.GetAsync(id);
            if (productEntity == null) throw new ProductServiceException($"Could not find user detail with this id {id}");
            return _mapper.Map<ProductResourceModel>(productEntity);
        }

        /// <summary>
        /// Gets all product resource models
        /// </summary>
        /// <returns></returns>
        public async Task<HashSet<ProductResourceModel>> GetAll()
        {
            _logger.LogInformation("ProductService::GetAll");

            HashSet<ProductResourceModel> productResourceModels = new HashSet<ProductResourceModel>();
            productResourceModels = _mapper.Map<HashSet<ProductResourceModel>>(await _productRepository.GetAllAsync());
            return productResourceModels;
        }
    }
}