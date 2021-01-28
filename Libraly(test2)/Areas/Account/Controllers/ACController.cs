using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Libraly.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Libraly.Logic.Models.UserDTO;
using Libraly.Logic.Services;
using AutoMapper;
using Libraly.Logic.Interfaces;

namespace Libraly_test2_.Areas.Account
{
    public class ACController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly UserManager<User> _userManager;

        public ACController(UserManager<User> userManager, IUserService userService,IMapper mapper)
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
                  //  IdentityResult result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    var res = await _userService.ChangePassword(user, model);
                    if (res.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        foreach (var errors in res.Errors)
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


       [HttpGet]
        public IActionResult AddBooks()
        {
            return View();
        }
    }
}
