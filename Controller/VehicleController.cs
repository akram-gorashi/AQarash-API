using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Al_Delal.Api.Contract;
using Al_Delal.Api.Repositories.Vehicles;
using Al_Delal.Api.Resource.Vehicle;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace Al_Delal.Api.Controller
{

    [ApiController]
    [Route(ApiRoutes.Vehicles.Vehicle)]
    // [Authorize]
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

            return Ok(vehiclesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetVehicle(int id)
        {
            var vehicle = await _repo.GetVehicle(id);

            var vehicleToReturn = _mapper.Map<VehicleForDetailsDto>(vehicle);

            return Ok(vehicleToReturn);
        }
/* 
        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return Content("file not selected");

            var path = Path.Combine(
                        Directory.GetCurrentDirectory(), "wwwroot",
                        file.GetFilename());

            using (var stream = new FileStream(path, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return RedirectToAction("Files");
        } */
    }
}
