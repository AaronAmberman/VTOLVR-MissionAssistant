using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using VTOLVR_MissionAssistant.ViewModels.Vts;
using VTS;
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
        private CollectionView briefingNotes;
        private CollectionViewSource briefingNotesSource;
        private ICommand browseCommand;
        private ICommand browseLogCommand;
        private CollectionView conditionalActions;
        private CollectionViewSource conditionalActionsSource;
        private CollectionView conditionals;
        private CollectionViewSource conditionalsSource;
        private ICommand copyUnitCommand;
        private ICommand copyEnemyUnitCommand;
        private Visibility dataNeededVisibility = Visibility.Collapsed;
        private ObservableCollection<string> errors = new ObservableCollection<string>();
        private CollectionView enemyBases;
        private CollectionViewSource enemyBasesSource;
        private CollectionView enemyUnits;
        private CollectionViewSource enemyUnitsSource;
        private CollectionView eventSequences;
        private CollectionViewSource eventSequencesSource;
        private string fileForData;
        private CollectionView friendlyBases;
        private CollectionViewSource friendlyBasesSource;
        private CollectionView friendlyUnits;
        private CollectionViewSource friendlyUnitsSource;
        private CollectionView globalValues;
        private CollectionViewSource globalValuesSource;
        private MessageBoxViewModel messageBoxViewModel;
        private CollectionView objectives;
        private CollectionViewSource objectivesSource;
        private CollectionView objectivesOpFor;
        private CollectionViewSource objectivesOpForSource;
        private ICommand openCommand;
        private CollectionView paths;
        private CollectionViewSource pathsSource;
        private ICommand reIndexUnitsCommand;
        private ICommand reIndexEnemyUnitsCommand;
        private CollectionView resourceManifest;
        private CollectionViewSource resourceManifestSource;
        private ICommand saveCommand;
        private string searchFilterBrieingNotes;
        private string searchFilterCondtionalActions;
        private string searchFilterConditionals;
        private string searchFilterEnemyBases;
        private string searchFilterEnemyUnits;
        private string searchFilterEventSequences;
        private string searchFilterFriendlyBases;
        private string searchFilterFriendlyUnits;
        private string searchFilterGlobalValues;
        private string searchFilterObjectives;
        private string searchFilterObjectivesOpFor;
        private string searchFilterPaths;
        private string searchFilterResources;
        private string searchFilterStaticObjects;
        private string searchFilterTimedEventGroups;
        private string searchFilterTriggerEvents;
        private string searchFilterWaypoints;
        private SettingsViewModel settingsViewModel;
        private ICommand scenarioInfoCommand;
        private ScenarioInfoViewModel scenarioInfoViewModel;
        private ICommand showSettingsCommand;
        private CollectionView staticObjects;
        private CollectionViewSource staticObjectsSource;
        private CollectionView timedEvents;
        private CollectionViewSource timedEventsSource;
        private CollectionView triggerEvents;
        private CollectionViewSource triggerEventsSource;
        private dynamic translations;
        private string version;
        private CustomScenarioViewModel vtsFile;
        private ObservableCollection<WarningViewModel> warnings = new ObservableCollection<WarningViewModel>();
        private CollectionView waypoints;
        private CollectionViewSource waypointsSource;

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

        public CollectionView BriefingNotes
        {
            get => briefingNotes;
            set
            {
                briefingNotes = value;
                OnPropertyChanged();
            }
        }

        public ICommand BrowseCommand => browseCommand ??= new RelayCommand(Browse);

        public ICommand BrowseLogCommand => browseLogCommand ??= new RelayCommand(BrowseLog);

        public CollectionView ConditionalActions
        {
            get => conditionalActions;
            set
            {
                conditionalActions = value;
                OnPropertyChanged();
            }
        }

        public CollectionView Conditionals
        {
            get => conditionals;
            set
            {
                conditionals = value;
                OnPropertyChanged();
            }
        }

        public ICommand CopyUnitCommand => copyUnitCommand ??= new RelayCommand(CopyUnit);

        public ICommand CopyEnemyUnitCommand => copyEnemyUnitCommand ??= new RelayCommand(CopyEnemyUnit);

        public Visibility DataNeededVisibility
        {
            get => dataNeededVisibility;
            set
            {
                dataNeededVisibility = value;
                OnPropertyChanged();
            }
        }

        public CollectionView EnemyBases
        { 
            get => enemyBases;
            set
            {
                enemyBases = value;
                OnPropertyChanged();
            }
        }

        public CollectionView EnemyUnits
        {
            get => enemyUnits;
            set
            {
                enemyUnits = value;
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

        public CollectionView EventSequences
        {
            get => eventSequences;
            set
            {
                eventSequences = value;
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

        public CollectionView FriendlyBases
        {
            get => friendlyBases;
            set
            {
                friendlyBases = value;
                OnPropertyChanged();
            }
        }

        public CollectionView FriendlyUnits
        {
            get => friendlyUnits;
            set
            {
                friendlyUnits = value;
                OnPropertyChanged();
            }
        }

        public Func<IList> GetSelectedFriendlyUnits { get; set; }

        public Func<IList> GetSelectedEnemyUnits { get; set; }

        public CollectionView GlobalValues
        {
            get => globalValues;
            set
            {
                globalValues = value;
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

        public CollectionView Objectives
        {
            get => objectives;
            set
            {
                objectives = value;
                OnPropertyChanged();
            }
        }

        public CollectionView ObjectivesOpFor
        {
            get => objectivesOpFor;
            set
            {
                objectivesOpFor = value;
                OnPropertyChanged();
            }
        }

        public ICommand OpenCommand => openCommand ??= new RelayCommand(Browse);

        public CollectionView Paths
        {
            get => paths;
            set
            {
                paths = value;
                OnPropertyChanged();
            }
        }

        public ICommand ReIndexUnitsCommand => reIndexUnitsCommand ??= new RelayCommand(ReIndexUnits);

        public ICommand ReIndexEnemyUnitsCommand => reIndexEnemyUnitsCommand ??= new RelayCommand(ReIndexUnits);

        public CollectionView ResourceManifest
        {
            get => resourceManifest;
            set
            {
                resourceManifest = value;
                OnPropertyChanged();
            }
        }

        public ICommand SaveCommand => saveCommand ??= new RelayCommand(Save);

        public ScenarioInfoViewModel ScenarioInfoViewModel
        {
            get => scenarioInfoViewModel;
            set
            {
                scenarioInfoViewModel = value;
                OnPropertyChanged();
            }
        }

        public string SearchFilterBrieingNotes
        {
            get => searchFilterBrieingNotes;
            set
            {
                searchFilterBrieingNotes = value;
                OnPropertyChanged();

                briefingNotes.Refresh();
            }
        }

        public string SearchFilterCondtionalActions
        {
            get => searchFilterCondtionalActions;
            set
            {
                searchFilterCondtionalActions = value;
                OnPropertyChanged();

                conditionalActions.Refresh();
            }
        }

        public string SearchFilterConditionals
        {
            get => searchFilterConditionals;
            set
            {
                searchFilterConditionals = value;
                OnPropertyChanged();

                conditionals.Refresh();
            }
        }

        public string SearchFilterEnemyBases
        {
            get => searchFilterEnemyBases;
            set
            {
                searchFilterEnemyBases = value;
                OnPropertyChanged();

                enemyBases.Refresh();
            }
        }

        public string SearchFilterEnemyUnits
        {
            get => searchFilterEnemyUnits;
            set
            {
                searchFilterEnemyUnits = value;
                OnPropertyChanged();

                enemyUnits.Refresh();
            }
        }

        public string SearchFilterEventSequences
        {
            get => searchFilterEventSequences;
            set
            {
                searchFilterEventSequences = value;
                OnPropertyChanged();

                eventSequences.Refresh();
            }
        }

        public string SearchFilterFriendlyBases
        {
            get => searchFilterFriendlyBases;
            set
            {
                searchFilterFriendlyBases = value;
                OnPropertyChanged();

                friendlyBases.Refresh();
            }
        }

        public string SearchFilterFriendlyUnits
        {
            get => searchFilterFriendlyUnits;
            set
            {
                searchFilterFriendlyUnits = value;
                OnPropertyChanged();

                friendlyUnits.Refresh();
            }
        }

        public string SearchFilterGlobalValues
        {
            get => searchFilterGlobalValues;
            set
            {
                searchFilterGlobalValues = value;
                OnPropertyChanged();

                globalValues.Refresh();
            }
        }

        public string SearchFilterObjectives
        {
            get => searchFilterObjectives;
            set
            {
                searchFilterObjectives = value;
                OnPropertyChanged();

                objectives.Refresh();
            }
        }

        public string SearchFilterObjectivesOpFor
        {
            get => searchFilterObjectivesOpFor;
            set
            {
                searchFilterObjectivesOpFor = value;
                OnPropertyChanged();

                objectivesOpFor.Refresh();
            }
        }

        public string SearchFilterPaths
        {
            get => searchFilterPaths;
            set
            {
                searchFilterPaths = value;
                OnPropertyChanged();

                paths.Refresh();
            }
        }

        public string SearchFilterResources
        {
            get => searchFilterResources;
            set
            {
                searchFilterResources = value;
                OnPropertyChanged();

                resourceManifest.Refresh();
            }
        }

        public string SearchFilterStaticObjects
        {
            get => searchFilterStaticObjects;
            set
            {
                searchFilterStaticObjects = value;
                OnPropertyChanged();

                staticObjects.Refresh();
            }
        }

        public string SearchFilterTimedEventGroups
        {
            get => searchFilterTimedEventGroups;
            set
            {
                searchFilterTimedEventGroups = value;
                OnPropertyChanged();

                timedEvents.Refresh();
            }
        }

        public string SearchFilterTriggerEvents
        {
            get => searchFilterTriggerEvents;
            set
            {
                searchFilterTriggerEvents = value;
                OnPropertyChanged();

                triggerEvents.Refresh();
            }
        }

        public string SearchFilterWaypoints
        {
            get => searchFilterWaypoints;
            set
            {
                searchFilterWaypoints = value;
                OnPropertyChanged();

                waypoints.Refresh();
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

        public CollectionView StaticObjects
        {
            get => staticObjects;
            set
            {
                staticObjects = value;
                OnPropertyChanged();
            }
        }

        public CollectionView TimedEvents
        {
            get => timedEvents;
            set
            {
                timedEvents = value;
                OnPropertyChanged();
            }
        }

        public CollectionView TriggerEvents
        {
            get => triggerEvents;
            set
            {
                triggerEvents = value;
                OnPropertyChanged();
            }
        }

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

        public CustomScenarioViewModel VtsFile
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

        public CollectionView Waypoints
        {
            get => waypoints;
            set
            {
                waypoints = value;
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
            try
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
                    ShowMessageBox(ServiceLocator.Instance.Translator.CurrentTranslations.VtsFileReadErrorMessage,
                        ServiceLocator.Instance.Translator.CurrentTranslations.FileReadErrorTitle, MessageBoxButton.OK, MessageBoxInternalDialogImage.Warning);
                }
                else
                {
                    CustomScenarioViewModel customScenarioViewModel = new CustomScenarioViewModel(scenario);

                    FileForData = file;
                    VtsFile = customScenarioViewModel;
                    DataNeededVisibility = Visibility.Collapsed;

                    // get various view sources so we can see different views of the same data
                    enemyUnitsSource = new CollectionViewSource
                    {
                        Source = customScenarioViewModel.Units
                    };
                    CollectionView enemyView = (CollectionView)enemyUnitsSource.View;
                    enemyView.Filter = EnemyFilter;

                    EnemyUnits = enemyView;

                    friendlyUnitsSource = new CollectionViewSource
                    {
                        Source = customScenarioViewModel.Units
                    };
                    CollectionView friendlyView = (CollectionView)friendlyUnitsSource.View;
                    friendlyView.Filter = FriendlyFilter;

                    FriendlyUnits = friendlyView;

                    enemyBasesSource = new CollectionViewSource
                    {
                        Source = customScenarioViewModel.Bases
                    };
                    CollectionView enemyBaseView = (CollectionView)enemyBasesSource.View;
                    enemyBaseView.Filter = EnemyBaseFilter;

                    EnemyBases = enemyBaseView;

                    friendlyBasesSource = new CollectionViewSource
                    {
                        Source = customScenarioViewModel.Bases
                    };
                    CollectionView friendlyBaseView = (CollectionView)friendlyBasesSource.View;
                    friendlyBaseView.Filter = FriendlyBaseFilter;

                    FriendlyBases = friendlyBaseView;

                    briefingNotesSource = new CollectionViewSource
                    {
                        Source = customScenarioViewModel.BriefingNotes
                    };
                    CollectionView briefingNotesView = (CollectionView)briefingNotesSource.View;
                    briefingNotesView.Filter = BriefingNotesFilter;

                    BriefingNotes = briefingNotesView;

                    conditionalActionsSource = new CollectionViewSource
                    {
                        Source = customScenarioViewModel.ConditionalActions
                    };
                    CollectionView conditionalActionsView = (CollectionView)conditionalActionsSource.View;
                    conditionalActionsView.Filter = ConditionalActionsFilter;

                    ConditionalActions = conditionalActionsView;

                    conditionalsSource = new CollectionViewSource
                    {
                        Source = customScenarioViewModel.Conditionals
                    };
                    CollectionView conditionalsView = (CollectionView)conditionalsSource.View;
                    conditionalsView.Filter = CondtionalsFilter;

                    Conditionals = conditionalsView;

                    eventSequencesSource = new CollectionViewSource
                    {
                        Source = customScenarioViewModel.EventSequences
                    };
                    CollectionView eventSequencesView = (CollectionView)eventSequencesSource.View;
                    eventSequencesView.Filter = EventSequencesFilter;

                    EventSequences = eventSequencesView;

                    globalValuesSource = new CollectionViewSource
                    {
                        Source = customScenarioViewModel.GlobalValues
                    };
                    CollectionView globalValuesView = (CollectionView)globalValuesSource.View;
                    globalValuesView.Filter = GlobalValuesFilter;

                    GlobalValues = globalValuesView;

                    objectivesSource = new CollectionViewSource
                    {
                        Source = customScenarioViewModel.Objectives
                    };
                    CollectionView objectivesView = (CollectionView)objectivesSource.View;
                    objectivesView.Filter = ObjectivesFilter;

                    Objectives = objectivesView;

                    objectivesOpForSource = new CollectionViewSource
                    {
                        Source = customScenarioViewModel.ObjectivesOpFor
                    };
                    CollectionView objectivesOpForView = (CollectionView)objectivesOpForSource.View;
                    objectivesOpForView.Filter = ObjectivesOpForFilter;

                    ObjectivesOpFor = objectivesOpForView;

                    pathsSource = new CollectionViewSource
                    {
                        Source = customScenarioViewModel.Paths
                    };
                    CollectionView pathsView = (CollectionView)pathsSource.View;
                    pathsView.Filter = PathsFilter;

                    Paths = pathsView;

                    resourceManifestSource = new CollectionViewSource
                    {
                        Source = customScenarioViewModel.ResourceManifest
                    };
                    CollectionView resourceManifestView = (CollectionView)resourceManifestSource.View;
                    resourceManifestView.Filter = ResourceManifestFilter;

                    ResourceManifest = resourceManifestView;

                    staticObjectsSource = new CollectionViewSource
                    {
                        Source = customScenarioViewModel.StaticObjects
                    };
                    CollectionView staticObjectsView = (CollectionView)staticObjectsSource.View;
                    staticObjectsView.Filter = StaticObjectsFilter;

                    StaticObjects = staticObjectsView;

                    timedEventsSource = new CollectionViewSource
                    {
                        Source = customScenarioViewModel.TimedEventGroups
                    };
                    CollectionView timedEventsView = (CollectionView)timedEventsSource.View;
                    timedEventsView.Filter = TimedEventsFilter;

                    TimedEvents = timedEventsView;

                    triggerEventsSource = new CollectionViewSource
                    {
                        Source = customScenarioViewModel.TriggerEvents
                    };
                    CollectionView triggerEventsView = (CollectionView)triggerEventsSource.View;
                    triggerEventsView.Filter = TriggerEventsFilter;

                    TriggerEvents = triggerEventsView;

                    waypointsSource = new CollectionViewSource
                    {
                        Source = customScenarioViewModel.Waypoints
                    };
                    CollectionView waypointsView = (CollectionView)waypointsSource.View;
                    waypointsView.Filter = WaypointsFilter;

                    Waypoints = waypointsView;
                }
            }
            catch (Exception ex)
            {
                ServiceLocator.Instance.Logger.Error($"An error occurred attempting to read the VTS file.{ Environment.NewLine}{ex}");

                ShowMessageBox(ServiceLocator.Instance.Translator.CurrentTranslations.VtsFileReadErrorMessage,
                    ServiceLocator.Instance.Translator.CurrentTranslations.FileReadErrorTitle, MessageBoxButton.OK, MessageBoxInternalDialogImage.Warning);
            }
        }

        private bool BriefingNotesFilter(object obj)
        {
            return true;
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

        private bool ConditionalActionsFilter(object obj)
        {
            return true;
        }

        private bool CondtionalsFilter(object obj)
        {
            return true;
        }

        private void CopyEnemyUnit()
        {
            List<UnitSpawnerViewModel> selectedUnits = GetSelectedEnemyUnits().OfType<UnitSpawnerViewModel>().ToList();

            CopyUnits(selectedUnits);
        }

        private void CopyUnit()
        {
            List<UnitSpawnerViewModel> selectedUnits = GetSelectedFriendlyUnits().OfType<UnitSpawnerViewModel>().ToList();

            CopyUnits(selectedUnits);
        }

        private void CopyUnits(List<UnitSpawnerViewModel> units)
        {
            if (units.Count == 0)
            {
                ShowMessageBox(Translations.MissingSelectionMessage, Translations.MissingSelection, MessageBoxInternalDialogImage.Warning);

                return;
            }
        }

        private bool EnemyBaseFilter(object obj)
        {
            BaseInfoViewModel @base = obj as BaseInfoViewModel;

            if (@base == null) return false;
            if (@base.BaseTeam == KeywordStrings.EnemyUnitGroup) return true;

            return false;
        }

        private bool EnemyFilter(object obj)
        {
            UnitSpawnerViewModel unit = obj as UnitSpawnerViewModel;

            if (unit == null) return false;
            if (KeywordStrings.EnemyUnitTypes.Contains(unit.UnitId))
            {
                if (string.IsNullOrWhiteSpace(SearchFilterEnemyUnits)) return true;
                if (unit.UnitName.Contains(SearchFilterEnemyUnits, StringComparison.OrdinalIgnoreCase)) return true;

                return false;
            }

            return false;
        }

        private bool EventSequencesFilter(object obj)
        {
            return true;
        }

        private bool FriendlyBaseFilter(object obj)
        {
            BaseInfoViewModel @base = obj as BaseInfoViewModel;

            if (@base == null) return false;
            if (@base.BaseTeam == KeywordStrings.AlliedUnitGroup) return true;

            return false;
        }

        private bool FriendlyFilter(object obj)
        {
            UnitSpawnerViewModel unit = obj as UnitSpawnerViewModel;

            if (unit == null) return false;
            if (!KeywordStrings.EnemyUnitTypes.Contains(unit.UnitId))
            {
                if (string.IsNullOrWhiteSpace(SearchFilterFriendlyUnits)) return true;
                if (unit.UnitName.Contains(SearchFilterFriendlyUnits, StringComparison.OrdinalIgnoreCase)) return true;

                return false;
            }

            return false;
        }

        private bool GlobalValuesFilter(object obj)
        {
            return true;
        }

        private void Logger_LogWriteError(object sender, EventArgs e)
        {
            ShowMessageBox(ServiceLocator.Instance.Translator.CurrentTranslations.LogWriteErrorMessage, ServiceLocator.Instance.Translator.CurrentTranslations.LogWriteErrorTitle, MessageBoxButton.OK, MessageBoxInternalDialogImage.CriticalError);
        }

        private bool ObjectivesFilter(object obj)
        {
            return true;
        }

        private bool ObjectivesOpForFilter(object obj)
        {
            return true;
        }

        private bool PathsFilter(object obj)
        {
            return true;
        }

        private void ReIndexUnits()
        {
            MessageBoxResult result = ShowQuestionBox(Translations.ReindexUnitsWarning, Translations.ConfirmReindex);

            if (result == MessageBoxResult.No) return;


        }

        private bool ResourceManifestFilter(object obj)
        {
            return true;
        }

        private void Save()
        {

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

        public void ShowMessageBox(string message, string title, MessageBoxInternalDialogImage image)
        {
            SetMessageBoxState(message, title, true, MessageBoxButton.OK, image, Visibility.Visible);
        }

        public void ShowMessageBox(string message, string title, MessageBoxButton button, MessageBoxInternalDialogImage image)
        {
            SetMessageBoxState(message, title, true, button, image, Visibility.Visible);
        }

        private MessageBoxResult ShowQuestionBox(string question, string title)
        {
            MessageBoxViewModel.MessageBoxMessage = question;
            MessageBoxViewModel.MessageBoxTitle = title;
            MessageBoxViewModel.MessageBoxIsModal = true;
            MessageBoxViewModel.MessageBoxButton = MessageBoxButton.YesNo;
            MessageBoxViewModel.MessageBoxImage = MessageBoxInternalDialogImage.Help;
            MessageBoxViewModel.MessageBoxVisibility = Visibility.Visible; // this will block because of is modal

            return MessageBoxViewModel.MessageBoxResult;
        }

        private void ShowScenarioInfo()
        {
            ScenarioInfoViewModel.Visibility = Visibility.Visible;
        }

        private void ShowSettings()
        {
            SettingsViewModel.Visibility = Visibility.Visible;
        }

        private bool StaticObjectsFilter(object obj)
        {
            return true;
        }

        private bool TimedEventsFilter(object obj)
        {
            return true;
        }

        private bool TriggerEventsFilter(object obj)
        {
            return true;
        }

        private bool WaypointsFilter(object obj)
        {
            return true;
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
