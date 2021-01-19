using Libraly.Data.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Libraly.Logic.Initializers
{
    class RoleInit
    {
        public static async Task InitAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            const string admin = "Администратор";
            string adminEmail = "admin@gmail.com";
            string passwordAdm = "AdM12";
            //Админ
            const string librariant = "Библиотекарь";
            string libEmail = "libr@gmail.com";
            string librPassword = "LiBR11";
            //библиотекарь
            const string user = "Пользователь";
            string userEmail = "user@mail.ru";
            string userPassord = "User1";
            //Пользователь, обыкновеный

            if (await roleManager.FindByNameAsync(admin)==null)
            { await roleManager.CreateAsync(new IdentityRole(admin)); }
            if (await roleManager.FindByNameAsync(librariant) == null)
            { await roleManager.CreateAsync(new IdentityRole(librariant)); }
            if (await roleManager.FindByNameAsync(user) == null)
            { await roleManager.CreateAsync(new IdentityRole(user)); }
            //добавление ролей

        }

    }
}
