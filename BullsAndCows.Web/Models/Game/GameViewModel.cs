using BullsAndCows.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BullsAndCows.Web.Models.Game
{
    public class GameViewModel
    {
        public GameViewModel()
        {

        }

        public GameViewModel(int gameId)
        {
            this.Id = gameId;
        }

        public GameViewModel(int gameId, bool isFinished, bool isPlayerWinner, int turn, string playerNumber, string computerNumber, ICollection<Guess> guesses) 
            : this(gameId)
        {
            this.IsFinished = isFinished;
            this.IsPlayerWinner = isPlayerWinner;
            this.Turn = turn;
            this.PlayerNumber = playerNumber;
            this.ComputerNumber = computerNumber;
            this.Guesses = guesses;
        }

        public string PlayerNumber { get; set; }

        [RegularExpression(@"^[0-9]{4}$", ErrorMessage = "Guess must be a four digit number.")]
        public string Guess { get; set; }

        public int Id { get; set; }

        public bool IsFinished { get; set; }

        public bool IsPlayerWinner { get; set; }

        public string ComputerNumber { get; set; }

        public int Turn { get; set; }

        public ICollection<Guess> Guesses { get; set; }
    }
}