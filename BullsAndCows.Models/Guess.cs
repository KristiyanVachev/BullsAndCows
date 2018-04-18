using System.ComponentModel.DataAnnotations.Schema;

namespace BullsAndCows.Models
{
    public class Guess
    {
        public Guess()
        {
            
        }
        
        public Guess(int gameId, int bulls, int cows, int turn, bool isPlayer)
        {
            this.GameId = gameId;
            this.Bulls = bulls;
            this.Cows = cows;
            this.Turn = turn;
            this.IsPlayer = isPlayer;
        }

        public int Id { get; set; }

        public int Bulls { get; set; }

        public int Cows { get; set; }

        public int Turn { get; set; }

        public bool IsPlayer { get; set; }

        public int GameId { get; set; }

        [ForeignKey("GameId")]
        public virtual Game Game { get; set; }

    }
}
