using System;
using System.Collections;
using System.Collections.Generic;
using Al_Delal.Api.Models;

namespace Al_Delal.Api.Resource.Vehicle
{
   public class VehicleForDetailsDto
   {
      public int Id { get; set; }
      public DateTime DateAdded { get; set; }
      public string Make { get; set; }
      public int Mileage { get; set; }
      public string Color { get; set; }
      public string Condition { get; set; }
      public string Model { get; set; }
      public int Year { get; set; }
      public string Fuel { get; set; }
      public string Transmission { get; set; }
      public int Price { get; set; }
      public string Description { get; set; }
      public string AgentName { get; set; }
      public string AgentPhoneNumber { get; set; }
      public string AgentLocation { get; set; }
      public IList<string> ImageUrl { get; set; }
      public int UserId { get; set; }
      public IList<VehicleForListDto> relatedVehicles { get; set; }
   }
}