using System.Collections.Generic;
using System.Threading.Tasks;
using Al_Delal.Api.Models;
using Al_Delal.Api.Repositories.Base;

namespace Al_Delal.Api.Repositories.Vehicles
{
   public interface IVehicleRepository : IRepositoryBase<Vehicle>
   {
      IEnumerable<Vehicle> GetVehicles();
      Vehicle GetVehicleById(int VehicleId);
      void CreateVehicle(Vehicle Vehicle);
      void UpdateVehicle(Vehicle dbVehicle, Vehicle Vehicle);
      void DeleteVehicle(Vehicle Vehicle);
   }
}