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

        private int snakeScore;
        public int SnakeScore
        {
            get
            {
                return snakeScore;
            }
            set
            {
                snakeScore = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Gamer(string name)
        {
            this.Name = name;
            this.SnakeScore = 0;
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
