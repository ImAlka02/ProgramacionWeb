using Act1ZooPlanet.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Act1ZooPlanet.Controllers
{
    public class EspeciesController : Controller
    {
        public IActionResult Index()
        {
            AnimalesContext context = new();

            var datos = context.
            return View();
        }
    }
}
