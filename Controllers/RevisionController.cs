using Microsoft.AspNetCore.Mvc;

namespace GestionEscolar.Controllers
{
    public class RevisionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}