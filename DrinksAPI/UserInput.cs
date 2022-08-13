using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrinksAPI
{
    public class UserInput
    {
        public int GetNumInput(string message)
        {
            Console.Write(message);
            string input = Console.ReadLine();
            while (!int.TryParse(input, out _) || int.Parse(input) < 0)
            {
                Console.WriteLine("Invalid input, try again");
                input = Console.ReadLine();
            }
            int finalInput = int.Parse(input);
            return finalInput;
        }

        public static string GetStringInput()
        {
            //Console.Write(message);

            string input = Console.ReadLine();

            while (String.IsNullOrEmpty(input))
            {
                Console.WriteLine("Invalid input,try again");
                input = Console.ReadLine();
            }
            return input;
        }
    }
}
