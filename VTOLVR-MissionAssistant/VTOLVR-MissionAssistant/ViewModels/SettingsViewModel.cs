using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Reflection;
using System.Threading;
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
        private Tuple<string, string> selectedLanguage;
        private Visibility visibility = Visibility.Collapsed;

        #endregion

        #region Properties

        public ICommand CancelCommand => cancelCommand ??= new RelayCommand(Cancel);

        public Func<bool> FocusLogFileTextBoxAction { get; set; }

        public List<Tuple<string, string>> Languages { get; set; } = new List<Tuple<string, string>>
        {
            new Tuple<string, string>("en", ServiceLocator.Instance.Translator.CurrentTranslations.English),
            new Tuple<string, string>("zh-Hans", ServiceLocator.Instance.Translator.CurrentTranslations.Chinese), //Chinese (Simplified)
            new Tuple<string, string>("ja", ServiceLocator.Instance.Translator.CurrentTranslations.Japanese),
            new Tuple<string, string>("ko", ServiceLocator.Instance.Translator.CurrentTranslations.Korean),
            new Tuple<string, string>("ru", ServiceLocator.Instance.Translator.CurrentTranslations.Russian)
        };

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

        public Tuple<string, string> SelectedLanguage
        {
            get => selectedLanguage;
            set
            {
                selectedLanguage = value;
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
            ProcessLanguage();
            ProcessLogFile();

            Result = MessageBoxResult.OK;
            Visibility = Visibility.Collapsed;
        }

        private void ProcessLanguage()
        {
            if (SelectedLanguage.Item1 != Properties.Settings.Default.Culture)
            {
                Properties.Settings.Default.Culture = SelectedLanguage.Item1;
                Properties.Settings.Default.Save();

                Thread.CurrentThread.CurrentCulture = new CultureInfo(SelectedLanguage.Item1);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(SelectedLanguage.Item1);

                CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(Properties.Settings.Default.Culture);

                ServiceLocator.Instance.Translator.CurrentTranslations = ServiceLocator.Instance.Translator.Translations[Properties.Settings.Default.Culture];
                ServiceLocator.Instance.MainWindowViewModel.Translations = ServiceLocator.Instance.Translator.CurrentTranslations;
            }
        }

        private void ProcessLogFile()
        {
            if (!string.IsNullOrWhiteSpace(LogFile))
            {
                if (!File.Exists(LogFile))
                {
                    ServiceLocator.Instance.MainWindowViewModel.ShowMessageBox(ServiceLocator.Instance.Translator.CurrentTranslations.LogFileNotExistsMessage,
                        ServiceLocator.Instance.Translator.CurrentTranslations.LogFileNotExistsTitle, MessageBoxButton.OK, MessageBoxInternalDialogImage.CriticalError);

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
        }

        #endregion
    }
}
