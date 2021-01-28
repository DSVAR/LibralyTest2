using AutoMapper;
using Libraly.Data.Entities;
using Libraly.Logic.Interfaces;
using Libraly.Logic.Models.UserDTO;
using Microsoft.AspNetCore.Http;
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
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        IHttpContextAccessor _httpContext;

        public UserService(UserManager<User> userManager, RoleManager<IdentityRole> roleManager ,SignInManager<User> signInManager,IMapper mapper, IHttpContextAccessor httpContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _mapper = mapper;
            _httpContext = httpContext;
            _roleManager = roleManager;
        }


        public async Task<IdentityResult> ChangePassword(User user,ChangePasswordViewsModel change)
        {
            return await _userManager.ChangePasswordAsync(user, change.OldPassword, change.NewPassword);
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

        public async Task<User> GetUser()
        {
            return await _userManager.GetUserAsync(_httpContext.HttpContext.User);
        }

        public async Task<IdentityRole> FindRoleName(string name)
        {
            return await _roleManager.FindByNameAsync(name);
        }

        public async Task AddRole(string name)
        {
            await _roleManager.CreateAsync(new IdentityRole(name));
        }

        public async Task<User> FindUser(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }

        public async Task AddToRole(User user, string role)
        {
           await _userManager.AddToRoleAsync(user, role);
        }
    }
}
