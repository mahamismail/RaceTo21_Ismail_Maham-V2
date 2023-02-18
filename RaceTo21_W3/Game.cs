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
         */
        public void AddPlayer(string n)
        {
            players.Add(new Player(n));

        }

        /* Figures out what task to do next in game
         * as represented by field nextTask
         * Calls methods required to complete task
         * then sets nextTask.
         */
        public void DoNextTask()
        {
            if (nextTask == Task.GetNumberOfPlayers)
            {
                Console.WriteLine("================================");
                numberOfPlayers = cardTable.GetNumberOfPlayers();
                nextTask = Task.GetNames;
            }
            else if (nextTask == Task.GetNames)
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
            else if (nextTask == Task.IntroducePlayers)
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
                cardTable.ShowHands(players);
                Player player = players[currentPlayer];
                if (player.status == PlayerStatus.active)
                {
                    
                    if (cardTable.HowManyCards(player) == 0) // if 0 cards picked then player chose to stay
                    {
                        player.status = PlayerStatus.stay;
                    }
                    else if (cardTable.numOfCardsPicked <= 3 && cardTable.numOfCardsPicked != 0) //If card is less than or equal to 3 cards enter this
                    {
                        int numOfCards = cardTable.numOfCardsPicked;
                        for (int i = 0; i < numOfCards; i++) // this loops according to the number of cards needed. If 3, deals out and adds 3 cards.
                        {
                            Card card = deck.DealTopCard();
                            player.cards.Add(card);
                        }
                        player.score = ScoreHand(player);

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
                cardTable.ShowHand(player);
                nextTask = Task.CheckForEnd;
            }
            else if (nextTask == Task.CheckForEnd)
            {
                if (CheckForRoundWin() || !CheckActivePlayers())
                {
                    rounds++;
                    Console.WriteLine("================================");
                    Player winner = DoFinalScoring();
                    cardTable.AnnounceWinner(winner);

                    Player overallWinner = DoOverallScoring();
                    cardTable.ShowScoreboard(players);

                    if (overallWinner != null)
                    {
                        cardTable.AnnounceOverallWinner(overallWinner);
                        nextTask = Task.GameOver;
                    }
                    else if (!cardTable.PlayAnotherRound()) // If they don't want to play another round, end it here.
                    {
                        nextTask = Task.GameOver; // ------------------------------------------------------------
                    }
                    else
                    {
                        ResetRound(winner);
                        nextTask = Task.PlayerTurn;
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

            /*int counter = 0;

            foreach (var player in players)
            {
                if (player.status == PlayerStatus.stay || player.status == PlayerStatus.active)
                {
                    if (counter == players.Count - 1) // if only one person is not busted, someone won
                    {
                        var status = player.status;
                        status = PlayerStatus.win;
                        return true;
                    }
                    return false; // means at least 2 people are still playing.
                }    
                else if (player.status == PlayerStatus.win) // if one player scores 21 points
                {
                    return true;
                }
                else if (player.status == PlayerStatus.bust) // if more than 21 points, player busted.
                {
                    counter++;
                    return false;
                }            
            }
            return false; // everyone has stayed or busted, or someone won!
            */
            //-------------------------------------------------------------------------------------------

            /*int counter = 0;

            foreach (var player in players)
            {
                if (player.status == PlayerStatus.win)
                {
                    return true;
                }
                else if (player.status == PlayerStatus.active)
                {
                    if (counter == players.Count - 1)
                    {
                        return true;
                    }
                    return false; // at least one player is still going!
                }
                else if (player.status == PlayerStatus.bust)
                {
                    counter++;

                    if (counter == players.Count - 1)
                    {
                        return true;
                    }
                }
                else if (player.status == PlayerStatus.stay)
                {
                    if (counter == players.Count - 1)
                    {
                        var status = player.status;
                        status = PlayerStatus.win;
                        return true;
                    }
                }
            }
            return false; // everyone has stayed or busted, or someone won!
            */
        }

        public Player DoFinalScoring()
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
                        highScore = player.score; // PLAYER'S OVERALL SCORE REMAINS THE SAME IF STAY
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


        /* Function: DoOverallScoring) ****************
         *****************************************/
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

        private void ResetRound(Player winner)
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
