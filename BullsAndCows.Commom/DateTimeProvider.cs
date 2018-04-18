using System;
using BullsAndCows.Commom.Contracts;

namespace BullsAndCows.Commom
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime GetCurrenTime()
        {
            return DateTime.Now;
        }
    }
}
