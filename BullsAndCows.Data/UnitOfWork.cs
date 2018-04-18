using System;
using BullsAndCows.Data.Contracts;

namespace BullsAndCows.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IBullsAndCowsDbContext dbContext;

        public UnitOfWork(IBullsAndCowsDbContext dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException("dbContext cannot be null");
            }

            this.dbContext = dbContext;
        }

        public void Dispose()
        {

        }

        public void Commit()
        {
            this.dbContext.SaveChanges();
        }
    }
}
