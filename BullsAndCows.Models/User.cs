using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BullsAndCows.Models
{
    public class User : IdentityUser
    {
        private ICollection<Game> games;

        public User()
        {
            this.games = new HashSet<Game>();
        }

        public User(string userName, string email) 
            : this()
        {
            this.UserName = userName;
            this.Email = email;
        }
        
        public virtual ICollection<Game> Games
        {
            get { return this.games; }
            set { this.games = value; }
        }
    }
}
