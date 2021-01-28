using Libraly.Data.Entities;
using Libraly.Logic.Models.UserDTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Libraly.Logic.Interfaces
{
    public interface IUserService
    {
        //Действия с пользователем
        Task<IdentityResult> Creat(User user);
        Task<User> GetUser();
        Task<SignInResult> LogIn(User user, bool b);
        Task LogOut();
        Task<IdentityResult> ChangePassword(User user,ChangePasswordViewsModel change);
        Task<IdentityResult> Delete(User user);
        //Действия с ролями
        Task AddRole(User user,string name);
    }
}
