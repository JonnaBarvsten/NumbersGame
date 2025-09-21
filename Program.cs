using System;
using System.Data;
using System.Diagnostics.Metrics;
using System.Runtime.Intrinsics.Arm;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace NumbersGame
{
    internal class Program
    {
    
        // Jonna Barvsten
        // Fullstack.NET

        // Returns messages based on how close the guess is to correct numnbe,
        public static string CheckGuess(int guessNumber, int number)
        {
           // Declare a integer that writes diffrent message
            int diff = Math.Abs(guessNumber - number);
            string message; 

            
            if (diff == 0)
            {

                message = "WOHO you made it!";

            }
            else if (diff <= 1)
            {
                message = "It is burning, you are very close!";

            }
            else if (diff <= 3)
            {
                message = "Hmm you are getting closer to the right number...";

            }
            else if (diff <= 10)
            {
                message = "It is very cold but on the right path!";
            }
            else 
            {
                message = "You are far far away!";

            }

            if (guessNumber < number) 
            {
                message += "\nYour guess is to low!";
            
            }
            else if(guessNumber > number) 
            {
                message += "\nYour guess is to high!";
            
            }

            return message;



        }


        // Returns how many possible numbers the user can guess based on difficulty level.
        public static int LevelOfGame(int level) 
        {   
            
            switch(level) 
            {
                case 1:
                    return 10;

                case 2:
                    return 25;
                case 3:
                    return 50;
                default:
                    return -1;

                
            
            }
            

        }

        //Returns how many guess that the user is allowed to do. 
        public static int UserTries(int tries) 
        {
            switch (tries) 
            {
                case 1:
                    return 6;
                case 2: 
                    return 5;
                case 3:
                    return 3;
                default:
                    return -1;
            
            }
            
        
        }

        static void Main(string[] args)
        {
          
            
            while (true)
            {
                
                Console.ForegroundColor = ConsoleColor.DarkRed;
                // Meny to choose level. 
                Console.WriteLine("Choose level to play game: \nPress 1 for EASY \nPress 2 for Medium \nPress 3 for HARD ");
               
                // Save userInput for level. 
                int levelChoice = int.Parse(Console.ReadLine());
            
                
                Console.Clear();

                 
                int maxNumber = LevelOfGame(levelChoice);
                int tries = UserTries(levelChoice);

                // Handle invalid input.
                if (maxNumber == -1 || tries == -1)
                {
                    Console.WriteLine("Please choose a number between 1-3"); 
                    continue;
                  
                }
            

                // Start the game
                Console.Write($"Welcome, I'm thinking about a number. Can you guess which?\nYou get {tries} tries. ");
 
                var rnd = new Random();
              
                int number = rnd.Next(1, maxNumber + 1);
                
                int guessNumber;
                
                bool guessRight = false;

                
                Console.WriteLine($"I'm thinking about a number between 1 and {maxNumber}");


                
                for (int i = 0; i < tries;)
                {
                    
                    Console.Write("Guess number: ");
                   
                    bool success = int.TryParse(Console.ReadLine(), out guessNumber);

                    
                    if (!success)
                    {
                        
                        Console.WriteLine("Please enter a number");
                        continue;


                    }
                    // Count valid attempts. 
                    i++;

                    
                    string result = CheckGuess(guessNumber, number);
                   
                    
                    Console.WriteLine(result);

                    
                    if (guessNumber == number)
                    {

                        guessRight = true; 
                        break;
                    }
                    
                }
                 
                
                if (!guessRight)
                {
                   
                    Console.WriteLine($"Sorry you failed guessing on {tries} times");
                    Console.WriteLine($"The right number was: {number}");
                }
                
                Console.ReadLine();
                
                Console.Clear();

                
                Console.WriteLine("Do you want to play again? Y/N?");
                
                string playAgain = Console.ReadLine().ToUpper();

                
                if (playAgain == "N")
                {
                    Console.WriteLine("Thanks for playing");
                    Console.ReadLine(); 
                    break; 
                }
                // Clear consol window for new game. 
                Console.Clear();
            }






        }

        
    }
}








