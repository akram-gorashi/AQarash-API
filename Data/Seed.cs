using System.Collections.Generic;
using Al_Delal.Api.Models;
using Newtonsoft.Json;

namespace Al_Delal.Api.Data
{
    public class Seed
    {
        private readonly DataContext _context;
        public Seed(DataContext context)
        {
            _context = context;
        }

        public void SeedUsers() 
        {
            var userData = System.IO.File.ReadAllText("Data/seedVehicle.json");
            var users = JsonConvert.DeserializeObject<List<Vehicle>>(userData);
            foreach (var user in users)
            {
                _context.Vehicles.Add(user);
            }

            _context.SaveChanges();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            } 
        }
    }
}