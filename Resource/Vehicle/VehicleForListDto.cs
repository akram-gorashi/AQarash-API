using System;
using System.Collections.Generic;
using Al_Delal.Api.Models;

namespace Al_Delal.Api.Resource.Vehicle
{
   public class VehicleForListDto
   {
      // refrence https://www.olx.co.za/cars-bakkies_c378
      public int Id { get; set; }
      public DateTime DateAdded { get; set; }

      public Model Model { get; set; }
      public int Mileage { get; set; }
      public int Year { get; set; }
      public string Price { get; set; }

   }
}