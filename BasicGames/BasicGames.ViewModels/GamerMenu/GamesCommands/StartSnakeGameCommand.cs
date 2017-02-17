using BasicGames.Models;
using BasicGames.ViewModels.SnakeGame;
using System;
using System.Windows.Input;

namespace BasicGames.ViewModels.GamerMenu.GamesCommands
{
    public class StartSnakeGameCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Gamer gamer;
        private SnakeViewModel snakeViewModel;

        public StartSnakeGameCommand(Gamer gamer, SnakeViewModel snakeViewModel)
        {
            this.gamer = gamer;
            this.snakeViewModel = snakeViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
           this.snakeViewModel.Init(this.gamer);
        }
    }
}
