﻿using System;
using System.Collections.Generic;

namespace RaceTo21
{
    public class CardTable
    {
        public CardTable()
        {
            Console.WriteLine("Setting Up Table...");
        }

        public int numOfCardsPicked; // public int used in HowManyCards()



        /* Function: ShowPlayers() ****************
         * Displays names of all players and introduces them by table position.
         * Called by Game object during player turn.
         * Game object provides list of players
         * Calls Introduce method on each player object.
         *****************************************/
        public void ShowPlayers(List<Player> players)
        {
            for (int i = 0; i < players.Count; i++)
            {
                players[i].Introduce(i+1); // List is 0-indexed but user-friendly player positions would start with 1...
            }
        }

        /* Function: GetNumberOfPlayers() ****************
         * Reads the user input from player.
         * Called by Game object during player turn.
         * Returns number of players to Game object.
         *****************************************/
        public int GetNumberOfPlayers()
        {
            Console.Write("How many players? ");
            string response = Console.ReadLine();
            int numberOfPlayers;
            while (int.TryParse(response, out numberOfPlayers) == false
                || numberOfPlayers < 2 || numberOfPlayers > 8)
            {
                Console.WriteLine("Invalid number of players.");
                Console.Write("How many players?");
                response = Console.ReadLine();
            }
            return numberOfPlayers;
        }

        /* Function: GetPlayerName() ****************
         * Reads the user input for name.
         * Called by Game object during player turn.
         * Game object provides player number
         * Returns name of player to Game object
         *****************************************/
        public string GetPlayerName(int playerNum)
        {
            Console.Write("What is the name of player# " + playerNum + "? ");
            string response = Console.ReadLine();
            while (response.Length < 1)
            {
                Console.WriteLine("Invalid name.");
                Console.Write("What is the name of player# " + playerNum + "? ");
                response = Console.ReadLine();
            }
            return response;
        }


        /* Function: HowManyCards() **********
         * Reads the user input of how many cards they will pick. 
         * Can be a maximum of 3 cards. (0,1,2,3) - 0 being STAY
         * Uses player as parameter.
         * Uses cardTable's public int numOfCardsPicked
         * Called in the Game object during Player Turn
         * Returns numOfCardsPicked
         ************************************/
        public int HowManyCards(Player player)
        {
            Console.WriteLine();
            Console.Write(player.name + ": How many cards? - 0 is STAY (0/1/2/3)");
            string response = Console.ReadLine();

            if (response.ToUpper().StartsWith("3")) // Pick 3
            {
                numOfCardsPicked = 3;
            }
            else if (response.ToUpper().StartsWith("2")) // Pick 2
            {
                numOfCardsPicked = 2;
            }
            else if (response.ToUpper().StartsWith("1")) // Pick 1
            {
                numOfCardsPicked = 1;
            }
            else if (response.ToUpper().StartsWith("0")) // This is stay
            {
                numOfCardsPicked = 0;
            }
            else
            {
                Console.WriteLine("Invalid number of cards. Choose 0, 1, 2, or 3!");
                Console.WriteLine();
                Console.Write("How many players?");
                response = Console.ReadLine();
            }
            return numOfCardsPicked;
        }


        /* Function: ShowHand() **********
        ************************************/
        public void ShowHand(Player player)
        {
            if (player.cards.Count > 0)
            {
                Console.Write(player.name + " has: ");
                foreach (Card card in player.cards)
                {
                    if (player.cards.Count == 1) // if there is only one card 
                    {
                        Console.Write(card.displayName);
                    }
                    else if (player.cards.IndexOf(card) == player.cards.Count - 1) // if the card is the latest card
                    {
                        Console.Write(card.displayName + ". ");
                    }
                    else
                    {
                        Console.Write(card.displayName + ", ");
                    }
                }
                Console.Write("= " + player.score + "/21 ");
                if (player.status != PlayerStatus.active)
                {
                    Console.Write("(" + player.status.ToString().ToUpper() + ")");
                }
                Console.WriteLine();
            }
        }

        /* Function: ShowHands() **********
         * Shows the hands of each player from the list of players.
         * Uses list of player as parameter.
         * Uses cardTable's public int numOfCardsPicked
         * Called in the Game object during Player Turn
         * Returns numOfCardsPicked
         ************************************/
        public void ShowHands(List<Player> players)
        {
            foreach (Player player in players)
            {
                ShowHand(player);
            }
        }

        /* Function: AnnounceWinner() **********
        ************************************/
        public void AnnounceWinner(Player player)
        {
            if (player != null)
            {
                Console.WriteLine(player.name + " wins!");
            }
            else
            {
                Console.WriteLine("Everyone busted!");
            }
            Console.Write("Press <Enter> to exit... ");
            while (Console.ReadKey().Key != ConsoleKey.Enter) { }
        }


        /* Function: ShowOverallScore() ****************
         * Displays overall scores of all players
         * Called by Game object at the end of the game.
         * Game object provides player name and overallScore.
         *****************************************/
        public void ShowOverallScore(Player player)
        {
            Console.Write(player.name + "'s Overall Score: " + player.overallScore);
        }

        public void ShowOverAllScores(List<Player> players)
        {
            foreach (Player player in players)
            {
                ShowOverallScore(player);
            }
        }
    }
}