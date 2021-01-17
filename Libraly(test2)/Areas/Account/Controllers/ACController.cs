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
       public ACController(UserRepository _UR)
        {
            UR = _UR;
        }
        // GET: AccountController
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewsModel model)
        {
            User user = await UR.Find(model.Id);

            return View();
        }


    }
}
