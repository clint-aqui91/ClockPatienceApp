using ClockPatienceApp.GameItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClockPatienceApp.GameLogic
{
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

        public void StartGame(int exposedCardsCount, string finalExposedCard)
        {
            Console.WriteLine("Welcome to Clock Patience Game");

            DeckOfCards deckOfCardsObject = new DeckOfCards();
            DeckOfCards.PrintDeckOfCards("Shuffled Deck Of Cards before game", deckOfCardsObject.DeckOfCardsList);

            Clock currentClock = new Clock();
            Clock resultClock = new Clock();

            currentClock = FillCardPiles(currentClock, deckOfCardsObject);
            PrintClock("Current Clock", currentClock);

            resultClock = PrepareResultClock(resultClock);
            PlayGame(exposedCardsCount, finalExposedCard, currentClock, resultClock);
        }

        public Clock PrepareResultClock(Clock resultClock)
        {
            string EmptyCard = "00";

            List<string> pileList = new List<string>();
            //pileList.Capacity = 4;
            for (int i = 0; i < 4; i++)
            {
                pileList.Add(EmptyCard);
            }

            for (int j = 0; j < 13; j++)
            {
                resultClock.HourHands.Add(pileList);
            }

            //PrintClock("Result Clock", resultClock);
            return resultClock;
        }

        public void PlayGame(int exposedCardsCount, string finalExposedCard, Clock currentClock, Clock resultClock)
        {
            //Console.WriteLine("Count" + currentClock.HourHands.Count.ToString());
            //Console.WriteLine("Capacity" + currentClock.HourHands.Capacity.ToString());
            //Console.Write("Third Card at Pile 2 " + currentClock.HourHands.ElementAt(1).ElementAt(2));

            string CurrentExposedCard;
            string RankOfExposedCard;

            CurrentExposedCard = currentClock.HourHands.ElementAt(12).ElementAt(0);
            exposedCardsCount++;

            currentClock.HourHands.ElementAt(12).Remove(CurrentExposedCard);

            RankOfExposedCard = CurrentExposedCard.ElementAt(0).ToString();

            //Console.WriteLine("Current Exposed Card " + CurrentExposedCard);
            //Console.WriteLine("Rank of Currently Exposed Card" + RankOfExposedCard);

            for (int i = 0; i < 52; i++)
            {

                switch (RankOfExposedCard)
                {
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

        // Method which displays a message to prompt user for an input (to either restart or end the game after the game is finished)
        public string HandleGameCompletionUserPrompts()
        {
            string UserInput;
            Console.WriteLine("\nEnter \"R\" to restart game or \"E\" to end Game");
            UserInput = Console.ReadLine();

            while ((!(UserInput.Equals("R"))) & (!(UserInput.Equals("E"))))
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

                case "E":
                    Console.WriteLine("\nEnding Game");
                    Environment.Exit(0);
                    break;
            }
        }
    }
}
