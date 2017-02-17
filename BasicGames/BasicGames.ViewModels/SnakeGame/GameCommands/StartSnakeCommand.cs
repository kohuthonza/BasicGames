using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace BasicGames.ViewModels.SnakeGame.GameCommands
{
    public class StartSnakeCommand : ICommand
    {
      
        public event EventHandler CanExecuteChanged;

        private SnakeViewModel snakeViewModel;

        public StartSnakeCommand(SnakeViewModel snake)
        {
            this.snakeViewModel = snake;
        }

        public bool CanExecute(object parameter)
        {
            return !this.snakeViewModel.IsStarted;
        }

        public void Execute(object parameter)
        {
            var snakeCanvas = parameter as Canvas;
            this.snakeViewModel.InitSnakeGame(snakeCanvas);
            this.snakeViewModel.InitUpdateTimer();
            this.snakeViewModel.IsStarted = true;
        }
    }
}
