using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BasicGames.ViewModels.FlappyBirdGame.FlappyBirdCommands
{
    public class JumpFlappyBirdCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        FlappyBird flappyBird;

        public JumpFlappyBirdCommand(FlappyBird flappyBird)
        {
            this.flappyBird = flappyBird;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.flappyBird.Jump();
        }
    }
}
