using System.Data.Entity;
using BullsAndCows.Data.Contracts;
using BullsAndCows.Data.Migrations;
using BullsAndCows.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BullsAndCows.Data
{
    public class BullsAndCowsDbContext : IdentityDbContext<User>, IBullsAndCowsDbContext
    {
        public BullsAndCowsDbContext() : this("BullsAndCowsDb")
        {
        }

        public BullsAndCowsDbContext(string nameOfConnectionString)
            : base(nameOfConnectionString)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BullsAndCowsDbContext, Configuration>());
            //Database.SetInitializer(new DropCreateDatabaseAlways<LeafDbContext>());
        }

        public virtual IDbSet<Game> Games { get; set; }

        public virtual IDbSet<Guess> Guesses { get; set; }

        public static BullsAndCowsDbContext Create()
        {
            return new BullsAndCowsDbContext();
        }

        public IDbSet<TEntity> DbSet<TEntity>() where TEntity : class
        {
            return this.Set<TEntity>();
        }

        public void SetAdded<TEntry>(TEntry entity) where TEntry : class
        {
            var entry = this.Entry(entity);
            entry.State = EntityState.Added;
        }

        public void SetDeleted<TEntry>(TEntry entity) where TEntry : class
        {
            var entry = this.Entry(entity);
            entry.State = EntityState.Deleted;
        }

        public void SetUpdated<TEntry>(TEntry entity) where TEntry : class
        {
            var entry = this.Entry(entity);
            entry.State = EntityState.Modified;
        }
    }
}
