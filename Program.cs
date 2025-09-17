using System;
using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NumbersGame
{
    internal class Program
    {

        public static string CheckGuessing(int guessNumber, int number)
        {
           
                if (guessNumber == number)
                {
                   
                    return "WOHO you made it";

                }
                else if (guessNumber < number)
                {
                    return "The number was to low!";

                }
                else
                {
                    return "You guess to high";

                }
            }

        static void Main(string[] args)
        {
            // Print message to user. 
            Console.WriteLine("Welcome! I'm thinking about a number. Can you guess which? You get five tries.");

            var rnd = new Random();
            int number = rnd.Next(1,21);
            int guessNumber;
            int tries = 0; 

            
            while ( tries < 5) 
            { 
            for (int i = 0; i < 5; i++)
            {
                Console.Write("Guess number: ");
                bool sucess = int.TryParse(Console.ReadLine(), out guessNumber);

                if (!sucess) 
                {
                    Console.WriteLine("Please enter a number");
                    // Gör att loopen börjar om istället för retunera 0 värde
                    continue;
                    
                }

                    tries++;

               string result = CheckGuessing(guessNumber, number);

                Console.WriteLine(result);
                
                if(guessNumber == number) 
                    {
                        return; 
                    }

            }

            }

            Console.WriteLine("Sorry you failed guessing on 5 times");






        }

        
    }
}
