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


        //public int GetNumInput(string message)
        //{
        //    Console.Write(message);
        //    string input = Console.ReadLine();
        //    while (!int.TryParse(input, out _) || int.Parse(input) < 0)
        //    {
        //        Console.WriteLine("Invalid input, try again");
        //        input = Console.ReadLine();
        //    }
        //    int finalInput = int.Parse(input);
        //    return finalInput;
        //}

        //public static string GetStringInput()
        //{
        //    //Console.Write(message);

        //    string input = Console.ReadLine();
          

        //    while (String.IsNullOrEmpty(input))
        //    {
        //        Console.WriteLine("Invalid input,try again");
        //        input = Console.ReadLine();
        //    }
        //    return input;
        //}

        public void GetCategoriesInput()
        {
            drinkApi.GetCategory();
            Console.WriteLine("Choose category:");

            string category = Console.ReadLine();

            while (!Validator.IsStringValid(category))
            {
                Console.WriteLine("\nInvalid category");
                category = Console.ReadLine();
            }

            GetDrinksInput(category);
        }

        private void GetDrinksInput(string category)
        {
            drinkApi.GetDrinksByCategory(category);

            Console.WriteLine("Choose a drink or go back to category menu by typing 0:");
            string drink = Console.ReadLine();

            if (drink == "0")
                GetCategoriesInput();

            while (!Validator.IsIdValid(drink))
            {
                Console.WriteLine("\nInvalid drink");
                drink = Console.ReadLine();
            }

            drinkApi.GetDrink(drink);
        }
    }
}
