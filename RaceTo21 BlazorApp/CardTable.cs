using System;
using System.Collections.Generic;

namespace RaceTo21_BlazorApp
{
    public class CardTable
    {
        public CardTable()
        {
            Console.WriteLine("Setting Up Table...");
        }

        public int numOfCardsPicked; // public int used in HowManyCards() to determine how many cards player chooses to pick
        public int overallTarget = 50; // the final overall score needed by one player to win the whole game.


        /* Function: ShowPlayers() ****************
         * Displays names of all players and introduces them by table position.
         * Called by Game object during player turns.
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
         * Returns console input as an int: numberOfPlayers
         
        public int GetNumberOfPlayers()
        {
            Console.Write("How many players? ");
            string response;
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
        *****************************************/

        /* Function: GetPlayerName() ****************
         * Reads the user input for name.
         * Called by Game object during player turn.
         * Game object provides player number
         * Returns console input as a string: response (name of the player).
         
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
        *****************************************/



        /* Function: HowManyCards() **********
         * Reads the user input of how many cards they will pick. 
         * Can be a maximum of 3 cards. (0,1,2,3) - 0 being STAY
         * Uses player as parameter.
         * Uses cardTable's public int numOfCardsPicked
         * Called in the Game object during Player Turn
         * Returns console input as an int: numOfCardsPicked
         ************************************/
        public int HowManyCards(Player player)
        {
            Console.Write($"{player.name} picked {numOfCardsPicked}");
            return numOfCardsPicked; // returns 0, 1, 2 or 3 only
        }
        


        /* Function: ShowHand() **********
         * Displays all cards in the player's hand
         * Called by Game object during Player Turns and ShowHands() method in the current CardTable class
         * Writes on console.
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
                    else if (player.cards.IndexOf(card) == player.cards.Count - 1) // if the card is the last card
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
         * Utilizes the list of players.
         * Called in the Game object during Player Turn
         * Calls showHand() method.
         ************************************/
        public void ShowHands(List<Player> players)
        {
            foreach (Player player in players)
            {
                ShowHand(player);
            }
        }


        /* Function: AnnounceWinner() **********
         * Displays the winner in the current round.
         * Called by the Game object during Player Turn
         * Writes on console.
        ************************************/
        public void AnnounceWinner(Player player)
        {
            if (player != null)
            {
                Console.WriteLine();
                Console.WriteLine($">>>>>>>>>>>>>> {player.name} wins this round! <<<<<<<<<<<<<<<<");
                Console.WriteLine();
            }
            else // if there is no player aka player is null
            {
                Console.WriteLine();
                Console.WriteLine(">>>>>>>>>>>>> Everyone busted! <<<<<<<<<<<<<<<<<<<");
                Console.WriteLine();
            }
        }

        /* Function: AnnounceOverallWinner() **********
         * Displays the overall winner of the whole game.
         * Called by the Game object during Player Turn
         * Writes on console.
        ************************************/
        public void AnnounceOverallWinner(Player player)
        {
            //(while (player != null)
            //{*
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine($"~~{player.name} wins the game!~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            //}
        }

        /* Function: ShowScoreBoard() **********
         * Loops through and displays the scoreboard aka Overall score of all players.
         * Called by the Game object during Player Turn.
         * Utilizes the list of players. 
         * Writes on console
        ************************************/
        public void ShowScoreboard(List<Player> players)
        {
            Console.WriteLine("================================");
            Console.WriteLine("~~~~~~~~~~ Score Board ~~~~~~~~~");
            Console.WriteLine();
            Console.WriteLine($"First player to accumulate {overallTarget} wins!");
            Console.WriteLine();
            foreach (Player player in players)
            {
                Console.WriteLine($"{player.name}'s overall score is {player.overallScore}/{overallTarget}");
            }
            Console.WriteLine("================================");
        }

        /* Function: PlayAnotherRound() **********
         * Check console input if player wants to continue on to another round or not.
         * Returns bool. True for Yes, False for No.
         * Called by the Game object during Player Turn
        ************************************/
        public bool PlayAnotherRound()
        {
            return true;
        }


    }
}