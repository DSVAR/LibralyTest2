using System;
using System.Collections.Generic;
using System.Text;
using Libraly.Data.Interfaces;
using Libraly.Data.Models;
using Libraly.Data.Context;

namespace Libraly.Data.Repositories
{
   public class UserRepository : IActionBD<User>
    {
        private User User;
        private readonly ApplicationContext App;
        public UserRepository(ApplicationContext context) 
        {
            App=context;
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

        public User Find(string value)
        {
            return App.Users.Find(value) ;
        }
    }
}
