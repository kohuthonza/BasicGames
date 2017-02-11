using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BasicGames.ViewModels.Commands
{
    class MoveHeadDownCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        Snake snake;

        public MoveHeadDownCommand(Snake snake)
        {
            this.snake = snake;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (!snake.Direction.Equals("Up"))
            {
                snake.Direction = "Down";
            }
        }
    }
}
