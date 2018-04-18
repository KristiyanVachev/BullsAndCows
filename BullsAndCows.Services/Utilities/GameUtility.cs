using System.Linq;
using Bytes2you.Validation;
using BullsAndCows.Commom.Contracts;
using BullsAndCows.Data.Contracts;
using BullsAndCows.Factories;
using BullsAndCows.Models;
using BullsAndCows.Services.Utilities.Contracts;

namespace BullsAndCows.Services.Utilities
{
    public class GameUtility : IGameUtility
    {
        private readonly IRepository<Game> gameRepository;
        private readonly IGameFactory gameFactory;
        private readonly IUnitOfWork unitOfWork;
        private readonly IDateTimeProvider dateTimeProvider;

        public GameUtility(IRepository<Game> gameRepository,
            IGameFactory gameFactory,
            IDateTimeProvider dateTimeProvider,
            IUnitOfWork unitOfWork)
        {
            Guard.WhenArgument(gameRepository, "GameRepository cannot be null").IsNull().Throw();
            Guard.WhenArgument(gameFactory, "gameFactory cannot be null").IsNull().Throw();
            Guard.WhenArgument(dateTimeProvider, "dateTimeProvider cannot be null").IsNull().Throw();
            Guard.WhenArgument(unitOfWork, "unitOfWork cannot be null").IsNull().Throw();

            this.gameRepository = gameRepository;
            this.gameFactory = gameFactory;
            this.dateTimeProvider = dateTimeProvider;
            this.unitOfWork = unitOfWork;
        }

        public Game CreateGame(string userId, string playerNumber, string computerNumber)
        {
            var currentTime = dateTimeProvider.GetCurrenTime();

            var test = this.gameFactory.CreateGame(userId, currentTime, playerNumber, computerNumber);

            this.gameRepository.Add(test);
            this.unitOfWork.Commit();

            return test;
        }

        public string GenerateNumber()
        {
            //Our bot isn't very imaginative. I guess he expects that you'll never think to guess the same number twice.
            //Oh, well. At least he'll make it easier to test.
            return "1234";
        }

        public Game GetGameById(int testId)
        {
            return this.gameRepository.GetById(testId);
        }

        public int GetBulls(string number, string guess)
        {
            var bulls = 0;

            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] == guess[i])
                {
                    bulls++;
                }
            }

            return bulls;
        }

        public int GetCows(string number, string guess, int bulls)
        {
            var cows = 0;

            for (int i = 0; i < number.Length; i++)
            {
                if (number.Contains(guess[i]))
                {
                    cows++;
                }
            }

            return cows - bulls;
        }

        public Guess CreateGuess(int gameId, int bulls, int cows, bool isPlayer)
        {
            var game = this.gameRepository.GetById(gameId);

            if (isPlayer)
            {
                game.Turn++;
            }

            var newGuess = this.gameFactory.CreateGuess(gameId, bulls, cows, game.Turn, isPlayer);

            game.Guesses.Add(newGuess);

            this.gameRepository.Update(game);
            this.unitOfWork.Commit();

            return newGuess;
        }

        public Game EndGame(int gameId, bool isPlayerWinner)
        {
            var game = this.gameRepository.GetById(gameId);

            game.IsPlayerWinner = isPlayerWinner;
            game.IsFinished = true;

            this.gameRepository.Update(game);
            this.unitOfWork.Commit();

            return game;
        }
    }
}
