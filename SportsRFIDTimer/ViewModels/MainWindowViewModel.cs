﻿using System;
using System.Collections.Generic;
using System.Windows.Controls;
using Griffin.Logging;
using Microsoft.Expression.Interactivity.Core;
using Microsoft.Practices.Prism.Commands;
using PrismMVVMLibrary;
using SportsRFIDTimer.UserControls;
using SportsRFIDTimer.Views;

namespace SportsRFIDTimer.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        private readonly ILogger _logger = LogManager.GetLogger<MainWindowViewModel>();
        public IList<MenuItemViewModel> Settings { get; set; }
        public IList<MenuItemViewModel> Help { get; set; } 

        public MainWindowViewModel()
        {
            Settings = new List<MenuItemViewModel>
                {
                    new MenuItemViewModel
                        {
                            Name = "Manage Users",
                            ActivateCommand = new ActionCommand(ManageUsers),
                            IsChecked = false,
                            IsCheckable = false
                        }
                };

            Help = new List<MenuItemViewModel>
                {
                    new MenuItemViewModel
                        {
                            Name = "About",
                            ActivateCommand = new ActionCommand(ShowAboutDialog),
                            IsCheckable = false,
                            IsChecked = false
                        }
                };
        }

        private void ShowAboutDialog()
        {
            _logger.Debug("Show about dialgo");
            var dialog = new DialogWindow("About", new AboutUserControl());
            dialog.Show();
        }

        private void ManageUsers()
        {
            _logger.Debug("Manage users called.");
            var dialog = new DialogWindow("Manage Users", new ManageUsersUserControl());
            dialog.Show();
        }
    }
}
