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
using Al_Delal.Api.Repositories.Base;

namespace Al_Delal.Api.Controller
{
   // [Authorize]
   [ApiController]
   [Route(ApiRoutes.Vehicles.Vehicle)]
   public class VehicleController : ControllerBase
   {
      private IRepositoryWrapper _repository;

      public VehicleController( IRepositoryWrapper repository)
      {

         _repository = repository;
      }

      [HttpGet]
      public IActionResult GetVehicles()
      {
         var vehicles = _repository.Vehicle.GetVehicles();

         // _logger.LogInfo($"Returned all Vehicles from database.");

         return Ok(vehicles);
      }

      [HttpGet("{id}", Name = "VehicleById")]
      public IActionResult GetVehicleById(int id)
      {
         var vehicle = _repository.Vehicle.GetVehicleById(id);

         if (vehicle == null)
         {
            // _logger.LogError($"vehicle with id: {id}, hasn't been found in db.");
            return NotFound();
         }
         else
         {
            // _logger.LogInfo($"Returned vehicle with id: {id}");
            return Ok(vehicle);
         }
      }

      [HttpPost]
      public IActionResult CreateVehicle([FromBody] Vehicle vehicle)
      {
         if (vehicle != null)
         {
            // _logger.LogError("Vehicle object sent from client is null.");
            return BadRequest("Vehicle object is null");
         }

         if (!ModelState.IsValid)
         {
            // _logger.LogError("Invalid Vehicle object sent from client.");
            return BadRequest("Invalid model object");
         }

         _repository.Vehicle.CreateVehicle(vehicle);
         _repository.Save();

         return CreatedAtRoute("VehicleById", new { id = vehicle.Id }, vehicle);
      }

      [HttpPut("{id}")]
      public IActionResult UpdateVehicle(int id, [FromBody] Vehicle vehicle)
      {
         if (vehicle != null)
         {
            // _logger.LogError("Vehicle object sent from client is null.");
            return BadRequest("Vehicle object is null");
         }

         if (!ModelState.IsValid)
         {
            // _logger.LogError("Invalid Vehicle object sent from client.");
            return BadRequest("Invalid model object");
         }

         var dbVehicle = _repository.Vehicle.GetVehicleById(id);
         if (dbVehicle == null)
         {
            // _logger.LogError($"Vehicle with id: {id}, hasn't been found in db.");
            return NotFound();
         }

         _repository.Vehicle.UpdateVehicle(dbVehicle, vehicle);
         _repository.Save();

         return NoContent();
      }

      [HttpDelete("{id}")]
      public IActionResult DeleteVehicle(int id)
      {
         var vehicle = _repository.Vehicle.GetVehicleById(id);
         if (vehicle == null)
         {
            // _logger.LogError($"Vehicle with id: {id}, hasn't been found in db.");
            return NotFound();
         }

         _repository.Vehicle.DeleteVehicle(vehicle);
         _repository.Save();

         return NoContent();
      }
   }
}