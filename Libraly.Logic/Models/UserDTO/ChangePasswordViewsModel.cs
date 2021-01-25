using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Libraly.Logic.Models.UserDTO
{
    public class ChangePasswordViewsModel
    {
        public string Id { get; set; }


       [Required(ErrorMessage = "Пустая строка")]
        public string OldPassword { get; set; }


        [Required(ErrorMessage = "Пустая строка")]
        [Compare("OldPassword", ErrorMessage ="Пароли не совпадают")]
        public string RepeatOldPassword { get; set; }


        [Required(ErrorMessage = "Пустая строка")]
        public string NewPassword { get; set; }
    }
}
