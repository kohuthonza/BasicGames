using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicGames.Models
{
    public class Gamers
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Gamers(string name)
        {
            this.Name = name;
            this.Score = 0;
        }
    }
}
