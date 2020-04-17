using System;
using System.Collections.Generic;

namespace Al_Delal.Api.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string Make { get; set; }
        public string TypeOfCar { get; set; }
        public string Mileage { get; set; }
        public string Color { get; set; }
        public string Condition { get; set; }
        public string Model { get; set; }
        public string Year { get; set; }
        public string Fuel { get; set; }
        public string Transmission { get; set; }
        public ICollection<Photo> Photos { get; set; }
    }
}