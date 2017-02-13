using BasicGames.Models;
using System;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace BasicGames.ViewModels.GamersCommands
{
    public class AddGamerCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private ObservableCollection<Gamer> gamers;

        public AddGamerCommand(ObservableCollection<Gamer> gamers)
        {
            this.gamers = gamers;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var nameBox = parameter as TextBox;
            this.gamers.Add(new Gamer(nameBox.Text));
            nameBox.Text = "";
        }
    }
}
