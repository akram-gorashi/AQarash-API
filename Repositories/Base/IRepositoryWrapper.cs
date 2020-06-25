using Al_Delal.Api.Repositories.Vehicles;

namespace Al_Delal.Api.Repositories.Base
{
   public interface IRepositoryWrapper
   {
      IVehicleRepository Vehicle { get; }
      void Save();
   }
}