using AutoMapper;
using Libraly.Data.Entities;
using Libraly.Logic.Interfaces;
using Libraly_test2_.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Libraly.Logic.Services
{
    public class UserService : IUserService
    {
        UserManager<User> _userManager;
        SignInManager<User> _signInManager;
        IMapper _mapper;

        public UserService(UserManager<User> userManager,SignInManager<User> signInManager,IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }


        public async Task ChangePassword()
        {
            throw new NotImplementedException();
        }

        public async Task<IdentityResult> Creat(RegisterViewModel model)
        {
            return await _userManager.CreateAsync(_mapper.Map<User>(model), model.Password);
        }

        public async Task Delete()
        {
            throw new NotImplementedException();
        }

        public async Task LogOut()
        {
            throw new NotImplementedException();
        }

        public async Task Register()
        {
            throw new NotImplementedException();
        }
    }
}
