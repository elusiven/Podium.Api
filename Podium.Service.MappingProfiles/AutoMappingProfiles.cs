using AutoMapper;
using Podium.Data.Primitives.Entities;
using Podium.Service.Primitives.Models.UserDetail;

namespace Podium.Service.MappingProfiles
{
    public class AutoMappingProfiles : Profile
    {
        public AutoMappingProfiles()
        {
            CreateMap<UserDetails, UserDetailResourceModel>().ReverseMap();
            CreateMap<UserDetails, CreateUserDetailModel>().ReverseMap();
        }
    }
}