using System;
using System.Windows.Input;

namespace BasicGames.ViewModels.SnakeGame.SnakeCommands
{
    public class MoveHeadDownCommand : ICommand
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
                snake.Directions.Add("Down");
            }
        }
    }
}
