using Libraly.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Libraly.Data.Interfaces
{
    public interface IUserActions<T> where T:class 
    {
        public IEnumerable<T> GetAllUsers();
        public Users UserFind(string value);
        public void AddUser(Users user);
        public void DeleteUser(Users user);
        public void UpdateUser(Users user);
        public void SaveChanges();
    }
}
