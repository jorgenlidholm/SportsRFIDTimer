using System.Windows;
using System.Windows.Controls;
using SportsRFIDTimer.UserControls;

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

        public DialogWindow(string title, DialogUserControlBase userControl)
        {
            InitializeComponent();

            Title = title;
            Content = userControl;
            Width = userControl.Width+25;
            Height = userControl.Height+40;

            userControl.CloseEvent += CloseWindow;
        }
        public void CloseWindow(object sender)
        {
            Close();
        }
    }
}
