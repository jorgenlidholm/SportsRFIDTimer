using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using SportsRFIDTimer.ViewModels;

namespace SportsRFIDTimer.UserControls
{
    /// <summary>
    /// Interaction logic for EditUserUserControlViewModel.xaml
    /// </summary>
    public partial class EditUserUserControl : DialogUserControlBase
    {
        private readonly EditUserUserControlViewModel _viewModel;

        public EditUserUserControl()
        {
            InitializeComponent();
        }

        public EditUserUserControl(UserViewModel userViewModel)
        {
            InitializeComponent();
            _viewModel = new EditUserUserControlViewModel(userViewModel);
            DataContext = _viewModel;
        }
    }
}
