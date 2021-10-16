using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Petra_Zelić___PMA.Controllers
{
    public class ZanrController : Controller
    {
        // ovi kontroleri sluze za prikaz view-a
        public IActionResult Zanr()
        {
            return View();
        }
    }
}
