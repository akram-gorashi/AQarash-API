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
        public DateTime LastActive { get; set; }
        public string City { get; set; }
        public int Phone { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}