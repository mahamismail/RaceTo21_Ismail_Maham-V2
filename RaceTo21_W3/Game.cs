﻿using System;
using System.Collections.Generic;

namespace RaceTo21
{
    public class Game
    {
        int numberOfPlayers; // number of players in current game
        List<Player> players = new List<Player>(); // list of objects containing player data
        CardTable cardTable; // object in charge of displaying game information
        Deck deck = new Deck(); // deck of cards
        int currentPlayer = 0; // current player on list
        public Task nextTask; // keeps track of game state
        private bool cheating = false; // lets you cheat for testing purposes if true
        public int overallTarget = 47; // the final overall score needed by on eplayer to win the game
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
            Console.WriteLine("================================"); // this line should be elsewhere right?
            if (nextTask == Task.GetNumberOfPlayers)
            {
                numberOfPlayers = cardTable.GetNumberOfPlayers();
                nextTask = Task.GetNames;
            }
            else if (nextTask == Task.GetNames)
            {
                for (var count = 1; count <= numberOfPlayers; count++)
                {
                    var name = cardTable.GetPlayerName(count);
                    AddPlayer(name); // NOTE: player list will start from 0 index even though we use 1 for our count here to make the player numbering more human-friendly
                }
                nextTask = Task.IntroducePlayers;
            }
            else if (nextTask == Task.IntroducePlayers)
            {   
                cardTable.ShowPlayers(players);
                nextTask = Task.ShowBigScores; // DISPLAY OVERALL SCORES
            }
            else if (nextTask == Task.ShowBigScores)
            {
                //cardTable.ShowOverallScore(); // CALL FUNCTION SHOW OVERALL SCORE ////////////////////// NOT WORKING
                nextTask = Task.PlayerTurn;
            }
            else if (nextTask == Task.PlayerTurn)
            {
                cardTable.ShowHands(players);
                Player player = players[currentPlayer];
                if (player.status == PlayerStatus.active)
                {
                    if (cardTable.HowManyCards(player) == 0) // if false make the player stay
                    {
                        player.status = PlayerStatus.stay;
                    }
                    else if (cardTable.numOfCardsPicked <= 3 && cardTable.numOfCardsPicked != 0) //if OfferACard is true call 1, 2, 3 cards then check score
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
                    else
                    {
                        player.status = PlayerStatus.stay;
                    }
                }
                cardTable.ShowHand(player);
                nextTask = Task.CheckForEnd;
            }
            else if (nextTask == Task.CheckForEnd)
            {
                if (CheckForWinAndBust() || !CheckActivePlayers())
                {
                    Player winner = DoFinalScoring();
                    cardTable.AnnounceWinner(winner);
                    nextTask = Task.GameOver;
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

        public bool CheckForWinAndBust()
        {
            int counter = 0;

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
        }

        public Player DoFinalScoring()
        {
            int highScore = 0;
            int overallScore;

            foreach (var player in players)
            {
                cardTable.ShowHand(player);
                if (player.status == PlayerStatus.win) // someone hit 21
                {
                    overallScore = player.gameScore;
                    overallScore = overallScore + player.score; // ADD THE SCORE TO THE PLAYER'S OVERALL SCORE IF WIN

                    return player;
                }
                if (player.status == PlayerStatus.stay || player.status == PlayerStatus.active) // still could win...
                {
                    if (player.score > highScore)
                    {
                        highScore = player.score; // PLAYER'S OVERALL SCORE REMAINS THE SAME IF STAY

                        overallScore = player.gameScore;
                    }
                }
                if (player.status == PlayerStatus.bust) // player went bust...
                {
                    overallScore = player.gameScore;
                    overallScore = overallScore - player.score; // DEDUCT THE SCORE FROM THE PLAYER'S OVERALL SCORE IF BUST
                }
            }
            if (highScore > 0) // someone scored, anyway!
            {
                // find the FIRST player in list who meets win condition
                return players.Find(player => player.score == highScore);
            }
            return null; // everyone must have busted because nobody won!
        }
    }
}
