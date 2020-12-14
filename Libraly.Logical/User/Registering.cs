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
          //  UR = repo;
        }

        public void Register(Users user)
        {
            
        }

        public bool CheckMail(string mail)
        {
            User = UR.UserFind(mail);
            if (User == null)
                return false;

            else
                return true;
        }

    }
}
