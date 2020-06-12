using Al_Delal.Api.Models;
using Al_Delal.Api.Resource.User;
using Al_Delal.Api.Resource.Vehicle;
using AutoMapper;

namespace Al_Delal.Api.Helper.Mapping
{
    public class ResourceToDomain: Profile
    {
          public ResourceToDomain()
        {
            CreateMap<UserForListDto, User>();
            CreateMap<UserForLoginDto, User>();
            CreateMap<UserForRegisterDto, User>();
            CreateMap<VehicleForListDto , Vehicle>();
            CreateMap<VehicleForDetailsDto, Vehicle>();
            CreateMap<AddVehicleDto, Vehicle>();
        }
    }
}