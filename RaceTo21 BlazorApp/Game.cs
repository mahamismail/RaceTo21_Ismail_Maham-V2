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
        public static bool cheating = true; // lets you cheat for testing purposes if true

        public static int rounds = 0; // the number of rounds played

        public Game(CardTable c)
        {
            cardTable = c;
            deck.Shuffle();
            //deck.ShowAllCards();
            nextTask = AllTasks.GetNumberOfPlayers;
        }


        /* Function: AddPlayer() **********
         * Adds new player and it's name to the list.
         * Called by DoNextTask() method in Game object
        ************************************/
        public static void AddPlayer(string n)
        {
            players.Add(new Player(n));

        }

        public static void DrawCards(int cardsPicked)
        {
            Player player = players[currentPlayer];

            cardTable.ShowHand(player); // players hands are shown in console
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
            cardTable.ShowHand(player); // show hand to players.
            CheckForRoundEnd();
        }

        public static void CheckForEnd()
        {
            if (CheckForRoundWin() || !CheckActivePlayers()) // do this is someone wins a round or there are no active players left.
            {
                rounds++;
                Console.WriteLine("================================");
                Player winner = DoRoundScoring(); // adds scores of players within the Round.
                cardTable.AnnounceWinner(winner); // announce the winner of the round

                Player overallWinner = DoOverallScoring(); // adds to the overall scoring and updates scoreboard.
                cardTable.ShowScoreboard(players); // displays scoreboard

                if (overallWinner != null) // if there is a winner
                {
                    cardTable.AnnounceOverallWinner(overallWinner); // announce winner
                    nextTask = AllTasks.GameOver; // GAME ENDS
                }
                else if (!cardTable.PlayAnotherRound()) // If they don't want to play another round
                {
                    nextTask = AllTasks.GameOver; // GAME ENDS
                }
                else // if continuing to the next round then:
                {
                    ResetRound(); // Reset the players.
                    nextTask = AllTasks.PlayerTurn; // Move on to the next turn in the next round
                }
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


        public static void CheckForRoundEnd()
        {
            if (CheckForRoundWin() || !CheckActivePlayers()) // do this is someone wins a round or there are no active players left.
            {
                rounds++;
                Player winner = DoRoundScoring(); // adds scores of players within the Round.
                winner.isWinner = true;
                cardTable.AnnounceWinner(winner); // announce the winner of the round
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

        /* Function: DoNextTask() **********
         * Figures out what task to do next in game
         * as represented by field nextTask
         * Calls methods required to complete task
         * then sets nextTask.
        
        public static void DoNextTask()
        {
            if (nextTask == AllTasks.GetNumberOfPlayers) // gets number of player
            {
                Console.WriteLine("================================");
                numberOfPlayers = cardTable.GetNumberOfPlayers();
                nextTask = AllTasks.GetNames;
            }
            else if (nextTask == AllTasks.GetNames) // get the name of player
            {
                Console.WriteLine("================================");
                for (var count = 1; count <= numberOfPlayers; count++)
                {
                    var name = cardTable.GetPlayerName(count);
                    AddPlayer(name); // NOTE: player list will start from 0 index even though we use 1 for our count here to make the player numbering more human-friendly
                    
                    List<Player> playersInRound = players;
                }
                nextTask = AllTasks.IntroducePlayers;
            }
            else if (nextTask == AllTasks.IntroducePlayers) // player is introduced in console
            {
                Console.WriteLine("================================");
                cardTable.ShowScoreboard(players);
                Console.Write($"Starting Round # {rounds + 1}");
                nextTask = AllTasks.PlayerTurn;
            }
            else if (nextTask == AllTasks.PlayerTurn)
            {
                Player player = players[currentPlayer];
                cardTable.ShowHand(player); // players hands are shown in console
                if (player.status == PlayerStatus.active)
                {
                    if (cardTable.numOfCardsPicked == 0) // if player picks 0 cards their status changes to STAY.
                    {
                        player.status = PlayerStatus.stay;
                    }
                    else if (cardTable.numOfCardsPicked <= 3 && cardTable.numOfCardsPicked != 0) // If player picks less than or equal to 3 cards, enter this.
                    {
                        int numOfCards = cardTable.numOfCardsPicked;
                        for (int i = 0; i < numOfCards; i++) // this loops according to the number of cards needed. If 3, deals out and adds 3 cards.
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
                cardTable.ShowHand(player); // show hand to players.
                nextTask = AllTasks.CheckForEnd;
            }
            else if (nextTask == AllTasks.CheckForEnd) // check if the Round is ending
            {

                if (CheckForRoundWin() || !CheckActivePlayers()) // do this is someone wins a round or there are no active players left.
                {
                    rounds++;
                    Console.WriteLine("================================");
                    Player winner = DoRoundScoring(); // adds scores of players within the Round.
                    cardTable.AnnounceWinner(winner); // announce the winner of the round

                    Player overallWinner = DoOverallScoring(); // adds to the overall scoring and updates scoreboard.
                    cardTable.ShowScoreboard(players); // displays scoreboard

                    if (overallWinner != null) // if there is a winner
                    {
                        cardTable.AnnounceOverallWinner(overallWinner); // announce winner
                        nextTask = AllTasks.GameOver; // GAME ENDS
                    }
                    else if (!cardTable.PlayAnotherRound()) // If they don't want to play another round
                    {
                        nextTask = AllTasks.GameOver; // GAME ENDS
                    }
                    else // if continuing to the next round then:
                    {
                        ResetRound(); // Reset the players.
                        nextTask = AllTasks.PlayerTurn; // Move on to the next turn in the next round
                    }
                }
                else
                {
                    currentPlayer++;
                    if (currentPlayer > players.Count - 1)
                    {
                        currentPlayer = 0; // back to the first player...
                    }
                    nextTask = AllTasks.PlayerTurn;
                }
            }
            else // we shouldn't get here...
            {
                Console.WriteLine("I'm sorry, I don't know what to do now!");
                nextTask = AllTasks.GameOver;
            }
        }
        ************************************/


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

        /**************************************************************************** NEEDS TO BE ADDED IN THE END
         * *********************************************************************************************/
        public static void CheckIfCurrent()
        {
            foreach (Player player in players)
                if (players.IndexOf(player) == currentPlayer)
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
             * if playerstatus is stay or active, false, unless counter is one less the number of players (counter = numOfPlayers -1) 
             * if playerstatus is bust return false.
             */

            int counter = 0;
            foreach (var player in players)
            {
                if (player.status == PlayerStatus.win)
                {
                    return true;
                }
                else if (player.status == PlayerStatus.stay || player.status == PlayerStatus.active)
                {
                    if (counter == players.Count - 1) 
                    {
                        player.status = PlayerStatus.win;
                        return true;
                    }
                }
                else if (player.status == PlayerStatus.bust)
                {
                    counter++;
                    if (counter == players.Count - 1)
                    {
                        return true;
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
                cardTable.ShowHand(player);
                if (player.status == PlayerStatus.win) // someone hit 21
                {
                    highScore = player.score;
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
                int counter = 0;

                if (player.status == PlayerStatus.win) // someone hit 21
                {
                    player.overallScore += player.score; // ADD THE SCORE TO THE PLAYER'S OVERALL SCORE IF WIN
                }
                /*if (player.status == PlayerStatus.stay || player.status == PlayerStatus.active) // still could win...
                {
                }*/
                if (player.status == PlayerStatus.bust) // player went bust...
                {
                    counter++;
                    player.overallScore -= (player.score - 21) ; // DEDUCT THE SCORE FROM THE PLAYER'S OVERALL SCORE IF BUST

                    /*if (player.overallScore < 0)
                    {
                        player.overallScore = 0;
                    }*/
                }
                if (player.status == PlayerStatus.stay || player.status == PlayerStatus.active) // player went bust...
                {
                    player.overallScore += player.score;
                    //if (counter == players.Count - 1)
                    //{
                    //    player.overallScore += player.score;
                    //}
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
