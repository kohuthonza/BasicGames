using System;
using System.Windows.Input;

namespace BasicGames.ViewModels.SnakeGame.SnakeCommands
{ 
    public class MoveHeadRightCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        Snake snake;

        public MoveHeadRightCommand(Snake snake)
        {
            this.snake = snake;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (!snake.Direction.Equals("Left"))
            {
                snake.Direction = "Right";
                snake.Directions.Add("Right");
            }
        }
    }
}
