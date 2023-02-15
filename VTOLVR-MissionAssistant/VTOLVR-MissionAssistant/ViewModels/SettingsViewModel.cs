using System;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Input;
using WPF.InternalDialogs;

namespace VTOLVR_MissionAssistant.ViewModels
{
    public class SettingsViewModel : ViewModelBase
    {
        #region Fields

        private ICommand cancelCommand;
        private string logFile;
        private ICommand okCommand;
        private MessageBoxResult result;
        private Visibility visibility = Visibility.Collapsed;

        #endregion

        #region Properties

        public ICommand CancelCommand => cancelCommand ??= new RelayCommand(Cancel);

        public Func<bool> FocusLogFileTextBoxAction { get; set; }

        public string LogFile
        {
            get => logFile;
            set
            {
                logFile = value;
                OnPropertyChanged();
            }
        }

        public ICommand OkCommand => okCommand ??= new RelayCommand(Ok);

        public MessageBoxResult Result
        {
            get => result;
            set
            {
                result = value;
                OnPropertyChanged();
            }
        }

        public Visibility Visibility
        {
            get => visibility;
            set
            {
                visibility = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Methods

        private void Cancel()
        {
            LogFile = Properties.Settings.Default.LogFile;

            Result = MessageBoxResult.Cancel;
            Visibility = Visibility.Collapsed;
        }

        private void Ok()
        {
            if (!string.IsNullOrWhiteSpace(LogFile))
            {
                if (!File.Exists(LogFile))
                {
                    ServiceLocator.Instance.MainWindowViewModel.ShowMessageBox(Properties.Strings.LogFileNotExistsMessage,
                        Properties.Strings.LogFileNotExistsTitle, MessageBoxButton.OK, MessageBoxInternalDialogImage.CriticalError);

                    FocusLogFileTextBoxAction?.Invoke();

                    return;
                }

                ServiceLocator.Instance.Logger.LogFile = LogFile;
            }
            else
            {
                // null, empty or white-space, ensure our log file like we did in app startup
                try
                {
                    string location = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

                    if (!string.IsNullOrWhiteSpace(location))
                    {
                        // do not set the setting because the user did not choose the path
                        ServiceLocator.Instance.Logger.LogFile = Path.Combine(location, "VTOLVR Mission Assistant.log");
                    }
                }
                catch
                {
                    // we cannot determine location for some reason, use desktop
                    ServiceLocator.Instance.Logger.LogFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "VTOLVR Mission Assistant.log");
                }
            }

            // allow the setting to take the entered path or null but not bad input
            Properties.Settings.Default.LogFile = LogFile;
            Properties.Settings.Default.Save();

            Result = MessageBoxResult.OK;
            Visibility = Visibility.Collapsed;
        }

        #endregion
    }
}
