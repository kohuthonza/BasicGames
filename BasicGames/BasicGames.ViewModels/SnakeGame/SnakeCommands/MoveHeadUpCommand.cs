using System;
using System.Windows.Input;

namespace BasicGames.ViewModels.SnakeGame.SnakeCommands
{
    public class MoveHeadUpCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        Snake snake;

        public MoveHeadUpCommand(Snake snake)
        {
            this.snake = snake;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (!snake.Direction.Equals("Down"))
            {
                snake.Direction = "Up";
                snake.Directions.Add("Up");
            };
        }
    }
}
