using System.Windows;
using System.Windows.Controls;

namespace SportsRFIDTimer.UserControls
{
    /// <summary>
    /// Interaction logic for AboutUserControl.xaml
    /// </summary>
    public partial class AboutUserControl : DialogUserControlBase
    {

        public AboutUserControl()
        {
            InitializeComponent();
        }

        private void Close_OnClick(object sender, RoutedEventArgs e)
        {
            base.OnCloseWindow();
        }
    }
}
