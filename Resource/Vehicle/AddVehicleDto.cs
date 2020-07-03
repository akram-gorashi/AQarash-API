using System;
using System.Collections.Generic;
using Al_Delal.Api.Models;
using Microsoft.AspNetCore.Http;

namespace Al_Delal.Api.Resource.Vehicle
{
    public class AddVehicleDto
    {
          public string Id { get; set; }
        public Make Make { get; set; }
      // public string TypeOfCar { get; set; }
      public int Mileage { get; set; }
      public Color Color { get; set; }
      public Condition Condition { get; set; }
      public Model Modal { get; set; }
      public int Year { get; set; }
      public Fuel Fuel { get; set; }
      public Transmission Transmission { get; set; }
      public string Price { get; set; }
      public string Description { get; set; }
      public string AgentName { get; set; }
      public string AgentPhoneNumber { get; set; }
      public string AgentLocation { get; set; }
      public int UserId { get; set; }
    }
}