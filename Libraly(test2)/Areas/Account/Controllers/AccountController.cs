using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libraly_test2_.Areas.Account
{
    public class AccountController : Controller
    {

        // GET: AccountController
        public ActionResult Index()
        {
            return View();
        }

       
    }
}
