using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Libraly_test2_.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "")]
        string UserName { get; set; }
        [Required(ErrorMessage = "")]
        string Password { get; set; }
    }
}
