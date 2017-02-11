using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace BasicGames.ViewModels.Commands
{
    public class StartSnakeCommand : ICommand
    {
      
        public event EventHandler CanExecuteChanged;

        private SnakeViewModel snakeViewModel;

        public StartSnakeCommand(SnakeViewModel snake)
        {
            this.snakeViewModel = snake;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var snakeCanvas = parameter as Canvas;
            this.snakeViewModel.InitSnakeGame(snakeCanvas);
        }
    }
}
