using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Al_Delal.Api.Data;
using Al_Delal.Api.Models;
using Al_Delal.Api.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Al_Delal.Api.Repositories.Vehicles
{
    public class VehicleRepository : RepositoryBase<Vehicle>, IVehicleRepository
    {
     public VehicleRepository(DataContext repositoryContext)
			: base(repositoryContext)
		{
		}

		public IEnumerable<Vehicle> GetVehicles()
		{
			return FindAll()
				.OrderBy(v => v.Year);
		}

		public Vehicle GetVehicleById(int vehicleId)
		{
			return FindByCondition(vehicle => vehicle.Id.Equals(vehicleId))
				.DefaultIfEmpty(new Vehicle())
				.FirstOrDefault();
		}

		public void CreateVehicle(Vehicle vehicle)
		{
			Create(vehicle);
		}

		public void UpdateVehicle(Vehicle dbVehicle, Vehicle Vehicle)
		{
			/* dbVehicle.Map(Vehicle);
			Update(dbVehicle); */
		}

		public void DeleteVehicle(Vehicle vehicle)
		{
			Delete(vehicle);
		}
	}
}