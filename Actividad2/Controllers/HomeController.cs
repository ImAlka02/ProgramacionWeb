﻿using Actividad2.Models;
using Microsoft.AspNetCore.Mvc;

namespace Actividad2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(MonedaViewModel vm)
        {
            if (vm.Moneda == "MX")
            {
                vm.Conversion = vm.Valor * (decimal)18.00;
            } else if (vm.Moneda == "USD")
            {
                vm.Conversion = vm.Valor / (decimal)18.00;
            }
            return View(vm);
        }
    }
}
