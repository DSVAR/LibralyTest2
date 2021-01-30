using Libraly.Data.Context;
using Libraly.Data.Entities;
using Libraly_test2_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using Libraly.Logic.Models.UserDTO;
using Libraly.Logic.Interfaces;
using AutoMapper;

namespace Libraly_test2_.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        

        private readonly IMapper _mapper;
        private readonly IUserService _userService;
  


        public UserController(ILogger<UserController> logger,  IUserService userService, IMapper mapper)
        {
            _logger = logger;        
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                //var user = new User { UserName = model.UserName, FullName = model.FullName, FirstName = model.FirstName, Email = model.Email };
                //var resulr = await _userManager.CreateAsync(user, model.Password);
                var user = _mapper.Map<UserModelView>(model);
                var result = await _userService.Creat(user);

                if (result.Succeeded)
                {
                    await _userService.LogIn(user, false);
                   // await _signInManager.SignInAsync(user, false);
                   // await _userManager.AddToRoleAsync(user, "Пользователь");
                    await _userService.AddRole(user, "Пользователь");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("ConfirmPassword", error.Description);
                    }
                }
            }
            return View(model);
        }


        [HttpGet]
        public IActionResult Entry(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Entry(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                //  var sw = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                var user = _mapper.Map<UserModelView>(model);
                var result = await _userService.LogIn(user, false);

                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("Password", "Неправильный логин или пароль.");
                }


            }
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _userService.LogOut();

            return Redirect("~/Home/Index");
        }

        [HttpGet]
        public IActionResult Account()
        {
            return RedirectToAction("Account/");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
