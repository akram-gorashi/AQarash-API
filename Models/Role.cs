using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Al_Delal.Api.Models
{
    public class Role : IdentityRole<int>
    {
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}