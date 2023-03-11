using System;
namespace RaceTo21_BlazorApp
{   
    public class Card
    {
        public string id;
        public string displayName;

    public Card(string shortCardName, string longCardName)
        {
            id = shortCardName;
            displayName = longCardName;
        }
    }
}
