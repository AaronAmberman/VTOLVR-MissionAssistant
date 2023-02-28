using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using VTOLVR_MissionAssistant.Collections;
using VTS;
using VTS.Data.Runtime;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    [DebuggerDisplay("VTS File:{File} (HasError:{HasError})")]
    public class CustomScenarioViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private CustomScenario customScenario;

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
        private object returnToBaseDestination;
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

        public object ReturnToBaseDestination
        {
            get => returnToBaseDestination;
            set
            {
                returnToBaseDestination = value;
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

        public CustomScenarioViewModel(CustomScenario scenario)
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
                ReturnToBaseDestination = ReturnToBaseDestination is ICloneable cloneable1 ? cloneable1.Clone() : ReturnToBaseDestination, // prefer clone
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
            if (ReturnToBaseDestination != null)
            {
                if (ReturnToBaseDestination is UnitSpawnerViewModel unitSpawner)
                {
                    unitSpawner.Parent = cs;
                }

                if (ReturnToBaseDestination is WaypointViewModel waypoint)
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

        private void ProcessEventTargetObjectReferences(EventTargetViewModel eventTarget, EventTarget et)
        {
            if (et.Target is TriggerEvent triggerEvent)
            {
                TriggerEventViewModel trigEve = TriggerEvents.FirstOrDefault(te => te.Id == triggerEvent.Id);

                eventTarget.Target = trigEve;
            }
            else if (et.Target is Sequence sequence)
            {
                SequenceViewModel sequenceViewModel = EventSequences.FirstOrDefault(es => es.Id == sequence.Id);

                eventTarget.Target = sequenceViewModel;
            }
            else if (et.Target is Objective objective)
            {
                ObjectiveViewModel objectiveViewModel = Objectives.FirstOrDefault(so => so.ObjectiveID == objective.ObjectiveID);

                if (objective == null)
                {
                    objectiveViewModel = ObjectivesOpFor.FirstOrDefault(so => so.ObjectiveID == objective.ObjectiveID);

                    eventTarget.Target = objective;
                }
                else
                {
                    eventTarget.Target = objective;
                }
            }
            else if (et.Target is TimedEventGroup timedEventGroup)
            {
                TimedEventGroupViewModel timedEventGroupViewModel = TimedEventGroups.FirstOrDefault(teg => teg.GroupId == timedEventGroup.GroupId);

                eventTarget.Target = timedEventGroup;
            }

            for (int k = 0; k < eventTarget.ParamInfos.Count; k++)
            {
                ParamInfoViewModel paramInfoViewModel = eventTarget.ParamInfos[k];
                ParamInfo pi = et.ParamInfos[k];

                if (pi.Value is ConditionalAction conditionalAction)
                {
                    ConditionalActionViewModel reference = ConditionalActions.FirstOrDefault(x => x.Id == conditionalAction.Id);

                    if (reference != null)
                    {
                        paramInfoViewModel.Value = reference;
                    }
                }
            }
        }

        private void ProcessObjectivePreReqs(int index, bool opFor)
        {
            ObjectiveViewModel objective = opFor ? ObjectivesOpFor[index] : Objectives[index];
            Objective o = opFor ? customScenario.ObjectivesOpFor[index] : customScenario.Objectives[index];

            if (o.PreReqObjectives.Count > 0)
            {
                foreach (Objective obj in o.PreReqObjectives)
                {
                    if (opFor)
                    {
                        ObjectiveViewModel match = ObjectivesOpFor.FirstOrDefault(x => x.ObjectiveID == obj.ObjectiveID);

                        objective.PreReqObjectives.Add(match);
                    }
                    else
                    {
                        ObjectiveViewModel match = Objectives.FirstOrDefault(x => x.ObjectiveID == obj.ObjectiveID);

                        objective.PreReqObjectives.Add(match);
                    }
                }
            }
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

            foreach (BaseInfo bi in customScenario.Bases)
            {
                BaseInfoViewModel baseInfo = new BaseInfoViewModel
                {
                    BaseTeam = bi.BaseTeam,
                    Id = bi.Id,
                    OverrideBaseName = bi.OverrideBaseName,
                    Parent = this
                };

                Bases.Add(baseInfo);
            }

            foreach (BriefingNote bn in customScenario.BriefingNotes)
            {
                BriefingNoteViewModel briefingNote = new BriefingNoteViewModel
                {
                    AudioClipPath = bn.AudioClipPath,
                    ImagePath = bn.ImagePath,
                    Text = bn.Text,
                    Parent = this
                };

                BriefingNotes.Add(briefingNote);
            }

            foreach (GlobalValue gv in customScenario.GlobalValues)
            {
                GlobalValueViewModel globalValue = new GlobalValueViewModel
                {
                    Description = gv.Description,
                    Index = gv.Index,
                    Name = gv.Name,
                    Value = gv.Value,
                    Parent = this
                };

                GlobalValues.Add(globalValue);
            }

            foreach (VTS.Data.Runtime.Path p in customScenario.Paths)
            {
                PathViewModel path = new PathViewModel
                {
                    Id = p.Id,
                    Loop = p.Loop,
                    Name = p.Name,
                    PathMode = p.PathMode,
                    Parent = this
                };

                foreach (ThreePointValue point in p.Points)
                {
                    path.Points.Add(new ThreePointValueViewModel
                    {
                        X = point.X,
                        Y = point.Y,
                        Z = point.Z
                    });
                }

                Paths.Add(path);
            }

            foreach (Resource r in customScenario.ResourceManifest)
            {
                ResourceViewModel resource = new ResourceViewModel
                {
                    Index = r.Index,
                    Path = r.Path,
                    Parent = this
                };

                ResourceManifest.Add(resource);
            }

            foreach (StaticObject so in customScenario.StaticObjects)
            {
                StaticObjectViewModel staticObject = new StaticObjectViewModel
                {
                    GlobalPosition = new ThreePointValueViewModel
                    {
                        X = so.GlobalPosition.X,
                        Y = so.GlobalPosition.Y,
                        Z = so.GlobalPosition.Z
                    },
                    Id = so.Id,
                    PrefabId = so.PrefabId,
                    Rotation = new ThreePointValueViewModel
                    {
                        X = so.Rotation.X,
                        Y = so.Rotation.Y,
                        Z = so.Rotation.Z
                    },
                    Parent = this
                };

                StaticObjects.Add(staticObject);
            }

            foreach (Waypoint w in customScenario.Waypoints)
            {
                WaypointViewModel waypoint = new WaypointViewModel
                {
                    GlobalPoint = new ThreePointValueViewModel
                    {
                        X = w.GlobalPoint.X,
                        Y = w.GlobalPoint.Y,
                        Z = w.GlobalPoint.Z
                    },
                    Id = w.Id,
                    Name = w.Name,
                    Parent = this
                };

                Waypoints.Add(waypoint);
            }

            for (int i = 0; i < customScenario.Waypoints.GetPropertyCount(); i++)
            {
                DictionaryEntry property = customScenario.Waypoints.GetProperty(i);

                Waypoints.Properties.Add(property);
            }

            foreach (UnitSpawner us in customScenario.Units)
            {
                UnitSpawnerViewModel unit = new UnitSpawnerViewModel
                {
                    EditorPlacementMode = us.EditorPlacementMode,
                    GlobalPosition = new ThreePointValueViewModel
                    {
                        X = us.GlobalPosition.X,
                        Y = us.GlobalPosition.Y,
                        Z = us.GlobalPosition.Z
                    },
                    LastValidPlacement = new ThreePointValueViewModel
                    {
                        X = us.LastValidPlacement.X,
                        Y = us.LastValidPlacement.Y,
                        Z = us.LastValidPlacement.Z
                    },
                    Rotation = new ThreePointValueViewModel
                    {
                        X = us.Rotation.X,
                        Y = us.Rotation.Y,
                        Z = us.Rotation.Z
                    },
                    SpawnChance = us.SpawnChance,
                    SpawnFlags = us.SpawnFlags,
                    UnitId = us.UnitId,
                    UnitInstanceId = us.UnitInstanceId,
                    UnitName = us.UnitName,
                    Parent = this
                };

                UnitFieldsViewModel unitFields = new UnitFieldsViewModel
                {
                    AllowReload = us.UnitFields.AllowReload,
                    AutoRefuel = us.UnitFields.AutoRefuel,
                    AutoReturnToBase = us.UnitFields.AutoReturnToBase,
                    AwacsVoiceProfile = us.UnitFields.AwacsVoiceProfile,
                    Behavior = us.UnitFields.Behavior,
                    CombatTarget = us.UnitFields.CombatTarget,
                    CommsEnabled = us.UnitFields.CommsEnabled,
                    DefaultBehavior = us.UnitFields.DefaultBehavior,
                    DefaultNavSpeed = us.UnitFields.DefaultNavSpeed,
                    DefaultOrbitPoint = us.UnitFields.DefaultOrbitPoint,
                    DefaultPath = us.UnitFields.DefaultPath,
                    DefaultRadarEnabled = us.UnitFields.DefaultRadarEnabled,
                    DefaultShotsPerSalvo = us.UnitFields.DefaultShotsPerSalvo,
                    DefaultWaypoint = us.UnitFields.DefaultWaypoint,
                    DetectionMode = us.UnitFields.DetectionMode,
                    EngageEnemies = us.UnitFields.EngageEnemies,
                    Equips = us.UnitFields.Equips,
                    Fuel = us.UnitFields.Fuel,
                    HullNumber = us.UnitFields.HullNumber,
                    InitialSpeed = us.UnitFields.InitialSpeed,
                    Invincible = us.UnitFields.Invincible,
                    MoveSpeed = us.UnitFields.MoveSpeed,
                    OrbitAltitude = us.UnitFields.OrbitAltitude,
                    ParkedStartMode = us.UnitFields.ParkedStartMode,
                    PlayerCommandsMode = us.UnitFields.PlayerCommandsMode,
                    RadarUnits = us.UnitFields.RadarUnits,
                    ReceiveFriendlyDamage = us.UnitFields.ReceiveFriendlyDamage,
                    ReloadTime = us.UnitFields.ReloadTime,
                    Respawnable = us.UnitFields.Respawnable,
                    RippleRate = us.UnitFields.RippleRate,
                    SpawnOnStart = us.UnitFields.SpawnOnStart,
                    StartMode = us.UnitFields.StartMode,
                    StopToEngage = us.UnitFields.StopToEngage,
                    UnitGroup = us.UnitFields.UnitGroup,
                    VoiceProfile = us.UnitFields.VoiceProfile,
                    Parent = unit
                };

                if (us.UnitFields.Waypoint != null)
                {
                    WaypointViewModel match = Waypoints.FirstOrDefault(w => w.Id == us.UnitFields.Waypoint.Id);

                    // we are not going to revalidate all the potential missing object references (the VTS api did that for us)

                    unitFields.Waypoint = match;
                }

                unit.UnitFields = unitFields;

                Units.Add(unit);
            }

            // set the custom scenario return to base waypoint
            if (customScenario.ReturnToBaseWaypoint != null)
            {
                if (customScenario.ReturnToBaseWaypoint is Waypoint waypoint)
                {
                    WaypointViewModel match = Waypoints.FirstOrDefault(w => w.Id == waypoint.Id);

                    ReturnToBaseDestination = match;
                }

                if (customScenario.ReturnToBaseWaypoint is UnitSpawner unit)
                {
                    UnitSpawnerViewModel match = Units.FirstOrDefault(w => w.UnitInstanceId == unit.UnitInstanceId);

                    ReturnToBaseDestination = match;
                }
            }

            // set the custom scenario refuel waypoint
            if (customScenario.RefuelWaypoint != null)
            {
                if (customScenario.RefuelWaypoint is Waypoint waypoint)
                {
                    WaypointViewModel match = Waypoints.FirstOrDefault(w => w.Id == waypoint.Id);

                    RefuelWaypoint = match;
                }

                if (customScenario.RefuelWaypoint is UnitSpawner unit)
                {
                    UnitSpawnerViewModel match = Units.FirstOrDefault(w => w.UnitInstanceId == unit.UnitInstanceId);

                    RefuelWaypoint = match;
                }
            }

            // set carrier spawn references and RTB destinations
            for (int i = 0; i < Units.Count; i++)
            {
                UnitSpawnerViewModel unitSpawnerViewModel = Units[i];
                UnitSpawner unitSpawner = customScenario.Units[i];

                if (unitSpawner.UnitFields.CarrierSpawns?.Count > 0)
                {
                    foreach (Tuple<int, UnitSpawner> carrierSpawn in unitSpawner.UnitFields.CarrierSpawns)
                    {
                        UnitSpawnerViewModel match = Units.FirstOrDefault(theUnit => theUnit.UnitInstanceId == carrierSpawn.Item2.UnitInstanceId);

                        unitSpawnerViewModel.UnitFields.CarrierSpawns.Add(new Tuple<int, UnitSpawnerViewModel>(carrierSpawn.Item1, match));
                    }
                }

                if (unitSpawner.UnitFields.ReturnToBaseDestination != null)
                {
                    if (unitSpawner.UnitFields.ReturnToBaseDestination is Waypoint waypoint)
                    {
                        WaypointViewModel match = Waypoints.FirstOrDefault(w => w.Id == waypoint.Id);

                        unitSpawnerViewModel.UnitFields.ReturnToBaseDestination = match;
                    }

                    if (unitSpawner.UnitFields.ReturnToBaseDestination is UnitSpawner unit)
                    {
                        UnitSpawnerViewModel match = Units.FirstOrDefault(w => w.UnitInstanceId == unit.UnitInstanceId);

                        unitSpawnerViewModel.UnitFields.ReturnToBaseDestination = match;
                    }
                }
            }

            foreach (UnitGroup unitGroup in customScenario.UnitGroups)
            {
                UnitGroupViewModel unitGroupViewModel = new UnitGroupViewModel
                {
                    Name = unitGroup.Name,
                    Parent = this
                };

                unitGroupViewModel.Alpha = ReadUnitGroup(unitGroup.Alpha);
                unitGroupViewModel.Bravo = ReadUnitGroup(unitGroup.Bravo);
                unitGroupViewModel.Charlie = ReadUnitGroup(unitGroup.Charlie);
                unitGroupViewModel.Delta = ReadUnitGroup(unitGroup.Delta);
                unitGroupViewModel.Echo = ReadUnitGroup(unitGroup.Echo);
                unitGroupViewModel.Foxtrot = ReadUnitGroup(unitGroup.Foxtrot);
                unitGroupViewModel.Golf = ReadUnitGroup(unitGroup.Golf);
                unitGroupViewModel.Hotel = ReadUnitGroup(unitGroup.Hotel);
                unitGroupViewModel.India = ReadUnitGroup(unitGroup.India);
                unitGroupViewModel.Juliet = ReadUnitGroup(unitGroup.Juliet);
                unitGroupViewModel.Kilo = ReadUnitGroup(unitGroup.Kilo);
                unitGroupViewModel.Lima = ReadUnitGroup(unitGroup.Lima);
                unitGroupViewModel.Mike = ReadUnitGroup(unitGroup.Mike);
                unitGroupViewModel.November = ReadUnitGroup(unitGroup.November);
                unitGroupViewModel.Oscar = ReadUnitGroup(unitGroup.Oscar);
                unitGroupViewModel.Papa = ReadUnitGroup(unitGroup.Papa);
                unitGroupViewModel.Quebec = ReadUnitGroup(unitGroup.Quebec);
                unitGroupViewModel.Romeo = ReadUnitGroup(unitGroup.Romeo);
                unitGroupViewModel.Sierra = ReadUnitGroup(unitGroup.Sierra);
                unitGroupViewModel.Tango = ReadUnitGroup(unitGroup.Tango);
                unitGroupViewModel.Uniform = ReadUnitGroup(unitGroup.Uniform);
                unitGroupViewModel.Victor = ReadUnitGroup(unitGroup.Victor);
                unitGroupViewModel.Whiskey = ReadUnitGroup(unitGroup.Whiskey);
                unitGroupViewModel.Xray = ReadUnitGroup(unitGroup.Xray);
                unitGroupViewModel.Yankee = ReadUnitGroup(unitGroup.Yankee);
                unitGroupViewModel.Zulu = ReadUnitGroup(unitGroup.Zulu);

                UnitGroups.Add(unitGroupViewModel);
            }

            foreach (Conditional c in customScenario.Conditionals)
            {
                Conditionals.Add(ReadConditional(c, this));
            }

            foreach (ConditionalAction conditionalAction in customScenario.ConditionalActions)
            {
                ConditionalActionViewModel conditionalActionViewModel = new ConditionalActionViewModel
                {
                    Id = conditionalAction.Id,
                    Name = conditionalAction.Name,
                    Parent = this
                };

                BlockViewModel baseBlockViewModel = new BlockViewModel
                {
                    BlockId = conditionalAction.BaseBlock.BlockId,
                    BlockName = conditionalAction.BaseBlock.BlockName,
                    Parent = conditionalAction
                };

                baseBlockViewModel.Actions = ReadEventInfo(conditionalAction.BaseBlock.Actions, baseBlockViewModel);
                baseBlockViewModel.Conditional = ReadConditional(conditionalAction.BaseBlock.Conditional, baseBlockViewModel);
                baseBlockViewModel.ElseActions = ReadEventInfo(conditionalAction.BaseBlock.ElseActions, baseBlockViewModel);

                foreach (Block eib in conditionalAction.BaseBlock.ElseIfBlocks)
                {
                    BlockViewModel elseIfBlockViewModel = new BlockViewModel
                    {
                        BlockId = eib.BlockId,
                        BlockName = eib.BlockName,
                        Parent = baseBlockViewModel
                    };

                    elseIfBlockViewModel.Actions = ReadEventInfo(eib.Actions, elseIfBlockViewModel);
                    elseIfBlockViewModel.Conditional = ReadConditional(eib.Conditional, elseIfBlockViewModel);
                    elseIfBlockViewModel.ElseActions = ReadEventInfo(eib.ElseActions, elseIfBlockViewModel);

                    baseBlockViewModel.ElseIfBlocks.Add(elseIfBlockViewModel);
                }

                conditionalActionViewModel.BaseBlock = baseBlockViewModel;

                ConditionalActions.Add(conditionalActionViewModel);
            }

            foreach (TriggerEvent te in customScenario.TriggerEvents)
            {
                TriggerEventViewModel triggerEvent = new TriggerEventViewModel
                {
                    Enabled = te.Enabled,
                    EventName = te.EventName,
                    Id = te.Id,
                    ProxyMode = te.ProxyMode,
                    Radius = te.Radius,
                    SphericalRadius = te.SphericalRadius,
                    TriggerMode = te.TriggerMode,
                    TriggerType = te.TriggerType,
                    Parent = this
                };

                triggerEvent.EventInfo = ReadEventInfo(te.EventInfo, triggerEvent);

                if (te.Conditional != null)
                {
                    ConditionalViewModel conditional = Conditionals.FirstOrDefault(x => x.Id == te.Conditional.Id);

                    triggerEvent.Conditional = conditional;
                }

                if (te.Waypoint != null)
                {
                    WaypointViewModel waypoint = Waypoints.FirstOrDefault(x => x.Id == te.Waypoint.Id);

                    triggerEvent.Waypoint = waypoint;
                }

                TriggerEvents.Add(triggerEvent);
            }

            foreach (Sequence s in customScenario.EventSequences)
            {
                SequenceViewModel sequence = new SequenceViewModel
                {
                    Id = s.Id,
                    SequenceName = s.SequenceName,
                    StartImmediately = s.StartImmediately,
                    WhileLoop = s.WhileLoop,
                    Parent = this
                };

                foreach (Event e in s.Events)
                {
                    EventViewModel @event = new EventViewModel
                    {
                        Delay = e.Delay,
                        NodeName = e.NodeName,
                        Parent = sequence
                    };

                    @event.EventInfo = ReadEventInfo(e.EventInfo, sequence);

                    if (e.Conditional != null)
                    {
                        ConditionalViewModel conditional = Conditionals.FirstOrDefault(x => x.Id == e.Conditional.Id);

                        @event.Conditional = conditional;
                    }

                    if (e.ExitConditional != null)
                    {
                        ConditionalViewModel conditional = Conditionals.FirstOrDefault(x => x.Id == e.ExitConditional.Id);

                        @event.ExitConditional = conditional;
                    }

                    sequence.Events.Add(@event);
                }

                EventSequences.Add(sequence);
            }

            foreach (Objective o in customScenario.Objectives)
            {
                Objectives.Add(ReadObjective(o));
            }

            foreach (Objective o in customScenario.ObjectivesOpFor)
            {
                ObjectivesOpFor.Add(ReadObjective(o));
            }

            foreach (TimedEventGroup teg in customScenario.TimedEventGroups)
            {
                TimedEventGroupViewModel timedEventGroup = new TimedEventGroupViewModel
                {
                    BeginImmediately = teg.BeginImmediately,
                    GroupId = teg.GroupId,
                    GroupName = teg.GroupName,
                    InitialDelay = teg.InitialDelay,
                    Parent = this
                };

                foreach (TimedEventInfo tei in teg.TimedEventInfos)
                {
                    TimedEventInfoViewModel timedEventInfo = new TimedEventInfoViewModel
                    {
                        EventName = tei.EventName,
                        Time = tei.Time,
                        Parent = timedEventGroup
                    };

                    foreach (EventTarget et in tei.EventTargets)
                    {
                        timedEventInfo.EventTargets.Add(ReadEventTarget(et, timedEventInfo));
                    }

                    timedEventGroup.TimedEventInfos.Add(timedEventInfo);
                }

                TimedEventGroups.Add(timedEventGroup);
            }

            // set references to conditional actions, trigger events, event sequences, objectives, objectives op for, timed event groups
            for (int i = 0; i < ConditionalActions.Count; i++)
            {
                ConditionalActionViewModel conditionalAction = ConditionalActions[i];
                ConditionalAction ca = customScenario.ConditionalActions[i];

                for (int j = 0; j < conditionalAction.BaseBlock.Actions.EventTargets.Count; j++)
                {
                    EventTargetViewModel eventTarget = conditionalAction.BaseBlock.Actions.EventTargets[j];
                    EventTarget et = ca.BaseBlock.Actions.EventTargets[j];

                    ProcessEventTargetObjectReferences(eventTarget, et);
                }

                for (int j = 0; j < conditionalAction.BaseBlock.ElseActions.EventTargets.Count; j++)
                {
                    EventTargetViewModel eventTarget = conditionalAction.BaseBlock.ElseActions.EventTargets[j];
                    EventTarget et = ca.BaseBlock.ElseActions.EventTargets[j];

                    ProcessEventTargetObjectReferences(eventTarget, et);
                }
            }

            for (int i = 0; i < TriggerEvents.Count; i++)
            {
                TriggerEventViewModel triggerEvent = TriggerEvents[i];
                TriggerEvent te = customScenario.TriggerEvents[i];

                for (int j = 0; j < triggerEvent.EventInfo.EventTargets.Count; j++)
                {
                    EventTargetViewModel eventTarget = triggerEvent.EventInfo.EventTargets[j];
                    EventTarget et = te.EventInfo.EventTargets[j];

                    ProcessEventTargetObjectReferences(eventTarget, et);
                }
            }

            for (int i = 0; i < EventSequences.Count; i++)
            {
                SequenceViewModel sequence = EventSequences[i];
                Sequence s = customScenario.EventSequences[i];

                for (int j = 0; j < sequence.Events.Count; j++)
                {
                    EventViewModel @event = sequence.Events[j];
                    Event e = s.Events[j];

                    for (int k = 0; k < @event.EventInfo.EventTargets.Count; k++)
                    {
                        EventTargetViewModel eventTarget = @event.EventInfo.EventTargets[k];
                        EventTarget et = e.EventInfo.EventTargets[k];

                        ProcessEventTargetObjectReferences(eventTarget, et);
                    }
                }
            }

            for (int i = 0; i < Objectives.Count; i++)
            {
                ObjectiveViewModel objective = Objectives[i];
                Objective o = customScenario.Objectives[i];

                for (int j = 0; j < objective.CompleteEvent.EventTargets.Count; j++)
                {
                    EventTargetViewModel eventTarget = objective.CompleteEvent.EventTargets[j];
                    EventTarget et = o.CompleteEvent.EventTargets[j];

                    ProcessEventTargetObjectReferences(eventTarget, et);
                }

                for (int j = 0; j < objective.FailEvent.EventTargets.Count; j++)
                {
                    EventTargetViewModel eventTarget = objective.FailEvent.EventTargets[j];
                    EventTarget et = o.FailEvent.EventTargets[j];

                    ProcessEventTargetObjectReferences(eventTarget, et);
                }

                for (int j = 0; j < objective.StartEvent.EventTargets.Count; j++)
                {
                    EventTargetViewModel eventTarget = objective.StartEvent.EventTargets[j];
                    EventTarget et = o.StartEvent.EventTargets[j];

                    ProcessEventTargetObjectReferences(eventTarget, et);
                }

                ProcessObjectivePreReqs(i, false);
            }

            for (int i = 0; i < ObjectivesOpFor.Count; i++)
            {
                ObjectiveViewModel objective = ObjectivesOpFor[i];
                Objective o = customScenario.ObjectivesOpFor[i];

                for (int j = 0; j < objective.CompleteEvent.EventTargets.Count; j++)
                {
                    EventTargetViewModel eventTarget = objective.CompleteEvent.EventTargets[j];
                    EventTarget et = o.CompleteEvent.EventTargets[j];

                    ProcessEventTargetObjectReferences(eventTarget, et);
                }

                for (int j = 0; j < objective.FailEvent.EventTargets.Count; j++)
                {
                    EventTargetViewModel eventTarget = objective.FailEvent.EventTargets[j];
                    EventTarget et = o.FailEvent.EventTargets[j];

                    ProcessEventTargetObjectReferences(eventTarget, et);
                }

                for (int j = 0; j < objective.StartEvent.EventTargets.Count; j++)
                {
                    EventTargetViewModel eventTarget = objective.StartEvent.EventTargets[j];
                    EventTarget et = o.StartEvent.EventTargets[j];

                    ProcessEventTargetObjectReferences(eventTarget, et);
                }

                ProcessObjectivePreReqs(i, true);
            }

            for (int i = 0; i < TimedEventGroups.Count; i++)
            {
                TimedEventGroupViewModel timedEventGroup = TimedEventGroups[i];
                TimedEventGroup teg = customScenario.TimedEventGroups[i];

                for (int j = 0; j < timedEventGroup.TimedEventInfos.Count; j++)
                {
                    TimedEventInfoViewModel timedEventInfo = timedEventGroup.TimedEventInfos[j];
                    TimedEventInfo tei = teg.TimedEventInfos[j];

                    for (int k = 0; k < timedEventInfo.EventTargets.Count; k++)
                    {
                        EventTargetViewModel eventTarget = timedEventInfo.EventTargets[k];
                        EventTarget et = tei.EventTargets[k];

                        ProcessEventTargetObjectReferences(eventTarget, et);
                    }
                }
            }
        }

        private ConditionalViewModel ReadConditional(Conditional c, object parent)
        {
            ConditionalViewModel conditional = new ConditionalViewModel
            {
                Id = c.Id,
                OutputNodePosition = new ThreePointValueViewModel 
                { 
                    X = c.OutputNodePosition.X,
                    Y = c.OutputNodePosition.Y,
                    Z = c.OutputNodePosition.Z
                },
                Root = c.Root,
                Parent = parent
            };

            foreach (Computation comp in c.Computations)
            {
                ComputationViewModel computation = new ComputationViewModel
                {
                    Chance = comp.Chance,
                    Comparison = comp.Comparison,
                    ControlCondition = comp.ControlCondition,
                    ControlValue = comp.ControlValue,
                    CValue = comp.CValue,
                    Id = comp.Id,
                    IsNot = comp.IsNot,
                    MethodName = comp.MethodName,
                    MethodParameters = comp.MethodParameters,
                    Type = comp.Type,
                    UiPosition = new ThreePointValueViewModel
                    {
                        X = comp.UiPosition.X,
                        Y = comp.UiPosition.Y,
                        Z = comp.UiPosition.Z
                    },
                    UnitGroup = comp.UnitGroup,
                    VehicleControl = comp.VehicleControl,
                    Parent = conditional
                };

                if (!string.IsNullOrWhiteSpace(comp.Type))
                {
                    //if (comp.Type == KeywordStrings.SccUnit)
                    //{
                    //}
                    //else if (comp.Type == KeywordStrings.SccUnitGroup)
                    //{
                    //}
                    //else if (comp.Type == KeywordStrings.SccUnitList)
                    //{
                    //}
                    //else if (comp.Type == KeywordStrings.SccChance)
                    //{

                    //}
                    //else if (comp.Type == KeywordStrings.SccVehicleControl)
                    //{
                    //}
                    //else if (comp.Type == KeywordStrings.SccGlobalValue)
                    //{
                    //}
                    // only static objects seem to use the object reference property
                    if (comp.Type == KeywordStrings.SccStaticObject)
                    {
                        if (comp.ObjectReference != null)
                        {
                            StaticObject so = comp.ObjectReference as StaticObject;

                            if (so != null)
                            {
                                StaticObjectViewModel match = StaticObjects.FirstOrDefault(x => x.Id == so.Id);

                                if (match != null)
                                {
                                    computation.ObjectReference = match;
                                }
                            }
                        }
                    }
                    else
                    {
                        computation.ObjectReference = comp.ObjectReference;
                    }
                }

                if (comp.GlobalValue != null)
                {
                    GlobalValueViewModel match = GlobalValues.FirstOrDefault(x => x.Index == comp.GlobalValue.Index);

                    computation.GlobalValue = match;
                }

                if (comp.Unit != null)
                {
                    UnitSpawnerViewModel match = Units.FirstOrDefault(x => x.UnitInstanceId == comp.Unit.UnitInstanceId);

                    computation.Unit = match;
                }

                if (comp.UnitList.Count > 0)
                {
                    foreach (UnitSpawner unit in comp.UnitList)
                    {
                        UnitSpawnerViewModel match = Units.FirstOrDefault(x => x.UnitInstanceId == comp.Unit.UnitInstanceId);

                        computation.UnitList.Add(match);
                    }
                }

                conditional.Computations.Add(computation);
            }

            // loop through a second time to set the factors property
            for (int i = 0; i < c.Computations.Count; i++)
            {
                Computation comp = c.Computations[i];
                ComputationViewModel computation = conditional.Computations[i];

                if (comp.Factors.Count > 0)
                {
                    ComputationViewModel match = conditional.Computations.FirstOrDefault(x => x.Id == comp.Id);

                    if (match != null) computation.Factors.Add(match);
                }
            }

            return conditional;
        }

        private EventInfoViewModel ReadEventInfo(EventInfo eventInfo, object parent)
        {
            EventInfoViewModel eventInfoViewModel = new EventInfoViewModel
            {
                EventName = eventInfo.EventName,
                Parent = parent,
            };

            foreach (EventTarget eventTarget in eventInfo.EventTargets)
            {
                eventInfoViewModel.EventTargets.Add(ReadEventTarget(eventTarget, eventInfoViewModel));
            }

            return eventInfoViewModel;
        }

        private EventTargetViewModel ReadEventTarget(EventTarget eventTarget, object parent)
        {
            EventTargetViewModel eventTargetViewModel = new EventTargetViewModel
            {
                EventName = eventTarget.EventName,
                MethodName = eventTarget.MethodName,
                TargetType = eventTarget.TargetType,
                Parent = parent
            };

            if (eventTarget.Target is UnitSpawner unit)
            {
                UnitSpawnerViewModel match = Units.FirstOrDefault(x => x.UnitInstanceId == unit.UnitInstanceId);

                eventTargetViewModel.Target = match;
            }
            else if (eventTarget.Target is StaticObject so)
            {
                StaticObjectViewModel match = StaticObjects.FirstOrDefault(x => x.Id == so.Id);

                eventTargetViewModel.Target = match;
            }
            else eventTargetViewModel.Target = eventTarget.Target;

            foreach (ParamInfo paramInfo in eventTarget.ParamInfos)
            {
                ParamInfoViewModel paramInfoViewModel = new ParamInfoViewModel
                {
                    Name = paramInfo.Name,
                    Type = paramInfo.Type,
                    Parent = eventTargetViewModel
                };

                if (paramInfo.Value == null) paramInfoViewModel.Value = null;
                else if (paramInfo.Value is UnitSpawner paramInfoUnit)
                {
                    UnitSpawnerViewModel match = Units.FirstOrDefault(x => x.UnitInstanceId == paramInfoUnit.UnitInstanceId);

                    paramInfoViewModel.Value = match;
                }
                else if (paramInfo.Value is List<UnitSpawner> paramInfoUnits)
                {
                    ObservableCollection<UnitSpawnerViewModel> units = new ObservableCollection<UnitSpawnerViewModel>();

                    foreach (UnitSpawner us in paramInfoUnits)
                    {
                        UnitSpawnerViewModel match = Units.FirstOrDefault(x => x.UnitInstanceId == us.UnitInstanceId);

                        units.Add(match);
                    }

                    paramInfoViewModel.Value = units;
                }
                else if (paramInfo.Value is BaseInfo baseInfo)
                {
                    BaseInfoViewModel match = Bases.FirstOrDefault(x => x.Id == baseInfo.Id);

                    paramInfoViewModel.Value = match;
                }
                else if (paramInfo.Value is FileInfo fileInfo)
                {
                    paramInfoViewModel.Value = new FileInfo(fileInfo.FullName);
                }
                else if (paramInfo.Value is GlobalValue globalValue)
                {
                    GlobalValueViewModel match = GlobalValues.FirstOrDefault(x => x.Index == globalValue.Index);

                    paramInfoViewModel.Value = match;
                }
                else if (paramInfo.Value is VTS.Data.Runtime.Path path)
                {
                    PathViewModel match = Paths.FirstOrDefault(x => x.Id == path.Id);

                    paramInfoViewModel.Value = match;
                }
                else if (paramInfo.Value is Waypoint waypoint)
                {
                    WaypointViewModel match = Waypoints.FirstOrDefault(x => x.Id == waypoint.Id);

                    paramInfoViewModel.Value = match;
                }
                else if (paramInfo.Value is ThreePointValue threePointValue)
                {
                    ThreePointValueViewModel value = new ThreePointValueViewModel
                    {
                        X = threePointValue.X,
                        Y = threePointValue.Y,
                        Z = threePointValue.Z
                    };

                    paramInfoViewModel.Value = value;
                }
                else paramInfoViewModel.Value = paramInfo.Value;

                foreach (ParamAttrInfo paramAttrInfo in paramInfo.ParamAttrInfos)
                {
                    ParamAttrInfoViewModel paramAttrInfoViewModel = new ParamAttrInfoViewModel
                    {
                        Data = paramAttrInfo.Data,
                        Type = paramAttrInfo.Type,
                        Parent = paramInfoViewModel
                    };

                    paramInfoViewModel.ParamAttrInfos.Add(paramAttrInfoViewModel);
                }

                eventTargetViewModel.ParamInfos.Add(paramInfoViewModel);
            }

            return eventTargetViewModel;
        }

        private ObjectiveViewModel ReadObjective(Objective objective)
        {
            ObjectiveViewModel objectiveViewModel = new ObjectiveViewModel
            {
                AutoSetWaypoint = objective.AutoSetWaypoint,
                CompletionReward = objective.CompletionReward,
                ObjectiveID = objective.ObjectiveID,
                ObjectiveInfo = objective.ObjectiveInfo,
                ObjectiveName = objective.ObjectiveName,
                ObjectiveType = objective.ObjectiveType,
                OrderID = objective.OrderID,
                Required = objective.Required,
                StartMode = objective.StartMode,
                Parent = this
            };

            objectiveViewModel.CompleteEvent = ReadEventInfo(objective.CompleteEvent, objectiveViewModel);
            objectiveViewModel.FailEvent = ReadEventInfo(objective.FailEvent, objectiveViewModel);
            objectiveViewModel.StartEvent = ReadEventInfo(objective.StartEvent, objectiveViewModel);

            if (objective.Waypoint is Waypoint waypoint)
            {
                WaypointViewModel waypointViewModel = Waypoints.FirstOrDefault(x => x.Id == waypoint.Id);

                objective.Waypoint = waypointViewModel;
            }
            else if (objective.Waypoint is UnitSpawner unit)
            {
                UnitSpawnerViewModel unitSpawnerViewModel = Units.FirstOrDefault(x => x.UnitInstanceId == unit.UnitInstanceId);

                objective.Waypoint = unitSpawnerViewModel;
            }

            ObjectiveFieldsViewModel objectiveFieldsViewModel = new ObjectiveFieldsViewModel
            {
                CompletionMode = objective.Fields.CompletionMode,
                FuelLevel = objective.Fields.FuelLevel,
                FullCompletionBonus = objective.Fields.FullCompletionBonus,
                MinRequired = objective.Fields.MinRequired,
                PerUnitReward = objective.Fields.PerUnitReward,
                Radius = objective.Fields.Radius,
                SphericalRadius = objective.Fields.SphericalRadius,
                TriggerRadius = objective.Fields.TriggerRadius,
                UnloadRadius = objective.Fields.UnloadRadius,
                Parent = objectiveViewModel
            };

            if (objective.Fields.FailConditional != null)
            {
                ConditionalViewModel match = Conditionals.FirstOrDefault(x => x.Id == objective.Fields.FailConditional.Id);

                objectiveFieldsViewModel.FailConditional = match;
            }

            if (objective.Fields.SuccessConditional != null)
            {
                ConditionalViewModel match = Conditionals.FirstOrDefault(x => x.Id == objective.Fields.SuccessConditional.Id);

                objectiveFieldsViewModel.SuccessConditional = match;
            }

            if (objective.Fields.DropoffRallyPoint != null)
            {
                WaypointViewModel match = Waypoints.FirstOrDefault(x => x.Id == objective.Fields.DropoffRallyPoint.Id);

                objectiveFieldsViewModel.DropoffRallyPoint = match;
            }

            if (objective.Fields.Target != null)
            {
                UnitSpawnerViewModel match = Units.FirstOrDefault(x => x.UnitInstanceId == objective.Fields.Target.UnitInstanceId);

                objectiveFieldsViewModel.Target = match;
            }

            if (objective.Fields.TargetUnit != null)
            {
                UnitSpawnerViewModel match = Units.FirstOrDefault(x => x.UnitInstanceId == objective.Fields.TargetUnit.UnitInstanceId);

                objectiveFieldsViewModel.TargetUnit = match;
            }

            if (objective.Fields.Targets.Count > 0)
            {
                foreach (UnitSpawner target in objective.Fields.Targets)
                {
                    UnitSpawnerViewModel match = Units.FirstOrDefault(x => x.UnitInstanceId == target.UnitInstanceId);

                    objectiveFieldsViewModel.Targets.Add(match);
                }
            }

            objectiveViewModel.Fields = objectiveFieldsViewModel;

            return objectiveViewModel;
        }

        private UnitGroupGroupingViewModel ReadUnitGroup(UnitGroupGrouping groupGrouping)
        {
            if (groupGrouping == null) return null;

            UnitGroupGroupingViewModel unitGroupGroupingViewModel = new UnitGroupGroupingViewModel
            {
                Name = groupGrouping.Name,
                Parent = this
            };

            if (groupGrouping.Settings != null)
            {
                UnitGroupSettingsViewModel unitGroupSettingsViewModel = new UnitGroupSettingsViewModel
                {
                    Name = groupGrouping.Settings.Name,
                    Parent = unitGroupGroupingViewModel,
                    SyncAltSpawns = groupGrouping.Settings.SyncAltSpawns
                };

                unitGroupGroupingViewModel.Settings = unitGroupSettingsViewModel;
            }

            foreach (UnitSpawner unit in groupGrouping.Units)
            {
                UnitSpawnerViewModel unitSpawnerViewModel = Units.FirstOrDefault(u => u.UnitInstanceId == unit.UnitInstanceId);

                if (unitSpawnerViewModel != null) unitGroupGroupingViewModel.Units.Add(unitSpawnerViewModel);
            }

            return unitGroupGroupingViewModel;
        }

        #endregion
    }
}
