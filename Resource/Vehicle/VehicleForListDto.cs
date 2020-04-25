using System;
using System.Collections.Generic;
using Al_Delal.Api.Models;

namespace Al_Delal.Api.Resource.Vehicle
{
    public class VehicleForListDto
    {
        // refrence https://www.olx.co.za/cars-bakkies_c378
        public int Id { get; set; }
        public string Model { get; set; }
        public int Mileage { get; set; }

        public int Year { get; set; }
        public string Price { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public int UserId { get; set; }
    }
}