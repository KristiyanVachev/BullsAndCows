using System.Collections.Generic;
using BullsAndCows.Models;

namespace BullsAndCows.Services.Utilities.Contracts
{
    public interface IGameUtility
    {
        Game CreateGame(string userId, string playerNumber, string computerNumber);

        string GenerateNumber();

        Game GetGameById(int gameId);

        int GetBulls(string number, string guess);

        int GetCows(string number, string guess, int bulls);

        Guess CreateGuess(int gameId, int bulls, int cows, bool isPlayer);

        Game EndGame(int gameId, bool isPlayerWinner);
    }
}
