using Libraly.Data.Context;
using Libraly.Data.Models;
using Libraly_test2_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Libraly.Logical.User;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Libraly_test2_.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly ApplicationContext AppContext;


        private readonly UserManager<User> UM;
        private readonly SignInManager<User> SIM;

        public UserController(ILogger<UserController> logger, ApplicationContext Context, UserManager<User> _UM, SignInManager<User> _SIM)
        {
            _logger = logger;
            AppContext = Context;
            UM = _UM;
            SIM = _SIM;
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
                var resulr = await UM.CreateAsync(user,model.Password);

                if (resulr.Succeeded) 
                {
                    await SIM.SignInAsync(user, false);
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
            var result = await SIM.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
            
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
            await SIM.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
