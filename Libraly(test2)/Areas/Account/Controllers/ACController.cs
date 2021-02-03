using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Libraly.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Libraly.Logic.Models.UserDTO;
using Libraly.Logic.Services;
using AutoMapper;
using Libraly.Logic.Interfaces;
using Libraly.Logic.Models.BookDTO;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Collections;

namespace Libraly_test2_.Areas.Account
{
    public class ACController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        private readonly IBookService _bookService;
        private readonly  IWebHostEnvironment _webHostEnviroment;
        
        public ACController(IUserService userService,IMapper mapper, IBookService bookService, IWebHostEnvironment webHostEnviroment)
        {
            _userService = userService;
            _mapper = mapper;
            _bookService = bookService;
            _webHostEnviroment = webHostEnviroment;
            
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


        [HttpPost]
        public IActionResult AddBooks(BookViewModel model,IFormFile formFile)
        {

            if (model.Url != null || formFile != null)
            {
                if (model.Url != null && formFile != null)
                    ModelState.AddModelError("PhotoPath", "Выбрать один из ресурсов обложки");
            }
            else
            {
                ModelState.AddModelError("PhotoPath", "Выберете обложку");
            }

            if (ModelState.IsValid) {

                

                var path = _webHostEnviroment.WebRootPath + "Images";
                var pathsecond = Path.Combine(_webHostEnviroment.WebRootPath, "Images");
                _bookService.Creat(model);
            }
            

            return View(model);
        }
    }
}
