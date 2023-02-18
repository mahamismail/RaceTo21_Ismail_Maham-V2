using System;
using System.Collections.Generic;

namespace RaceTo21
{
    public class Game
    {
        int numberOfPlayers; // number of players in current game
        List<Player> players = new List<Player>(); // list of objects containing player data
        List<Player> playersInRound = new List<Player>(); // list of objects containing player data = new List<Player>(); 
        CardTable cardTable; // object in charge of displaying game information
        Deck deck = new Deck(); // deck of cards
        int currentPlayer = 0; // current player on list
        public Task nextTask; // keeps track of game state
        private bool cheating = false; // lets you cheat for testing purposes if true

        public int rounds = 0; // the number of rounds played

        public Game(CardTable c)
        {
            cardTable = c;
            deck.Shuffle();
            //deck.ShowAllCards();
            nextTask = Task.GetNumberOfPlayers;
        }

        /* Adds a player to the current game
         * Called by DoNextTask() method
    
        /* Function: AddPlayer() **********
         * Adds new player and it's name to the list.
         * Called by DoNextTask() method in Game object
        ************************************/
        public void AddPlayer(string n)
        {
            players.Add(new Player(n));

        }

        /* Function: DoNextTask() **********
         * Figures out what task to do next in game
         * as represented by field nextTask
         * Calls methods required to complete task
         * then sets nextTask.
        ************************************/
        public void DoNextTask()
        {
            if (nextTask == Task.GetNumberOfPlayers) // gets number of player
            {
                Console.WriteLine("================================");
                numberOfPlayers = cardTable.GetNumberOfPlayers();
                nextTask = Task.GetNames;
            }
            else if (nextTask == Task.GetNames) // get the name of player
            {
                Console.WriteLine("================================");
                for (var count = 1; count <= numberOfPlayers; count++)
                {
                    var name = cardTable.GetPlayerName(count);
                    AddPlayer(name); // NOTE: player list will start from 0 index even though we use 1 for our count here to make the player numbering more human-friendly
                    
                    List<Player> playersInRound = players;
                }
                nextTask = Task.IntroducePlayers;
            }
            else if (nextTask == Task.IntroducePlayers) // player is introduced in console
            {
                Console.WriteLine("================================");
                cardTable.ShowPlayers(players);
                cardTable.ShowScoreboard(players);
                Console.Write($"Starting Round # {rounds + 1}");
                nextTask = Task.PlayerTurn;
            }
            else if (nextTask == Task.PlayerTurn)
            {
                Console.WriteLine();
                Console.WriteLine("================================");
                cardTable.ShowHands(players); // players hands are shown in console
                Player player = players[currentPlayer];
                if (player.status == PlayerStatus.active)
                {
                    /*********************** Level 1 Feature *******************************
                    A player can choose to draw up to 3 cards each turn, but they get all 
                    cards at once; they don’t get to decide after each card

                    Meethod created HowManyCards()
                    ************************************************************************/
                    if (cardTable.HowManyCards(player) == 0) // if player picks 0 cards their status changes to STAY.
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
                nextTask = Task.CheckForEnd;
            }
            else if (nextTask == Task.CheckForEnd) // check if the Round is ending
            {
                /*********************** Level 2 Feature *******************************
        
                Only the winning player earns points equal to their score that round. 
                    o Players who went “bust” lose points equal to their hand total minus 21. 
                    o Game ends when one player reaches an agreed-upon score (for example, 50 points)

                >Player plays multiple rounds until one player reaches overallTarget.<

                Methods added: ResetRound(), ResetPlayer(), AnnounceOverallWinner(), 
                DoOverallScoring(), PlayAnotherRound, ShowScoreboard()

                ************************************************************************/

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
                        nextTask = Task.GameOver; // GAME ENDS
                    }
                    else if (!cardTable.PlayAnotherRound()) // If they don't want to play another round
                    {
                        nextTask = Task.GameOver; // GAME ENDS
                    }
                    else // if continuing to the next round then:
                    {
                        ResetRound(); // Reset the players.
                        nextTask = Task.PlayerTurn; // Move on to the next turn in the next round
                    }
                }
                else
                {
                    currentPlayer++;
                    if (currentPlayer > players.Count - 1)
                    {
                        currentPlayer = 0; // back to the first player...
                    }
                    nextTask = Task.PlayerTurn;
                }
            }
            else // we shouldn't get here...
            {
                Console.WriteLine("I'm sorry, I don't know what to do now!");
                nextTask = Task.GameOver;
            }
        }


        /* Function: ScoreHand() **********
         * Figures out what task to do next in game
         * as represented by field nextTask
         * Calls methods required to complete task
         * then sets nextTask.
        ************************************/
        public int ScoreHand(Player player)
        {
            int score = 0;

            if (cheating == true && player.status == PlayerStatus.active)
            {
                string response = null;
                while (int.TryParse(response, out score) == false)
                {
                    Console.Write("OK, what should player " + player.name + "'s score be?");
                    response = Console.ReadLine();
                }
                return score;
            }
            else
            {
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
            }
            return score;

        }

        /* Function: CheckActivePlayers() **********
         * Checks if each player is acrtive or not
         * Returns true if at least one player is active
         * Called in Game Tasks.
        ************************************/
        public bool CheckActivePlayers()
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
        public bool CheckForRoundWin()
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
        public Player DoRoundScoring()
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
        public Player DoOverallScoring()
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
        private void ResetRound()
        {   

            //players.Remove(winner);
            currentPlayer = 0;
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
