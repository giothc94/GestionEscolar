using Microsoft.AspNetCore.Mvc;

namespace GestionEscolar.Controllers
{
    public class DocenteController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Nombre = "Gabriel";
            ViewBag.Materia = "Matematica Fiananciera";
            ViewBag.nr = 24;
            return View(ViewBag);
        }
        public IActionResult Notas()
        {
            return View();
        }
    }
}