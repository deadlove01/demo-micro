using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PizzaClient.Models
{
    public class PizzaInfo
    {
        public string PizzaName { get; set; }

        public int Cost { get; set; }

        public string Ingredients { get; set; }

        public string InStock { get; set; }
    }

}
