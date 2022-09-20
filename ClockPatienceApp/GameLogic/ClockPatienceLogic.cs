﻿using ClockPatienceApp.GameItems;
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
            StartGame(ExposedCardsCount, FinalExposedCard);
            //EndGame(0, "LastCard");

        }

        public void StartGame(int ExposedCardsCount, string FinalExposedCard)
        {
            Console.WriteLine("Welcome to Clock Patience Game");
            DeckOfCards deckOfCardsObject = new DeckOfCards();
            DeckOfCards.PrintDeckOfCards("Shuffled Deck Of Cards before game", deckOfCardsObject.DeckOfCardsList);
            Clock currentClock = new Clock();
            Clock resultClock = new Clock();
            currentClock = FillCardPiles(currentClock, deckOfCardsObject);


            // Game Code goes here
        }

        public Clock FillCardPiles(Clock clockObject, DeckOfCards deckOfCardsObject)
        {
            int CardCount = 0;
            foreach(string Card in deckOfCardsObject.DeckOfCardsList)
            {
              //  for (CardCount = 0; CardCount < 3; CardCount++)
              //  {
                    //clockObject.HourHands[List]
                    //clockObject.PileList.Add(Card);
                    //if (CardCount%3 == 0)
                   // {
                  //      clockObject.ClockList
                  //  }
                //}
                
            }
            return clockObject;
        }

        // Method which displays a message to prompt user for an input (to either restart or end the game after the game is finished)
        public string HandleGameCompletionUserPrompts()
        {
            string UserInput;
            //   Console.WriteLine("Game Ended");
            Console.WriteLine("\nEnter \"R\" to restart game or \"E\" to end Game");
            UserInput = Console.ReadLine();


            while ( (!(UserInput.Equals("R"))) & (!(UserInput.Equals("E"))))
            {
                Console.WriteLine("Invalid Input.\n\nEnter \"R\" to restart game or \"E\" to end Game");
                UserInput = Console.ReadLine();
                // Console.WriteLine("User response was " + userInput);
            }



            return UserInput;

        }

        public void DisplayGameResults(int exposedCardsCount, string finalExposedCard)
        {
            Console.WriteLine("\nNumber of Exposed Cards: " + exposedCardsCount);
            Console.WriteLine("Final Exposed Card: " + finalExposedCard);
            return;
        }

        // Method which contains the logic after the game is finished.
        public void EndGame(int exposedCardsCount, string finalExposedCard)
        {

            Console.WriteLine("\nGame Ended");
            DisplayGameResults(exposedCardsCount, finalExposedCard);
            string? UserResponse;
            UserResponse = HandleGameCompletionUserPrompts();
            switch (UserResponse)
            {
                case "R":
                    Console.WriteLine("\nRestarting Game");
                    ClockPatienceLogic newGame = new ClockPatienceLogic();
                    newGame.StartGame(0, "");
                    break;
                //ClockPatienceLogic newGame = new ClockPatienceLogic();
                // newGame.StartGame();

                //break;

                case "E":
                    Console.WriteLine("\nEnding Game");
                    Environment.Exit(0);
                    break;

            }


        }




    }
}
