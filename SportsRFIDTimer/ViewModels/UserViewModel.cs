using System;
using Contracts;
using PrismMVVMLibrary;

namespace SportsRFIDTimer.ViewModels
{
    public class UserViewModel : ViewModelBase
    {
        private readonly User _user;

        public UserViewModel(User user)
        {
            _user = user;
        }

        public Guid Id
        {
            get { return _user.Id; }
        }
        public string Name
        {
            get { return _user.Name; }
            set
            {
                _user.Name = value;
                RaisePropertyChanged(() => Name);
            }
        }

        public int Number
        {
            get { return _user.Number; }
            set
            {
                _user.Number = value;
                RaisePropertyChanged(() => Number);
            }
        }

        public String TagId
        {
            get { return _user.TagId; }
            set
            {
                _user.TagId = value;
                RaisePropertyChanged(() => TagId);
            }
        }

        public String Email
        {
            get { return _user.Email; }
            set
            {
                _user.Email = value;
                RaisePropertyChanged(() => Email);
            }
        }

        public String Meta
        {
            get { return _user.Meta; }
            set
            {
                _user.Meta = value;
                RaisePropertyChanged(() => Meta);
            }
        }
    }
}