using System.Collections.Generic;
using System.Threading.Tasks;
using Al_Delal.Api.Contract;
using Al_Delal.Api.Repositories.Vehicles;
using Al_Delal.Api.Resource.Vehicle;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Al_Delal.Api.Controller
{
    [Authorize]
    [ApiController]
    [Route(ApiRoutes.Vehicles.Vehicle)]
    public class VehicleController : ControllerBase
    {
        private readonly IVehicleRepository _repo;
        private readonly IMapper _mapper;
        public VehicleController(IVehicleRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetVehicles()
        {
            var vehicles = await _repo.GetVehicles();

            var vehiclesToReturn = _mapper.Map<IEnumerable<VehicleForListDto>>(vehicles);

            return Ok(vehicles);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await _repo.GetVehicle(id);

            var vehicleToReturn = _mapper.Map<VehicleForDetailsDto>(vehicle);

            return Ok(vehicleToReturn);
        }
    }

}
