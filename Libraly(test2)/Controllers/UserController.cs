using Libraly.Data.Context;
using Libraly.Data.Entities;
using Libraly_test2_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Libraly_test2_.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly ApplicationContext AppContext;


        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UserController(ILogger<UserController> logger, ApplicationContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _logger = logger;
            AppContext = context;
            _userManager = userManager;
            _signInManager = signInManager;
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
                var user = new User { UserName = model.UserName, FullName = model.FullName, FirstName = model.FirstName, Email=model.Email};
                var resulr = await _userManager.CreateAsync(user,model.Password);

                if (resulr.Succeeded) 
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else { 
                    foreach (var error in resulr.Errors)
                    {
                        ModelState.AddModelError("ConfirmPassword", error.Description);
                    }
                }
            }
                return View(model);
        }


        [HttpGet]
        public IActionResult Entry(string returnUrl=null)
        {
            return View(new LoginViewModel { ReturnUrl=returnUrl});
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Entry(LoginViewModel model)
        {
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
            
            if(result.Succeeded)
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
            return View(model);
        }

     
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
           
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
