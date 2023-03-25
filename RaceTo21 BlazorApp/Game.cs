using System;
using System.Collections.Generic;

namespace RaceTo21_BlazorApp
{
    public class Game
    {
        public static int numberOfPlayers = 2; // number of players in current game
        public static List<Player> players = new List<Player>(); // list of objects containing player data
        static public string[] tempNames = new string[8];
        public static CardTable cardTable; // object in charge of displaying game information
        public static Deck deck = new Deck(); // deck of cards
        public static int currentPlayer = 0; // current player on list
        public static AllTasks nextTask; // keeps track of game state
        public static int rounds = 0; // the number of rounds played
        public static int turnsTaken = 0;

        public Game(CardTable c) // called in Game Setup
        {
            cardTable = c;
            deck.Shuffle();
            nextTask = AllTasks.GetNumberOfPlayers;
        }

        /* Function: AddPlayer() **********
         * Adds new player and it's name to the list.
         * Called in GoToScorePage() on the numberOfPlayers.razor
         when clicking PLAY button.
        ************************************/
        public static void AddPlayer(string n)
        {
            players.Add(new Player(n));

        }

        /* Function: DrawCards() **********
         * Draws 1,2,3 cards per player depending on
         button pressed. If none car cards and stays
        if PASS is pressed.
         * Called in GoToScorePage() on the numberOfPlayers.razor
         when clicking PLAY button.
        ************************************/
        public static void DrawCards(int cardsPicked)
        {
            Player player = players[currentPlayer];

            if (player.status == PlayerStatus.active)
            {
                if (cardsPicked == 0) // if player picks 0 cards their status changes to STAY.
                {
                    player.status = PlayerStatus.stay;
                }
                else if (cardsPicked <= 3 && cardsPicked != 0) // If player picks less than or equal to 3 cards, enter this.
                {
                    for (int i = 0; i < cardsPicked; i++) // this loops according to the number of cards needed. If 3, deals out and adds 3 cards.
                    {
                        Card card = deck.DealTopCard();
                        player.cards.Add(card);
                    }
                    player.score = ScoreHand(player); // immediately checks if score made player go bust or win.

                    if (player.score > 21)
                    {
                        player.status = PlayerStatus.bust;
                    }
                    else if (player.score == 21)
                    {
                        player.status = PlayerStatus.win;
                    }
                }
            }
            turnsTaken++;
            CheckForRoundEnd();
            
        }

        /* Function: CheckForRoundEnd() **********
         * This function checks if the current round has ended or not and moves on to the next turn.
         * It is called at the end of the DrawCard function
        ************************************/
        public static void CheckForRoundEnd()
        {
            if (CheckForRoundWin() || !CheckActivePlayers()) // do this is someone wins a round or there are no active players left.
            {
                //rounds++;
                Player winner = DoRoundScoring(); // adds scores of players within the Round.
            }
            else
            {
                currentPlayer++;
                CheckIfCurrent();

                if (currentPlayer > players.Count - 1)
                {
                    currentPlayer = 0; // back to the first player...
                    CheckIfCurrent();
                }
                nextTask = AllTasks.PlayerTurn;
            }
        }

        /* Function: ScoreHand() **********
         * Figures out what task to do next in game
         * as represented by field nextTask
         * Calls methods required to complete task
         * then sets nextTask.
        ************************************/
        public static int ScoreHand(Player player)
        {
            int score = 0;
            foreach (Card card in player.cards)
            {
                string faceValue = card.id.Remove(card.id.Length - 1);
                switch (faceValue)
                {
                    case "K":
                    case "Q":
                    case "J":
                        score = score + 10;
                        break;
                    case "A":
                        score = score + 1;
                        break;
                    default:
                        score = score + int.Parse(faceValue);
                        break;
                }
            }
            return score;
        }

        /* Function: CheckIfCurrent() **********
        * Checks which player is the current player
        * Called in CheckForRoundEnd() and ResetRound()
        ************************************/
        public static void CheckIfCurrent()
        {
            foreach (Player player in players)
                if (players.IndexOf(player) == currentPlayer && player.status == PlayerStatus.active)
                {
                    player.isCurrentPlayer = true;
                }
                else
                {
                    player.isCurrentPlayer = false;
                }
        }

        
        /* Function: CheckActivePlayers() **********
         * Checks if each player is acrtive or not
         * Returns true if at least one player is active
         * Called in Game Tasks.
        ************************************/
        public static bool CheckActivePlayers()
        {
            foreach (var player in players)
            {
                if (player.status == PlayerStatus.active)
                {
                    return true; // at least one player is still going!
                }
            }
            return false; // everyone has stayed or busted, or someone won!
        }

        /* Function: CheckRoundWin() **********
         * Checks if any player has won.
         * Returns true if a player has won
         * Called by DoNextTask() method
        ************************************/
        public static bool CheckForRoundWin()
        {
            /* if playerstatus is win then return true
            * if playerstatus is stay or active, it is false, but it checks a condition if only one Active Player is left and can return true
            * if playerstatus is bust returns false, but checks a condition if only one Active Player is left and can return true
            */

            int busteds = 0; // a count of busted players
            int stayer = 0; // a count of stayed players
            int activePlayerIndex = players.FindIndex(p => p.status == PlayerStatus.active);

            foreach (var player in players)
            {
                if (player.status == PlayerStatus.win) // if player wins
                {
                    player.isWinner = true;
                    return true;
                }
                else if (player.status == PlayerStatus.stay)
                {
                    stayer++;
                    if (busteds == players.Count - 1 || stayer == players.Count - 1 || stayer + busteds == players.Count - 1) // if all busted but one, OR all stayed but one, OR all stayed and busted but one. 
                    {
                        if (activePlayerIndex != -1)
                        {
                            // Get the only active player in the list
                            Player activePlayer = players[activePlayerIndex];
                            players[activePlayerIndex].isWinner = true;
                            players[activePlayerIndex].status = PlayerStatus.win;
                            return true;

                        }
                    }
                }
                else if (player.status == PlayerStatus.bust) // if player bust
                {
                    busteds++;
                    if (busteds == players.Count - 1)
                    {
                        if (activePlayerIndex != -1)
                        {
                            // Get the only active player in the list
                            Player activePlayer = players[activePlayerIndex];
                            players[activePlayerIndex].isWinner = true;
                            players[activePlayerIndex].status = PlayerStatus.win;
                            return true;

                        }

                    }

                }
            }
            return false;
        }

        /* Function: DoRoundScoring() **********
         * Updates scores. Gets the player that won in the round.
         * Called by method DoNextTask() in Game.
         * Returns a player (who is the winner of the round)
        ************************************/
        public static Player DoRoundScoring()
        {
            int highScore = 0;

            foreach (var player in players)
            {
                if (player.status == PlayerStatus.win) // someone hit 21
                {
                    highScore = player.score;
                    player.isWinner = true;
                    return player;
                }
                if (player.status == PlayerStatus.stay || player.status == PlayerStatus.active) // still could win...
                {
                    if (player.score > highScore)
                    {
                        highScore = player.score;
                    }
                }
            }
            if (highScore > 0) // someone scored, anyway!
            {
                // find the FIRST player in list who meets win condition
                return players.Find(player => player.score == highScore);
            }
            return null; // everyone must have busted because nobody won!
        }


        /* Function: DoOverallScoring() **********
        * Updates overallScores of each Player. Get the player that won in the game.
        * Called by method DoNextTask() in Game.
        * Adds/Subtracts round scores to overallScores of each player.
        * Can returns a player (who is the overall winner of the whole game), else returns null.
        ************************************/
        public static Player DoOverallScoring()
        {
            foreach (var player in players)
            {

                if (player.status == PlayerStatus.win) // someone hit 21
                {
                    player.overallScore += player.score; // ADD THE SCORE TO THE PLAYER'S OVERALL SCORE IF WIN
                }

                if (player.status == PlayerStatus.bust) // player went bust...
                {
                    player.overallScore -= (player.score - 21) ; // DEDUCT THE SCORE FROM THE PLAYER'S OVERALL SCORE IF BUST
                }

                if (player.status == PlayerStatus.stay || player.status == PlayerStatus.active) // player went bust...
                {
                    player.overallScore += player.score;
                }

                if (player.overallScore >= cardTable.overallTarget)
                {
                    return player;
                }
            }

            return null; // everyone must have busted because nobody won!

        }

        /* Function: ResetRound() **********
         * This method preps for the next round: 
         * Creates a fresh shuffled deck, resets each player and sets the new round name.
         * Calls the ResetPlayer() method for each player
         * Called by method DoNextTask() in Game.
         * Writes to console. 
        ************************************/
        public static void ResetRound()
        {

            //players.Remove(winner);
            currentPlayer = 0;
            CheckIfCurrent();
            turnsTaken = 0;

            deck = new Deck();
            deck.Shuffle();

            foreach (Player player in players)
            {
                player.ResetPlayer();
            }
            Console.WriteLine("================================");
            Console.Write($"Starting Round # {rounds + 1}");

        }
    }
}
