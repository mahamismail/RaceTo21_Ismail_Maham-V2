using System;
using System.Collections.Generic;

namespace RaceTo21_BlazorApp
{
	public class Player
	{
		public string name { get; private set; }
		public List<Card> cards = new List<Card>();
		public PlayerStatus status = PlayerStatus.active;
		public int score; // round score
		public int overallScore; // Game Score
		public bool isCurrentPlayer; // checks if this the current player or not
		public bool isWinner; // checks if this player is a winner or not
		

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
		 * Also resets multiple propperties of the player.
		 * Called by ResetRound() method.
		************************************/
		public void ResetPlayer()
        {
			isCurrentPlayer = false;
			isWinner = false;
			score = 0;
			status = PlayerStatus.active;
			cards.Clear();
        }

	}
}

