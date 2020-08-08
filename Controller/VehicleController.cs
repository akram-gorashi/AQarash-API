using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Al_Delal.Api.Contract;
using Al_Delal.Api.Models;
using Al_Delal.Api.Repositories.Vehicles;
using Al_Delal.Api.Resource.Vehicle;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Newtonsoft.Json;

namespace Al_Delal.Api.Controller
{
   // [Authorize]
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

      [HttpPost]

      public async Task<IActionResult> AddVehicle([FromForm] Vehicle vehicle)
      {

         try
         {
            var vehicleId = await _repo.AddVehicle(vehicle);
            if (vehicleId > 0)
            {
               if (vehicle.Images != null)
               {
                  UploadImages(vehicle.Images, vehicleId);
               }
               
               return Ok(vehicleId);
            }
            else
            {
               return NotFound();
            }
         }
         catch (Exception)
         {

            return BadRequest("Realy Bad request");
         }


      }

      public IActionResult UploadImages(IEnumerable<IFormFile> Images, int vehicleId)
      {

         try
         {
            var files = Images;
            var folderName = Path.Combine("/", vehicleId.ToString());
            if (!Directory.Exists(folderName))
            {
               Directory.CreateDirectory(folderName);
            }
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);

            if (files.Any(f => f.Length == 0))
            {
               return BadRequest("No Images");
            }

            foreach (var file in files)
            {
               var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
               
               var fullPath = Path.Combine(pathToSave, fileName);
               var dbPath = Path.Combine(folderName, fileName); //you can add this path to a list and then return all dbPaths to the client if require

               using (var stream = new FileStream(fullPath, FileMode.Create))
               {
                  file.CopyTo(stream);
               }
            }

            return Ok("All the files are successfully uploaded.");
         }
         catch (Exception)
         {
            return StatusCode(500, "Internal server error");
         }


      }
      [HttpGet]
      public IActionResult GetVehicles([FromQuery] FilterQuery filterQuery)
      {
         try
         {
            var vehicles = _repo.GetVehicles(filterQuery);
            var metadata = new
            {
               vehicles.TotalCount,
               vehicles.PageSize,
               vehicles.CurrentPage,
               vehicles.TotalPages,
               vehicles.HasNext,
               vehicles.HasPrevious
            };
            if (vehicles == null)
            {
               return NotFound();
            }
            var vehiclesToReturn = _mapper.Map<IEnumerable<VehicleForListDto>>(vehicles);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));

            return Ok(vehiclesToReturn);
         }
         catch (Exception)
         {
            return BadRequest();
         }
      }

      [HttpGet("{id}")]
      public async Task<IActionResult> GetVehicle(int id)
      {
         try
         {
            var vehicle = await _repo.GetVehicle(id);
            if (vehicle == null)
            {
               return NotFound();
            }
            var vehicleToReturn = _mapper.Map<VehicleForDetailsDto>(vehicle);

            return Ok(vehicleToReturn);
         }

         catch (Exception)
         {
            return BadRequest();
         }
      }
      [HttpDelete("{vehicleId}")]
      public async Task<IActionResult> DeleteVehicle(int? vehicleId)
      {
         int result = 0;

         if (vehicleId == null)
         {
            return BadRequest();
         }

         try
         {
            result = await _repo.DeleteVehicle(vehicleId);
            if (result == 0)
            {
               return NotFound();
            }
            return Ok();
         }
         catch (Exception)
         {

            return BadRequest();
         }
      }


      [HttpPut]

      public async Task<IActionResult> UpdateVehicle([FromBody] Vehicle vehicle)
      {
         if (ModelState.IsValid)
         {
            try
            {
               await _repo.UpdateVehicle(vehicle);

               return Ok();
            }
            catch (Exception ex)
            {
               if (ex.GetType().FullName == "Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException")
               {
                  return NotFound();
               }

               return BadRequest();
            }
         }

         return BadRequest();
      }


   }


}
