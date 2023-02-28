using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using VTOLVR_MissionAssistant.ViewModels.Vts;
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
        private ObservableCollection<string> errors = new ObservableCollection<string>();
        private string fileForData;
        private MessageBoxViewModel messageBoxViewModel;
        private SettingsViewModel settingsViewModel;
        private ICommand scenarioInfoCommand;
        private ScenarioInfoViewModel scenarioInfoViewModel;
        private ICommand showSettingsCommand;
        private dynamic translations;
        private string version;
        private CustomScenario vtsFile;
        private ObservableCollection<WarningViewModel> warnings = new ObservableCollection<WarningViewModel>();

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

        public ObservableCollection<string> Errors 
        { 
            get => errors;
            set
            {
                errors = value;
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

        public ScenarioInfoViewModel ScenarioInfoViewModel
        {
            get => scenarioInfoViewModel;
            set
            {
                scenarioInfoViewModel = value;
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

        public ICommand ScenarioInfoCommand => scenarioInfoCommand ??= new RelayCommand(ShowScenarioInfo);

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

        public ObservableCollection<WarningViewModel> Warnings
        {
            get => warnings;
            set
            {
                warnings = value;
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

            CustomScenarioViewModel customScenarioViewModel = new CustomScenarioViewModel(scenario);

            if (scenario.HasError)
            {
                ShowMessageBox(ServiceLocator.Instance.Translator.CurrentTranslations.VtsFileReadErrorMessage, 
                    ServiceLocator.Instance.Translator.CurrentTranslations.FileReadErrorTitle, MessageBoxButton.OK, MessageBoxInternalDialogImage.Warning);
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

        private void ShowScenarioInfo()
        {
            ScenarioInfoViewModel.Visibility = Visibility.Visible;
        }

        private void ShowSettings()
        {
            SettingsViewModel.Visibility = Visibility.Visible;
        }

        private void WriteVtsApiWarnings(string message)
        {
            Debug.WriteLine(message);

            if (message.Contains("error", StringComparison.OrdinalIgnoreCase) || message.Contains("exception", StringComparison.OrdinalIgnoreCase))
            {
                ServiceLocator.Instance.Logger.Error(message);

                Errors.Add(message);
            }
            else
            {
                ServiceLocator.Instance.Logger.Warning(message);

                WarningViewModel warningViewModel = new WarningViewModel();

                if (message.StartsWith("VTS.Data.Runtime.CustomScenario", StringComparison.OrdinalIgnoreCase))
                {
                    warningViewModel.Type = "VTS.Data.Runtime.CustomScenario";

                    string temp = message.Replace("VTS.Data.Runtime.CustomScenario", "");

                    int index = temp.IndexOf(':');

                    if (index >= 0)
                    {
                        warningViewModel.SubType = temp[..index].Trim();
                        warningViewModel.Message = temp[(index + 1)..].Trim();

                    }
                }

                List<WarningViewModel> preSort = Warnings.ToList();
                preSort.Add(warningViewModel);

                preSort = preSort.OrderBy(x => x.Type).ThenBy(x => x.SubType).ToList();

                Warnings.Clear();
                Warnings.AddRange(preSort);
            }
        }

        #endregion
    }
}
