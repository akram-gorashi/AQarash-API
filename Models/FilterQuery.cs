using System;

namespace Al_Delal.Api.Models
{
   public class FilterQuery : PageQuery
   {
      public string Make { get; set; }
      public string TypeOfCar { get; set; }
      public int Mileage { get; set; }
      public string Condition { get; set; }
      public string Model { get; set; }

      public string Fuel { get; set; }
      public string Transmission { get; set; }
      public string Price { get; set; }
      public uint MinYear { get; set; }
      public uint MaxYear { get; set; } = (uint)DateTime.Now.Year;

      public bool ValidYearRange => MaxYear > MinYear;
   }
}