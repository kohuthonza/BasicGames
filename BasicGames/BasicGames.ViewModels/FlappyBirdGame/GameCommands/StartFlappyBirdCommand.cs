using BasicGames.ViewModels.FlappyBirdGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace BasicGames.ViewModels.FlappyBirdGame.GameCommands
{
    public class StartFlappyBirdCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private FlappyBirdViewModel flappyBirdViewModel;

        public StartFlappyBirdCommand(FlappyBirdViewModel flappyBirdViewModel)
        {
            this.flappyBirdViewModel = flappyBirdViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return !this.flappyBirdViewModel.IsStarted;
        }

        public void Execute(object parameter)
        {
            var flappyBirdCanvas = parameter as Canvas;
            this.flappyBirdViewModel.InitFlappyBirdGame(flappyBirdCanvas);
            this.flappyBirdViewModel.InitUpdateTimer();
            this.flappyBirdViewModel.IsStarted = true;
        }
    }
}
