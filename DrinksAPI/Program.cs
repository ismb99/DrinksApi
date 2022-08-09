using DrinksAPI;
using Newtonsoft.Json;
using RestSharp;
using System.Net;


GetByingredients();

//var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
//var request = new RestRequest("list.php?c=list");
//var response = await client.ExecuteAsync(request);

//if (response.StatusCode == HttpStatusCode.OK &&  response != null)
//{
//    string rawResponse = response.Content;
//    var result = JsonConvert.DeserializeObject<CategoryDrinks>(rawResponse);

//    foreach (var item in result.Drinks)
//    {
//        Console.WriteLine(item.strCategory);
//    }
//}


void  GetByingredients()
{
    var client = new RestClient("https://www.thecocktaildb.com/api/json/v1/1/");
    var request = new RestRequest("list.php?i=list");
    var response =  client.ExecuteAsync(request);

    if (response.Result.StatusCode == HttpStatusCode.OK)
    {
        string rawResponse = response.Result.Content;
        var result = JsonConvert.DeserializeObject<CategoryDrinks>(rawResponse);

        foreach (var item in result.Drinks)
        {
            Console.WriteLine(item.strIngredient1);
        }
    }
}
    
