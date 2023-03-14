﻿using System;
using System.Collections.Generic;
using System.Linq; // currently only needed if we use alternate shuffle method

namespace RaceTo21_BlazorApp
{
    public class Deck
    {
        List<Card> cards = new List<Card>();

        public Deck()
        {
            Console.WriteLine("================================");
            Console.WriteLine("********* Building deck ********");
            string[] suits = { "Spades", "Hearts", "Clubs", "Diamonds" };
            int cardCounter = 0;

            Dictionary<string, string> imageIDs = new Dictionary<string, string>(); // add a dictionary for keeping image png Ids

            for (int cardVal = 1; cardVal <= 13; cardVal++)
            {
                foreach (string cardSuit in suits)
                {
                    string cardName;
                    string pngName;
                    string cardLongName;

                    switch (cardVal)
                    {
                        case 1:
                            cardName = "A";
                            pngName = "A";
                            cardLongName = "Ace";
                            break;
                        case 11:
                            cardName = "J";
                            pngName = "J";
                            cardLongName = "Jack";
                            break;
                        case 12:
                            cardName = "Q";
                            pngName = "Q";
                            cardLongName = "Queen";
                            break;
                        case 13:
                            cardName = "K";
                            pngName = "K";
                            cardLongName = "King";
                            break;
                        default:
                            cardName = cardVal.ToString();
                            pngName = cardVal.ToString().PadLeft(2, '0'); // to set 0 before a single digit number in png name
                            cardLongName = cardName;
                            break;
                    }
                    cards.Add(new Card(cardName + cardSuit.First<char>(), cardLongName + " of " + cardSuit)); // Adding the Card string to Card List

                    var keyofimage = cards[cardCounter].id;
                    cardCounter++;

                    imageIDs[$"{keyofimage}"] = $"card_{cardSuit.ToLower()}_{pngName}.png"; // adding field and value to Dictionary imageIDs.

                }
            }

            //Uncomment to view the png names of each card
            /* View png names
            foreach (string key in imageIDs.Keys)
            {
                Console.Write(key + ":" + imageIDs[key]); // show all png names
                Console.WriteLine();
            }
            */
        }

        /* Function: Shuffle() **********
         * Shuffles the deck of cards.
         * Called by the game instance at the beginning.
        ************************************/
        public void Shuffle()
        {
            Console.WriteLine("Shuffling Cards...");

            Random rng = new Random();

            // one-line method that uses Linq:
            // cards = cards.OrderBy(a => rng.Next()).ToList();

            for (int i=0; i<cards.Count; i++)
            {
                Card tmp = cards[i];
                int swapindex = rng.Next(cards.Count);
                cards[i] = cards[swapindex]; // makes a duplicate
                cards[swapindex] = tmp; //doesn't change anything

            }
        }

        /* Function: ShowAllCards() **********
         * Displays all Cards in the deck.
        ************************************/
        public void ShowAllCards()
        {
            for (int i=0; i<cards.Count; i++)
            {
                Console.Write(i+":"+cards[i].displayName); // a list property can look like an Array!
                if (i < cards.Count -1)
                {
                    Console.Write(" ");
                } else
                {
                    Console.WriteLine("");
                }
            }
        }

        /* Function: DealTopCard() **********
         * Deals the top most card in the deck. (the last card in the deck list)
         * Returns the last card in the list.
         * Call by Game Object in tasks
        ************************************/
        public Card DealTopCard()
        {
            Card card = cards[cards.Count - 1];
            cards.RemoveAt(cards.Count - 1);
            // Console.WriteLine("I'm giving you " + card);
            return card;
        }
    }
}

