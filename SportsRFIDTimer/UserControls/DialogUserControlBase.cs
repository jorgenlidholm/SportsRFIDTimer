
using System;
using System.Windows;
using System.Windows.Controls;
using Griffin.Logging;

namespace SportsRFIDTimer.UserControls
{
    public delegate void CloseWindowDelegate(object sender);

    public class DialogUserControlBase : UserControl
    {
        private static ILogger _logger = LogManager.GetLogger<DialogUserControlBase>();
        public event CloseWindowDelegate CloseEvent;

        protected virtual void OnCloseWindow()
        {
            if (CloseEvent != null)
            {
                _logger.Info("Closing window of {0}", this.GetType().ToString());
                CloseEvent(this);
            }
        }
    }
}
