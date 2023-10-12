using Microsoft.AspNetCore.Mvc;
using RazaPerros.Models.Entities;
using RazaPerros.Models.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RazaPerros.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string id)
        {
            PerrosContext context = new();
            IndexViewModel vm = new();
            
            var datos = context.Razas.OrderBy(x => x.Nombre).Select(x => new Raza()
            {
                Id = x.Id,
                NombreRaza = x.Nombre
            });
            var letras = datos.Select(x => x.NombreRaza[0]).ToList();
            vm.Letra = letras.Distinct();
            if (id == null)
            {
                vm.Razas = datos;
            }
            else
            {
                datos = datos.Where(x => x.NombreRaza.StartsWith(id));
                vm.Razas = datos;
            }
            return View(vm);

            //var datos = context.Razas.OrderBy(x => x.Nombre).Select(x => new Raza()
            //{
            //    Id = x.Id,
            //    NombreRaza = x.Nombre
            //});
            //var o = datos.GroupBy(x => x.NombreRaza.Substring(0, 1)).ToList();

            //vm.Razas = datos;
            //vm.Letra = new();
            //foreach (var l in o)
            //{
            //    vm.Letra.Add(l.Key);
            //}

            //if (id == null)
            //{
            //    return View(vm);
            //} else
            //{
            //    var x = o.FirstOrDefault(x => x.Key == id);
            //    vm.Razas = x;
            //    return View(vm);
            //}
        }

        public IActionResult Raza(string nombre)
        {
            return View();
        }
    }
}
