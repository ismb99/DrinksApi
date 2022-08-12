using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DrinksAPI
{
    public class DrinkApi
    {
        public void GetDrinksByCategory()
        {

            var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest("list.php?c=list");
            var response =  client.ExecuteAsync(request);
            List<Category> categories = new();

            if (response.Result.StatusCode == HttpStatusCode.OK && response != null)
            {
                string rawResponse = response.Result.Content;
                var result = JsonConvert.DeserializeObject<Categories>(rawResponse);


                categories = result.Drinks;

                TableVisualition.ShowTable(categories, "Drinks Category");

            }
        }

        public  void DrinkName()
        {
            var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
            var request = new RestRequest("filter.php?c=Ordinary_Drink");
            var response = client.ExecuteAsync(request);

            List<OrdinaryDrink> ordinaryDrinks = new();


            if (response.Result.StatusCode == HttpStatusCode.OK && response != null)
            {
                string rawResponse = response.Result.Content;
                var result = JsonConvert.DeserializeObject<OrdinaryDrinkList>(rawResponse);

                ordinaryDrinks = result.OrdinaryDrinkNames;


                TableVisualition.ShowTable(ordinaryDrinks, "Ordinary Drinks List");

            }
        }
    }
}
