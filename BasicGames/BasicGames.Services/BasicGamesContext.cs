using BasicGames.Models;
using System.Data.Entity;

namespace BasicGames.Services
{
    public class BasicGamesContext : DbContext
    {
        public BasicGamesContext() : base("GamersDatabase")
        {

        }

        public DbSet<Gamer> Gamers { get; set; }
    }
}
