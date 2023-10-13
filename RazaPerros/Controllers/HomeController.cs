using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RazaPerros.Models.Entities;
using RazaPerros.Models.ViewModels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RazaPerros.Controllers
{
    public class HomeController : Controller
    {
        PerrosContext context = new();

        public IActionResult Index(string id)
        {
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
        [Route ("/Raza/{nombre}")]
        public IActionResult Raza(string nombre)
        {
            Random random = new();

            var datos = context.Razas.Include(x => x.IdPaisNavigation)
                .Include(x => x.Estadisticasraza)
                .Include(x => x.Caracteristicasfisicas).Where(x => x.Nombre == nombre.Replace("-"," ")).FirstOrDefault();

            InfoRazaViewModel vm = new InfoRazaViewModel()
            {
                Id = datos.Id,
                NombreRaza = datos.Nombre ?? "No disponible",
                Descripcion = datos.Descripcion ?? "No disponible",
                OtrosNombres = datos.OtrosNombres ?? "No disponible",
                Pais = datos.IdPaisNavigation.Nombre ?? "No disponible",
                Peso = datos.PesoMin + " - " + datos.PesoMax,
                Altura = datos.AlturaMin + " - " + datos.AlturaMax,
                EsperanzaVida = datos.EsperanzaVida,
                NivelEnergia = datos.Estadisticasraza.NivelEnergia,
                FacilidadEntrenamiento = datos.Estadisticasraza.FacilidadEntrenamiento,
                EjercicioObligatiorio = datos.Estadisticasraza.EjercicioObligatorio,
                AmigableExtraños = datos.Estadisticasraza.AmistadDesconocidos,
                AmigablePerros = datos.Estadisticasraza.AmistadPerros,
                NecesidadCepillado = datos.Estadisticasraza.NecesidadCepillado,
                Patas = datos.Caracteristicasfisicas.Patas ?? "No disponible",
                Cola = datos.Caracteristicasfisicas.Cola ?? "No disponible",
                Hocico = datos.Caracteristicasfisicas.Hocico ?? "No disponible",
                Pelo = datos.Caracteristicasfisicas.Pelo ?? "No disponible",
                Color = datos.Caracteristicasfisicas.Color ?? "No disponible",
                Perros = context.Razas.Where(x => x.Nombre != nombre.Replace("-", " ")).Select(x => new PerroModel()
                {
                    Id = x.Id,
                    Nombre = x.Nombre
                }).OrderBy(x => EF.Functions.Random()).ToList().Take(4)
                };


            
            return View(vm);
        }

        [Route ("/ListadoPaises")]
        public IActionResult Paises()
        {
            var datos = context.Razas.OrderBy(x=>x.IdPaisNavigation.Nombre)
                .GroupBy(x=> x.IdPaisNavigation.Nombre)
                .Select( x=> new PaisesViewModel(){
                    Pais = x.Key,
                    Perros = x.Select( y => new PerroModel()
                    {
                        Id = y.Id,
                        Nombre = y.Nombre
                    })
                });
            return View(datos);
        }
    }
}
