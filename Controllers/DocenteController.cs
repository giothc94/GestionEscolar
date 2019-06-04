using Microsoft.AspNetCore.Mvc;

namespace GestionEscolar.Controllers
{
    public class DocenteController : Controller
    {
        public IActionResult Index()
        {
            
            return View();
        }
    }
}