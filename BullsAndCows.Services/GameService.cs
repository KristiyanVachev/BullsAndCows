using Bytes2you.Validation;
using BullsAndCows.Auth.Contracts;
using BullsAndCows.Models;
using BullsAndCows.Services.Contracts;
using BullsAndCows.Services.Utilities.Contracts;

namespace BullsAndCows.Services
{
    public class GameService : IGameService
    {
        private readonly IGameUtility gameUtility;
        private readonly IUserUtility userUtility;
        private readonly IAuthenticationProvider authenticationProvider;

        public GameService(IGameUtility gameUtility,
            IUserUtility userUtility,
            IAuthenticationProvider authenticationProvider)
        {
            //TODO: Extract "cannot be null" message to costant
            Guard.WhenArgument(gameUtility, "GameUtility cannot be null").IsNull().Throw();
            Guard.WhenArgument(userUtility, "UserUtility cannot be null").IsNull().Throw();
            Guard.WhenArgument(authenticationProvider, "AuthenticationProvider cannot be null").IsNull().Throw();

            this.gameUtility = gameUtility;
            this.userUtility = userUtility;
            this.authenticationProvider = authenticationProvider;
        }

        public Game NewGame(string number)
        {
            var userId = this.authenticationProvider.CurrentUserId;

            var computerNumber = this.gameUtility.GenerateNumber();

            var newGame = this.gameUtility.CreateGame(userId, number, computerNumber);

            return newGame;
        }

        public Guess MakeAGuess(int gameId, string guess, bool isPlayer)
        {
            var game = this.gameUtility.GetGameById(gameId);

            var number = isPlayer ? game.ComputerNumber : game.PlayerNumber;

            var bulls = this.gameUtility.GetBulls(number, guess);
            var cows = this.gameUtility.GetCows(number, guess, bulls);

            var newGuess = this.gameUtility.CreateGuess(gameId, bulls, cows, isPlayer);

            return newGuess;
        }

        public string GenerateGuess()
        {
            //Our bot is extremely stupid. It predicts the same value over and over again...
            //A smarter bot could, say take his best guess and make new guesses with the same numbers as there are cows...

            return "2345";
        }

        public Game FinishGame(int gameId, bool isPlayerWinner)
        {
            var game = this.gameUtility.EndGame(gameId, isPlayerWinner);

            return game;
        }

        public Game GetGameById(int gameId)
        {
            return this.gameUtility.GetGameById(gameId);
        }

        public bool UserIsOwner(int gameId)
        {
            var userId = this.authenticationProvider.CurrentUserId;

            var game = this.gameUtility.GetGameById(gameId);

            if (game == null)
            {
                return false;
            }

            return game.UserId == userId;
        }
    }
}
