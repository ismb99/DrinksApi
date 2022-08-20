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
        public string strCategory { get; set; }
        public string strAlcoholic { get; set; }
        public string strIngredient1 { get; set; }
        public string strIngredient2 { get; set; }
        public string strIngredient3 { get; set; }
        public string strIngredient4 { get; set; }

    }

    public class OrdinaryDrinkList
    {
        [JsonProperty("drinks")]
        public List<OrdinaryDrink> OrdinaryDrinkNames { get; set; }

    }
}
