using BullsAndCows.Models;

namespace BullsAndCows.Factories
{
    public interface IUserFactory
    {
        User CreateUser(string userName, string email);
    }
}
