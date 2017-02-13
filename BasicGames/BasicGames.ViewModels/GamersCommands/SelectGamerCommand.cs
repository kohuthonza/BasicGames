using BasicGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BasicGames.ViewModels.GamersCommands
{
    public class SelectGamerCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private GamerViewModel gamerViewModel;

        public SelectGamerCommand(GamerViewModel gamerViewModel)
        {
            this.gamerViewModel = gamerViewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            gamerViewModel.Init(parameter as Gamer);
        }
    }
}
