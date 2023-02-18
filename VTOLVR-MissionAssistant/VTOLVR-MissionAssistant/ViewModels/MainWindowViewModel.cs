using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Input;
using VTS.Data.Runtime;
using WPF.InternalDialogs;

namespace VTOLVR_MissionAssistant.ViewModels
{
    /// <summary>The view model for the main window.</summary>
    public class MainWindowViewModel : ViewModelBase
    {
        #region Fields

        private ICommand aboutCommand;
        private Visibility aboutBoxVisibility = Visibility.Collapsed;
        private ICommand browseCommand;
        private ICommand browseLogCommand;
        private Visibility dataNeededVisibility = Visibility.Collapsed;
        private string fileForData;
        private MessageBoxViewModel messageBoxViewModel;
        private SettingsViewModel settingsViewModel;
        private ICommand showSettingsCommand;
        private dynamic translations;
        private string version;
        private CustomScenario vtsFile;

        #endregion

        #region Properties

        public ICommand AboutCommand => aboutCommand ??= new RelayCommand(About);

        public Visibility AboutBoxVisibility
        {
            get => aboutBoxVisibility;
            set
            {
                aboutBoxVisibility = value;
                OnPropertyChanged();
            }
        }

        public ICommand BrowseCommand => browseCommand ??= new RelayCommand(Browse);

        public ICommand BrowseLogCommand => browseLogCommand ??= new RelayCommand(BrowseLog);

        public Visibility DataNeededVisibility
        {
            get => dataNeededVisibility;
            set
            {
                dataNeededVisibility = value;
                OnPropertyChanged();
            }
        }

        public string FileForData
        {
            get => fileForData;
            set
            {
                fileForData = value;
                OnPropertyChanged();
            }
        }

        public MessageBoxViewModel MessageBoxViewModel
        {
            get { return messageBoxViewModel; }
            set
            {
                messageBoxViewModel = value;
                OnPropertyChanged();
            }
        }

        public SettingsViewModel SettingsViewModel
        {
            get { return settingsViewModel; }
            set
            {
                settingsViewModel = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowSettingsCommand => showSettingsCommand ??= new RelayCommand(ShowSettings);

        public dynamic Translations
        {
            get => translations;
            set
            {
                translations = value;
                OnPropertyChanged();
            }
        }

        public string Version
        {
            get => version;
            set
            {
                version = value;
                OnPropertyChanged();
            }
        }

        public CustomScenario VtsFile
        {
            get => vtsFile;
            set
            {
                vtsFile = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Constructors

        public MainWindowViewModel()
        {
            ServiceLocator.Instance.Logger.LogWriteError += Logger_LogWriteError;
        }

        #endregion

        #region Methods

        private void About()
        {
            AboutBoxVisibility = Visibility.Visible;
        }

        private void Browse()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                AddExtension = true,
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "VTS Files(*.vts)|*.vts",
                InitialDirectory = @"C:\Program Files (x86)\Steam\steamapps\common\VTOL VR\CustomScenarios",
                Multiselect = false,
                Title = ServiceLocator.Instance.Translator.CurrentTranslations.BrowseTitle,
                ValidateNames = true
            };

            bool? result = ofd.ShowDialog();

            if (!result.HasValue) return;
            if (!result.Value) return;

            string file = ofd.FileName;

            CustomScenario scenario = new CustomScenario(file, WriteVtsApiWarnings);

            if (scenario.HasError)
            {
                ShowMessageBox(ServiceLocator.Instance.Translator.CurrentTranslations.VtsFileReadErrorMessage, ServiceLocator.Instance.Translator.CurrentTranslations.FileReadErrorTitle, MessageBoxButton.OK, MessageBoxInternalDialogImage.Warning);
            }
            else
            {
                FileForData = file;
                VtsFile = scenario;
                DataNeededVisibility = Visibility.Collapsed;
            }
        }

        private void BrowseLog()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                AddExtension = true,
                CheckFileExists = true,
                CheckPathExists = true,
                Filter = "Text Files(*.txt)|*.txt|Log Files(*.log)|*.log",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
                Multiselect = false,
                Title = ServiceLocator.Instance.Translator.CurrentTranslations.BrowseTitle,
                ValidateNames = true
            };

            bool? result = ofd.ShowDialog();

            if (!result.HasValue) return;
            if (!result.Value) return;

            string file = ofd.FileName;

            SettingsViewModel.LogFile = file;
        }

        private void Logger_LogWriteError(object sender, EventArgs e)
        {
            ShowMessageBox(ServiceLocator.Instance.Translator.CurrentTranslations.LogWriteErrorMessage, ServiceLocator.Instance.Translator.CurrentTranslations.LogWriteErrorTitle, MessageBoxButton.OK, MessageBoxInternalDialogImage.CriticalError);
        }

        public void ShowMessageBox(string message)
        {
            SetMessageBoxState(message, string.Empty, true, MessageBoxButton.OK, MessageBoxInternalDialogImage.Information, Visibility.Visible);
        }

        public void ShowMessageBox(string message, string title)
        {
            SetMessageBoxState(message, title, true, MessageBoxButton.OK, MessageBoxInternalDialogImage.Information, Visibility.Visible);
        }

        public void ShowMessageBox(string message, string title, MessageBoxButton button)
        {
            SetMessageBoxState(message, title, true, button, MessageBoxInternalDialogImage.Information, Visibility.Visible);
        }

        public void ShowMessageBox(string message, string title, MessageBoxButton button, MessageBoxInternalDialogImage image)
        {
            SetMessageBoxState(message, title, true, button, image, Visibility.Visible);
        }

        private void SetMessageBoxState(string message, string title, bool isModal, MessageBoxButton button, MessageBoxInternalDialogImage image, Visibility visibility)
        {
            MessageBoxViewModel.MessageBoxMessage = message;
            MessageBoxViewModel.MessageBoxTitle = title;
            MessageBoxViewModel.MessageBoxIsModal = isModal;
            MessageBoxViewModel.MessageBoxButton = button;
            MessageBoxViewModel.MessageBoxImage = image;
            MessageBoxViewModel.MessageBoxVisibility = visibility;
        }

        private void ShowSettings()
        {
            SettingsViewModel.Visibility = Visibility.Visible;
        }

        private void WriteVtsApiWarnings(string message)
        {
            Debug.WriteLine(message);

            if (message.Contains("error", StringComparison.OrdinalIgnoreCase) || message.Contains("exception", StringComparison.OrdinalIgnoreCase))
                ServiceLocator.Instance.Logger.Error(message);
            else
                ServiceLocator.Instance.Logger.Warning(message);
        }

        #endregion
    }
}
