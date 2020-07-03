using Al_Delal.Api.Models;
using Al_Delal.Api.Resource.User;
using Al_Delal.Api.Resource.Vehicle;
using AutoMapper;

namespace Al_Delal.Api.Helper.Mapping
{
    public class DomainToResource : Profile
    {
        public DomainToResource()
        {
            CreateMap<User, UserForListDto>();
            CreateMap<User, UserForLoginDto>();
            CreateMap<User, UserForRegisterDto>();
            CreateMap<Vehicle, VehicleForListDto>();
            CreateMap<Vehicle, VehicleForDetailsDto>();
           
        }
    }
}