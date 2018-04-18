using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BullsAndCows.Models
{
    public class Game
    {
        private ICollection<Guess> guesses;

        public Game()
        {
            this.guesses = new HashSet<Guess>();
        }

        public Game(string userId, DateTime createdOn, string playerNumber, string computerNumber) : this()
        {
            this.UserId = userId;
            this.CreatedOn = createdOn;
            this.PlayerNumber = playerNumber;
            this.ComputerNumber = computerNumber;
            this.IsFinished = false;
        }

        public int Id { get; set; }

        public bool IsFinished { get; set; }

        public DateTime? CreatedOn { get; set; }

        public DateTime? FinishedOn { get; set; }

        public bool IsPlayerWinner { get; set; }

        public string PlayerNumber { get; set; }

        public string ComputerNumber { get; set; }

        public int Turn { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual ICollection<Guess> Guesses
        {
            get { return this.guesses; }
            set { this.guesses = value; }
        }
    }
}
