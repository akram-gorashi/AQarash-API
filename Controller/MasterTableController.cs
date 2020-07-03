using System.Threading.Tasks;
using Al_Delal.Api.Contract;
using Al_Delal.Api.Repositories.Vehicles;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;


namespace Al_Delal.Api.Controller
{
   [ApiController]
   [Route(ApiRoutes.MasterTables.MasterTable)]

   public class MasterTableController : ControllerBase
   {
      private readonly IVehicleRepository _repo;
      private readonly IMapper _mapper;

      public MasterTableController(IVehicleRepository repo, IMapper mapper)
      {
         _mapper = mapper;
         _repo = repo;
      }

      [HttpGet]
      public async Task<IActionResult> GetUsers()
      {
         var masterTable = await _repo.GetMasterTable();
         return Ok(masterTable);
      }

   }
}