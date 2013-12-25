using System.Windows;
using System.Windows.Controls;

namespace SportsRFIDTimer.Views
{
    /// <summary>
    /// Interaction logic for DialogWindow.xaml
    /// </summary>
    public partial class DialogWindow : Window
    {
        public DialogWindow()
        {
            InitializeComponent();
        }

        public DialogWindow(string title, UserControl userControl)
        {
            InitializeComponent();

            Title = title;
            Content = userControl;
            Width = userControl.Width+25;
            Height = userControl.Height+40;
        }

    }
}
