using BasicGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BasicGames.ViewModels.Commands
{
    public class StartSnakeGameCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Gamer gamer;
        private SnakeViewModel snakeViewModel;

        public StartSnakeGameCommand(Gamer gamer, SnakeViewModel snakeViewModel)
        {
            this.gamer = gamer;
            this.snakeViewModel = snakeViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
           snakeViewModel.Init(gamer);
        }
    }
}
