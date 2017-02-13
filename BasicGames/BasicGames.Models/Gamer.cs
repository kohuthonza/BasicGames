using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BasicGames.Models
{
    public class Gamer : INotifyPropertyChanged
    {
        public string Name { get; set; }

        private int snakeTopScore;
        public int SnakeTopScore
        {
            get
            {
                return snakeTopScore;
            }
            set
            {
                snakeTopScore = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Gamer(string name)
        {
            this.Name = name;
            this.SnakeTopScore = 0;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
