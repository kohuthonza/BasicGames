using BasicGames.Models;
using BasicGames.ViewModels.FlappyBirdGame;
using BasicGames.ViewModels.GamerMenu.GamesCommands;
using BasicGames.ViewModels.SnakeGame;
using System.ComponentModel;
using System.Runtime.CompilerServices;


namespace BasicGames.ViewModels
{
    public class GamerViewModel : INotifyPropertyChanged
    {
        public SnakeViewModel SnakeViewModel { get; set; }
        public FlappyBirdViewModel FlappyBirdViewModel { get; set; }

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
        private StartFlappyBirdGameCommand startFlappyBirdGameCommand;
        public StartFlappyBirdGameCommand StartFlappyBirdGameCommand
        {
            get
            {
                return startFlappyBirdGameCommand;
            }
            set
            {
                startFlappyBirdGameCommand = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public GamerViewModel()
        {
            this.SnakeViewModel = new SnakeViewModel();
            this.FlappyBirdViewModel = new FlappyBirdViewModel();
        }

        public void Init(Gamer gamer)
        {
            this.Gamer = gamer;
            this.StartSnakeGameCommand = new StartSnakeGameCommand(this.Gamer, this.SnakeViewModel);
            this.StartFlappyBirdGameCommand = new StartFlappyBirdGameCommand(this.Gamer, this.FlappyBirdViewModel);
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
