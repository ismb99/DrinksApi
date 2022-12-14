using DrinksAPI.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DrinksAPI
{
    public class DrinkApi
    {
        static RestClient BaseUrl = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");

        public List<Category> GetCategory()
        {
            var request = new RestRequest("list.php?c=list");
            var response = BaseUrl.ExecuteAsync(request);

            List<Category> categories = new();

            if (response.Result.IsSuccessful)
            {
                string rawResponse = response.Result.Content;

                var result = JsonConvert.DeserializeObject<Categories>(rawResponse);
               
               categories = result.CategoriesList;
               

                TableVisualition.ShowTable(categories, "Categories Menu");
                return categories;

            }

            return categories;
        }



        public List<Drink>GetDrinksByCategory(string category)
        {
            var request = new RestRequest($"filter.php?c={category}");
            var response = BaseUrl.ExecuteAsync(request);

            List<Drink> drinks = new();

            if (response.Result.IsSuccessful)
            {
                string rawResponse = response.Result.Content;

                var result = JsonConvert.DeserializeObject<Drinks>(rawResponse);

                drinks = result.DrinkList;

                TableVisualition.ShowTable(drinks, "Drinks Menu");
                return drinks;

            }
            return drinks;
        }

        internal void GetDrink(string? drink)
        {
            var request = new RestRequest($"lookup.php?i={drink}");
            var response = BaseUrl.ExecuteAsync(request);

            if (response.Result.IsSuccessful)
            {
                string rawResponse = response.Result.Content;

                var result = JsonConvert.DeserializeObject<DrinkDetailObject>(rawResponse);
                List<DrinkDetail> returnedList = result.DrinkDetailList;

                DrinkDetail drinkDetail = returnedList[0];

                List<object> prepList = new();

                string formattedName = "";

                foreach (PropertyInfo prop in drinkDetail.GetType().GetProperties())
                {
                    if (prop.Name.Contains("str"))
                    {
                        formattedName = prop.Name.Substring(3);
                    }

                    if (!string.IsNullOrEmpty(prop.GetValue(drinkDetail)?.ToString()))
                    {
                        prepList.Add(new
                        {
                            Key = formattedName,
                            Value = prop.GetValue(drinkDetail)
                        });
                    }
                }

                TableVisualition.ShowTable(prepList, drinkDetail.strDrink);
            }
        }
    }
}
