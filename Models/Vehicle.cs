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
        public int Mileage { get; set; }
        public string Color { get; set; }
        public string Condition { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public string Fuel { get; set; }
        public string Transmission { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
    }
}