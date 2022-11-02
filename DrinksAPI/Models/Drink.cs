﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksAPI.Models
{
    public class Drink
    {
        public string idDrink { get; set; }
        public string strDrink { get; set; }
    }

    public class Drinks
    {
        [JsonProperty("drinks")]
        public List<Drink> DrinkList { get; set; }
    }

}
