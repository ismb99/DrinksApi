using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksAPI
{
    public class UserInput
    {
        DrinkApi drinkApi = new();

        public void GetCategoriesInput()
        {
            var categories = drinkApi.GetCategory();

            Console.WriteLine("Choose category:");

            string category = Console.ReadLine();

            while (!Validator.IsStringValid(category))
            {
                Console.WriteLine("\nInvalid category");
                category = Console.ReadLine();
            }

            if (!categories.Any(x => x.DrinksCategory == category))
            {
                Console.WriteLine("Category doesn't exist.");
                GetCategoriesInput();
            }

            GetDrinksInput(category);
        }

        private void GetDrinksInput(string category)
        {
            var drinks = drinkApi.GetDrinksByCategory(category);

            Console.WriteLine("Choose a drink or go back to category menu by typing 0:");
            string drink = Console.ReadLine();

            if (drink == "0")
                GetCategoriesInput();

            while (!Validator.IsIdValid(drink))
            {
                Console.WriteLine("\nInvalid drink");
                drink = Console.ReadLine();
            }

            if (!drinks.Any(x => x.idDrink == drink))
            {
                Console.WriteLine("Drink doesn't exist.");
                GetDrinksInput(category);
            }

            drinkApi.GetDrink(drink);

            Console.WriteLine("Press any key to go back to categories menu");
            Console.ReadKey();
        }
    }
}
