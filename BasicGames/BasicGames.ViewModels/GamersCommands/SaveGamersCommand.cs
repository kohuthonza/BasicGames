using System;
using BasicGames.Services;
using System.Windows.Input;

namespace BasicGames.ViewModels.GamersCommands
{
    public class SaveGamersCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private BasicGamesContext basicGamesContext;

        public SaveGamersCommand(BasicGamesContext basicGamesContext)
        {
            this.basicGamesContext = basicGamesContext;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.basicGamesContext.SaveChanges();
        }
    }
}
