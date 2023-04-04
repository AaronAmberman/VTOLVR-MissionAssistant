using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Threading;
using WPF.Translations;

namespace VTOLVR_MissionAssistant
{
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            #region Culture

            // ensure we have a culture, if not back to English
            if (string.IsNullOrWhiteSpace(VTOLVR_MissionAssistant.Properties.Settings.Default.Culture))
            {
                VTOLVR_MissionAssistant.Properties.Settings.Default.Culture = "en";
                VTOLVR_MissionAssistant.Properties.Settings.Default.Save();
            }

            // set our culture to the current one from settings
            Thread.CurrentThread.CurrentCulture = new CultureInfo(VTOLVR_MissionAssistant.Properties.Settings.Default.Culture);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(VTOLVR_MissionAssistant.Properties.Settings.Default.Culture);

            CultureInfo.DefaultThreadCurrentCulture = new CultureInfo(VTOLVR_MissionAssistant.Properties.Settings.Default.Culture);

            #endregion

            #region Translator

            try
            {
                ResourceDictionaryTranslationDataProvider rdtdp = new ResourceDictionaryTranslationDataProvider();

                Translation keyContract = new Translation(new ResourceDictionary
                {
                    Source = new Uri("pack://application:,,,/Languages/Language.en.xaml")
                }, rdtdp, false);

                // setup our language resources
                Translator<ResourceDictionary> translator = new Translator<ResourceDictionary>
                {
                    KeyContract = keyContract,
                    TranslationDataProvider = rdtdp
                };

                translator.AddResourceForTranslation("en", new ResourceDictionary
                {
                    Source = new Uri("pack://application:,,,/Languages/Language.en.xaml")
                }, false);
                translator.AddResourceForTranslation("ja", new ResourceDictionary
                {
                    Source = new Uri("pack://application:,,,/Languages/Language.ja.xaml")
                }, false);
                translator.AddResourceForTranslation("ko", new ResourceDictionary
                {
                    Source = new Uri("pack://application:,,,/Languages/Language.ko.xaml")
                }, false);
                translator.AddResourceForTranslation("ru", new ResourceDictionary
                {
                    Source = new Uri("pack://application:,,,/Languages/Language.ru.xaml")
                }, false);
                translator.AddResourceForTranslation("zh-Hans", new ResourceDictionary
                {
                    Source = new Uri("pack://application:,,,/Languages/Language.zh-Hans.xaml")
                }, false);

                ServiceLocator.Instance.Translator = translator;
                ServiceLocator.Instance.Translator.CurrentTranslations = translator.Translations[VTOLVR_MissionAssistant.Properties.Settings.Default.Culture];
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred attempting to add a resource dictionary to the translator.{Environment.NewLine}{ex}");

                MessageBox.Show("The translator for the application could be setup properly. Existing application.");

                Environment.Exit(-1);
                return;
            }

            #endregion

            #region VTOL VR

            // check to make sure VTOL is not running
            Process vtol = Process.GetProcesses().FirstOrDefault(p => p.ProcessName == "VTOLVR");

            if (vtol != null)
            {
                MessageBox.Show(ServiceLocator.Instance.Translator.CurrentTranslations.VTOLRunningMessage,
                    ServiceLocator.Instance.Translator.CurrentTranslations.VTOLRunningTitle, MessageBoxButton.OK, MessageBoxImage.Error);

                Environment.Exit(-2);
                return;
            }

            #endregion

            #region Log File

            // ensure we have a custom log path, if not...use application location
            if (string.IsNullOrWhiteSpace(VTOLVR_MissionAssistant.Properties.Settings.Default.LogFile))
            {
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
            else
            {
                // if we are using the user provided value then just read the whole setting as they can specify a custom file name if desired
                ServiceLocator.Instance.Logger.LogFile = VTOLVR_MissionAssistant.Properties.Settings.Default.LogFile;
            }

            #endregion

            ServiceLocator.Instance.Logger.Info(ServiceLocator.Instance.Translator.CurrentTranslations.BeginSession);
        }

        private void Application_DispatcherUnhandledException(object sender, DispatcherUnhandledExceptionEventArgs e)
        {
            e.Handled = true;

            try
            {
                ServiceLocator.Instance.Logger.Error($"An unhandled exception occurred. Details:{Environment.NewLine}{e.Exception}");

                // we don't know what happened, tell the user and carry on
                MessageBox.Show(ServiceLocator.Instance.Translator.CurrentTranslations.UnhandledErrorMessage,
                    ServiceLocator.Instance.Translator.CurrentTranslations.UnhandledErrorTitle, MessageBoxButton.OK, MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred ensuring the log file exists or an error occurred trying to write to the log file.{Environment.NewLine}{ex}");
            }

            //Current.Shutdown(e.Exception.HResult);
        }

        private void Application_Exit(object sender, ExitEventArgs e)
        {
            ServiceLocator.Instance.Logger.Info(ServiceLocator.Instance.Translator.CurrentTranslations.EndSession);
            ServiceLocator.Instance.Translator.Dispose();
        }
    }
}
