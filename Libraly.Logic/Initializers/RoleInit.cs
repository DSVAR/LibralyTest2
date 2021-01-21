using Libraly.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Libraly.Logic.Initializers
{
    public class RoleInit
    {
        public static async Task InitAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
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

            if (await roleManager.FindByNameAsync(admin)==null)
            { await roleManager.CreateAsync(new IdentityRole(admin)); }
            if (await roleManager.FindByNameAsync(librarian) == null)
            { await roleManager.CreateAsync(new IdentityRole(librarian)); }
            if (await roleManager.FindByNameAsync(user) == null)
            { await roleManager.CreateAsync(new IdentityRole(user)); }
            //добавление ролей

            if(await userManager.FindByEmailAsync(adminEmail) == null)
            {
                var adminNew = new User { Email = adminEmail, UserName = adminEmail };
                var result =await userManager.CreateAsync(adminNew, passwordAdm);
                if (result.Succeeded) 
                    await userManager.AddToRoleAsync(adminNew, admin);
            }


            if (await userManager.FindByEmailAsync(userEmail) == null)
            {
                var userNew = new User { Email = userEmail, UserName = userEmail };
                var result = await userManager.CreateAsync(userNew, userPassword);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(userNew, user);
            }


            if (await userManager.FindByEmailAsync(libEmail) == null)
            {
                var libriantNew = new User { Email = libEmail, UserName = libEmail };
                var result = await userManager.CreateAsync(libriantNew, librPassword);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(libriantNew, librarian);
            }

        }

    }
}
