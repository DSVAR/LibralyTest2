using Libraly_test2_.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Libraly.Logic.Interfaces
{
    public interface IUserService
    {
        Task<IdentityResult> Creat(RegisterViewModel model);
        Task LogIn();
        Task LogOut();
        Task ChangePassword();
        Task Delete();
    }
}
