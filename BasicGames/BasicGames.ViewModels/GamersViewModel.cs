using BasicGames.Models;
using BasicGames.Services;
using BasicGames.ViewModels.GamersCommands;
using System;
using System.Data.Entity;
using System.Collections.ObjectModel;

namespace BasicGames.ViewModels
{
    public class GamersViewModel
    {
        public GamerViewModel GamerViewModel { get; set; }
        public SelectGamerCommand SelectGamerCommand { get; set; }
        public AddGamerCommand AddGamerCommand { get; set; }
        public RemoveGamerCommand RemoveGamerCommand { get; set; }
        public SaveGamersCommand SaveGamersCommand { get; set; }

        public ObservableCollection<Gamer> Gamers { get; set; }

        public GamersViewModel()
        {
            BasicGamesContext context = new BasicGamesContext();
            //context.Gamers.Load();
            //this.Gamers = context.Gamers.Local;
            this.Gamers = new ObservableCollection<Gamer>();
            this.Gamers.Add(new Gamer("Honza"));
            this.GamerViewModel = new GamerViewModel();
            this.AddGamerCommand = new AddGamerCommand(context);
            this.RemoveGamerCommand = new RemoveGamerCommand(context);
            this.SaveGamersCommand = new SaveGamersCommand(context);
            this.SelectGamerCommand = new SelectGamerCommand(this.GamerViewModel);
           
        }
    }
}
