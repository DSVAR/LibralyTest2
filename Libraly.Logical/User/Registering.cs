using System;
using System.Collections.Generic;
using System.Text;
using Libraly.Data.Context;
using Libraly.Data.Models;
using Libraly.Data.Repositories;

namespace Libraly.Logical.User
{
    public class Registering
    {
     
        private Users User;
        private readonly UserRepository UR;

        public Registering(UserRepository repo)
        {
            UR = repo;
        }

        public bool Register(Users user)
        {
            try { 
            UR.AddUser(user);
            UR.SaveChanges();
                return true;
            }
            catch {
            return false;
            }

        }

        public bool CheckMail(string mail)
        {
            var users = UR.GetAllUsers();
            foreach(var i in users)
            {
                if (i.Email == mail)
                    User = i;
            }

            
            if (User.Email == null)
                return false ;

            else
                return true;
        }

        public bool CheckNickname(string nickname)
        {
            var users = UR.GetAllUsers();
            foreach (var i in users)
            {
                if (i.NickName == nickname)
                    User = i;
            }


            if (User.NickName == null)
                return false;

            else
                return true;

        }
    }
}
