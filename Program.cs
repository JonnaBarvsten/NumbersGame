using System;
using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NumbersGame
{
    internal class Program
    {

        public static string CheckGuesses(int );
        {
        
        }
        
        static void Main(string[] args)
        {
            // Print message to user. 
            Console.WriteLine("Welcome! I'm thinking about a number. Can you guess which? You get five tries.");

            var rnd = new Random();
            int number = rnd.Next(1, 121);

           
            bool isRunning = true;

                for ( int i = 0; i < 5; i ++) 
                {
                    Console.Write("Guess number: ");
                    int guessNumber = int.Parse(Console.ReadLine());

                    Console.WriteLine(guessNumber);

                    if (guessNumber == number)
                {
                    Console.WriteLine("WOHO you made it!");

                    isRunning = false; 
                      
                }
                else if (guessNumber < number)
                {
                    Console.WriteLine("The number was to low!");
                        
                }
                else
                {
                    Console.WriteLine("You guess to high");
                        
                }
                

                   
                }

            Console.WriteLine("Sorry you failed guessing on 5 times");






            CheckGuesses();

        }
    }
}
