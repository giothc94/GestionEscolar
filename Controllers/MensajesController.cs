using Microsoft.AspNetCore.Mvc;

namespace GestionEscolar.Controllers
{
    public class MensajesController:Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}