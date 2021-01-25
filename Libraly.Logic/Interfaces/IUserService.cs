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
        Task<IdentityResult> Creat(User user);
        Task<SignInResult> LogIn(User user, bool b);
        Task LogOut();
        Task<IdentityResult> ChangePassword(ChangePasswordViewsModel change);
        Task<IdentityResult> Delete(User user);
        Task AddRole(User user,string name);
    }
}
