using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockPatienceApp.GameLogic
{
    internal class ClockPatienceLogic
    {
        //internal void StartGame()
        //{
        //   throw new NotImplementedException();
        //}



        private int ExposedCardsCount { get; set; }
        private string? FinalExposedCard { get; set; }

        // Instance Constructor
        public ClockPatienceLogic()
        {
            ExposedCardsCount = 0;
            FinalExposedCard = "";

        }

        public void StartGame()
        {
            Console.WriteLine("Welcome to Clock Patience Game");

            // Game Code goes here
        }

        // Method which displays a message to prompt user for an input (to either restart or end the game after the game is finished)
        public string HandleGameCompletionUserPrompts(string? userInput)
        {
            //   Console.WriteLine("Game Ended");
            Console.WriteLine("\nEnter \"R\" to restart game or \"E\" to end Game");
            userInput = Console.ReadLine();


            while ((!(userInput.Equals("R"))) & (!(userInput.Equals("E"))))
            {
                Console.WriteLine("Invalid Input.\n\nEnter \"R\" to restart game or \"E\" to end Game");
                userInput = Console.ReadLine();
                // Console.WriteLine("User response was " + userInput);
            }



            return userInput;

        }

        public void DisplayGameResults(int exposedCardsCount, string finalExposedCard)
        {
            Console.WriteLine("\nNumber of Exposed Cards: " + exposedCardsCount);
            Console.WriteLine("Final Exposed Card: " + finalExposedCard);
            return;
        }

        // Method which contains the logic after the game is finished.
        public void EndGame()
        {

            Console.WriteLine("\nGame Ended");
            DisplayGameResults(ExposedCardsCount, FinalExposedCard);
            string? UserResponse;
            UserResponse = HandleGameCompletionUserPrompts("");
            switch (UserResponse)
            {
                case "R":
                    Console.WriteLine("\nRestarting Game");
                    ClockPatienceLogic newGame = new ClockPatienceLogic();
                    newGame.StartGame();
                    break;
                //ClockPatienceLogic newGame = new ClockPatienceLogic();
                // newGame.StartGame();

                //break;

                case "E":
                    Console.WriteLine("\nEnding Game");
                    Environment.Exit(0);
                    break;

                    //       default:
                    //         Console.WriteLine("Invalid Input");
                    //       UserResponse = ShowGameCompletionMessage(null);
                    //     break;

            }
            //ClockPatienceLogic newGame = new ClockPatienceLogic();
            //newGame.StartGame();


        }




    }
}
