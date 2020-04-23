using System;
using System.Collections.Generic;

namespace Al_Delal.Api.Models
{
    public class User
    {
         public int Id { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
         public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public string Phone { get; set; }
     /* there is no relation between user and vehicle just send userid with vehcile post request to register the 
     vehcile with the  user id */
       // public Vehicle Vehicle { get; set; }
    }
}