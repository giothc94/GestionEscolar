using Microsoft.AspNetCore.Mvc;

namespace GestionEscolar.Controllers
{
    public class NotasController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}