using System;
using System.Collections.Generic;
using System.Text;
using Libraly.Data.Context;
using Libraly.Data.Models;
using Libraly.Data.Repositories;
using Microsoft.AspNetCore.Identity;

namespace Libraly.Logical.User
{
    public class Registering
    {
     
        private Data.Models.User User;
        private readonly UserRepository UR;


        private readonly UserManager<Data.Models.User> UM;
        public Registering(UserRepository repo, UserManager<Data.Models.User> _UM)
        {
            UR = repo;
            UM = _UM;
        }

        public  bool Register(Data.Models.User user)
        {
            
           var result=  UM.CreateAsync(User);
          

           return true;
        }

        public bool CheckMail(string mail)
        {
            var users = UR.GetAllDates();
            foreach(var i in users)
            {
                if (i.Email == mail)
                    User = i;
            }


            if (User != null)
            {
                if (User.Email == null)
                    return false;

                else
                    return true;
            }
            else
                return false;
        }

        public bool CheckNickname(string nickname)
        {
            var users = UR.GetAllDates();
            foreach (var i in users)
            {
                if (i.NickName == nickname)
                    User = i;
            }

            
            if (User != null) { 
                if (User.NickName== null )
                    return false;

                else
                    return true;
            }
            else
                return false;

        }
    }
}
