using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Al_Delal.Api.Models
{
   public class User : IdentityUser<int>
   {
      public string FullName { get; set; }
      public string Gender { get; set; }
      public DateTime Created { get; set; }
      public DateTime LastActive { get; set; }
      public virtual ICollection<UserRole> UserRoles { get; set; }

      /* there is no relation between user and vehicle just send userid with vehcile post request to register the 
      vehcile with the  user id */
      // public Vehicle Vehicle { get; set; }

   }
}