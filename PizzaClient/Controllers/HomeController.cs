using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PizzaClient.Models;
using PizzaClient.Utils;
using PizzaClient.VMs;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaClient.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PizzaClientTool _pizzaClient;

        public HomeController(ILogger<HomeController> logger, PizzaClientTool pizzaClientTool)
        {
            _logger = logger;
            _pizzaClient = pizzaClientTool;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM homeVm = new HomeVM();
            
            var pizzas = await _pizzaClient.GetPizzasAsync();
            if (pizzas == null || pizzas.Length == 0)
                homeVm.ErrorMessage = "We must be sold out. Try again tomorrow.";
            else
                homeVm.ErrorMessage = "";
            homeVm.Pizzas = pizzas;
            return View(homeVm);
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
