using System.Collections.Generic;
using System.Threading.Tasks;
using Al_Delal.Api.Models;

namespace Al_Delal.Api.Repositories.Vehicles
{
    public interface IVehicleRepository
    {

        Task<List<Vehicle>> GetVehicles();

        Task<Vehicle> GetVehicle(int? vehicleId);

        Task<int> AddVehicle(Vehicle vehicle);

        Task<int> DeleteVehicle(int? vehicleId);

        Task UpdateVehicle(Vehicle vehicle);
    }
}