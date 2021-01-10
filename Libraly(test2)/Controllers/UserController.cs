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

//        private readonly Registering Reg;

        private readonly UserManager<User> UM;
        private readonly SignInManager<User> SIM;
        public UserController(ILogger<UserController> logger, ApplicationContext Context, Registering registering,  UserManager<User> _UM, SignInManager<User> _SIM)
        {
            _logger = logger;
            AppContext = Context;
         //   Reg = registering;
            UM = _UM;
            SIM = _SIM;
        }


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

        public IActionResult Entry(User model)
        {
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
