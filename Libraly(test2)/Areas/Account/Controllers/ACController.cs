using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Libraly.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Libraly.Logic.Models.UserDTO;
using Libraly.Logic.Services;
using AutoMapper;

namespace Libraly_test2_.Areas.Account
{
    public class ACController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserService _userService;
        private readonly UserManager<User> _userManager;

        public ACController(UserManager<User> userManager, UserService userService,IMapper mapper)
        {
            _userManager = userManager;
            _userService = userService;
            _mapper = mapper;
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

                var user = await _userService.GetUser();

                if (user != null)
                {
                    IdentityResult result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    var res = await _userService.ChangePassword(model);
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
