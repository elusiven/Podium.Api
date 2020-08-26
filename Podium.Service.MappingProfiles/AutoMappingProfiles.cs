using AutoMapper;
using Podium.Data.Primitives.Entities;
using Podium.Service.Primitives.Models.LoanCalculation;
using Podium.Service.Primitives.Models.Product;
using Podium.Service.Primitives.Models.PropertyDetail;
using Podium.Service.Primitives.Models.UserDetail;

namespace Podium.Service.MappingProfiles
{
    public class AutoMappingProfiles : Profile
    {
        public AutoMappingProfiles()
        {
            CreateMap<UserDetails, UserDetailResourceModel>().ReverseMap();
            CreateMap<UserDetails, CreateUserDetailModel>().ReverseMap();
            CreateMap<LoanCalculationResourceModel, LoanCalculation>().ReverseMap();
            CreateMap<Product, ProductResourceModel>().ReverseMap();
            CreateMap<PropertyDetails, PropertyDetailResourceModel>().ReverseMap();
        }
    }
}