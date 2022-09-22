using ClockPatienceApp.GameItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockPatienceApp.GameLogic
{

    /// <summary>
    /// Class <c>ClockPatienceLogic</c> contains the logic of the Clock Patience game.
    /// </summary>
    /// 
    internal class ClockPatienceLogic
    {

        private int ExposedCardsCount { get; set; }
        private string? FinalExposedCard { get; set; }

        // Instance Constructor
        public ClockPatienceLogic()
        {
            ExposedCardsCount = 0;
            FinalExposedCard = "";

            StartGame(ExposedCardsCount, FinalExposedCard);
        }

        /// <summary>
        /// Method <c>StartGame</c> starts the game, by generating the game item objects (deck of cards, and two clocks - original/current clock which will hold the shuffled clock
        /// and the result clock which will hold cards with the same rank in the same hour hand pile. This method also calls the method responsible of holding the game logic and
        /// rules and which plays the game.
        /// </summary>
        public void StartGame(int exposedCardsCount, string finalExposedCard)
        {
            Console.WriteLine("Welcome to Clock Patience Game");

            // Create the deck of cards object (based on the DeckOfCards class and output its content into the console/user interface).
            DeckOfCards deckOfCardsObject = new DeckOfCards();
            DeckOfCards.PrintDeckOfCards("Shuffled Deck Of Cards before game", deckOfCardsObject.DeckOfCardsList);

            // Create the currentClock and resultClock objects based on the Clock class, fill the currentClockObject fill its hour hands with pile of cards from the deckOfCardsObject
            // and output their contents (list of strings using the PrintClock method).
            Clock currentClockObject = new Clock();
            Clock resultClockObject = new Clock();

            currentClockObject = FillCardPiles(currentClockObject, deckOfCardsObject);
            PrintClock("Current Clock", currentClockObject);

            resultClockObject = PrepareResultClock(resultClockObject);

            // Start playing the game
            PlayGame(exposedCardsCount, finalExposedCard, currentClockObject, resultClockObject);
        }

        /// <summary>
        /// Method <c>PrepareResultClock</c> adds a string list representing an empty pile of cards to the result clock.
        /// </summary>
        public Clock PrepareResultClock(Clock resultClock)
        {
            //string EmptyCard = "00";

            List<string> pileList = new List<string>();
            //pileList.Capacity = 4;
            /*
            for (int i = 0; i < 4; i++)
            {
                pileList.Add(EmptyCard);
            }
            */

            for (int j = 0; j < 13; j++)
            {
                resultClock.HourHands.Add(pileList);
            }

            //PrintClock("Result Clock", resultClock);
            return resultClock;
        }

        /// <summary>
        /// Method <c>PrepareResultClock</c> holds the game logic and its rules. Once a pile of cards from the currentClock is emptied, the game is ended, by calling the EndGame method.
        /// </summary>
        public void PlayGame(int exposedCardsCount, string finalExposedCard, Clock currentClock, Clock resultClock)
        {
            //Console.WriteLine("Count" + currentClock.HourHands.Count.ToString());
            //Console.WriteLine("Capacity" + currentClock.HourHands.Capacity.ToString());
            //Console.Write("Third Card at Pile 2 " + currentClock.HourHands.ElementAt(1).ElementAt(2));

            string CurrentExposedCard;
            string RankOfExposedCard;

            // The first card from the "K" hour hand pile is exposed and the counter holding the number of exposed cards is incremented by 1.
            CurrentExposedCard = currentClock.HourHands.ElementAt(12).ElementAt(0);
            exposedCardsCount++;

            // The string value representing the exposed card, "K" hour hand pile is removed from the string array list.
            currentClock.HourHands.ElementAt(12).Remove(CurrentExposedCard);

            // The rank of the exposed card is retrieved, used to select the statement list matching the rank (by using switch cases).
            RankOfExposedCard = CurrentExposedCard.ElementAt(0).ToString();

            //Console.WriteLine("Current Exposed Card " + CurrentExposedCard);
            //Console.WriteLine("Rank of Currently Exposed Card" + RankOfExposedCard);

            // For loop which iterates 52 times (the number of cards in the deck).
            for (int i = 0; i < 52; i++)
            {

                // case switch statements, which are selected based on the currently exposed card's rank.
                switch (RankOfExposedCard)
                {
                    // Each case adds the currently exposed card in the respective resultClock's Hour hand (which matches the same rank, removes the card from the current/original clock,
                    // ends the game if the hour hand's card pile is empty (following the previous card removal from the same hour hand card pile, or gets the rank of the exposed card,
                    // breaks/exits the case switch and repeats the same cycle (through the for loop). The exposed card counter is always incremented, whenever a card is exposed.
                    case "A":

                        resultClock.HourHands.ElementAt(0).Add(CurrentExposedCard);

                        CurrentExposedCard = currentClock.HourHands.ElementAt(0).ElementAt(0);
                        currentClock.HourHands.ElementAt(0).Remove(CurrentExposedCard);

                        if (!currentClock.HourHands.ElementAt(0).Any())
                        {
                            exposedCardsCount++;
                            EndGame(exposedCardsCount, CurrentExposedCard);
                        }

                        else
                        {
                            RankOfExposedCard = CurrentExposedCard.ElementAt(0).ToString();
                        }

                        break;

                    case "2":

                        resultClock.HourHands.ElementAt(1).Add(CurrentExposedCard);

                        CurrentExposedCard = currentClock.HourHands.ElementAt(1).ElementAt(0);
                        currentClock.HourHands.ElementAt(1).Remove(CurrentExposedCard);

                        if (!currentClock.HourHands.ElementAt(1).Any())
                        {
                            exposedCardsCount++;
                            EndGame(exposedCardsCount, CurrentExposedCard);
                        }

                        else
                        {
                            RankOfExposedCard = CurrentExposedCard.ElementAt(0).ToString();
                        }

                        break;

                    case "3":

                        resultClock.HourHands.ElementAt(2).Add(CurrentExposedCard);

                        CurrentExposedCard = currentClock.HourHands.ElementAt(2).ElementAt(0);
                        currentClock.HourHands.ElementAt(2).Remove(CurrentExposedCard);

                        if (!currentClock.HourHands.ElementAt(11).Any())
                        {
                            exposedCardsCount++;
                            EndGame(exposedCardsCount, CurrentExposedCard);
                        }

                        else
                        {
                            RankOfExposedCard = CurrentExposedCard.ElementAt(0).ToString();
                        }

                        break;

                    case "4":
                        resultClock.HourHands.ElementAt(3).Add(CurrentExposedCard);

                        CurrentExposedCard = currentClock.HourHands.ElementAt(3).ElementAt(0);
                        currentClock.HourHands.ElementAt(3).Remove(CurrentExposedCard);

                        if (!currentClock.HourHands.ElementAt(3).Any())
                        {
                            exposedCardsCount++;
                            EndGame(exposedCardsCount, CurrentExposedCard);
                        }

                        else
                        {
                            RankOfExposedCard = CurrentExposedCard.ElementAt(0).ToString();
                        }

                        break;

                    case "5":

                        resultClock.HourHands.ElementAt(4).Add(CurrentExposedCard);

                        CurrentExposedCard = currentClock.HourHands.ElementAt(4).ElementAt(0);
                        currentClock.HourHands.ElementAt(4).Remove(CurrentExposedCard);

                        if (!currentClock.HourHands.ElementAt(4).Any())
                        {
                            exposedCardsCount++;
                            EndGame(exposedCardsCount, CurrentExposedCard);
                        }

                        else
                        {
                            RankOfExposedCard = CurrentExposedCard.ElementAt(0).ToString();
                        }

                        break;

                    case "6":

                        resultClock.HourHands.ElementAt(5).Add(CurrentExposedCard);

                        CurrentExposedCard = currentClock.HourHands.ElementAt(5).ElementAt(0);
                        currentClock.HourHands.ElementAt(5).Remove(CurrentExposedCard);

                        if (!currentClock.HourHands.ElementAt(5).Any())
                        {
                            exposedCardsCount++;
                            EndGame(exposedCardsCount, CurrentExposedCard);
                        }

                        else
                        {
                            RankOfExposedCard = CurrentExposedCard.ElementAt(0).ToString();
                        }

                        break;

                    case "7":

                        resultClock.HourHands.ElementAt(6).Add(CurrentExposedCard);

                        CurrentExposedCard = currentClock.HourHands.ElementAt(6).ElementAt(0);
                        currentClock.HourHands.ElementAt(6).Remove(CurrentExposedCard);

                        if (!currentClock.HourHands.ElementAt(6).Any())
                        {
                            exposedCardsCount++;
                            EndGame(exposedCardsCount, CurrentExposedCard);
                        }

                        else
                        {
                            RankOfExposedCard = CurrentExposedCard.ElementAt(0).ToString();
                        }

                        break;

                    case "8":

                        resultClock.HourHands.ElementAt(7).Add(CurrentExposedCard);

                        CurrentExposedCard = currentClock.HourHands.ElementAt(7).ElementAt(0);
                        currentClock.HourHands.ElementAt(7).Remove(CurrentExposedCard);

                        if (!currentClock.HourHands.ElementAt(7).Any())
                        {
                            exposedCardsCount++;
                            EndGame(exposedCardsCount, CurrentExposedCard);
                        }

                        else
                        {
                            RankOfExposedCard = CurrentExposedCard.ElementAt(0).ToString();
                        }

                        break;

                    case "9":

                        resultClock.HourHands.ElementAt(8).Add(CurrentExposedCard);

                        CurrentExposedCard = currentClock.HourHands.ElementAt(8).ElementAt(0);
                        currentClock.HourHands.ElementAt(8).Remove(CurrentExposedCard);

                        if (!currentClock.HourHands.ElementAt(8).Any())
                        {
                            exposedCardsCount++;
                            EndGame(exposedCardsCount, CurrentExposedCard);
                        }

                        else
                        {
                            RankOfExposedCard = CurrentExposedCard.ElementAt(0).ToString();
                        }

                        break;

                    case "T":

                        resultClock.HourHands.ElementAt(9).Add(CurrentExposedCard);

                        CurrentExposedCard = currentClock.HourHands.ElementAt(9).ElementAt(0);
                        currentClock.HourHands.ElementAt(9).Remove(CurrentExposedCard);


                        if (!currentClock.HourHands.ElementAt(9).Any())
                        {
                            exposedCardsCount++;
                            EndGame(exposedCardsCount, CurrentExposedCard);
                        }

                        else
                        {
                            RankOfExposedCard = CurrentExposedCard.ElementAt(0).ToString();
                        }

                        break;

                    case "J":

                        resultClock.HourHands.ElementAt(10).Add(CurrentExposedCard);

                        CurrentExposedCard = currentClock.HourHands.ElementAt(10).ElementAt(0);
                        currentClock.HourHands.ElementAt(10).Remove(CurrentExposedCard);

                        if (!currentClock.HourHands.ElementAt(10).Any())
                        {
                            exposedCardsCount++;
                            EndGame(exposedCardsCount, CurrentExposedCard);
                        }

                        else
                        {
                            RankOfExposedCard = CurrentExposedCard.ElementAt(0).ToString();
                        }

                        break;

                    case "Q":

                        resultClock.HourHands.ElementAt(11).Add(CurrentExposedCard);

                        CurrentExposedCard = currentClock.HourHands.ElementAt(11).ElementAt(0);
                        currentClock.HourHands.ElementAt(11).Remove(CurrentExposedCard);

                        if (!currentClock.HourHands.ElementAt(11).Any())
                        {
                            exposedCardsCount++;
                            EndGame(exposedCardsCount, CurrentExposedCard);
                        }

                        else
                        {
                            RankOfExposedCard = CurrentExposedCard.ElementAt(0).ToString();
                        }

                        break;

                    case "K":


                        resultClock.HourHands.ElementAt(12).Add(CurrentExposedCard);

                        CurrentExposedCard = currentClock.HourHands.ElementAt(12).ElementAt(0);
                        currentClock.HourHands.ElementAt(12).Remove(CurrentExposedCard);

                        if (!currentClock.HourHands.ElementAt(12).Any())
                        {
                            exposedCardsCount++;
                            EndGame(exposedCardsCount, CurrentExposedCard);
                        }

                        else
                        {
                            RankOfExposedCard = CurrentExposedCard.ElementAt(0).ToString();
                        }

                        break;
                }

                exposedCardsCount++;
            }

        }

        /// <summary>
        /// Method <c>FillCardPiles</c> fills the clock object's hour hand string list with a pile of 4 cards.
        /// </summary>
        public Clock FillCardPiles(Clock clockObject, DeckOfCards deckOfCardsObject)
        {
            int CardCount = 0;
            int PileCount = 0;

            List<string> pileList = new List<string>();
            pileList.Capacity = 4;

            foreach (string Card in deckOfCardsObject.DeckOfCardsList)
            {
                pileList.Add(Card);
                PileCount++;

                if (pileList.Count == 4)
                {
                    clockObject.HourHands.Add(pileList.ToList());
                    pileList.Clear();
                }

            }

            return clockObject;
        }

        /// <summary>
        /// Method <c>PrintClock</c> prints the clock object (passed as an argument).
        /// </summary>
        public void PrintClock(string ClockType, Clock clockObject)
        {
            int RowCount = 0;
            int CardsInClock = 0;
            Console.WriteLine("\nCard List in " + ClockType);

            for (int x = 0; x < 13; x++)
            {
                foreach (string Card in clockObject.HourHands[RowCount])
                {
                    Console.Write(Card + " ");
                    //RowCount++;
                    CardsInClock++;
                    //c++;

                    if (CardsInClock % 4 == 0)
                    {
                        Console.Write("\n");
                        RowCount++;
                    }

                }

            }
        }

        /// <summary>
        /// Method <c>HandleGameCompletionUserPrompts</c> displays a message to prompt user for an input (to either restart or end the game after the game is finished).
        /// </summary>
        public string HandleGameCompletionUserPrompts()
        {
            string UserInput;
            Console.WriteLine("\nEnter \"R\" to restart game or \"E\" to end Game");
            UserInput = Console.ReadLine();

            // Perform While when user input is not equal to "R" and "E". Exit While loop if user input is equal to / matches "R" and "E"
            while ((!(UserInput.Equals("R"))) & (!(UserInput.Equals("E"))))
            {
                Console.WriteLine("Invalid Input.\n\nEnter \"R\" to restart game or \"E\" to end Game");
                UserInput = Console.ReadLine();
                // Console.WriteLine("User response was " + userInput);
            }

            return UserInput;
        }

        /// <summary>
        /// Method <c>DisplayGameResults</c> displays the required game results, namely the exposed cards count and the final exposed card.
        /// </summary>
        public void DisplayGameResults(int exposedCardsCount, string finalExposedCard)
        {
            Console.WriteLine("\nNumber of Exposed Cards: " + exposedCardsCount);
            Console.WriteLine("Final Exposed Card: " + finalExposedCard);
            return;
        }

        /// <summary>
        /// Method <c>EndGame</c> hands the game's end, by displaying a message stating that the game ended, the game results and calls the method which handles the user's response inputs, and then
        /// either restarts/replays the game or ends the game (closes the application).
        /// </summary>
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

                case "E":
                    Console.WriteLine("\nEnding Game");
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
