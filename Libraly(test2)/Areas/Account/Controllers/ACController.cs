using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libraly_test2_.Models;
using Libraly.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Libraly.Logic.Models.UserDTO;

namespace Libraly_test2_.Areas.Account
{
    public class ACController : Controller
    {


        private readonly UserManager<User> _userManager;

        public ACController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }
        // GET: AccountController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(ChangePasswordViewsModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(User);
                if (user != null)
                {
                    IdentityResult result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var errors in result.Errors)
                        {
                            ModelState.AddModelError("OldPassword", errors.Description);
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
