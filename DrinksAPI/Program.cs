using DrinksAPI;
using Newtonsoft.Json;
using RestSharp;
using System.Net;



var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
var request = new RestRequest("list.php?c=list");
var response = await client.ExecuteAsync(request);

if (response.StatusCode == HttpStatusCode.OK && response != null)
{
    string rawResponse = response.Content;
    var result = JsonConvert.DeserializeObject<CategoryDrinks>(rawResponse);

    foreach (var item in result.Drinks)
    {
        Console.WriteLine(item.strCategory);
    }
}



