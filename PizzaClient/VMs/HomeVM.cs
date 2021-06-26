using PizzaClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaClient.VMs
{
    public class HomeVM
    {
        public IEnumerable<PizzaInfo> Pizzas { get; set; }
        public string ErrorMessage { get; set; }
    }
}
