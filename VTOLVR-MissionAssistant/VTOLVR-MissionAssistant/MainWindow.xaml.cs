using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows;
using VTOLVR_MissionAssistant.ViewModels;

namespace VTOLVR_MissionAssistant
{
    public partial class MainWindow : Window
    {
        #region Constructors

        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string ver = string.Empty;

            try
            {
                ver = Assembly.GetExecutingAssembly()?.GetName()?.Version?.ToString();
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred attempting to get the version information.{Environment.NewLine}{ex}");
                ServiceLocator.Instance.Logger.Error($"An error occurred attempting to get the version information.{Environment.NewLine}{ex}");

                ver = "Unable to retrieve version information.";
            }

            MainWindowViewModel viewModel = new MainWindowViewModel
            {
                DataNeededVisibility = Visibility.Visible, // show data needed control right away
                GetSelectedEnemyBases = () => { return enemyBases.SelectedItems; },
                GetSelectedEnemyUnits = () => { return enemyUnits.SelectedItems; },
                GetSelectedEventSequences = () => { return eventSequences.SelectedItems; },
                GetSelectedFriendlyBases = () => { return friendlyBases.SelectedItems; },
                GetSelectedFriendlyUnits = () => { return friendlyUnits.SelectedItems; },
                GetSelectedObjectives = () => { return objectives.SelectedItems; },
                GetSelectedObjectivesOpFor = () => { return objectivesOpFor.SelectedItems; },
                GetSelectedPaths = () => { return paths.SelectedItems; },
                GetSelectedStaticObjects = () => { return staticObjects.SelectedItems; },
                GetSelectedTimedEvents = () => { return timedEvents.SelectedItems; },
                GetSelectedTriggeredEvents = () => { return triggerEvents.SelectedItems; },
                GetSelectedWaypoints = () => { return waypoints.SelectedItems; },
                MessageBoxViewModel = new MessageBoxViewModel(),
                ScenarioInfoViewModel = new ScenarioInfoViewModel(),
                SettingsViewModel = new SettingsViewModel
                {
                    FocusLogFileTextBoxAction = logFileTextBox.Focus,
                    LogFile = Properties.Settings.Default.LogFile,
                },
                Translations = ServiceLocator.Instance.Translator.CurrentTranslations,
                Version = ver,
            };

            if (Properties.Settings.Default.Culture == "en")
            {
                viewModel.SettingsViewModel.SelectedLanguage = viewModel.SettingsViewModel.Languages[0];
            }
            else if (Properties.Settings.Default.Culture == "zh-Hans")
            {
                viewModel.SettingsViewModel.SelectedLanguage = viewModel.SettingsViewModel.Languages[1];
            }
            else if (Properties.Settings.Default.Culture == "ja")
            {
                viewModel.SettingsViewModel.SelectedLanguage = viewModel.SettingsViewModel.Languages[2];
            }
            else if (Properties.Settings.Default.Culture == "ko")
            {
                viewModel.SettingsViewModel.SelectedLanguage = viewModel.SettingsViewModel.Languages[3];
            }
            else if (Properties.Settings.Default.Culture == "ru")
            {
                viewModel.SettingsViewModel.SelectedLanguage = viewModel.SettingsViewModel.Languages[4];
            }

            DataContext = viewModel;

            ServiceLocator.Instance.MainWindowViewModel = viewModel;

            // gets our focus in the "popup" so the controls it covers can't be interacted with via the keyboard
            browseForFile.Focus();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void Window_Closed(object sender, EventArgs e)
        {

        }

        #endregion
    }
}
