﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Libraly.Logic.Models.UserDTO
{
    public class RegisterViewModel 
    {
        [Required(ErrorMessage ="Пустое поле")]
        public string FirstName { get; set; }

     
        [Required(ErrorMessage = "Пустое поле") ]
        public string FullName { get; set; }


        [Required(ErrorMessage = "Пустое поле")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Пустое поле")]
        [RegularExpression(@"^[A-Za-z0-9.+-]+@[A-Za-z0-9-]+\.[A-Za-z]{2,4}$",ErrorMessage ="Почта должна выглядить так sobaken@gmail.com")]
        public string Email { get; set; }
      

        [Required(ErrorMessage = "Пустое поле")]
        [RegularExpression(@"^[A-Za-z0-9]{4,20}$",ErrorMessage ="Не соблюдены правила для пароля.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Compare("Password",ErrorMessage ="Не одинаковые пароли.")]
        public string ConfirmPassword { get; set; }
    }
}
