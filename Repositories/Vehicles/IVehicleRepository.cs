using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Al_Delal.Api.Contract;
using Al_Delal.Api.Models;

namespace Al_Delal.Api.Repositories.Vehicles
{
   public interface IVehicleRepository
   {
    
      PagedList<Vehicle> GetVehicles(VehicleParameters vehicleParameters);

      Task<Vehicle> GetVehicle(int? vehicleId);

      Task<int> AddVehicle(Vehicle vehicle);

      Task<int> DeleteVehicle(int? vehicleId);

      Task UpdateVehicle(Vehicle vehicle);
   }
}