using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Libraly.Data.Entities
{
    public class User : IdentityUser
    {
      
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
        public string Password { get; set; }
    }
}
