using System.Collections.Generic;
using System.Collections.ObjectModel;
using Contracts;
using PrismMVVMLibrary;

namespace SportsRFIDTimer.ViewModels
{
    public class ManageUsersUserControlViewModel : ViewModelBase
    {
        private ObservableCollection<UserViewModel> _users;

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

    }
}