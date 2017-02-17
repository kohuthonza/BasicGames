using BasicGames.Models;
using BasicGames.ViewModels.FlappyBirdGame;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BasicGames.ViewModels.GamerMenu.GamesCommands
{
    public class StartFlappyBirdGameCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private Gamer gamer;
        private FlappyBirdViewModel flappyBirdViewModel;

        public StartFlappyBirdGameCommand(Gamer gamer, FlappyBirdViewModel flappyBirdViewModel)
        {
            this.gamer = gamer;
            this.flappyBirdViewModel = flappyBirdViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.flappyBirdViewModel.Init(this.gamer);
        }
    }
}
