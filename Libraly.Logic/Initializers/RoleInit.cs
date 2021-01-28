using Libraly.Data.Entities;
using Libraly.Logic.Interfaces;
using Libraly.Logic.Models.UserDTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Libraly.Logic.Initializers
{
    public class RoleInit
    {

        // сделать все через сервисы!!!!!
        public static async Task InitAsync(IUserService _userService)
        {
            const string admin = "Администратор";
            string adminEmail = "admin@gmail.com";
            string passwordAdm = "Administartor12";
            //Админ
            const string librarian = "Библиотекарь";
            string libEmail = "libr@gmail.com";
            string librPassword = "Librian11";
            //библиотекарь
            const string user = "Пользователь";
            string userEmail = "user@mail.ru";
            string userPassword = "Userjoke1";
            //Пользователь, обыкновеный

            //if (await roleManager.FindByNameAsync(admin)==null)
            //{ await roleManager.CreateAsync(new IdentityRole(admin)); }
            //if (await roleManager.FindByNameAsync(librarian) == null)
            //{ await roleManager.CreateAsync(new IdentityRole(librarian)); }
            //if (await roleManager.FindByNameAsync(user) == null)
            //{ await roleManager.CreateAsync(new IdentityRole(user)); }


            if(await _userService.FindRoleName(admin) == null) 
            { await _userService.AddRole(admin); }

            if (await _userService.FindRoleName(librarian) == null)
            { await _userService.AddRole(librarian); }

            if (await _userService.FindRoleName(user) == null)
            { await _userService.AddRole(user); }
            //добавление ролей

            if (await _userService.FindUser(adminEmail) == null)
            {   var adminNew = new UserModelView { Email = adminEmail, UserName = adminEmail,Password=passwordAdm };
                var result =await _userService.Creat(adminNew);
                if (result.Succeeded) 
                    await _userService.AddToRole(adminNew, admin);
            }

            if (await _userService.FindUser(userEmail) == null)
            {
                var userNew = new UserModelView { Email = userEmail, UserName = userEmail, Password = userPassword };
                var result = await _userService.Creat(userNew);
                if (result.Succeeded)
                    await _userService.AddToRole(userNew, user);
            }


            if (await _userService.FindUser(libEmail) == null)
            {
                var libriantNew = new UserModelView { Email = libEmail, UserName = libEmail, Password = librPassword};
                var result = await _userService.Creat(libriantNew);
                if (result.Succeeded)
                    await _userService.AddToRole(libriantNew, librarian);
            }




        }

    }
}
