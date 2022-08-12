using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace DrinksAPI
{
    public class Category
    {
        public string strCategory { get; set; }
    }

    public class Categories
    {
        public List<Category> Drinks { get; set; }

    }
}
