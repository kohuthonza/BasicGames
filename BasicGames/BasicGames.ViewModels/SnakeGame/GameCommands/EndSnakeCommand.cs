using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace BasicGames.ViewModels.SnakeGame.GameCommands
{
    public class EndSnakeCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private SnakeViewModel snakeViewModel;

        public EndSnakeCommand(SnakeViewModel snakeViewModel)
        {
            this.snakeViewModel = snakeViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var snakeCanvas = parameter as Canvas;
            snakeCanvas.Children.Clear();
            snakeViewModel.Score = 0;
            if (this.snakeViewModel.IsStarted)
            {
                this.snakeViewModel.StopTimers();
                this.snakeViewModel.IsStarted = false;
            }
        }
    }
}
