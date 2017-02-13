using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace BasicGames.ViewModels.SnakeGame.GameCommands
{
    public class PauseSnakeCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private SnakeViewModel snakeViewModel;

        public PauseSnakeCommand(SnakeViewModel snakeViewModel)
        {
            this.snakeViewModel = snakeViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var pauseButton = parameter as Button;

            if (this.snakeViewModel.IsPaused)
            {
                this.snakeViewModel.Continue();
                pauseButton.Content = "Pause";
            }
            else
            {
                this.snakeViewModel.Pause();
                pauseButton.Content = "Continue";
            }
        }
    }
}
