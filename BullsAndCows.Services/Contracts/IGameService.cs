using BullsAndCows.Models;

namespace BullsAndCows.Services.Contracts
{
    public interface IGameService
    {
        Game NewGame(string number);

        Guess MakeAGuess(int gameId, string guess, bool isPlayer);

        string GenerateGuess();

        Game GetGameById(int gameId);

        bool UserIsOwner(int gameId);

        Game FinishGame(int gameId, bool isPlayerWinner);
    }
}
