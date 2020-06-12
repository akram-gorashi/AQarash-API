using System;
using System.ComponentModel.DataAnnotations;

namespace Al_Delal.Api.Resource.User
{
   public class UserForRegisterDto
   {
      [Required]
      public string Username { get; set; }
      [Required]
      public string FullName { get; set; }
      [Required]
      [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify a password between 4 and 8 characters")]
      public string Password { get; set; }
      public DateTime Created { get; set; }
   }
}