using System;

namespace HeroGameApi
{
    public class Game
    {
        public int GameId { get; set; }
        public string Winner { get; set; }
        public DateTime Date { get; set; }
          public Game(int GameId, string Winner, DateTime Date)
        {
            this.GameId = GameId;
            this.Winner = Winner;
            this.Date = Date;
        }
    }
}