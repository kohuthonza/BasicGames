using BasicGames.Models;
using BasicGames.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BasicGames.ViewModels
{
    public class GamersViewModel
    {
        public GamerViewModel GamerViewModel { get; set; }
        public ICommand SelectGamerCommand { get; set; }

        public ObservableCollection<Gamer> Gamers { get; set; }

        public GamersViewModel()
        {
            this.GamerViewModel = new GamerViewModel();
            this.SelectGamerCommand = new SelectGamerCommand(this.GamerViewModel);

            Gamers = new ObservableCollection<Gamer>();
            Gamers.Add(new Gamer("Honza"));
            Gamers.Add(new Gamer("Jurka"));
        }
    }
}
