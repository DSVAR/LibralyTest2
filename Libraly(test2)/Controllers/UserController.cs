using Libraly.Data.Context;
using Libraly.Data.Models;
using Libraly_test2_.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Text.RegularExpressions;
using Libraly.Logical.User;

namespace Libraly_test2_.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly ApplicationContext AppContext;
        private string PatternEmail = @"^[A-Za-z0-9.+-]+@[A-Za-z0-9-]+\.[A-Za-z]{2,4}$";
        private string PatternPassword = @"[A-Za-z0-9]";
        private readonly Registering Reg;

        public UserController(ILogger<UserController> logger, ApplicationContext Context, Registering registering)
        {
            _logger = logger;
            AppContext = Context;
            Reg = registering;
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(Users model)
        {
            if (string.IsNullOrEmpty(model.NickName)) { ModelState.AddModelError("NickName", "Строка никнейма пустая"); }
            else
            {
                //есть похожий никнейм
            }

            if (string.IsNullOrEmpty(model.FirstName)) { ModelState.AddModelError("FirstName", "Строка имени пустая"); }
            if (string.IsNullOrEmpty(model.FullName)) { ModelState.AddModelError("FullName", "Строка Фамилии пустая"); }


            if (string.IsNullOrEmpty(model.Email)) { ModelState.AddModelError("Email", "Строка почты пустая"); }
            else
            {
                if (!Regex.IsMatch(model.Email, PatternEmail)) { ModelState.AddModelError("Email", "Не верный формат email"); }
                else
                 if (Reg.CheckMail(model.Email)) { ModelState.AddModelError("Email", "Такой почтовый ящик зарегистрирован"); }
            }

            if (string.IsNullOrEmpty(model.PasswordHash)) { ModelState.AddModelError("PasswordHash", "Строка пароля пустая"); }
            else
            {
                if (Regex.IsMatch(model.PasswordHash, PatternPassword)) { /*ModelState.AddModelError("PasswordHash", "бум");*/ }
                else { ModelState.AddModelError("PasswordHash", "пароль не совпадает с правилами"); }
            }


            if (ModelState.IsValid)
            {

                ModelState.AddModelError("PasswordHash","most likely");
            }



            return View(model);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
