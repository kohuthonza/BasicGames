using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicGames.Models
{
    public class SnakeRectangle
    {
        public int XCoord { get; set; }
        public int YCoord { get; set; }

        public SnakeRectangle(int XCoord, int YCoord)
        {
            this.XCoord = XCoord;
            this.YCoord = YCoord;
        }
    }
}
