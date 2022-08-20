using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksAPI
{
    public class Menu
    {

       public static void ShowMenu()
        {
            Console.Clear();
            bool isRunning = false;

            while (!isRunning)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Welcome to the drink api");
                Console.WriteLine("Choose an option");
                Console.WriteLine("1, Get categories");
                Console.WriteLine("2 Quit");
                Console.WriteLine("********************************");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DrinkApi.GetCategory();

                        break;

                        case "2":
                        Console.WriteLine("Goodbye");
                        isRunning = true;
                        break;

                        default:
                        Console.WriteLine("Wrong input");
                        break;
                }
            }
            // Skriv inte ut tomma properies
            // Ett sätt att välja categorier utan att behöva skriva in namnet eller switch med hårdkoade värden som meny meny
        }
    }
}
