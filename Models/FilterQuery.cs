using System;

namespace Al_Delal.Api.Models
{
   public class FilterQuery : PageQuery
   {
      public string Make { get; set; }
      public int Mileage { get; set; }
      public int Condition { get; set; }
      public int Model { get; set; }

      public int Fuel { get; set; }
      public int Transmission { get; set; }
      public string Price { get; set; }
      public uint MinYear { get; set; }
      public uint MaxYear { get; set; } = (uint)DateTime.Now.Year;

      public bool ValidYearRange => MaxYear > MinYear;
   }
}