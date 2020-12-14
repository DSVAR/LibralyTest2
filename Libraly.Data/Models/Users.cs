using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libraly.Data.Models
{
    public class Users : IdentityUser
    {
        public string FirstName { get; set; }
        public string FullName { get; set; }
        public string NickName { get; set; }
    }
}
