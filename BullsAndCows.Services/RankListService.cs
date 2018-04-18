using BullsAndCows.Data.Contracts;
using BullsAndCows.Models;
using BullsAndCows.Services.Contracts;
using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;

namespace BullsAndCows.Services
{
    public class RankListService : IRankListService
    {
        private readonly IRepository<Game> gameRepository;

        public RankListService(IRepository<Game> gameRepository)
        {
            Guard.WhenArgument(gameRepository, "GameRepository cannot be null").IsNull().Throw();

            this.gameRepository = gameRepository;
        }

        public ICollection<Game> GetTopPlayerGames(int top)
        {
            var topPlayerGames = this.gameRepository.Entities
                .Where(x => x.IsFinished && x.IsPlayerWinner)
                .OrderBy(x => x.Turn)
                .Take(top)
                .ToList();

            return topPlayerGames;
        }
    }
}
