using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Libraly_test2_.Areas.Controllers
{
    public class AHomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
