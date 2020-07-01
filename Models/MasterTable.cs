using System.Collections.Generic;

namespace Al_Delal.Api.Models
{
   public class MasterTable
   {
      public int Id { get; set; }

      /* Toyota */
      public IList<Make> Make { get; set; }
      public IList<Color> Color { get; set; }
      public IList<Condition> Condition { get; set; }
      // Corolla 
      public IList<Model> Modal { get; set; }
      public IList<Fuel> Fuel { get; set; }
      public IList<Transmission> Transmission { get; set; }

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