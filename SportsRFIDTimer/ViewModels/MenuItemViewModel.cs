using System;
using System.Windows.Input;
using Griffin.Logging;
using PrismMVVMLibrary;

namespace SportsRFIDTimer.ViewModels
{
    public class MenuItemViewModel : ViewModelBase
    {
        private readonly ILogger _logger = LogManager.GetLogger<MenuItemViewModel>();
        public string Name { get; set; }
        public bool IsChecked { get; set; }
        public bool IsCheckable { get; set; }
        public ICommand ActivateCommand { get; set; }
    }
}