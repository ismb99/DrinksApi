using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksAPI
{
    public class OrdinaryDrink
    {
        public string StrDrink { get; set; }
        public string IdDrink { get; set; }
    }

    public class OrdinaryDrinkList
    {
        [JsonProperty("drinks")]
        public List<OrdinaryDrink> OrdinaryDrinkNames { get; set; }

    }
}
