using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Libraly.Logic.Interfaces
{
    public interface IUserService
    {
        Task Creat(UserViewModel);
        Task LogIn();
        Task LogOut();
        Task ChangePassword();
        Task Delete();
    }
}
