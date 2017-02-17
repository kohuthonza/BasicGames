using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace BasicGames.ViewModels.FlappyBirdGame.GameCommands
{
    public class EndFlappyBirdCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private FlappyBirdViewModel flappyBirdViewModel;

        public EndFlappyBirdCommand(FlappyBirdViewModel flappyBirdViewModel)
        {
            this.flappyBirdViewModel = flappyBirdViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var flappyBirdCanvas = parameter as Canvas;
            flappyBirdCanvas.Children.Clear();
            flappyBirdViewModel.Score = 0;
            if (this.flappyBirdViewModel.IsStarted)
            {
                this.flappyBirdViewModel.UpdateTimer.Stop();
                this.flappyBirdViewModel.IsStarted = false;
            }
        }
    }
}
