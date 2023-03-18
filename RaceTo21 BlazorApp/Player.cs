using System;
using System.Collections.Generic;

namespace RaceTo21_BlazorApp
{
	public class Player
	{
		public string name { get; private set; }
		public List<Card> cards = new List<Card>();
		public PlayerStatus status = PlayerStatus.active;
		public int score;
		public int overallScore;
		public bool isCurrentPlayer;
		public bool isWinner;

		public Player(string n)
		{
			name = n;
			isCurrentPlayer = false;
			isWinner = false;

		}

		/* Function: Introduce() **********
		 * Introduces plyer by name.
		 * Called by CardTable object
		************************************/
		public void Introduce(int playerNum)
		{
			Console.WriteLine("Hello, my name is " + name + " and I am player #" + playerNum);
		}

		/* Function: ResetPlayer() **********
		 * Sets all players to active and clears all cards in the player's hand.
		 * Called by ResetRound() method.
		************************************/
		public void ResetPlayer()
        {
			isCurrentPlayer = false;
			isWinner = false;
			status = PlayerStatus.active;
			cards.Clear();
        }

	}
}

