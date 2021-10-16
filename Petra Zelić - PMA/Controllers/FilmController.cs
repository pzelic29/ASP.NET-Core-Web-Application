using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Petra_Zelić___PMA.Controllers
{
    public class FilmController : Controller
    {
        public IActionResult Film()   //sluze za prikaz nekog sadrzaja tj. Viewa
        {
            return View();
        }

        public IActionResult NoviFilm()
        {
            return View();
        }

        public IActionResult IzmjeniFilm()
        {
            return View();
        }
    }
}
