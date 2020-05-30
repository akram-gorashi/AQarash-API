using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using Al_Delal.Api.Models;
using Al_Delal.Api.Resource.User;
using Al_Delal.Api.Resource.Vehicle;
using AutoMapper;

namespace Al_Delal.Api.Helper.Mapping
{
<<<<<<< HEAD
   public class DomainToResource : Profile
   {
      public DomainToResource()
      {
         CreateMap<User, UserForListDto>();
         CreateMap<User, UserForLoginDto>();
         CreateMap<User, UserForRegisterDto>();
         CreateMap<Vehicle, VehicleForListDto>()
        .ForMember(destination => destination.ImageUrl, option => option.MapFrom<ImageUrlResolver>());
         CreateMap<Vehicle, VehicleForDetailsDto>()
        .ForMember(destination => destination.ImageUrl, option => option.MapFrom<ImageUrlResolver>());

      }
   }

   public class ImageUrlResolver : IValueResolver<Vehicle, object, IList<string>>
   {

      public IList<string> Resolve(Vehicle source, object destination, IList<string> destinationMember, ResolutionContext context)
      {
         List<string> imagesName = new List<string>();
         var folderName = Path.Combine(@"C:/Users/Akram/Desktop/alQarash/Images/" + source.Id.ToString());

         //  string[] fileNames = Directory.GetFiles("C:/Users/Akram/Desktop/alQarash/Images/", source.Id.ToString(), "*.jpg");
         string[] fileArray = Directory.GetFiles(folderName);

         foreach (var fileName in fileArray)
         {
            imagesName.Add(fileName.Replace("\\", "/"));
         }
         return imagesName;
      }
   }
=======
    public class DomainToResource: Profile
    {
        public DomainToResource()
        {
            CreateMap<User, UserForListDto>();
            CreateMap<Vehicle, VehicleForListDto>();
            CreateMap<Vehicle, VehicleForDetailsDto>();
        }
    }
>>>>>>> [update]
}