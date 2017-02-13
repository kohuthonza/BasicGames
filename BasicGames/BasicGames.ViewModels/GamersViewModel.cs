using BasicGames.Models;
using BasicGames.ViewModels.GamersCommands;
using System.Collections.ObjectModel;

namespace BasicGames.ViewModels
{
    public class GamersViewModel
    {
        public GamerViewModel GamerViewModel { get; set; }
        public SelectGamerCommand SelectGamerCommand { get; set; }
        public AddGamerCommand AddGamerCommand { get; set; }

        public ObservableCollection<Gamer> Gamers { get; set; }

        public GamersViewModel()
        {
            this.GamerViewModel = new GamerViewModel();
            this.Gamers = new ObservableCollection<Gamer>();
            this.AddGamerCommand = new AddGamerCommand(this.Gamers);
            this.SelectGamerCommand = new SelectGamerCommand(this.GamerViewModel);

            
            Gamers.Add(new Gamer("Honza"));
            Gamers.Add(new Gamer("Jurka"));
        }
    }
}
