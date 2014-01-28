using System.Reflection;
using System.Windows;
using System.Windows.Media.Animation;
using FirstFloor.ModernUI.Windows.Controls;
using Griffin.Container;

namespace SportsRFIDTimer.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ModernWindow
    {       
        private enum Position
        {
            Left,
            Right
        };

        private Position _position = Position.Left;
                    

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindowContent_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
        {
            if (_position == Position.Left)
            {
                this.BeginStoryboard((Storyboard)this.FindResource("SlideRightAnimation"));
                _position = Position.Right;
            }
            else
            {
                this.BeginStoryboard((Storyboard)this.FindResource("SlideLeftAnimation"));
                _position = Position.Left;
            }
        }
    }
}
