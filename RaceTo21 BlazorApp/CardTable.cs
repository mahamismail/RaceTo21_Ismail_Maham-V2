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

    }
}