using System;

namespace Al_Delal.Api.Resource.User
{
    public class UserForListDto
    {
        public string FullName { get; set; }
        public string Username { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }

    }
}

