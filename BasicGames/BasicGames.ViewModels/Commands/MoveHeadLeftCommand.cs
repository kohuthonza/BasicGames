using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace BasicGames.ViewModels.Commands
{
    class MoveHeadLeftCommand : ICommand
    {
        private Snake snake;

        public event EventHandler CanExecuteChanged;

        public MoveHeadLeftCommand(Snake snake)
        {
            this.snake = snake;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (!snake.Direction.Equals("Right"))
            {
                snake.Direction = "Left";
            }

        }
    }
}
