using BullsAndCows.Models;
using BullsAndCows.Web.Models.Game;
using System.Collections.Generic;

namespace BullsAndCows.Web.Models
{
    public interface IViewModelFactory
    {
        GameViewModel CreateDetailedGameViewModel(int gameId, bool isFinished, bool isPlayerWinner, int turn, string playerNumber, string computerNumber, ICollection<Guess> guesses);

        GameViewModel CreateGameViewModel(int gameId);
    }
}