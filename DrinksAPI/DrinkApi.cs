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
        RestClient BaseUrl = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");


        public void GetCategory()
        {
            var request = new RestRequest("list.php?c=list");
            var response = BaseUrl.ExecuteAsync(request);

            if (response.Result.IsSuccessful)
            {
                string rawResponse = response.Result.Content;
                var result = JsonConvert.DeserializeObject<Categories>(rawResponse);
                List<Category> categories = result.Drinks;

                TableVisualition.ShowTable(categories, "Drinks Category");

                Console.WriteLine("\nChoose category");
                var input = UserInput.GetStringInput();
                GetDrinksByCategory(input);
            }
        }

        //public void DrinkName()
        //{
        //    var request = new RestRequest("filter.php?c=Ordinary_Drink");
        //    var response = BaseUrl.ExecuteAsync(request);

        //    List<OrdinaryDrink> ordinaryDrinks = new();

        //    if (response.Result.StatusCode == HttpStatusCode.OK && response != null)
        //    {
        //        string rawResponse = response.Result.Content;
        //        var result = JsonConvert.DeserializeObject<OrdinaryDrinkList>(rawResponse);

        //        ordinaryDrinks = result.OrdinaryDrinkNames;

        //        TableVisualition.ShowTable(ordinaryDrinks, "Ordinary Drinks List");
        //    }
        //}

        public void GetDrinksByCategory(string name)
        {
            var request = new RestRequest($"filter.php?c={name}");
            var response = BaseUrl.ExecuteAsync(request);

            var res = response;
            if (response.Result.IsSuccessful)
            {
                string rawResponse = response.Result.Content;
                var result = JsonConvert.DeserializeObject<OrdinaryDrinkList>(rawResponse);

                if (result == null)
                {
                    Console.WriteLine("Wrong input try again, press any key to continue");
                    Console.ReadLine();
                    GetCategory();


                    //Console.WriteLine("\nChoose category");
                    //var input = UserInput.GetStringInput();
                    //GetDrinksByCategory(input);
                }

                else
                {
                    List<OrdinaryDrink> drinkType = result?.OrdinaryDrinkNames;
                    TableVisualition.ShowTable(drinkType, name.ToUpper());

                    Console.WriteLine("\nChoose a drink by id");
                    var drinkId = UserInput.GetStringInput();
                    GetDrinksById(drinkId);


                }

            }
        }

        public void GetDrinksById(string id)
        {
            var request = new RestRequest($"lookup.php?i={id}");
            var response = BaseUrl.ExecuteAsync(request);

            List<OrdinaryDrink> ordinaryDrinks = new();

            if (response.Result.StatusCode == HttpStatusCode.OK)
            {
                string rawResponse = response.Result.Content;
                var result = JsonConvert.DeserializeObject<OrdinaryDrinkList>(rawResponse);

                ordinaryDrinks = result.OrdinaryDrinkNames;

                TableVisualition.ShowTable(ordinaryDrinks, "Drink info");


                //if (result == null)
                //{
                //    Console.WriteLine("Wrong input try again, press any key to continue");
                //    Console.ReadLine();
                //    GetCategory();

                //    //Console.WriteLine("\nChoose category");
                //    //var input = UserInput.GetStringInput();
                //    //GetDrinksByCategory(input);
                //}

                //else
                //{
                //    List<OrdinaryDrink> drinkType = result?.OrdinaryDrinkNames;
                //    TableVisualition.ShowTable(drinkType, id.ToUpper());
                //}

            }
        }
    }
}
