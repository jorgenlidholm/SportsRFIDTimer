using System;
using Griffin.Logging;
using Microsoft.Practices.Prism.Events;
using PrismMVVMLibrary;
using SportsRFIDTimer.Events;

namespace SportsRFIDTimer.ViewModels
{
    public class DebugUserControlViewModel : ViewModelBase
    {
        private string _debugText = "";
        private readonly ILogger _logger = LogManager.GetLogger<DebugUserControlViewModel>();
        private readonly IEventAggregator _eventAggregator;

        public DebugUserControlViewModel()
        {
            _logger.Debug("Created DebugUserControlViewmodel Instance.");
            _eventAggregator = MessageBus.Instance();
            _eventAggregator.GetEvent<MessageLoggedEvent>().Subscribe(Handle);
        }

        public String DebugText
        {
            get { return _debugText; }
            set
            {
                if (_debugText == value) return;
                _debugText = value;
                RaisePropertyChanged(() => DebugText);
                RaisePropertyChanged(() => CaretIndex);
            }
        }


        public long CaretIndex
        {
            get { return _debugText.Length - 1; }
        }

        public void Handle(MessageLogged message)
        {
            var msg = String.Format("{0}:{1}:{2}", message.DateTime, message.LogLevel, message.Message);
            DebugText = DebugText + Environment.NewLine + msg;
        }
    }
}
