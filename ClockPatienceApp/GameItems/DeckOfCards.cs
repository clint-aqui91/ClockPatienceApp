using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace ClockPatienceApp.GameItems
{

    /// <summary>
    /// Class <c>DeckOfCards</c> represents a deck of cards made up of 52 cards. It consists primarly consists of a string list.
    /// </summary>
    internal class DeckOfCards
    {
        private List<string>? _deckOfCardsList;

        // Get & Set Accessors for the Deck of Cards list
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

        /// <summary>
        /// Method <c>BuildDeckOfCards</c> generates a string list containing the cards.
        /// </summary>
        private List<string> BuildDeckOfCards(List<string> deckOfCards)
        {
            // Here we are ensuring that the List is cleared (any elements and indexes are emptied, in case this method is called from multiple occurences of the application or
            // is passed as an argument containing any elements or indexes.
            deckOfCards.Clear();

            string Ranks = "Ranks";
            string Suits = "Suits";
            string NewDeckOfCards = "New Deck Of Cards";
            string ShuffledDeckOfCards = "Shuffled Deck Of Cards";

            List<string> cardRanks = new List<string>();
            List<string> cardSuits = new List<string>();

            // Card ranks and suits are generated using the GenerateCardComponents method, based on the passed arguments into it.
            cardRanks = GenerateCardComponents(Ranks, cardRanks);

            cardSuits = GenerateCardComponents(Suits, cardSuits);

            // Deck of cards (string list) is generated using the previously generated card ranks and suits and displayed inside the console / User Interface.
            deckOfCards = GenerateDeckOfCards(cardRanks, cardSuits);
            PrintDeckOfCards(NewDeckOfCards, deckOfCards);

            // The deck of cards are shuffled and printed/outputted inside the console / User Interface.
            deckOfCards = ShuffleDeckOfCards(deckOfCards);
            PrintDeckOfCards(ShuffledDeckOfCards, deckOfCards);

            return deckOfCards;
        }

        /// <summary>
        /// Method <c>GenerateDeckOfCards</c> generates a deck of cards.
        /// </summary>
        private static List<string> GenerateDeckOfCards(List<string> cardRanksList, List<string> cardSuitsList)
        {
            string Card;

            List<string> deckOfCards = new List<string>();

            // 2 nested foreach loops which loops through each suit and rank found in their respective string list and adds them into a string, to create a card which in turn is added to the
            // deck of cards string list.
            foreach (string Rank in cardRanksList)
            {
                foreach (string Suit in cardSuitsList)
                {
                    Card = "";
                    Card = Rank + Suit;

                    deckOfCards.Add(Card);
                }
            }

            return deckOfCards;
        }

        /// <summary>
        /// Method <c>ShuffleDeckOfCards</c> randomly shuffles (pseudo-random number generator) the deck of cards.
        /// </summary>
        private List<string> ShuffleDeckOfCards(List<string> deckOfCards)
        {
            Random random = new Random();
            deckOfCards = deckOfCards.OrderBy(i => random.Next()).ToList();

            return deckOfCards;
        }

        /// <summary>
        /// Method <c>GenerateCardComponents</c> generates the components of card (suits and ranks), depending on the passed component type string value.
        /// </summary>
        private static List<string> GenerateCardComponents(string componentType, List<string> cardComponentsList)
        {
            string[] arrayOfRanks = { "A", "2", "3", "4", "5", "6", "7", "8", "9", "T", "J", "Q", "K" };
            string[] arrayOfSuits = { "H", "D", "C", "S" };
            
            cardComponentsList.Clear();

            // If component type value is ranks, generate a string list from the array containig the rank values.
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

            // If component type value is suits, generate a string list from the array containig the suit values.
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

        /// <summary>
        /// Method <c>PrintCardComponents</c> outputs the card components (ranks or suits, depending on the passed arguments) to the console/user interface.
        /// </summary>
        private static void PrintCardComponents(string componentName, List<string> cardComponents)
        {
            Console.WriteLine("\nCard " + componentName);
            for (int i = 0; i < cardComponents.Count; i++)
            {
                Console.WriteLine("Index: " + i + " - Card " + componentName + ": " + cardComponents[i]);
            }
        }

        /// <summary>
        /// Method <c>PrintDeckOfCards</c> outputs the deck of cards to the console/user interface.
        /// </summary>
        internal protected static void PrintDeckOfCards(string deckOfCardsType, List<string> deckOfCards)
        {
            int CountOfCardsInDeck = 0;
            Console.WriteLine("\n" + deckOfCardsType);

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
                    Console.WriteLine("\nNumber of Cards in Deck: " + Convert.ToString(CountOfCardsInDeck));
                }
            }

        }
    }
}




