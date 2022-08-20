using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksAPI.Models
{
    public class OrdinaryDrink
    {
        [JsonProperty("StrDrink")]
        public string Drink { get; set; }

        [JsonProperty("IdDrink")]
        public string Id { get; set; }

        [JsonProperty("strCategory")]
        public string Category { get; set; }

        [JsonProperty("strAlcoholic")]
        public string Alcoholic { get; set; }

        [JsonProperty("strIngredient1")]
        public string Ingredient1 { get; set; }

        [JsonProperty("strIngredient2")]
        public string Ingredient2 { get; set; }

        [JsonProperty("strIngredient3")]
        public string Ingredient3 { get; set; }

        [JsonProperty("strIngredient4")]
        public string Ingredient4 { get; set; }
    }

    public class OrdinaryDrinkList
    {
        [JsonProperty("drinks")]
        public List<OrdinaryDrink> OrdinaryDrinkNames { get; set; }

    }
}
