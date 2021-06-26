using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using backend.Models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaInfoController : ControllerBase
    {
        private static readonly PizzaInfo[] TheMenu = new[]
        {
            new PizzaInfo { PizzaName = "The Mighty Meatball", Ingredients = "Meatballs and cheese", Cost = 40, InStock = "yes"},
            new PizzaInfo { PizzaName = "Crab Apple", Ingredients = "Dungeness crab and apples", Cost = 35, InStock = "no"},
            new PizzaInfo { PizzaName = "Forest Floor", Ingredients = "Mushrooms, rutabagas, and walnuts", Cost = 20, InStock = "yes"},
            new PizzaInfo { PizzaName = "Don't At Me", Ingredients = "Pineapple, Canadian bacon, jalapeños", Cost = 25, InStock = "yes"},
            new PizzaInfo { PizzaName = "Vanilla", Ingredients = "Sausage and pepperoni", Cost = 15, InStock = "no"},
            new PizzaInfo { PizzaName = "Spice Coming At Ya", Ingredients = "Peppers, chili sauce, spicy andouille", Cost = 50, InStock = "yes"}
        };
        private readonly ILogger<PizzaInfoController> _logger;

        public PizzaInfoController(ILogger<PizzaInfoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PizzaInfo>>> GetTModels()
        {
            // TODO: Your code here
            await Task.Yield();
            return new ActionResult<IEnumerable<PizzaInfo>>(TheMenu);
        }

    }
}