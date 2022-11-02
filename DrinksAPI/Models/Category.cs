using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DrinksAPI.Models
{
    public class Category
    {
        [JsonProperty("strCategory")]
        public string? DrinksCategory { get; set; }
    }

    public class Categories
    {
        [JsonProperty("drinks")]

        public List<Category>? CategoriesList { get; set; }
    }
}
