using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace Al_Delal.Api.Models
{
   public class Vehicle
   {
      public int Id { get; set; }
      public DateTime DateAdded { get; set; }
      public IList<Make> Make { get; set; }
      // public string TypeOfCar { get; set; }
      public int Mileage { get; set; }
      public IList<Color> Color { get; set; }
      public IList<Condition> Condition { get; set; }
      public IList<Model> Modal { get; set; }
      public int Year { get; set; }
      public IList<Fuel> Fuel { get; set; }
      public IList<Transmission> Transmission { get; set; }
      public string Price { get; set; }
      public string Description { get; set; }
      public string AgentName { get; set; }
      public string AgentPhoneNumber { get; set; }
      public string AgentLocation { get; set; }

      public User User { get; set; }
      public int UserId { get; set; }
   }
}