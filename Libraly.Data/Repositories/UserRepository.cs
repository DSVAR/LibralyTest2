using System;
using System.Collections.Generic;
using System.Text;
using Libraly.Data.Interfaces;
using Libraly.Data.Models;
using Libraly.Data.Context;

namespace Libraly.Data.Repositories
{
   public class UserRepository : IUserActions<Users>
    {
    //    private Users User;
        private readonly ApplicationContext App;
        public UserRepository(ApplicationContext context) 
        {
            App=context;
        }

        public void AddUser(Users user)
        {
            throw new NotImplementedException();
        }

        public void DeleteUser(Users user)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Users> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void UpdateUser(Users user)
        {
            throw new NotImplementedException();
        }

        public Users UserFind(string value)
        {
            return App.Users.Find(value);
        }
    }
}
