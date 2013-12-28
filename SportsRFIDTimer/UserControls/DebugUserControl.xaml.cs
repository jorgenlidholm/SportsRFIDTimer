using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Windows;
using System.Windows.Controls;
using Griffin.Decoupled.DomainEvents;
using SportsRFIDTimer.Domain.Events;

namespace SportsRFIDTimer.UserControls
{
    /// <summary>
    /// Interaction logic for DebugUserControl.xaml
    /// </summary>
    public partial class DebugUserControl : UserControl
    {
        public DebugUserControl()
        {
            InitializeComponent();
            DebugTextBox.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
        }

        public string DebugText
        {
            get { return DebugTextBox.Text; }
            set { DebugTextBox.Text = value; }
        }

        private void TagRegisteredEvent_OnClick(object sender, RoutedEventArgs e)
        {
            var tagRegistered = new TagRegistered("123-ABC-456", DateTime.Now);
            DomainEvent.Publish(tagRegistered);
        }

        private void DebugTextBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            DebugTextBox.ScrollToEnd();
        }
    }
}
