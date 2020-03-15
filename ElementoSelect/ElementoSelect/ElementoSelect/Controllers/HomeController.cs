using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ElementoSelect.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ElementoSelect.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var model = new Pedido();
            model.Clientes = new List<SelectListItem>()
            {
                new SelectListItem("Seleccionar cliente","0",true),
                new SelectListItem("Cliente 2","1"),
                new SelectListItem("Cliente 2","2"),
                new SelectListItem("Cliente 3","3"),
                new SelectListItem("Cliente 4","4"),
            };
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
