using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace BasicGames.ViewModels.FlappyBirdGame.GameCommands
{
    public class PauseFlappyBirdCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private FlappyBirdViewModel flappyBirdViewModel;

        public PauseFlappyBirdCommand(FlappyBirdViewModel flappyBirdViewModel)
        {
            this.flappyBirdViewModel = flappyBirdViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var pauseButton = parameter as Button;

            if (this.flappyBirdViewModel.IsPaused)
            {
                this.flappyBirdViewModel.Continue();
                pauseButton.Content = "Pause";
            }
            else
            {
                this.flappyBirdViewModel.Pause();
                pauseButton.Content = "Continue";
            }
        }
    }
}
