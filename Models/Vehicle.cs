using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace Al_Delal.Api.Models
{
   public class Vehicle
   {
      public int Id { get; set; }
      public DateTime DateAdded { get; set; }
      public int MakeId { get; set; }
      // public string TypeOfCar { get; set; }
      public int Mileage { get; set; }
      public int ColorId { get; set; }
      public int ConditionId { get; set; }
      public int ModalId { get; set; }
      public int Year { get; set; }
      public int FuelId { get; set; }
      public int TransmissionId { get; set; }
      public string Price { get; set; }
      public string Description { get; set; }
      public string AgentName { get; set; }
      public string AgentPhoneNumber { get; set; }
      public string AgentLocation { get; set; }
      [NotMapped]
      public IEnumerable<IFormFile> Images { get; set; }
     /*  public virtual User User { get; set; }
 */      public int UserId { get; set; }
   }
}