﻿using BasicGames.Models;
using System;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using BasicGames.Services;

namespace BasicGames.ViewModels.GamersCommands
{
    public class AddGamerCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        private BasicGamesContext gamersContext;

        public AddGamerCommand(BasicGamesContext gamersContext)
        {
            this.gamersContext = gamersContext;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var nameBox = parameter as TextBox;
            this.gamersContext.Gamers.Add(new Gamer(nameBox.Text));
            this.gamersContext.SaveChanges();
            nameBox.Text = "";
        }
    }
}
