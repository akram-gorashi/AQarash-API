using Al_Delal.Api.Data;
using Al_Delal.Api.Repositories.Vehicles;

namespace Al_Delal.Api.Repositories.Base
{
   public class RepositoryWrapper : IRepositoryWrapper
	{
		private DataContext _repoContext;
		private IVehicleRepository _vehicle;
	

		public IVehicleRepository Vehicle
		{
			get
			{
				if (_vehicle == null)
				{
					_vehicle = new VehicleRepository(_repoContext);
				}

				return _vehicle;
			}
		}

		

	/* 	public RepositoryWrapper(DataContext repositoryContext)
		{
			_repoContext = repositoryContext;
		} */

		public void Save()
		{
			_repoContext.SaveChanges();
		}
	}
}