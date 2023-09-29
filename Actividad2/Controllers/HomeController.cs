using Actividad2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Actividad2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Convertir(MonedaViewModel vm) 
        {
            if(vm.Moneda == "mx" || vm.Moneda == "MX")
            {
                vm.Conversion = vm.Valor * (decimal)18.00;
            } else if(vm.Moneda == "usd" || vm.Moneda == "USD")
            {
                vm.Conversion = vm.Valor / (decimal)18.00;
            }
            return View(vm);  
        }
    }
}
