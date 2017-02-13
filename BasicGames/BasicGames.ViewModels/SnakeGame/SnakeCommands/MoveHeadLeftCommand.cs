using System;
using System.Windows.Input;

namespace BasicGames.ViewModels.SnakeGame.SnakeCommands
{
    public class MoveHeadLeftCommand : ICommand
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
                snake.Directions.Add("Left");
            }

        }
    }
}
