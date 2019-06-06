using Microsoft.AspNetCore.Mvc;

namespace GestionEscolar.Controllers
{
    public class CursosController : Controller
    {
        public IActionResult Revision()
        {
            return View();
        }
    }
}