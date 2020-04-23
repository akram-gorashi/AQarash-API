using Al_Delal.Api.Models;
using Al_Delal.Api.Resource.User;
using AutoMapper;

namespace Al_Delal.Api.Helper.Mapping
{
    public class DomainToResource: Profile
    {
        public DomainToResource()
        {
            CreateMap<User, UserForListDto>();
        }
    }
}