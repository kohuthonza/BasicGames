using BasicGames.Models;
using BasicGames.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BasicGames.ViewModels
{
    public class GamerViewModel : INotifyPropertyChanged
    {
        public SnakeViewModel SnakeViewModel { get; set; }

        private Gamer gamer;
        public Gamer Gamer
        {
            get
            {
                return gamer;
            }
            set
            {
                gamer = value;
                OnPropertyChanged();
            }
        }
        private StartSnakeGameCommand startSnakeGameCommand;
        public StartSnakeGameCommand StartSnakeGameCommand
        {
            get
            {
                return startSnakeGameCommand;
            }
            set
            {
                startSnakeGameCommand = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public GamerViewModel()
        {
            this.SnakeViewModel = new SnakeViewModel();
        }

        public void Init(Gamer gamer)
        {
            this.Gamer = gamer;
            this.StartSnakeGameCommand = new StartSnakeGameCommand(this.Gamer, this.SnakeViewModel);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
