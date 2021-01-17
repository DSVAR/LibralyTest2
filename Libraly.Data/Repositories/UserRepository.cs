using System;
using System.Collections.Generic;
using System.Text;
using Libraly.Data.Interfaces;
using Libraly.Data.Models;
using Libraly.Data.Context;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Libraly.Data.Repositories
{
   public class UserRepository : IActionBD<User>
    {
        private User User;
        private readonly ApplicationContext App;
        private readonly UserManager<User> UM;
        public UserRepository(ApplicationContext context,UserManager<User> _UM) 
        {
            App=context;
            UM = _UM;
        }

        public void Add(User user)
        {
            App.Users.Add(user);
        }

        public void Delete(User user)
        {
            App.Users.Remove(user);
        }

        public IEnumerable<User> GetAllDates()
        {
            return App.Users;
        }

        public void SaveChanges()
        {
            App.SaveChanges();
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User> Find(string Id)
        {
            return await UM.FindByIdAsync(Id);
        }
    }
}
