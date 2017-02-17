using BasicGames.Models;
using BasicGames.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BasicGames.ViewModels.GamersCommands
{
    public class RemoveGamerCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private BasicGamesContext gamersContext;

        public RemoveGamerCommand(BasicGamesContext gamersContext)
        {
            this.gamersContext = gamersContext;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var gamer = parameter as Gamer;
            this.gamersContext.Gamers.Remove(gamer);
            this.gamersContext.SaveChanges();
        }
    }
}
