using System.Collections.Generic;
using BullsAndCows.Models;

namespace BullsAndCows.Services.Utilities.Contracts
{
    public interface IUserUtility
    {
        IEnumerable<User> GetAll();

        User GetById(string id);
    }
}
