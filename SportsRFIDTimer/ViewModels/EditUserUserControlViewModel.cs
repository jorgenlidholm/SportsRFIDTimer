using System;
using Griffin.Decoupled.Commands;
using Microsoft.Practices.Prism.Commands;
using PrismMVVMLibrary;
using SportsRFIDTimer.Domain;
using SportsRFIDTimer.Domain.Commands;
using ICommand = System.Windows.Input.ICommand;

namespace SportsRFIDTimer.ViewModels
{
    public class EditUserUserControlViewModel : ViewModelBase
    {
        private readonly UserViewModel _user;
        private readonly UserViewModel _editUser;

        public EditUserUserControlViewModel()
        {
        }

        public EditUserUserControlViewModel(UserViewModel user)
        {
            _user = user;
            _editUser = new UserViewModel(user.User);
        }

        public String Name
        {
            get { return _editUser.Name; }
            set
            {
                if (_editUser.Name == value) return;
                _editUser.Name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public String Meta
        {
            get { return _editUser.Meta; }
            set
            {
                if(_editUser.Meta == value) return;
                _editUser.Meta = value;
                RaisePropertyChanged(()=>Meta);
            }
        }

        public String Email
        {
            get { return _editUser.Email; }
            set
            {
                if (_editUser.Email == value) return;
                _editUser.Email = value;
                RaisePropertyChanged(() => Email);
            }
        }

        public String TagId
        {
            get { return _editUser.TagId; }
            set
            {
                if (_editUser.TagId == value) return;
                _editUser.TagId = value;
                RaisePropertyChanged(() => TagId);
            }
        }

        public int Number
        {
            get { return _editUser.Number; }
            set
            {
                if (_editUser.Number == value) return;
                _editUser.Number = value;
                RaisePropertyChanged(() => Number);
            }
        }
        public ICommand SaveAndCloseCommand
        {
            get { return new SaveAndCloseCommand(_user,_editUser); }
        }
    }

    public class SaveAndCloseCommand : ICommand
    {
        private readonly UserViewModel _origUser;
        private readonly UserViewModel _newUser;

        public SaveAndCloseCommand(UserViewModel origUser, UserViewModel newUser)
        {
            _origUser = origUser;
            _newUser = newUser;

        }
        public bool CanExecute(object parameter)
        {
            return !Equal();
        }

        private bool Equal()
        {
            return _origUser.Meta == _newUser.Meta
                   && _origUser.Name == _newUser.Name
                   && _origUser.Number == _newUser.Number
                   && _origUser.TagId == _newUser.TagId;
        }
        
        public void Execute(object parameter)
        {
            _origUser.UpdateUser(_newUser);
            CommandDispatcher.Dispatch(new UpdateUser(_origUser.User));
        }

        public event EventHandler CanExecuteChanged;
    }
}