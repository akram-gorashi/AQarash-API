using System;

namespace Al_Delal.Api.Models
{
   public class FilterQuery : PageQuery
   {
       public int MakeId { get; set; }
      public int Mileage { get; set; }
      public int ColorId { get; set; }
      public int ConditionId { get; set; }
      public int ModalId { get; set; }
      public int Year { get; set; }
      public int FuelId { get; set; }
      public int TransmissionId { get; set; }
      public uint MinYear { get; set; }
      public uint MaxYear { get; set; } = (uint)DateTime.Now.Year;

      public bool ValidYearRange => MaxYear > MinYear;
   }
}