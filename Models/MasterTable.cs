using System.Collections.Generic;

namespace Al_Delal.Api.Models
{
   public class MasterTable
   {
      public int Id { get; set; }

      /* Toyota */
      public ICollection<Make> Make { get; set; }
      public ICollection<Color> Color { get; set; }
      public ICollection<Condition> Condition { get; set; }
      // Corolla 
      public ICollection<Model> Modal { get; set; }
      public ICollection<Fuel> Fuel { get; set; }
      public ICollection<Transmission> Transmission { get; set; }

   }

   public class Transmission
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public string NameAr { get; set; }
   }

   public class Fuel
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public string NameAr { get; set; }
   }

   public class Model
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public string NameAr { get; set; }
   }

   public class Condition
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public string NameAr { get; set; }
   }

   public class Color
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public string NameAr { get; set; }
   }

   public class Make
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public string NameAr { get; set; }
   }
}