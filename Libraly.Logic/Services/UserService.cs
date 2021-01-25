using AutoMapper;
using Libraly.Data.Entities;
using Libraly.Logic.Interfaces;
using Libraly.Logic.Models.UserDTO;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Libraly.Logic.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IMapper _mapper;

        public UserService(UserManager<User> userManager,SignInManager<User> signInManager,IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
        }


        public async Task<IdentityResult> ChangePassword(ChangePasswordViewsModel change)
        {
            return await _userManager.ChangePasswordAsync(_mapper.Map<User>(change), change.OldPassword, change.NewPassword);
        }

        public async Task<IdentityResult> Creat(User user)
        {
            return await _userManager.CreateAsync(user, user.Password);
        }

        public async Task<IdentityResult> Delete(User user)
        {
            return await _userManager.DeleteAsync(user);
        }

        public async Task LogOut()
        {
            await _signInManager.SignOutAsync();
        }
        public async Task<SignInResult> LogIn(User user, bool b)
        {
                
                return await _signInManager.PasswordSignInAsync(user.UserName, user.Password, false, false);
           
        }

        public async Task AddRole(User user, string name)
        {
            await _userManager.AddToRoleAsync(user, name);
        }
    }
}
