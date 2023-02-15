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
                MessageBoxViewModel = new MessageBoxViewModel(),
                SettingsViewModel = new SettingsViewModel
                {
                    FocusLogFileTextBoxAction = logFileTextBox.Focus,
                    LogFile = Properties.Settings.Default.LogFile,
                },
                Version = ver,
            };

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
