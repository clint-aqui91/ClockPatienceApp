using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace ClockPatienceApp.GameItems
{
    internal class DeckOfCards
    {
        private List<string>? _deckOfCardsList;

        // Accessor for the Deck of Cards list
        public List<string>? DeckOfCardsList
        {
            get { return _deckOfCardsList; }
            set { _deckOfCardsList = value; }
        }

        // Constructor which also creates a List of type string, containing elements representing shuffled game cards
        public DeckOfCards()
        {
            DeckOfCardsList = new List<string>();
            DeckOfCardsList = BuildDeckOfCards(DeckOfCardsList);
        }

        private List<string> BuildDeckOfCards(List <string> deckOfCards)
        {
            // Here we are ensuring that the List is cleared (any elements and indexes are emptied, in case this method is called from multiple occurences of the application and is passed as an argument containing any elements or indexes.
            deckOfCards.Clear();
            string Ranks = "Ranks";
            string Suits = "Suits";
            string NewDeckOfCards = "New Deck Of Cards";
            string ShuffledDeckOfCards = "Shuffled Deck Of Cards";
            
            
            List<string> cardRanks = new List<string>();
            List<string> cardSuits = new List<string>();

            cardRanks = GenerateCardComponents(Ranks, cardRanks);

            cardSuits = GenerateCardComponents(Suits, cardSuits);

            deckOfCards = GenerateDeckOfCards(cardRanks, cardSuits);
            PrintDeckOfCards(NewDeckOfCards,deckOfCards);

            deckOfCards = ShuffleDeckOfCards(deckOfCards);
            PrintDeckOfCards(ShuffledDeckOfCards, deckOfCards);

            return deckOfCards;
        }

        private static List<string> GenerateDeckOfCards(List<string> cardRanksList, List<string> cardSuitsList)
        {
            string Card;
            
            List<string> deckOfCards = new List<string>();

            foreach (string Rank in cardRanksList)
            {
                foreach(string Suit in cardSuitsList)
                {
                    Card = "";
                    Card = Rank + Suit;

                    deckOfCards.Add(Card);
                }
            }

            return deckOfCards;
        }

        private List<string> ShuffleDeckOfCards (List<string> deckOfCards)
        {
            Random random = new Random();
            //int i = 0;
            deckOfCards = deckOfCards.OrderBy(i => random.Next()).ToList();
            //List<string> shuffled_list = deckOfCards.OrderBy(i => random.Next()).ToList(i => i.Key, i => i.Value);
            //return (List<string>)deckOfCards.OrderBy(item => random.Next()).ToList();
            //deckOfCards = deckOfCards.OrderBy(x => Guid.NewGuid()).ToList();
            return deckOfCards;
        }

        private static List<string> GenerateCardComponents(string componentType, List<string> cardComponentsList)
        {
            string[] arrayOfRanks = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K" };
            string[] arrayOfSuits = { "H", "D", "C", "S" };
            cardComponentsList.Clear();
            if (componentType == "Ranks")
            {
                Console.WriteLine("\nRank List size before: ");
                Console.WriteLine("Ranks List Capacity: " + Convert.ToString(cardComponentsList.Capacity));
                Console.WriteLine("Ranks List Count: " + Convert.ToString(cardComponentsList.Count));
               
                cardComponentsList.AddRange(arrayOfRanks);

                PrintCardComponents(componentType, cardComponentsList);
                Console.WriteLine("\nRank List size after: ");
                Console.WriteLine("Ranks List Capactiy: " + Convert.ToString(cardComponentsList.Capacity));
                Console.WriteLine("Ranks List Count: " + Convert.ToString(cardComponentsList.Count));
                
            }

            if (componentType == "Suits")
            {
                Console.WriteLine("\nSuits List size before: ");
                Console.WriteLine("Suits List Capacity: " + Convert.ToString(cardComponentsList.Capacity));
                Console.WriteLine("Suits List Count: " + Convert.ToString(cardComponentsList.Count));
               
                cardComponentsList.AddRange(arrayOfSuits);

                PrintCardComponents(componentType, cardComponentsList);
                Console.WriteLine("\nSuits List size after: ");
                Console.WriteLine("Suits List Capacity: " + Convert.ToString(cardComponentsList.Capacity));
                Console.WriteLine("Suits List Count: " + Convert.ToString(cardComponentsList.Count));

            }
            return cardComponentsList;
        }

        private static void PrintCardComponents(string componentName, List<string> cardComponents)
        {
            Console.WriteLine("\nCard " + componentName);
            for (int i = 0; i < cardComponents.Count; i++)
            {
                Console.WriteLine("Index: " + i + " - Card " + componentName + ": " + cardComponents[i]);
            }
        }

        internal protected static void PrintDeckOfCards(string deckOfCardsType, List<string> deckOfCards)
        {
            int CountOfCardsInDeck = 0;
            Console.WriteLine("\n"+ deckOfCardsType);
            foreach (string CardInDeck in deckOfCards)
            {


                //Console.WriteLine(CardInDeck);
                CountOfCardsInDeck++;
                Console.Write(CardInDeck + " ");

                // If current card location is a full multiplier of 13 write in a new line
                if (CountOfCardsInDeck % 13 == 0)
                {
                    Console.Write("\n");
                }

                // If end of Cards Deck is reached, print the number of Cards in Deck
                if (CountOfCardsInDeck == 52)
                {
                    Console.WriteLine("\nNumber of Cards in Deck: "+ Convert.ToString(CountOfCardsInDeck));
                }
            }

        }
    }
}
    
            
    

