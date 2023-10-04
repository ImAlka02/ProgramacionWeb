using Act1ZooPlanet.Models.Entities;
using Act1ZooPlanet.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Act1ZooPlanet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            AnimalesContext context = new();

            var datos = context.Clase.OrderBy(x => x.Nombre).Select(x=> new ClaseViewModel()
            {
                Id = x.Id,
                Nombre = x.Nombre ?? "Sin clase",
                Descripcion = x.Descripcion ?? "Sin descripcion"
            });
            return View(datos);
        }
    }
}
