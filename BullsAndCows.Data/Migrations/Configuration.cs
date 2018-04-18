using System.Linq;
using BullsAndCows.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Constants = BullsAndCows.Commom.Constants;

namespace BullsAndCows.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<BullsAndCows.Data.BullsAndCowsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
            ContextKey = "BullsAndCows.Data.LeafDbContext";
        }

        protected override void Seed(BullsAndCowsDbContext context)
        {
            if (!(context.Users.Any(u => u.UserName == "typhon")))
            {
                var userStore = new UserStore<User>(context);
                var userManager = new UserManager<User>(userStore);
                var userToInsert = new User { UserName = "typhon", Email = "typhon04@gmail.com" };
                userManager.Create(userToInsert, "nanana");
            }

            context.SaveChanges();
        }
    }
}
