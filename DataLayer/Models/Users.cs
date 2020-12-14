using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;

namespace DataLayer.Models
{
    class Users: IdentityUser
    {   
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
