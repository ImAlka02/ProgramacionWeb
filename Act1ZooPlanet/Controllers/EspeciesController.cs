using Act1ZooPlanet.Models.Entities;
using Act1ZooPlanet.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace Act1ZooPlanet.Controllers
{
    public class EspeciesController : Controller
    {
        public IActionResult Index(string Id)
        {
            Id = Id.Replace("-", " ");
            AnimalesContext context = new();

            var datos = context.Clase.Where(x=> x.Nombre == Id).Include(x => x.Especies)
                .Select(x => new EspeciesViewModel()
                {
                    IdClase = x.Id,
                    NombreClase = x.Nombre ?? "Sin nombre",
                    Especie = x.Especies.Select(x => new EspecieModel()
                    {
                        IdEspecie = x.Id,
                        NombreEspecie = x.Especie
                    })
                }).FirstOrDefault();
            
            return View(datos);
        }

        public IActionResult Especie(string Id) 
        {
            Id = Id.Replace("-", " ");

            AnimalesContext context = new();

            var datos = context.Especies.Where(x => x.Especie == Id).Include(x => x.IdClaseNavigation).Select(x=> new EspecieViewModel()
            {
                Id = x.Id,
                Nombre = x.Especie,
                Clase = x.IdClaseNavigation.Nombre,
                Habitad = x.Habitat,
                Observaciones = x.Observaciones,
                Peso = x.Peso,
                Size = x.Tamaño
            }).FirstOrDefault();
            return View(datos);
        }
    }
}
