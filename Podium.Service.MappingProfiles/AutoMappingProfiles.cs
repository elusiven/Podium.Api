using AutoMapper;
using Podium.Data.Primitives.Entities;
using Podium.Service.Primitives.Models.LoanCalculation;
using Podium.Service.Primitives.Models.Product;
using Podium.Service.Primitives.Models.PropertyDetail;
using Podium.Service.Primitives.Models.UserDetail;
using Podium.Shared;

namespace Podium.Service.MappingProfiles
{
    public class AutoMappingProfiles : Profile
    {
        public AutoMappingProfiles()
        {
            CreateMap<UserDetails, UserDetailResourceModel>().ReverseMap();
            CreateMap<UserDetails, CreateUserDetailModel>().ReverseMap();
            CreateMap<LoanCalculationResourceModel, LoanCalculation>().ReverseMap();
            CreateMap<CreateLoanCalculationModel, LoanCalculation>().ReverseMap();
            CreateMap<Product, ProductResourceModel>().ReverseMap();
            CreateMap<LoanCalculationProductModel, LoanCalculationProduct>().ReverseMap();
            CreateMap<PropertyDetails, PropertyDetailResourceModel>().ReverseMap();
            CreateMap<Enums.LoanType, string>().ConvertUsing(src => src.ToString());
        }
    }
}