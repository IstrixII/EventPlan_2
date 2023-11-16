using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Teste1.Controllers
{
    public class EventosController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
