using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using VTOLVR_MissionAssistant.Collections;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    [DebuggerDisplay("VTS File:{File} (HasError:{HasError})")]
    public class CustomScenarioViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private VTS.Data.Runtime.CustomScenario customScenario;

        private string file;
        private bool hasError;

        private string allowedEquips;
        private int baseBudget;
        private string campaignId;
        private int campaignOrderIndex;
        private string environmentName;
        private bool equipsConfigurable;
        private bool forceEquips;
        private string forcedEquips;
        private float fuelDrainMultiplier;
        private string gameVersion;
        private bool infiniteAmmo;
        private float infiniteAmmoReloadDelay;
        private bool isTraining;
        private string mapId;
        private bool multiplayer;
        private float normalForcedFuel;
        private int quickSaveLimit;
        private string quickSaveMode;
        private object refuelWaypoint;
        private object returnToBaseWaypoint;
        private string scenarioId;
        private string scenarioName;
        private string scenarioDescription;
        private bool selectableEnvironment;
        private string vehicle;
        private ObservableCollection<BaseInfoViewModel> bases = new ObservableCollection<BaseInfoViewModel>();
        private ObservableCollection<BriefingNoteViewModel> briefingNotes = new ObservableCollection<BriefingNoteViewModel>();
        private ObservableCollection<ConditionalActionViewModel> conditionalActions = new ObservableCollection<ConditionalActionViewModel>();
        private ObservableCollection<ConditionalViewModel> conditionals = new ObservableCollection<ConditionalViewModel>();
        private ObservableCollection<SequenceViewModel> eventSequences = new ObservableCollection<SequenceViewModel>();
        private ObservableCollection<GlobalValueViewModel> globalValues = new ObservableCollection<GlobalValueViewModel>();
        private ObservableCollection<ObjectiveViewModel> objectives = new ObservableCollection<ObjectiveViewModel>();
        private ObservableCollection<ObjectiveViewModel> objectivesOpFor = new ObservableCollection<ObjectiveViewModel>();
        private ObservableCollection<PathViewModel> paths = new ObservableCollection<PathViewModel>();
        private ObservableCollection<ResourceViewModel> resourceManifest = new ObservableCollection<ResourceViewModel>();
        private ObservableCollection<StaticObjectViewModel> staticObjects = new ObservableCollection<StaticObjectViewModel>();
        private ObservableCollection<TimedEventGroupViewModel> timedEventGroups = new ObservableCollection<TimedEventGroupViewModel>();
        private ObservableCollection<TriggerEventViewModel> triggerEvents = new ObservableCollection<TriggerEventViewModel>();
        private ObservableCollection<UnitGroupViewModel> unitGroups = new ObservableCollection<UnitGroupViewModel>();
        private ObservableCollection<UnitSpawnerViewModel> units = new ObservableCollection<UnitSpawnerViewModel>();
        private ObservablePropertyedCollection<WaypointViewModel> waypoints = new ObservablePropertyedCollection<WaypointViewModel>();

        #endregion

        #region Properties

        public string File
        {
            get => file;
            set
            {
                file = value;
                OnPropertyChanged();
            }
        }

        public bool HasError
        {
            get => hasError;
            set
            {
                hasError = value;
                OnPropertyChanged();
            }
        }

        public string AllowedEquips
        {
            get => allowedEquips;
            set
            {
                allowedEquips = value;
                OnPropertyChanged();
            }
        }

        public int BaseBudget
        {
            get => baseBudget;
            set
            {
                baseBudget = value;
                OnPropertyChanged();
            }
        }

        public string CampaignId
        {
            get => campaignId;
            set
            {
                campaignId = value;
                OnPropertyChanged();
            }
        }

        public int CampaignOrderIndex
        {
            get => campaignOrderIndex;
            set
            {
                campaignOrderIndex = value;
                OnPropertyChanged();
            }
        }

        public string EnvironmentName
        {
            get => environmentName;
            set
            {
                environmentName = value;
                OnPropertyChanged();
            }
        }

        public bool EquipsConfigurable
        {
            get => equipsConfigurable;
            set
            {
                equipsConfigurable = value;
                OnPropertyChanged();
            }
        }

        public bool ForceEquips
        {
            get => forceEquips;
            set
            {
                forceEquips = value;
                OnPropertyChanged();
            }
        }

        public string ForcedEquips
        {
            get => forcedEquips;
            set
            {
                forcedEquips = value;
                OnPropertyChanged();
            }
        }

        public float FuelDrainMultiplier
        {
            get => fuelDrainMultiplier;
            set
            {
                fuelDrainMultiplier = value;
                OnPropertyChanged();
            }
        }

        public string GameVersion
        {
            get => gameVersion;
            set
            {
                gameVersion = value;
                OnPropertyChanged();
            }
        }

        public bool InfiniteAmmo
        {
            get => infiniteAmmo;
            set
            {
                infiniteAmmo = value;
                OnPropertyChanged();
            }
        }

        public float InfiniteAmmoReloadDelay
        {
            get => infiniteAmmoReloadDelay;
            set
            {
                infiniteAmmoReloadDelay = value;
                OnPropertyChanged();
            }
        }

        public bool IsTraining
        {
            get => isTraining;
            set
            {
                isTraining = value;
                OnPropertyChanged();
            }
        }

        public string MapId
        {
            get => mapId; set
            {
                mapId = value;
                OnPropertyChanged();
            }
        }

        public bool Multiplayer
        {
            get => multiplayer;
            set
            {
                multiplayer = value;
                OnPropertyChanged();
            }
        }

        public float NormalForcedFuel
        {
            get => normalForcedFuel;
            set
            {
                normalForcedFuel = value;
                OnPropertyChanged();
            }
        }

        public int QuickSaveLimit
        {
            get => quickSaveLimit;
            set
            {
                quickSaveLimit = value;
                OnPropertyChanged();
            }
        }

        public string QuickSaveMode
        {
            get => quickSaveMode;
            set
            {
                quickSaveMode = value;
                OnPropertyChanged();
            }
        }

        public object RefuelWaypoint
        {
            get => refuelWaypoint;
            set
            {
                refuelWaypoint = value;
                OnPropertyChanged();
            }
        }

        public object ReturnToBaseWaypoint
        {
            get => returnToBaseWaypoint;
            set
            {
                returnToBaseWaypoint = value;
                OnPropertyChanged();
            }
        }

        public string ScenarioId
        {
            get => scenarioId;
            set
            {
                scenarioId = value;
                OnPropertyChanged();
            }
        }

        public string ScenarioName
        {
            get => scenarioName;
            set
            {
                scenarioName = value;
                OnPropertyChanged();
            }
        }

        public string ScenarioDescription
        {
            get => scenarioDescription;
            set
            {
                scenarioDescription = value;
                OnPropertyChanged();
            }
        }

        public bool SelectableEnvironment
        {
            get => selectableEnvironment;
            set
            {
                selectableEnvironment = value;
                OnPropertyChanged();
            }
        }

        public string Vehicle
        {
            get => vehicle;
            set
            {
                vehicle = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<BaseInfoViewModel> Bases
        {
            get => bases;
            set
            {
                bases = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<BriefingNoteViewModel> BriefingNotes
        {
            get => briefingNotes;
            set
            {
                briefingNotes = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ConditionalActionViewModel> ConditionalActions
        {
            get => conditionalActions;
            set
            {
                conditionalActions = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ConditionalViewModel> Conditionals
        {
            get => conditionals;
            set
            {
                conditionals = value;
                OnPropertyChanged();
            }
        }
        public ObservableCollection<SequenceViewModel> EventSequences
        {
            get => eventSequences;
            set
            {
                eventSequences = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<GlobalValueViewModel> GlobalValues
        {
            get => globalValues;
            set
            {
                globalValues = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ObjectiveViewModel> Objectives
        {
            get => objectives;
            set
            {
                objectives = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ObjectiveViewModel> ObjectivesOpFor
        {
            get => objectivesOpFor; 
            set
            {
                objectivesOpFor = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<PathViewModel> Paths
        {
            get => paths; 
            set
            {
                paths = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<ResourceViewModel> ResourceManifest
        {
            get => resourceManifest; 
            set
            {
                resourceManifest = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<StaticObjectViewModel> StaticObjects
        {
            get => staticObjects; 
            set
            {
                staticObjects = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TimedEventGroupViewModel> TimedEventGroups
        {
            get => timedEventGroups; 
            set
            {
                timedEventGroups = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<TriggerEventViewModel> TriggerEvents
        {
            get => triggerEvents;
            set
            {
                triggerEvents = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<UnitGroupViewModel> UnitGroups
        {
            get => unitGroups; 
            set
            {
                unitGroups = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<UnitSpawnerViewModel> Units
        {
            get => units; 
            set
            {
                units = value;
                OnPropertyChanged();
            }
        }

        public ObservablePropertyedCollection<WaypointViewModel> Waypoints
        {
            get => waypoints;
            set
            {
                waypoints = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public CustomScenarioViewModel()
        {
        }

        public CustomScenarioViewModel(VTS.Data.Runtime.CustomScenario scenario)
        {
            customScenario = scenario;

            ReadData();
        }

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        public CustomScenarioViewModel Clone()
        {
            CustomScenarioViewModel cs = new CustomScenarioViewModel
            {
                AllowedEquips = AllowedEquips,
                BaseBudget = BaseBudget,
                CampaignId = CampaignId,
                CampaignOrderIndex = CampaignOrderIndex,
                EquipsConfigurable = EquipsConfigurable,
                EnvironmentName = EnvironmentName,
                ForceEquips = ForceEquips,
                ForcedEquips = ForcedEquips,
                FuelDrainMultiplier = FuelDrainMultiplier,
                GameVersion = GameVersion,
                InfiniteAmmo = InfiniteAmmo,
                InfiniteAmmoReloadDelay = InfiniteAmmoReloadDelay,
                IsTraining = IsTraining,
                MapId = MapId,
                Multiplayer = Multiplayer,
                NormalForcedFuel = NormalForcedFuel,
                QuickSaveLimit = QuickSaveLimit,
                QuickSaveMode = QuickSaveMode,
                RefuelWaypoint = RefuelWaypoint is ICloneable cloneable ? cloneable.Clone() : RefuelWaypoint, // prefer clone
                ReturnToBaseWaypoint = ReturnToBaseWaypoint is ICloneable cloneable1 ? cloneable1.Clone() : ReturnToBaseWaypoint, // prefer clone
                ScenarioId = ScenarioId,
                ScenarioName = ScenarioName,
                ScenarioDescription = ScenarioDescription,
                SelectableEnvironment = SelectableEnvironment,
                Vehicle = Vehicle,
                Bases = new ObservableCollection<BaseInfoViewModel>(Bases.Select(x => x.Clone()).ToList()),
                BriefingNotes = new ObservableCollection<BriefingNoteViewModel>(BriefingNotes.Select(x => x.Clone()).ToList()),
                ConditionalActions = new ObservableCollection<ConditionalActionViewModel>(ConditionalActions.Select(x => x.Clone()).ToList()),
                Conditionals = new ObservableCollection<ConditionalViewModel>(Conditionals.Select(x => x.Clone()).ToList()),
                EventSequences = new ObservableCollection<SequenceViewModel>(EventSequences.Select(x => x.Clone()).ToList()),
                GlobalValues = new ObservableCollection<GlobalValueViewModel>(GlobalValues.Select(x => x.Clone()).ToList()),
                Objectives = new ObservableCollection<ObjectiveViewModel>(Objectives.Select(x => x.Clone()).ToList()),
                ObjectivesOpFor = new ObservableCollection<ObjectiveViewModel>(ObjectivesOpFor.Select(x => x.Clone()).ToList()),
                Paths = new ObservableCollection<PathViewModel>(Paths.Select(x => x.Clone()).ToList()),
                ResourceManifest = new ObservableCollection<ResourceViewModel>(ResourceManifest.Select(x => x.Clone()).ToList()),
                StaticObjects = new ObservableCollection<StaticObjectViewModel>(StaticObjects.Select(x => x.Clone()).ToList()),
                TimedEventGroups = new ObservableCollection<TimedEventGroupViewModel>(TimedEventGroups.Select(x => x.Clone()).ToList()),
                TriggerEvents = new ObservableCollection<TriggerEventViewModel>(TriggerEvents.Select(x => x.Clone()).ToList()),
                UnitGroups = new ObservableCollection<UnitGroupViewModel>(UnitGroups.Select(x => x.Clone()).ToList()),
                Units = new ObservableCollection<UnitSpawnerViewModel>(Units.Select(x => x.Clone()).ToList()),
                Waypoints = new ObservablePropertyedCollection<WaypointViewModel>(Waypoints),
                HasError = HasError,
                File = File
            };

            // update parent references on top level objects
            if (ReturnToBaseWaypoint != null)
            {
                if (ReturnToBaseWaypoint is UnitSpawnerViewModel unitSpawner)
                {
                    unitSpawner.Parent = cs;
                }

                if (ReturnToBaseWaypoint is WaypointViewModel waypoint)
                {
                    waypoint.Parent = cs;
                }
            }

            if (RefuelWaypoint != null)
            {
                if (RefuelWaypoint is UnitSpawnerViewModel unitSpawner)
                {
                    unitSpawner.Parent = cs;
                }

                if (RefuelWaypoint is WaypointViewModel waypoint)
                {
                    waypoint.Parent = cs;
                }
            }

            foreach (BaseInfoViewModel baseInfo in Bases) baseInfo.Parent = cs;
            foreach (BriefingNoteViewModel briefingNote in BriefingNotes) briefingNote.Parent = cs;
            foreach (ConditionalActionViewModel conditionalAction in ConditionalActions) conditionalAction.Parent = cs;
            foreach (ConditionalViewModel conditional in Conditionals) conditional.Parent = cs;
            foreach (SequenceViewModel sequence in EventSequences) sequence.Parent = cs;
            foreach (GlobalValueViewModel globalValue in GlobalValues) globalValue.Parent = cs;
            foreach (ObjectiveViewModel objective in Objectives) objective.Parent = cs;
            foreach (ObjectiveViewModel objective in ObjectivesOpFor) objective.Parent = cs;
            foreach (PathViewModel path in Paths) path.Parent = cs;
            foreach (ResourceViewModel resource in ResourceManifest) resource.Parent = cs;
            foreach (StaticObjectViewModel staticObject in StaticObjects) staticObject.Parent = cs;
            foreach (TimedEventGroupViewModel timedEventGroup in TimedEventGroups) timedEventGroup.Parent = cs;
            foreach (TriggerEventViewModel triggerEvent in TriggerEvents) triggerEvent.Parent = cs;
            foreach (UnitGroupViewModel unitGroupGrouping in UnitGroups) unitGroupGrouping.Parent = cs;
            foreach (UnitSpawnerViewModel unitSpawner in Units) unitSpawner.Parent = cs;
            foreach (WaypointViewModel waypoint in Waypoints) waypoint.Parent = cs;

            return cs;
        }

        private void ReadData()
        {
            AllowedEquips = customScenario.AllowedEquips;
            BaseBudget = customScenario.BaseBudget;
            CampaignId = customScenario.CampaignId;
            CampaignOrderIndex = customScenario.CampaignOrderIndex;
            EquipsConfigurable = customScenario.EquipsConfigurable;
            EnvironmentName = customScenario.EnvironmentName;
            ForceEquips = customScenario.ForceEquips;
            ForcedEquips = customScenario.ForcedEquips;
            FuelDrainMultiplier = customScenario.FuelDrainMultiplier;
            GameVersion = customScenario.GameVersion;
            InfiniteAmmo = customScenario.InfiniteAmmo;
            InfiniteAmmoReloadDelay = customScenario.InfiniteAmmoReloadDelay;
            IsTraining = customScenario.IsTraining;
            MapId = customScenario.MapId;
            Multiplayer = customScenario.Multiplayer;
            NormalForcedFuel = customScenario.NormalForcedFuel;
            QuickSaveLimit = customScenario.QuickSaveLimit;
            QuickSaveMode = customScenario.QuickSaveMode;
            ScenarioId = customScenario.ScenarioId;
            ScenarioName = customScenario.ScenarioName;
            ScenarioDescription = customScenario.ScenarioDescription;
            SelectableEnvironment = customScenario.SelectableEnvironment;
            Vehicle = customScenario.Vehicle;


        }

        #endregion
    }
}
