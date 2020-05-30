using System;
using System.Collections.Generic;
using Al_Delal.Api.Models;
using Microsoft.AspNetCore.Http;

namespace Al_Delal.Api.Resource.Vehicle
{
    public class AddVehicleDto
    {
          public string Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string Make { get; set; }
        public string TypeOfCar { get; set; }
        public int Mileage { get; set; }
        public string Color { get; set; }
        public string Condition { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Fuel { get; set; }
        public string Transmission { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        //  public List<IFormFile> Photos { get; set; }
       
        public string UserId { get; set; }
    }
}