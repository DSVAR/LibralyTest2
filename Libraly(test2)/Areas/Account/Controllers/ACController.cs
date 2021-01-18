using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libraly_test2_.Models;
using Libraly.Data.Models;
using Microsoft.AspNetCore.Identity;
using Libraly.Data.Repositories;

namespace Libraly_test2_.Areas.Account
{
    public class ACController : Controller
    {

        private readonly UserRepository UR;
        private readonly UserManager<User> UM;
        
       public ACController(UserRepository _UR, UserManager<User> _UM)
        {
            UR = _UR;
            UM = _UM;
        }
        // GET: AccountController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ChangePasswordViewsModel model)
        {
            if (ModelState.IsValid) { 
                var user = await UM.GetUserAsync(User);
                if (user != null)
                {
                    IdentityResult result = await UM.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach(var errors in result.Errors)
                        {
                            ModelState.AddModelError("NewPassword", errors.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError("NewPassword", "Пользователь не найден");
                }
            }
          
            return View(model);
        }


    }
}
