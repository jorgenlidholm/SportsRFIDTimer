using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using PrismMVVMLibrary;
using SportsRFIDTimer.Domain.User;
using SportsRFIDTimer.UserControls;
using SportsRFIDTimer.Views;

namespace SportsRFIDTimer.ViewModels
{
    public class ManageUsersUserControlViewModel : ViewModelBase
    {
        private ObservableCollection<UserViewModel> _users;
        private UserViewModel _selectedItem;
        private long _selectedIndex;

        public ManageUsersUserControlViewModel()
        {
            var users = new List<UserViewModel>
                {
                    new UserViewModel(new User("Jörgen Lidholm", 11){Email = "jorgen.lidholm@gmail.com", Meta = "GasGas EC300", TagId = "123-ABC-FGH"}),
                    new UserViewModel(new User("Jonas Larssin", 35){Email = "zyberspy@hotmail.com",Meta = "Husaberg FE350", TagId = "QWE-123-RTY"})
                };
            _users = new ObservableCollection<UserViewModel>(users);
        }

        public ObservableCollection<UserViewModel> Users
        {
            get { return _users; }
            set
            {
                _users = value;
                RaisePropertyChanged(() => Users);
            }
        }

        public UserViewModel SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                _selectedItem = value;
                RaisePropertyChanged(() => SelectedItem);
            }
        }

        public long SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                RaisePropertyChanged(() => SelectedIndex);
            }
        }

        public ICommand EditUserCommand
        {
            get { return new EditUserCommandHandler(); }
        }

    }

    public class EditUserCommandHandler : ICommand
    {
        public bool CanExecute(object parameter)
        {
            return parameter is UserViewModel;
        }

        public void Execute(object parameter)
        {
            if (! (parameter is UserViewModel))
                throw new ArgumentException(String.Format("Invalid paramater, expected {0} found {1}",
                                                          typeof (UserViewModel),
                                                          parameter.GetType()));
            var uvm = parameter as UserViewModel;
            var dialog = new DialogWindow("Edit " + uvm.Name, new EditUserUserControl(uvm));
            dialog.ShowDialog();
        }

        public event EventHandler CanExecuteChanged;
    }
}