using System.Linq;

namespace Al_Delal.Api.Helper
{
   public static class AppUtill
   {
      /**
      * Checks if an object fields are null or empty
      */
      public static bool IsObjectNullOrEmpty(object Object)
      {
         return Object.GetType().GetProperties()
         .Where(pi => pi.PropertyType == typeof(string))
         .Select(pi => (string)pi.GetValue(Object))
         .All(value => string.IsNullOrEmpty(value));
      }
   }
}