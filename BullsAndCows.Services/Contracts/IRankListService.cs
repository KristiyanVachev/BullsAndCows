using BullsAndCows.Models;
using System.Collections.Generic;

namespace BullsAndCows.Services.Contracts
{
    public interface IRankListService
    {
        ICollection<Game> GetTopPlayerGames(int top);
    }
}
