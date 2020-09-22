using System.Collections.Generic;
using System.IO;
using Al_Delal.Api.Models;
using Al_Delal.Api.Resource.User;
using Al_Delal.Api.Resource.Vehicle;
using AutoMapper;
using Al_Delal.Api.Data;
using System.Linq;

namespace Al_Delal.Api.Helper.Mapping
{

   public class DomainToResource : Profile
   {
      public DomainToResource()
      {
         CreateMap<User, UserForListDto>();
         CreateMap<User, UserForLoginDto>();
         CreateMap<User, UserForRegisterDto>();
         CreateMap<Vehicle, VehicleForListDto>()
        .ForMember(destination => destination.NoOfImage, option => option.MapFrom<ImageUrlResolver>());
         CreateMap<Vehicle, VehicleForDetailsDto>()
        .ForMember(destination => destination.relatedVehicles, option => option.MapFrom<RelatedVehicleResolver>())
        .ForMember(destination => destination.NoOfImage, option => option.MapFrom<ImageUrlResolver>());

      }
   }

   public class ImageUrlResolver : IValueResolver<Vehicle, object, int>
   {

      public int Resolve(Vehicle source, object destination, int destinationMember, ResolutionContext context)
      {
         var myDir = Path.Combine("/var/www/vehicles-images/" + source.Id.ToString());
         var fileCount = (from file in Directory.EnumerateFiles(myDir, "*", SearchOption.AllDirectories)
                          select file).Count();
         return fileCount;
      }
   }


   public class RelatedVehicleResolver : IValueResolver<Vehicle, object, IList<VehicleForListDto>>
   {
      private readonly DataContext _context;
      private readonly IMapper _mapper;

      public RelatedVehicleResolver(DataContext context, IMapper mapper)
      {
         _context = context;
         _mapper = mapper;
      }

      public IList<VehicleForListDto> Resolve(Vehicle source, object destination, IList<VehicleForListDto> destinationMember, ResolutionContext context)
      {
         List<Vehicle> vehicles = new List<Vehicle>();
         vehicles = _context.Vehicles.Where(v => v.Make == source.Make).Take(3).OrderByDescending(v => v.DateAdded).ToList();
         var relatedVehicles = _mapper.Map<List<VehicleForListDto>>(vehicles);
         return relatedVehicles;
      }
   }
}