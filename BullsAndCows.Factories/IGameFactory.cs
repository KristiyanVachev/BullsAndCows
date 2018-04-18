using System;
using BullsAndCows.Models;

namespace BullsAndCows.Factories
{
    public interface IGameFactory
    {
        Game CreateGame(string userId, DateTime createdOn, string playerNumber, string computerNumber);

        Guess CreateGuess(int gameId, int bulls, int cows, int turn, bool isPlayer);
    }
}
