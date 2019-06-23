using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace GestionEscolar.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AreasController: ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] {"nombre materia","nombre dos"};
        }
    }
}