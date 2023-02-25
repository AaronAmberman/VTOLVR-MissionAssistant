using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace VTOLVR_MissionAssistant.ViewModels.Vts
{
    /// <summary>Represents the unit fields on a unit.</summary>
    public class UnitFieldsViewModel : ViewModelBase, ICloneable
    {
        #region Fields

        private bool allowReload;
        private bool autoRefuel;
        private bool autoReturnToBase;
        private string awacsVoiceProfile;
        private string behavior;
        private ObservableCollection<Tuple<int, UnitSpawnerViewModel>> carrierSpawns = new ObservableCollection<Tuple<int, UnitSpawnerViewModel>>();
        private bool combatTarget;
        private bool commsEnabled;
        private string defaultBehavior;
        private int defaultNavSpeed;
        private string defaultOrbitPoint;
        private string defaultPath;
        private bool defaultRadarEnabled;
        private int defaultShotsPerSalvo;
        private string defaultWaypoint;
        private string detectionMode;
        private bool engageEnemies;
        private string equips;
        private int fuel;
        private int hullNumber;
        private int initialSpeed;
        private bool invincible;
        private string moveSpeed;
        private float orbitAltitude;
        private string parkedStartMode;
        private string playerCommandsMode;
        private string radarUnits;
        private int rippleRate;
        private bool receiveFriendlyDamage;
        private int reloadTime;
        private bool respawnable;
        private object returnToBaseDestination;
        private bool spawnOnStart;
        private string startMode;
        private bool stopToEngage;
        private string unitGroup;
        private string voiceProfile;
        private WaypointViewModel waypoint;

        #endregion

        #region Properties

        public bool AllowReload
        {
            get => allowReload;
            set
            {
                allowReload = value;
                OnPropertyChanged();
            }
        }

        public bool AutoRefuel
        {
            get => autoRefuel;
            set
            {
                autoRefuel = value;
                OnPropertyChanged();
            }
        }

        public bool AutoReturnToBase
        {
            get => autoReturnToBase;
            set
            {
                autoReturnToBase = value;
                OnPropertyChanged();
            }
        }

        public string AwacsVoiceProfile
        {
            get => awacsVoiceProfile;
            set
            {
                awacsVoiceProfile = value;
                OnPropertyChanged();
            }
        }

        public string Behavior
        {
            get => behavior;
            set
            {
                behavior = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Tuple<int, UnitSpawnerViewModel>> CarrierSpawns
        {
            get => carrierSpawns;
            set
            {
                carrierSpawns = value;
                OnPropertyChanged();
            }
        }

        public bool CombatTarget
        {
            get => combatTarget;
            set
            {
                combatTarget = value;
                OnPropertyChanged();
            }
        }

        public bool CommsEnabled
        {
            get => commsEnabled;
            set
            {
                commsEnabled = value;
                OnPropertyChanged();
            }
        }

        public string DefaultBehavior
        {
            get => defaultBehavior;
            set
            {
                defaultBehavior = value;
                OnPropertyChanged();
            }
        }

        public int DefaultNavSpeed
        {
            get => defaultNavSpeed;
            set
            {
                defaultNavSpeed = value;
                OnPropertyChanged();
            }
        }

        public string DefaultOrbitPoint
        {
            get => defaultOrbitPoint;
            set
            {
                defaultOrbitPoint = value;
                OnPropertyChanged();
            }
        }

        public string DefaultPath
        {
            get => defaultPath;
            set
            {
                defaultPath = value;
                OnPropertyChanged();
            }
        }

        public bool DefaultRadarEnabled
        {
            get => defaultRadarEnabled;
            set
            {
                defaultRadarEnabled = value;
                OnPropertyChanged();
            }
        }

        public int DefaultShotsPerSalvo
        {
            get => defaultShotsPerSalvo;
            set
            {
                defaultShotsPerSalvo = value;
                OnPropertyChanged();
            }
        }

        public string DefaultWaypoint
        {
            get => defaultWaypoint;
            set
            {
                defaultWaypoint = value;
                OnPropertyChanged();
            }
        }

        public string DetectionMode
        {
            get => detectionMode;
            set
            {
                detectionMode = value;
                OnPropertyChanged();
            }
        }

        public bool EngageEnemies
        {
            get => engageEnemies;
            set
            {
                engageEnemies = value;
                OnPropertyChanged();
            }
        }

        public string Equips
        {
            get => equips;
            set
            {
                equips = value;
                OnPropertyChanged();
            }
        }

        public int Fuel
        {
            get => fuel;
            set
            {
                fuel = value;
                OnPropertyChanged();
            }
        }

        public int HullNumber
        {
            get => hullNumber;
            set
            {
                hullNumber = value;
                OnPropertyChanged();
            }
        }

        public int InitialSpeed
        {
            get => initialSpeed;
            set
            {
                initialSpeed = value;
                OnPropertyChanged();
            }
        }

        public bool Invincible
        {
            get => invincible;
            set
            {
                invincible = value;
                OnPropertyChanged();
            }
        }

        public string MoveSpeed
        {
            get => moveSpeed;
            set
            {
                moveSpeed = value;
                OnPropertyChanged();
            }
        }

        public float OrbitAltitude
        {
            get => orbitAltitude;
            set
            {
                orbitAltitude = value;
                OnPropertyChanged();
            }
        }

        public string ParkedStartMode
        {
            get => parkedStartMode;
            set
            {
                parkedStartMode = value;
                OnPropertyChanged();
            }
        }

        public string PlayerCommandsMode
        {
            get => playerCommandsMode;
            set
            {
                playerCommandsMode = value;
                OnPropertyChanged();
            }
        }

        public string RadarUnits
        {
            get => radarUnits;
            set
            {
                radarUnits = value;
                OnPropertyChanged();
            }
        }

        public int RippleRate
        {
            get => rippleRate;
            set
            {
                rippleRate = value;
                OnPropertyChanged();
            }
        }

        public bool ReceiveFriendlyDamage
        {
            get => receiveFriendlyDamage;
            set
            {
                receiveFriendlyDamage = value;
                OnPropertyChanged();
            }
        }

        public int ReloadTime
        {
            get => reloadTime;
            set
            {
                reloadTime = value;
                OnPropertyChanged();
            }
        }

        public bool Respawnable
        {
            get => respawnable;
            set
            {
                respawnable = value;
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

        public bool SpawnOnStart
        {
            get => spawnOnStart;
            set
            {
                spawnOnStart = value;
                OnPropertyChanged();
            }
        }

        public string StartMode
        {
            get => startMode;
            set
            {
                startMode = value;
                OnPropertyChanged();
            }
        }

        public bool StopToEngage
        {
            get => stopToEngage;
            set
            {
                stopToEngage = value;
                OnPropertyChanged();
            }
        }

        public string UnitGroup
        {
            get => unitGroup;
            set
            {
                unitGroup = value;
                OnPropertyChanged();
            }
        }

        public string VoiceProfile
        {
            get => voiceProfile;
            set
            {
                voiceProfile = value;
                OnPropertyChanged();
            }
        }

        public WaypointViewModel Waypoint
        {
            get => waypoint; 
            set
            {
                waypoint = value;
                OnPropertyChanged();
            }
        }

        public UnitSpawnerViewModel Parent { get; set; }

        #endregion

        #region Methods

        object ICloneable.Clone()
        {
            return Clone();
        }

        /// <summary>Creates a new instance of <see cref="UnitFieldsViewModel"/> with all the same values as this instance.</summary>
        /// <returns>A cloned UnitFields object.</returns>
        public UnitFieldsViewModel Clone()
        {
            return new UnitFieldsViewModel
            {
                AllowReload = AllowReload,
                AutoRefuel = AutoRefuel,
                AutoReturnToBase = AutoReturnToBase,
                AwacsVoiceProfile = AwacsVoiceProfile,
                Behavior = Behavior,
                CarrierSpawns = new ObservableCollection<Tuple<int, UnitSpawnerViewModel>>(CarrierSpawns.Select(x => new Tuple<int, UnitSpawnerViewModel>(x.Item1, x.Item2.Clone())).ToList()),
                CombatTarget = CombatTarget,
                CommsEnabled = CommsEnabled,
                DefaultBehavior = DefaultBehavior,
                DefaultNavSpeed = DefaultNavSpeed,
                DefaultOrbitPoint = DefaultOrbitPoint,
                DefaultPath = DefaultPath,
                DefaultRadarEnabled = DefaultRadarEnabled,
                DefaultShotsPerSalvo = DefaultShotsPerSalvo,
                DefaultWaypoint = DefaultWaypoint,
                DetectionMode = DetectionMode,
                EngageEnemies = EngageEnemies,
                Equips = Equips,
                Fuel = Fuel,
                HullNumber = HullNumber,
                InitialSpeed = InitialSpeed,
                Invincible = Invincible,
                MoveSpeed = MoveSpeed,
                OrbitAltitude = OrbitAltitude,
                ParkedStartMode = ParkedStartMode,
                PlayerCommandsMode = PlayerCommandsMode,
                RadarUnits = RadarUnits,
                Respawnable = Respawnable,
                RippleRate = RippleRate,
                ReceiveFriendlyDamage = ReceiveFriendlyDamage,
                ReloadTime = ReloadTime,
                ReturnToBaseDestination = ReturnToBaseDestination,
                SpawnOnStart = SpawnOnStart,
                StartMode = StartMode,
                StopToEngage = StopToEngage,
                UnitGroup = UnitGroup,
                VoiceProfile = VoiceProfile,
                Waypoint = Waypoint?.Clone(),
                Parent = Parent
            };
        }

        #endregion
    }
}
