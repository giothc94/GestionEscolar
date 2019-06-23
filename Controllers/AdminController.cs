using Microsoft.AspNetCore.Mvc;

namespace GestionEscolar.Controllers
{
    public class AdminController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Dashboard()
        {
            return View();
        }
        public IActionResult Listas()
        {
            return View();
        }
        public IActionResult RegistrarDocente()
        {
            return View();
        }
        public IActionResult RegistrarEstudiante()
        {
            return View();
        }
        public IActionResult RegistrarCarrera()
        {
            return View();
        }
        public IActionResult RegistrarMateria()
        {
            return View();
        }
    }
}